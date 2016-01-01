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
    public class TD_Dino_1 : TD_GameActor
    {
        Vector2 cent;

        public TD_Dino_1() : this(new Vector2())
        {

        }

        public TD_Dino_1(Vector2 Start_Pos)
        {
            pos = Start_Pos;
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            this.sprite = TD_Game.Instance.Content.Load<Texture2D>("Dino_1");

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

            if (look.Length() < 20.0f)
            {
                //if(look.Length() > 20.0f)
                // {
                //      **Stop dino code**
                // }
            }
            else
            {
                look.Normalize();

                // Check if a bullet Intersects with a Dino and if it does,
                // then flag the bullet and Dino as not alive and give 
                // the player points.
                foreach(TD_GameActor bullet in TD_Game.Instance.Bullets)
                {
                    if (this.box.Intersects(bullet.box))
                    {
                        this.isAlive = false;
                        bullet.isAlive = false;
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

                // Movment code for the Dino on the X axis.
                if (this.pos.X > TD_Game.Instance.turret.pos.X)
                {
                    if (TD_Game.Instance.level_1.Level_Scroll_L || TD_Game.Instance.level_2.Level_Scroll_L) 
                    {
                        this.pos.X -= (speed - 4.0f);
                    }
                    else if (TD_Game.Instance.level_1.Level_Scroll_R || TD_Game.Instance.level_2.Level_Scroll_R)
                    {
                        this.pos.X -= (speed + 4.0f);
                    }
                    else
                    {
                        this.pos.X -= speed;
                    }
                }

                // Movment code for the Dino on the X axis.
                if (this.pos.X < TD_Game.Instance.turret.pos.X)
                {
                    if (TD_Game.Instance.level_1.Level_Scroll_R || TD_Game.Instance.level_2.Level_Scroll_R)
                    {
                        this.pos.X += (speed - 4.0f);
                    }
                    else
                    {
                        this.pos.X += speed;
                    }
                }

                // Movment code for the Dino on the Y axis.
                if (this.pos.Y < TD_Game.Instance.turret.pos.Y)
                {
                    this.pos.Y += speed - 1f;
                    velocity.Y -= (-speed * 2) - 1f;
                }
                else if (this.pos.Y > TD_Game.Instance.turret.pos.Y)
                {
                    pos.Y -= speed - 1f;
                    velocity.Y += (speed * 2) - 1f;
                }
                else
                {
                    velocity.Y = 0;
                }
            }
            look.Normalize();
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
                    TD_Game.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, rot, cent, scale, SpriteEffects.FlipHorizontally, 1);
                }
                else
                {
                    TD_Game.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, rot, cent, scale, SpriteEffects.None, 1);
                }
            }            
        }
    }
}

