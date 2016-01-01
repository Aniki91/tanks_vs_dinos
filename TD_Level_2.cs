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
    class TD_Level_2 : TD_GameActor
    {

        //bool for tank being on the ice
        public static bool isOnIce;

        //level position
        public Vector2 levelPos_0;
        public Vector2 levelPos_1;
        public Vector2 levelPos_2;
        public Vector2 levelPos_3;
        public Vector2 levelPos_4;
        public Vector2 levelPos_5;
        public Vector2 levelPos_6;
        public Vector2 endGame_pos;

        // Background positions - Background 2
        public static Vector2 backPos_0;
        public static Vector2 backPos_1;
        public static Vector2 backPos_2;
        public static Vector2 backPos_3;
        public static Vector2 backPos_4;
        public static Vector2 backPos_5;
        public static Vector2 backPos_6;

        // Background position - Background 3
        public static Vector2 backPos_0_3;
        public static Vector2 backPos_1_3;
        public static Vector2 backPos_2_3;
        public static Vector2 backPos_3_3;
        public static Vector2 backPos_4_3;
        public static Vector2 backPos_5_3;
        public static Vector2 backPos_6_3;

        // Background position - Background 4
        public static Vector2 backPos_0_4;
        public static Vector2 backPos_1_4;
        public static Vector2 backPos_2_4;
        public static Vector2 backPos_3_4;
        public static Vector2 backPos_4_4;
        public static Vector2 backPos_5_4;
        public static Vector2 backPos_6_4;

        // Background 1
        public static Texture2D background_1;

        // Background 2
        public static Texture2D background_2_0;
        public static Texture2D background_2_1;
        public static Texture2D background_2_2;
        public static Texture2D background_2_3;
        public static Texture2D background_2_4;
        public static Texture2D background_2_5;
        public static Texture2D background_2_6;

        // Background 3
        public static Texture2D background_3_0;
        public static Texture2D background_3_1;
        public static Texture2D background_3_2;
        public static Texture2D background_3_3;
        public static Texture2D background_3_4;
        public static Texture2D background_3_5;
        public static Texture2D background_3_6;

        // Background 4
        public static Texture2D background_4_0;
        public static Texture2D background_4_1;
        public static Texture2D background_4_2;
        public static Texture2D background_4_3;
        public static Texture2D background_4_4;
        public static Texture2D background_4_5;
        public static Texture2D background_4_6;

        //first image and collision
        public Texture2D floorTile_0;
        public Texture2D floorTile_1;
        public Rectangle ft1_floorCol_1;
        public Rectangle ft1_floorCol_2;
        public Rectangle ft1_floorCol_3;
        public Rectangle ft1_skyCol_1;

        //second image and collision
        public Texture2D floorTile_2;
        public Rectangle ft2_floorCol_1;
        public Rectangle ft2_floorCol_2;

        //third image and collision
        public Texture2D floorTile_3;
        public Rectangle ft3_floorCol_1;
        public Rectangle ft3_floorCol_2;
        public Rectangle ft3_floorCol_3;

        //fourth image and collision
        public Texture2D floorTile_4;
        public Rectangle ft4_floorCol_1;
        public Rectangle ft4_floorCol_2;
        public Rectangle ft4_floorCol_3;

        //fifth image and collision
        public Texture2D floorTile_5;
        public Rectangle ft5_floorCol_1;
        public Rectangle ft5_floorCol_2;
        public Rectangle ft5_floorCol_3;
        public Texture2D floorTile_6;
        

        // End Game
        public Texture2D endGame;
        public Rectangle endGame_rect;

        //health pick up stuff
        public Texture2D health_img_1;
        public Rectangle health_col_1;
        public bool isPickedUp;
        public Vector2 healthPick_pos;

        public List<TD_GameActor> temp_Actor_List = new List<TD_GameActor>();

       
        public override void Initialize()
        {

           
          
        }

        public override void LoadContent()
        {
            if (true) //TD_Game.Instance.level_No == 2)
            {
                
                
                
                isOnIce = false;

                ft1_skyCol_1 = new Rectangle(0, 0, 4160, 0);

                //level position
                levelPos_0 = new Vector2(-832, 0);
                levelPos_2 = new Vector2(832, 0);
                levelPos_3 = new Vector2(1664, 0);
                levelPos_4 = new Vector2(2496, 0);
                levelPos_5 = new Vector2(3328, 0);
                levelPos_6 = new Vector2(4151, 0);
                endGame_pos = new Vector2(3264, 0);

                // Background positions 2
                backPos_0 = new Vector2(-832, 0);
                backPos_2 = new Vector2(832, 0);
                backPos_3 = new Vector2(1664, 0);
                backPos_4 = new Vector2(2560, 0);
                backPos_5 = new Vector2(3392, 0);
                backPos_6 = new Vector2(4224, 0);

                // Bacground positions 3
                backPos_0_3 = new Vector2(-832, 0);
                backPos_2_3 = new Vector2(832, 0);
                backPos_3_3 = new Vector2(1664, 0);
                backPos_4_3 = new Vector2(2560, 0);
                backPos_5_3 = new Vector2(3392, 0);
                backPos_6_3 = new Vector2(4224, 0);

                // Bacground positions 4
                backPos_0_4 = new Vector2(-832, 0);
                backPos_2_4 = new Vector2(832, 0);
                backPos_3_4 = new Vector2(1664, 0);
                backPos_4_4 = new Vector2(2560, 0);
                backPos_5_4 = new Vector2(3392, 0);
                backPos_6_4 = new Vector2(4224, 0);

                // Background 1
                background_1 = TD_Game.Instance.Content.Load<Texture2D>("BackGround_1_Ice");

                // Background 2
                background_2_0 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");
                background_2_1 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");
                background_2_2 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");
                background_2_3 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");
                background_2_4 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");
                background_2_5 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");
                background_2_6 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_Ice");

                // Background 3
                background_3_0 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");
                background_3_1 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");
                background_3_2 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");
                background_3_3 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");
                background_3_4 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");
                background_3_5 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");
                background_3_6 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_1");

                // Background 3
                background_4_0 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");
                background_4_1 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");
                background_4_2 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");
                background_4_3 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");
                background_4_4 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");
                background_4_5 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");
                background_4_6 = TD_Game.Instance.Content.Load<Texture2D>("Background_2_2");


                //first image and collision
                floorTile_0 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_0");
                floorTile_1 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_1");
                ft1_floorCol_1 = new Rectangle(0, 0, 128, 512);
                ft1_floorCol_2 = new Rectangle(128, 384, 576, 128);
                ft1_floorCol_3 = new Rectangle(704, 448, 128, 64);

                //second image and collision
                floorTile_2 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_2");
                ft2_floorCol_1 = new Rectangle(832, 448, 768, 64);
                ft2_floorCol_2 = new Rectangle(1600, 192, 64, 320);

                //third image and collision
                floorTile_3 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_3");
                ft3_floorCol_1 = new Rectangle(1664, 192, 192, 320);
                ft3_floorCol_2 = new Rectangle(1856, 320, 320, 192);
                ft3_floorCol_3 = new Rectangle(2176, 256, 320, 256);

                //fourth image and collision
                floorTile_4 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_4");
                ft4_floorCol_1 = new Rectangle(2496, 256, 128, 256);
                ft4_floorCol_2 = new Rectangle(2624, 448, 576, 64);
                ft4_floorCol_3 = new Rectangle(3200, 320, 128, 192);

                //fifth image and collision
                floorTile_5 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_5");
                ft5_floorCol_1 = new Rectangle(3328, 320, 256, 192);
                ft5_floorCol_2 = new Rectangle(3584, 448, 448, 64);
                ft5_floorCol_3 = new Rectangle(4032, 0, 128, 512);
                floorTile_6 = TD_Game.Instance.Content.Load<Texture2D>("Level2_Tile_6");

                // End Game
                endGame = TD_Game.Instance.Content.Load<Texture2D>("End_Game");
                endGame_rect = new Rectangle(3904, 256, 64, 320);

                //health pick up
                health_img_1 = TD_Game.Instance.Content.Load<Texture2D>("healthPickup_Level2");
                health_col_1 = new Rectangle(2560, 320, health_img_1.Width, health_img_1.Height);
                healthPick_pos = new Vector2(2560, 320);
            }


        }

        public override void Update(GameTime gameTime)
        {
            if (TD_Game.Instance.level_No == 2)
            {
                //scrolling screen
                if (TD_Game.Instance.playerTank.pos.X >= 425 )
                {
                    levelPos_1.X -= 4f;
                    levelPos_2.X -= 4f;
                    levelPos_3.X -= 4f;
                    levelPos_4.X -= 4f;
                    levelPos_5.X -= 4f;
                    levelPos_6.X -= 4f;
                    endGame_pos.X -= 4f;

                    backPos_0.X -= 1f;
                    backPos_1.X -= 1f;
                    backPos_2.X -= 1f;
                    backPos_3.X -= 1f;
                    backPos_4.X -= 1f;
                    backPos_5.X -= 1f;
                    backPos_6.X -= 1f;

                    backPos_0_3.X -= 2f;
                    backPos_1_3.X -= 2f;
                    backPos_2_3.X -= 2f;
                    backPos_3_3.X -= 2f;
                    backPos_4_3.X -= 2f;
                    backPos_5_3.X -= 2f;
                    backPos_6_3.X -= 2f;

                    backPos_0_4.X -= 3f;
                    backPos_1_4.X -= 3f;
                    backPos_2_4.X -= 3f;
                    backPos_3_4.X -= 3f;
                    backPos_4_4.X -= 3f;
                    backPos_5_4.X -= 3f;
                    backPos_6_4.X -= 3f;

                    TD_Game.Instance.Actor_List[0].pos.X -= 4f;

                    this.Level_Scroll_R = true;
                }
                else if (TD_Game.Instance.playerTank.pos.X <= 125)
                {
                    levelPos_1.X += 4f;
                    levelPos_2.X += 4f;
                    levelPos_3.X += 4f;
                    levelPos_4.X += 4f;
                    levelPos_5.X += 4f;
                    levelPos_6.X += 4f;
                    endGame_pos.X += 4f;

                    backPos_0.X += 1f;
                    backPos_1.X += 1f;
                    backPos_3.X += 1f;
                    backPos_2.X += 1f;
                    backPos_4.X += 1f;
                    backPos_5.X += 1f;
                    backPos_6.X += 1f;

                    backPos_0_3.X += 2f;
                    backPos_1_3.X += 2f;
                    backPos_2_3.X += 2f;
                    backPos_3_3.X += 2f;
                    backPos_4_3.X += 2f;
                    backPos_5_3.X += 2f;
                    backPos_6_3.X += 2f;

                    backPos_0_4.X += 3f;
                    backPos_1_4.X += 3f;
                    backPos_2_4.X += 3f;
                    backPos_3_4.X += 3f;
                    backPos_4_4.X += 3f;
                    backPos_5_4.X += 3f;
                    backPos_6_4.X += 3f;

                    TD_Game.Instance.Actor_List[0].pos.X += 4f;

                    this.Level_Scroll_L = true;
                }
                else
                {
                    this.Level_Scroll_R = false;
                    this.Level_Scroll_L = false;
                }

                //Collision
                if (TD_PlayerTank.collision.isTopOf(ft1_floorCol_1) ||
                  (TD_PlayerTank.collision.isTopOf(ft1_floorCol_2)) ||
                  (TD_PlayerTank.collision.isTopOf(ft2_floorCol_2)) ||
                  (TD_PlayerTank.collision.isTopOf(ft3_floorCol_1)) ||
                  (TD_PlayerTank.collision.isTopOf(ft3_floorCol_2)) ||
                  (TD_PlayerTank.collision.isTopOf(ft3_floorCol_3)) ||
                  (TD_PlayerTank.collision.isTopOf(ft4_floorCol_1)) ||
                  (TD_PlayerTank.collision.isTopOf(ft4_floorCol_3)) ||
                  (TD_PlayerTank.collision.isTopOf(ft5_floorCol_1)) ||
                  (TD_PlayerTank.collision.isTopOf(ft5_floorCol_2)))
                {
                    TD_PlayerTank.isTopCol = true;
                }
                //ice collision so that the tank
                //moves a bit faster than it does 
                //on normal terrain
                else if (TD_PlayerTank.collision.isTopOf(ft1_floorCol_3) ||
                        (TD_PlayerTank.collision.isTopOf(ft2_floorCol_1)))
                {
                    TD_PlayerTank.isTopCol = true;
                    isOnIce = true;
                }
                else if (TD_PlayerTank.collision.isTopOf(ft4_floorCol_2))
                {
                    TD_Game.Instance.playerTank.isAlive = false;
                }
                else
                {
                    TD_PlayerTank.isTopCol = false;
                    isOnIce = false;
                }

                if (TD_PlayerTank.collision.Intersects(endGame_rect))
                {
                    TD_Game.Instance.playerTank.bFinish = true;
                }

                //right side collision
                if (TD_PlayerTank.collision.isToRightOf(ft1_floorCol_1) ||
                   (TD_PlayerTank.collision.isToRightOf(ft1_floorCol_2)) ||
                   (TD_PlayerTank.collision.isToRightOf(ft3_floorCol_1)) ||
                   (TD_PlayerTank.collision.isToRightOf(ft4_floorCol_1)) ||
                   (TD_PlayerTank.collision.isToRightOf(ft5_floorCol_1)))
                {
                    TD_PlayerTank.isLeftCol = true;
                }
                else
                {
                    TD_PlayerTank.isLeftCol = false;
                }

                //left side collision
                if (TD_PlayerTank.collision.isToLeftOf(ft2_floorCol_2) ||
                   (TD_PlayerTank.collision.isToLeftOf(ft3_floorCol_3)) ||
                   (TD_PlayerTank.collision.isToLeftOf(ft3_floorCol_3)) ||
                   (TD_PlayerTank.collision.isToLeftOf(ft4_floorCol_3)) ||
                   (TD_PlayerTank.collision.isToLeftOf(ft5_floorCol_3)))
                {
                    TD_PlayerTank.isRightCol = true;
                }
                else
                {
                    TD_PlayerTank.isRightCol = false;
                }

                // Sky Collision
                if (TD_PlayerTank.collision.Intersects(ft1_skyCol_1))
                {
                    TD_PlayerTank.skyCol = true;
                }
                else
                {
                    TD_PlayerTank.skyCol = false;
                }

                // Health pick up to give the Tank health, if the health
                // is greater than the health needed to reach 100, then the Tank
                // gets reset to 100 health.
                if (TD_PlayerTank.collision.Intersects(health_col_1) && isPickedUp == false && TD_PlayerTank.tank_health <= 80)
                {
                    TD_PlayerTank.tank_health = TD_PlayerTank.tank_health + 20;
                    isPickedUp = true;
                }
                else if (TD_PlayerTank.collision.Intersects(health_col_1) && isPickedUp == false && TD_PlayerTank.tank_health >= 81)
                {
                    TD_PlayerTank.tank_health = 100;
                    isPickedUp = true;
                }

            }



        }

        public override void Draw(GameTime gameTime)
        {
            if (TD_Game.Instance.level_No == 2)
            {
                //drawing end flag
                TD_Game.Instance.spriteBatch.Draw(endGame, endGame_pos, Color.White);

                //draw the level images
                TD_Game.Instance.spriteBatch.Draw(floorTile_0, levelPos_0, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_1, levelPos_1, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_2, levelPos_2, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_3, levelPos_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_4, levelPos_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_5, levelPos_5, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_6, levelPos_6, Color.White);
            }

            // Flag to make the health invisible if it's picked up.
            if (isPickedUp == false)
            {
                TD_Game.Instance.spriteBatch.Draw(health_img_1, healthPick_pos, Color.White);
            }
        }
    }

    static class RectangleHelper
    {
        public static bool isTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 6 && r1.Bottom <= r2.Top + 1
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
        }

        public static bool isToLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right >= r2.Left - 6 && r1.Right <= r2.Left + 1
                && r1.Bottom >= r2.Top + 5 && r1.Top <= r2.Bottom - 5);
        }

        public static bool isToRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Right - 6 && r1.Left <= r2.Right + 1
                && r1.Bottom >= r2.Top + 5 && r1.Top <= r2.Bottom - 5);
        }

        public static bool isUnderOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top >= r2.Bottom - 6 && r1.Top <= r2.Bottom + 1
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
        }
    }
}

