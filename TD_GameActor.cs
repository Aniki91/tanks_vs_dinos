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
    public abstract class TD_GameActor
    {
        // Abstract Base Glass holding common variables to be used in the classes
        // And also game functions to Override.
        public Texture2D sprite;

        public Vector2 pos;
        public Vector2 look;
        public Vector2 velocity;

        public Rectangle box 
        { 
            get 
            { 
                return new Rectangle((int)pos.X, (int)pos.Y, sprite.Width, sprite.Height); 
            } 
        }

        public bool Level_Scroll_R = false;
        public bool Level_Scroll_L = false;

        public float rot = 0.0f;
        public float scale = 1.0f;
        public float speed = 2.0f;

        public bool isAlive = true;
        public bool bFinish = false;

        public virtual int score { get; set; }

        public List<TD_GameActor> Bullets = new List<TD_GameActor>();

        public abstract void Initialize();

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }
}
