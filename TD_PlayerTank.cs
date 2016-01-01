using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TanksVsDinos
{
    public class TD_PlayerTank :TD_GameActor
    {
        // Collision bools for collision to the Left, Right, and on top of
        // a rectangle. Aswell as collision to stop the player going out
        // of the playable area on the Y axis.
        public static bool isTopCol;
        public static bool isRightCol;
        public static bool isLeftCol;
        public static bool skyCol;

        public static bool isJumped;
        public static bool isColliding;
        public bool drawJets;

        public Texture2D jetsBoost;
        public Texture2D healthBar;
        public Texture2D powerUp;
        public Texture2D hudBackground;

        public static Rectangle collision;

        public static int tank_health;
        public static int power_up;

        public static readonly TimeSpan intervalBetweenDamage = TimeSpan.FromMilliseconds(500);
        public TimeSpan lastTimeDamaged;

        public SpriteFont Font { get; set; }
        
        public Vector2 scorepos;

        SoundEffect engineSound;
        SoundEffectInstance engineInstance;

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            // Player position and the "Score: " position.
            pos = new Vector2(175, 256);
            scorepos = new Vector2(5, 50);

            hudBackground = TD_Game.Instance.Content.Load<Texture2D>("HUD_Background");
            jetsBoost = TD_Game.Instance.Content.Load<Texture2D>("Jets");
            this.sprite = TD_Game.Instance.Content.Load < Texture2D > ("Tank");
            
            // Tanks collision.
            collision = new Rectangle((int)pos.X - 5, (int)pos.Y - 5, this.sprite.Width, this.sprite.Height);

            // Tank health and initial value.
            healthBar = TD_Game.Instance.Content.Load<Texture2D>("health_bar");
            tank_health = 100;

            // PowerUp health and initial background.
            powerUp = TD_Game.Instance.Content.Load<Texture2D>("powerup_bar");
            power_up = 100;

            // Score system.
            Font = TD_Game.Instance.Content.Load<SpriteFont>("Arial");

            // Engine sound
            engineSound = TD_Game.Instance.Content.Load<SoundEffect>("Engine_Sound");
            engineInstance = engineSound.CreateInstance();
            engineInstance.IsLooped = true;
            engineInstance.Play();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            GamePadState Controler = GamePad.GetState(PlayerIndex.One);

            if (TD_Game.gameState == GameState.MainMenu)
            {
                if (keyState.IsKeyDown(Keys.Back) || Controler.Buttons.X == ButtonState.Pressed)
                {
                    TD_Game.gameState = GameState.game;
                    TD_Game.Instance.level_No = 1;
                }
                else if (Controler.Buttons.A == ButtonState.Pressed || keyState.IsKeyDown(Keys.D8))
                {
                    TD_Game.gameState = GameState.game;
                    TD_Game.Instance.level_No = 2;
                }
                else if (Controler.Buttons.B == ButtonState.Pressed || keyState.IsKeyDown(Keys.D9))
                {
                    TD_Game.gameState = GameState.game;
                    TD_Game.Instance.level_No = 3;
                }

                if (keyState.IsKeyDown(Keys.O) || Controler.Buttons.Y == ButtonState.Pressed)
                {
                    TD_Game.gameState = GameState.options;
                }
            }
            else if (TD_Game.gameState == GameState.options)
            {
                if (keyState.IsKeyDown(Keys.B) || Controler.Buttons.Back == ButtonState.Pressed)
                {
                    TD_Game.gameState = GameState.MainMenu;
                }
            }
            else
            {



                // Player movement being updated.
                pos.X += (int)velocity.X;
                pos.Y += (int)velocity.Y;
                collision.X += (int)velocity.X;
                collision.Y += (int)velocity.Y;

                // Search through the Bad_Guys list, and if one's collision box Intersects
                // with the Tank's collision box, then the Health of the player is lowered,
                // and a delay is made so that the player cannot be hit again for a short
                // period of time.
                for (int i = 0; i < TD_Game.Instance.Bad_Guys1.Count; i++)
                {
                    if (this.box.Intersects(TD_Game.Instance.Bad_Guys1[i].box)
                        && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime))
                    {
                        tank_health -= 5;
                        lastTimeDamaged = gameTime.TotalGameTime;
                    }
                }
                #region Dino Damage Code.

                if (TD_Game.Instance.level_No == 2)
                {

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino2.Bullets.Count > 0 && i < TD_Game.Instance.tempDino2.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino2.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino2.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino3.Bullets.Count > 0 && i < TD_Game.Instance.tempDino3.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino3.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino3.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino3.Bullets.Count > 0 && i < TD_Game.Instance.tempDino3.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino3.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino3.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino4.Bullets.Count > 0 && i < TD_Game.Instance.tempDino4.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino4.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino4.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino5.Bullets.Count > 0 && i < TD_Game.Instance.tempDino5.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino5.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino5.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino6.Bullets.Count > 0 && i < TD_Game.Instance.tempDino6.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino6.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino6.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino7.Bullets.Count > 0 && i < TD_Game.Instance.tempDino7.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino7.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino7.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino8.Bullets.Count > 0 && i < TD_Game.Instance.tempDino8.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino8.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino8.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino9.Bullets.Count > 0 && i < TD_Game.Instance.tempDino9.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino9.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino9.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino10.Bullets.Count > 0 && i < TD_Game.Instance.tempDino10.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino10.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino10.Bullets[i].isAlive = false;

                            }
                        }
                    }

                    for (int i = 0; i < TD_Game.Instance.Bad_Guys2.Count; i++)
                    {
                        if (TD_Game.Instance.tempDino11.Bullets.Count > 0 && i < TD_Game.Instance.tempDino11.Bullets.Count)
                        {

                            if ((this.box.Intersects(TD_Game.Instance.tempDino11.Bullets[i].box)
                                && (lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime)))
                            {
                                tank_health -= 10;
                                lastTimeDamaged = gameTime.TotalGameTime;
                                TD_Game.Instance.tempDino11.Bullets[i].isAlive = false;

                            }
                        }
                    }
                }
                #endregion





                // If the Tank's health is empty or the Tank goes outside
                // the bounds of the bottom of the screen, then he dies.
                if (tank_health <= 0 || this.pos.Y > (512 + this.sprite.Height))
                {
                    this.isAlive = false;
                }

                // If the player is moving left or right, and no collision is being made
                // then they can continue to go in that direction.
                if ((keyState.IsKeyDown(Keys.D) || Controler.DPad.Right == ButtonState.Pressed || Controler.ThumbSticks.Left.X > 0.5f) && isRightCol == false)
                {
                    if (TD_Level_2.isOnIce == true)
                    {
                        velocity.X += 0.001f * gameTime.ElapsedGameTime.Milliseconds;
                    }
                    else
                    {
                        velocity.X = 4f;
                    }
                }
                else if ((keyState.IsKeyDown(Keys.A) || Controler.DPad.Left == ButtonState.Pressed || Controler.ThumbSticks.Left.X < -0.5f) && isLeftCol == false)
                {
                    if (TD_Level_2.isOnIce == true)
                    {
                        velocity.X -= 0.001f * gameTime.ElapsedGameTime.Milliseconds;
                    }
                    else
                    {
                        velocity.X = -4f;
                    }
                }
                else 
                {
                    velocity.X = 0f;
                }

                // If space is being pressed and the players Power is not empty and Collision
                // with the sky is false, then the jets can be drawn to the screen,
                // and the Tank moves up while losing energy.
                if ((keyState.IsKeyDown(Keys.Space) || Controler.Triggers.Left >= 0.5f) && skyCol == false && power_up > 0)
                {
                    drawJets = true;
                    velocity.Y -= 0.0175f * gameTime.ElapsedGameTime.Milliseconds;
                    power_up -= 1;
                }
                else if (isTopCol == false)
                {
                    // If the playeris not holding space, but is still airborne,
                    // then the jets are undrawn and the player begins to move
                    // back down to the ground.
                    drawJets = false;
                    velocity.Y = 4.0f;
                }
                else
                {
                    velocity.Y = 0f;
                }

                // If the Power_Up bar is within the rangine of 0 - 100 and the player
                // is on the ground, then their Power_Up bar begins to recharge.
                if (power_up >= 0 && power_up < 100 && isTopCol == true)
                {
                    power_up += 1;
                }
            }
        }

        public override void Draw(GameTime gametime)
        {
            // Drawing the grey background behind the realtime HUD.
            //TD_Game.Instance.spriteBatch.Draw(hudBackground, new Vector2(0, 0), Color.White);

            // Draw the Health bar.
            TD_Game.Instance.spriteBatch.Draw(healthBar, new Vector2(574, 10), new Rectangle(0, 40, healthBar.Width, 32), Color.Gray);
            // Draws the realtime information of Health the Tank currently has.
            TD_Game.Instance.spriteBatch.Draw(healthBar, new Vector2(574, 10), new Rectangle(0, 40, (int)(healthBar.Width * ((double)tank_health / 100)), 32), Color.Red);
            // Making the Health bar look nicer.
            TD_Game.Instance.spriteBatch.Draw(healthBar, new Vector2(574, 10), new Rectangle(0, 0, healthBar.Width, 32), Color.White);

            // Draw the Health bar.
            TD_Game.Instance.spriteBatch.Draw(powerUp, new Vector2(5, 10), new Rectangle(0, 40, powerUp.Width, 32), Color.Gray);
            // Draws the realtime information of Energy the Tank currently has.
            TD_Game.Instance.spriteBatch.Draw(powerUp, new Vector2(5, 10), new Rectangle(0, 40, (int)(powerUp.Width * ((double)power_up / 100)), 32), Color.Silver);
            // Making the Energy bar look nicer.
            TD_Game.Instance.spriteBatch.Draw(powerUp, new Vector2(5, 10), new Rectangle(0, 0, powerUp.Width, 32), Color.White);

            // Drawing the Score.
            TD_Game.Instance.spriteBatch.DrawString(Font, "Score: " + TD_Game.Instance.turret.score.ToString(), scorepos, Color.Black);

            // Bool to determine whether the jets should be drawn or not.
            if (drawJets == true)
            {
                TD_Game.Instance.spriteBatch.Draw(jetsBoost, pos, Color.White);
            }

            // Draw the Tank.
            TD_Game.Instance.spriteBatch.Draw(this.sprite, pos, Color.White);            
        }
    }
}
