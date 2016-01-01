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
    public class TD_Fire : TD_GameActor
    {
        Vector2 cent;


        public TD_Fire() : this(2.0f)
        {
        }

        public TD_Fire(float speed)
        {
            this.speed = speed;
        }

        public override void Initialize()
        {
        }

        public override void  LoadContent()
        {
            cent = new Vector2();
            cent.X = 0;
            cent.Y = this.sprite.Height / 2;
        }

        public override void Update(GameTime gameTime)
        {          
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // The speed and direction of the Bullet onces fired.
            pos += (timeDelta * (speed * 750) * look);                 
        }

        public override void Draw(GameTime gameTime)
        {
            TD_Game.Instance.spriteBatch.Draw(sprite, this.pos, null, Color.White, rot, cent, scale * 0.75f, SpriteEffects.None, 1);            
        }    
    }    
}
