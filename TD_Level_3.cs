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
        public Texture2D crossHair;
        public Texture2D crossHair_TEST;

        public bool hide;

        public Rectangle aimBox;
        public Rectangle TEST;

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            if (TD_Game.Instance.level_No == 3)
            {
                Level_Tile = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_FPS");
                crossHair = TD_Game.Instance.Content.Load<Texture2D>("Crosshair");
                crossHair_TEST = TD_Game.Instance.Content.Load<Texture2D>("Crosshair");

                TEST = new Rectangle(64, 64, 64, 64);
            }
        }

        public override void Update(GameTime gametime)
        {
            if (TD_Game.Instance.level_No == 3)
            {
                aimBox = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 61, 61);

                if (aimBox.Intersects(TEST) == true && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    hide = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (TD_Game.Instance.level_No == 3)
            {
                TD_Game.Instance.spriteBatch.Draw(Level_Tile, new Vector2(0, 0), Color.White);
                TD_Game.Instance.spriteBatch.Draw(crossHair, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

                if (hide == false)
                {
                    TD_Game.Instance.spriteBatch.Draw(crossHair_TEST, new Vector2(TEST.X, TEST.Y), Color.White);
                }
            }
        }
    }
}
