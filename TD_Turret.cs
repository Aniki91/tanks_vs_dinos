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
    public class TD_Turret:TD_GameActor
    {

        public SoundEffect soundEffect;

        Vector2 cent;

        // Variable used to calculate a time difference between attacks
        // to allow the play to fire again, instead of constantly firing bullets.
        private static readonly TimeSpan intervalBetweenAttack1 = TimeSpan.FromMilliseconds(250);
        private TimeSpan lastTimeAttack;

        public override void Initialize()
        {
        }

        public override void  LoadContent()
        {          
            this.sprite = TD_Game.Instance.Content.Load<Texture2D>("Tank_Gun");
            soundEffect = TD_Game.Instance.Content.Load<SoundEffect>("Bullet_Sound");          

            cent = new Vector2();
            cent.Y = this.sprite.Height / 2;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            GamePadState Controler = GamePad.GetState(PlayerIndex.One);

            // If the Tank is not alive, then the Turret is not alive.
            if (TD_Game.Instance.playerTank.isAlive == false)
            {
                this.isAlive = false;
            }

            // If the Tank has finished the level, then the Turret is not alive.
            if (TD_Game.Instance.level_1.bFinish == true)
            {
                this.isAlive = false;
            }

            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            // The position of the Turrent.
            this.pos.X = TD_Game.Instance.playerTank.pos.X + (TD_Game.Instance.playerTank.sprite.Width / 2) - 10;
            this.pos.Y = TD_Game.Instance.playerTank.pos.Y + (TD_Game.Instance.playerTank.sprite.Height / 2 ) + 10;

            // Rotation of the Turret to the right/down.
            if (keyState.IsKeyDown(Keys.Right) ||  Controler.ThumbSticks.Right.X > 0)
            {
                if (rot <= 3.14f / 8)
                {
                    rot += timeDelta * speed;                    
                }
            }

            // Rotation of the turret to the left/up.
            if (keyState.IsKeyDown(Keys.Left) || Controler.ThumbSticks.Right.X < 0)
            {
                if (rot >= -3.14 / 5)
                {
                    rot -= timeDelta * speed;                    
                }              
            }

            // The input and bullet code for post firing.
            if (keyState.IsKeyDown(Keys.Enter) || Controler.Triggers.Right >= 0.5f)
            {
                TD_GameActor Bullet = new TD_Fire();
               
                // If enough time has passed, then the Tank can fire again.
                if (lastTimeAttack + intervalBetweenAttack1 < gameTime.TotalGameTime)
                {
                    Bullet.sprite = TD_Game.Instance.Content.Load<Texture2D>("Bullet_1");

                    soundEffect.Play(1.0f, 0, 0);

                    Bullet.look.X = (float)Math.Sin((rot + (3.14 / 2)));
                    Bullet.look.Y = -(float)Math.Cos((rot + (3.14 / 2)));

                    Bullet.pos.X = this.pos.X;
                    Bullet.pos.Y = this.pos.Y;

                    Bullets.Add(Bullet);

                    // Once a bullet has left the playable screen, remove it from the List.
                    foreach (TD_GameActor Check in this.Bullets)
                    {
                        if (Check.box.X > TD_Game.Instance.GraphicsDevice.DisplayMode.Width || Check.box.Y > TD_Game.Instance.GraphicsDevice.DisplayMode.Height || Check.box.X < 0 || Check.box.Y < 0)
                        {
                            Check.Bullets.Remove(Bullet);
                        }
                    }
                    lastTimeAttack = gameTime.TotalGameTime;
                }               
            }  
        }

        public override void Draw(GameTime gameTime)
        {
            TD_Game.Instance.spriteBatch.Draw(sprite, this.pos, null, Color.White, rot, cent, (scale * 1.25f), SpriteEffects.None, 1);            
        }    
    }
}
