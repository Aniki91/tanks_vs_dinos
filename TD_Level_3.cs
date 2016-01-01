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
    class TD_Level_3 : TD_GameActor
    {
        public Texture2D Level_Tile;
        public static Texture2D crossHair;
        //public Texture2D crossHair_TEST;

        public Rectangle aimBox;
        //public Rectangle TEST;

        // Credits
        public Texture2D Credits;
        public Vector2 Credits_Pos;


        //timing code
        private static readonly TimeSpan intervalBetweenAttack1 = TimeSpan.FromMilliseconds(625);
        private TimeSpan lastTimeAttack;

        //sound effect for gun
        public SoundEffect soundEffect;

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {


            if (true)
            {
                Level_Tile = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_FPS");
                crossHair = TD_Game.Instance.Content.Load<Texture2D>("Crosshair");
                //crossHair_TEST = TD_Game.Instance.Content.Load<Texture2D>("Crosshair");
                Credits = TD_Game.Instance.Content.Load<Texture2D>("Credits");
                Credits_Pos = new Vector2(0, -512);
                soundEffect = TD_Game.Instance.Content.Load<SoundEffect>("Bullet_Sound");

                //Test_dino = new TD_Dino_3(100, 100);


                //TEST = new Rectangle(64, 64, 64, 64);
            }
        }

        public override void Update(GameTime gametime)
        {
            if (TD_Game.Instance.level_No == 3)
            {
                GamePadState Controler = GamePad.GetState(PlayerIndex.One);

                aimBox = new Rectangle((int)TD_Game.Instance.crossHair_Pos.X,(int)TD_Game.Instance.crossHair_Pos.Y, 61, 61);

                if (Controler.ThumbSticks.Right.X > 0)
                {
                    aimBox.X = aimBox.X + 10;
                }

                if (Controler.ThumbSticks.Right.X < 0)
                {
                    aimBox.X = aimBox.X - 10;
                }

                if (Controler.ThumbSticks.Right.Y > 0)
                {
                    aimBox.Y = aimBox.Y - 10;
                }

                if (Controler.ThumbSticks.Right.Y < 0)
                {
                    aimBox.Y = aimBox.Y + 10;
                }

                for (int i = 0; i < TD_Game.Instance.FPS_BadGuys.Count; i++)
                {
                    if (Controler.Triggers.Right >= 0.5f && (lastTimeAttack + intervalBetweenAttack1 < gametime.TotalGameTime))
                    {
                        soundEffect.Play(1.0f, 0, 0);

                        if (aimBox.Intersects(TD_Game.Instance.FPS_BadGuys[i].box) == true)
                        {
       
                                TD_Game.Instance.FPS_BadGuys[i].isAlive = false;
                            
                        }

                        lastTimeAttack = gametime.TotalGameTime;
                    }
                }

                if (Credits_Pos.Y != 0)
                {
                    Credits_Pos.Y = Credits_Pos.Y + 1;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (TD_Game.Instance.level_No == 3)
            {               
                TD_Game.Instance.spriteBatch.Draw(Level_Tile, new Vector2(0, 0), Color.White);
                TD_Game.Instance.spriteBatch.Draw(Credits, Credits_Pos, Color.White);
            }
        }
    }
}
