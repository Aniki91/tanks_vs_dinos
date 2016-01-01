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
    public class TD_Dino_3 : TD_GameActor
    {

        Vector2 cent;

        public Rectangle level_3_box;

        public static readonly TimeSpan intervalBetweenDamage = TimeSpan.FromMilliseconds(500);
        public TimeSpan lastTimeDamaged;

        float SIZE_OF_DINO = 1;

        public TD_Dino_3(int POSX, int POSY)
        {
            this.scale = 0.01f;
            this.pos.X = POSX;
            this.pos.Y = POSY;
            this.sprite = TD_Game.Instance.Content.Load<Texture2D>("Dino_1");
        }

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            this.isAlive = true;
            cent = new Vector2();
            cent.X = sprite.Width / 2;
            cent.Y = sprite.Height / 2;



        }

        public override void Update(GameTime gameTime)
        {
            if (TD_Game.Instance.level_No == 3)
            {

                if (SIZE_OF_DINO < 2.0f)
                {
                    level_3_box = new Rectangle((int)this.pos.X, (int)this.pos.Y, (int)(this.sprite.Width * SIZE_OF_DINO), (int)(this.sprite.Height * SIZE_OF_DINO));
                    SIZE_OF_DINO += 0.015f;


                    TD_PlayerTank.tank_health -= 10;
                }

                for (int i = 0; i < TD_Game.Instance.FPS_BadGuys.Count; i++)
                {
                    if ((lastTimeDamaged + intervalBetweenDamage < gameTime.TotalGameTime) && SIZE_OF_DINO >= 2.0f)
                    {
                        TD_PlayerTank.tank_health -= 10;
                        lastTimeDamaged = gameTime.TotalGameTime;
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
                    TD_Game.Instance.spriteBatch.Draw(sprite, pos, null, Color.White, rot, cent, scale + SIZE_OF_DINO, SpriteEffects.None, 1);
        }
    }
}
