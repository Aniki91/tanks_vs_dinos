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
    public class TD_Dino_2 : TD_Dino_1
    {
        Vector2 cent;


        private static readonly TimeSpan intervalBetweenAttack1 = TimeSpan.FromMilliseconds(1000);
        private TimeSpan lastTimeAttack;

        public TD_Dino_2() : this(new Vector2(400,125))
        {
        }

        public TD_Dino_2(Vector2 Start_Pos)
        {
            pos = Start_Pos;
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            this.sprite = TD_Game.Instance.Content.Load<Texture2D>("Dino_Turret"); // this needs new sprite

            cent = new Vector2();
            cent.X = sprite.Width / 2;
            cent.Y = sprite.Height / 2;
        }

        public override void Update(GameTime gametime)
        {

            float timeDelta = (float)gametime.ElapsedGameTime.TotalSeconds;

            // If the player is dead, look to the origin,
            // else look towards the center of the Turret,
            // which is at the center of the Tank.
            if (TD_Game.Instance.turret.isAlive == false)
            {
                look = new Vector2();
            }
            else
            {
                look = TD_Game.Instance.turret.pos - this.pos;
            }



            if (TD_Game.Instance.level_1.Level_Scroll_L || TD_Game.Instance.level_2.Level_Scroll_L)
            {
                this.pos.X += (speed + 2.0f);
            }
            else if (TD_Game.Instance.level_1.Level_Scroll_R || TD_Game.Instance.level_2.Level_Scroll_R)
            {
                this.pos.X -= (speed + 2.0f);
            }



            if (look.Length() > 450.0f)
            {
                //code to detect if dino is hit

                for (int i = 0; i < TD_Game.Instance.Bullets.Count; i++)
                {
                    if (this.box.Intersects(TD_Game.Instance.Bullets[i].box))
                    {
                        this.isAlive = false;
                        TD_Game.Instance.Bullets[i].isAlive = false;
                        TD_Game.Instance.turret.score += 125;
                    }
                }

            }
            else
            {
                look.Normalize();

                // Check if a bullet Intersects with a Dino and if it does,
                // then flag the bullet and Dino as not alive and give 
                // the player points.



                for (int i = 0; i < TD_Game.Instance.Bullets.Count; i++)
                {
                    if (this.box.Intersects(TD_Game.Instance.Bullets[i].box))
                    {
                        this.isAlive = false;
                        TD_Game.Instance.Bullets[i].isAlive = false;
                        TD_Game.Instance.turret.score += 200;
                    }
                }

                // Rotation code for the Dino on the Y axis.
                if (TD_Game.Instance.turret.pos.Y < pos.Y)
                {
                    rot = (float)Math.Atan(look.X / -look.Y);
                }
                else
                {
                    rot = (float)(Math.Atan(-look.X / look.Y));
                    rot = rot + 3.14f;
                }
                    

                TD_GameActor BGBullet = new TD_Fire(0.5f);

                // If enough time has passed, then the Tank can fire again.
                if (lastTimeAttack + intervalBetweenAttack1 < gametime.TotalGameTime)
                {

                    BGBullet.sprite = TD_Game.Instance.Content.Load<Texture2D>("Dino_Bullet");

                    //soundEffect.Play(1.0f, 0, 0);

                    BGBullet.look.X = (float)Math.Sin(rot);
                    BGBullet.look.Y = -(float)Math.Cos(rot);

                    BGBullet.pos.X = this.pos.X;
                    BGBullet.pos.Y = this.pos.Y;

                    this.Bullets.Add(BGBullet);

                    // Once a bullet has left the playable screen, remove it from the List.
                    foreach (TD_GameActor Check in this.Bullets)
                    {
                        if (Check.box.X > TD_Game.Instance.GraphicsDevice.DisplayMode.Width || Check.box.Y > TD_Game.Instance.GraphicsDevice.DisplayMode.Height || Check.box.X < 0 || Check.box.Y < 0)
                        {
                            Check.Bullets.Remove(BGBullet);
                        }
                    }

                    lastTimeAttack = gametime.TotalGameTime;

                }

                look.Normalize();

            }
        }

        public override void Draw(GameTime gametime)
        {
            // If the Tank is alive and it's the Dinos pos.X is less than
            // the turret.pos.X, then flips the Dino sprite horizontally,
            // else draw the Dino normally.
            if (TD_Game.Instance.turret.isAlive == true)
            {
                if (this.pos.X < TD_Game.Instance.turret.pos.X)
                {
                    TD_Game.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, 0, cent, scale, SpriteEffects.FlipHorizontally, 1);
                }
                else
                {
                    TD_Game.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, 0, cent, scale, SpriteEffects.None, 1);
                }
            }
        }
    }
}

