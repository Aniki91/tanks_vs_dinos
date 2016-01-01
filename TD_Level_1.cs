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
    public class TD_Level_1 : TD_GameActor
    {
        // Level positions
        public Vector2 levelPos_0;
        public Vector2 levelPos_1; // (0, 0)
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

        // First image and Collision
        public Texture2D floorTile_0;
        public Texture2D floorTile_1;
        public Rectangle ft1_floorCol_1;
        public Rectangle ft1_floorCol_2;
        public Rectangle ft1_floorCol_3;
        public Rectangle ft1_skyCol_1;

        // Second image and collision
        public Texture2D floorTile_2;
        public Rectangle ft2_floorCol_1;
        public Rectangle ft2_floorCol_2;
        public Rectangle ft2_floorCol_3;
        public Rectangle ft2_floorCol_4;

        // Third image and collision
        public Texture2D floorTile_3;
        public Rectangle ft3_floorCol_1;
        public Rectangle ft3_floorCol_2;
        public Rectangle ft3_waterCol_1;

        // Fourth image and collision
        public Texture2D floorTile_4;
        public Rectangle ft4_floorCol_1;
        public Rectangle ft4_floorCol_2;
        public Rectangle ft4_floorCol_3;
        public Rectangle ft4_waterCol_1;

        // Fifth image and collision
        public Texture2D floorTile_5;
        public Texture2D floorTile_6;
        public Rectangle ft5_floorCol_1;
        public Rectangle ft5_floorCol_2;
        public Rectangle ft5_floorCol_3;
        public Rectangle ft5_floorCol_4;

        // End Game
        public Texture2D endGame;
        public Rectangle endGame_rect;

        //health pick up stuff
        public Texture2D health_img_1;
        public Rectangle health_col_1;
        public bool isPickedUp;
        public Vector2 healthPick_pos;

        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            if (true)
            {
                // Level positions
                levelPos_0 = new Vector2(-832, 0);
                levelPos_2 = new Vector2(832, 0);
                levelPos_3 = new Vector2(1664, 0);
                levelPos_4 = new Vector2(2560, 0);
                levelPos_5 = new Vector2(3392, 0);
                levelPos_6 = new Vector2(4224, 0);
                endGame_pos = new Vector2(3392, 0);

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
                backPos_6_4 = new Vector2(4160, 0);

                // Background 1
                background_1 = TD_Game.Instance.Content.Load<Texture2D>("BackGround_1");

                // Background 2
                background_2_0 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");
                background_2_1 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");
                background_2_2 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");
                background_2_3 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");
                background_2_4 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");
                background_2_5 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");
                background_2_6 = TD_Game.Instance.Content.Load<Texture2D>("Background_2");

                // Background 3
                background_3_0 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");
                background_3_1 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");
                background_3_2 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");
                background_3_3 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");
                background_3_4 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");
                background_3_5 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");
                background_3_6 = TD_Game.Instance.Content.Load<Texture2D>("Background_3");

                // Background 3
                background_4_0 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");
                background_4_1 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");
                background_4_2 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");
                background_4_3 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");
                background_4_4 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");
                background_4_5 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");
                background_4_6 = TD_Game.Instance.Content.Load<Texture2D>("Background_4");

                // First image and Collision
                floorTile_0 = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_0");
                floorTile_1 = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_1");
                ft1_floorCol_1 = new Rectangle(0, 440, 832, 64);
                ft1_floorCol_2 = new Rectangle(0, 0, 64, 512);
                ft1_floorCol_3 = new Rectangle(640, 320, 192, 192);
                ft1_skyCol_1 = new Rectangle(0, -32, 4224, 32);

                // Second image and Collision
                floorTile_2 = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_2");
                ft2_floorCol_1 = new Rectangle(832, 320, 128, 192);
                ft2_floorCol_2 = new Rectangle(960, 384, 384, 128);
                ft2_floorCol_3 = new Rectangle(1344, 256, 128, 256);
                ft2_floorCol_4 = new Rectangle(1472, 192, 192, 320);

                // Thrid image and Collision
                floorTile_3 = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_3");
                ft3_floorCol_1 = new Rectangle(1664, 192, 128, 320);
                ft3_floorCol_2 = new Rectangle(2432, 384, 128, 128);
                ft3_waterCol_1 = new Rectangle(1792, 448, 704, 64);

                // Fourth image and Collision
                floorTile_4 = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_4");
                ft4_floorCol_1 = new Rectangle(2560, 384, 128, 128);
                ft4_floorCol_2 = new Rectangle(2944, 256, 64, 256);
                ft4_floorCol_3 = new Rectangle(3328, 192, 128, 320);
                ft4_waterCol_1 = new Rectangle(2560, 448, 704, 64);

                // Fifth image and collision
                floorTile_5 = TD_Game.Instance.Content.Load<Texture2D>("Level_Tile_5");
                floorTile_6 = TD_Game.Instance.Content.Load<Texture2D>("Level_TIle_6");
                ft5_floorCol_1 = new Rectangle(3392, 192, 192, 320);
                ft5_floorCol_2 = new Rectangle(3584, 320, 256, 192);
                ft5_floorCol_3 = new Rectangle(3840, 448, 320, 64);
                ft5_floorCol_4 = new Rectangle(4160, 0, 128, 512);

                // End Game
                endGame = TD_Game.Instance.Content.Load<Texture2D>("End_Game");
                endGame_rect = new Rectangle(4032, 256, 64, 320);

                //health pick up
                health_img_1 = TD_Game.Instance.Content.Load<Texture2D>("healthPickup");
                health_col_1 = new Rectangle(2560, 320, health_img_1.Width, health_img_1.Height);
                healthPick_pos = new Vector2(2560, 320);
            }


        }

        public override void Update(GameTime gametime)
        {

            if (TD_Game.Instance.level_No == 1)
            {
                // If the player is on top of water, then he dies,
                // else if the touches the End Game flag, then he wins.
                if (TD_PlayerTank.collision.isTopOf(ft3_waterCol_1) ||
                    TD_PlayerTank.collision.isTopOf(ft4_waterCol_1))
                {
                    TD_Game.Instance.playerTank.isAlive = false;
                }
                else if (TD_PlayerTank.collision.Intersects(endGame_rect))
                {
                    TD_Game.Instance.playerTank.bFinish = true;
                    TD_Game.Instance.playerTank.pos.X = 175;
                    TD_Game.Instance.playerTank.pos.Y = 256;
                }

                // If the player moves too far to the right, the screen
                // images scroll left, and vice versa for moving left.
                if (TD_Game.Instance.playerTank.pos.X >= 425 && TD_Game.Instance.Actor_List.Count > 0)
                {
                    levelPos_0.X -= 4f;
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

                    healthPick_pos.X -= 4f;

                    TD_Game.Instance.Actor_List[0].pos.X -= 4f;

                    this.Level_Scroll_R = true;
                }
                else if (TD_Game.Instance.playerTank.pos.X <= 125)
                {
                    levelPos_0.X += 4f;
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

                    healthPick_pos.X += 4f;

                    TD_Game.Instance.Actor_List[0].pos.X += 4f;

                    this.Level_Scroll_L = true;
                }
                else
                {
                    this.Level_Scroll_L = false;
                    this.Level_Scroll_R = false;
                }

                // Tank collision if he is on top of a rectangle/the ground.
                if (TD_PlayerTank.collision.isTopOf(ft1_floorCol_1) ||
                    TD_PlayerTank.collision.isTopOf(ft1_floorCol_3) ||
                    TD_PlayerTank.collision.isTopOf(ft2_floorCol_1) ||
                    TD_PlayerTank.collision.isTopOf(ft2_floorCol_2) ||
                    TD_PlayerTank.collision.isTopOf(ft2_floorCol_3) ||
                    TD_PlayerTank.collision.isTopOf(ft2_floorCol_4) ||
                    TD_PlayerTank.collision.isTopOf(ft3_floorCol_1) ||
                    TD_PlayerTank.collision.isTopOf(ft3_floorCol_2) ||
                    TD_PlayerTank.collision.isTopOf(ft4_floorCol_1) ||
                    TD_PlayerTank.collision.isTopOf(ft4_floorCol_2) ||
                    TD_PlayerTank.collision.isTopOf(ft4_floorCol_3) ||
                    TD_PlayerTank.collision.isTopOf(ft5_floorCol_1) ||
                    TD_PlayerTank.collision.isTopOf(ft5_floorCol_2) ||
                    TD_PlayerTank.collision.isTopOf(ft5_floorCol_3))
                {
                    TD_PlayerTank.isTopCol = true;
                }
                else
                {
                    TD_PlayerTank.isTopCol = false;
                }

                // Left side collision of the Tank.
                if (TD_PlayerTank.collision.isToRightOf(ft1_floorCol_2) ||
                    TD_PlayerTank.collision.isToRightOf(ft2_floorCol_1) ||
                    TD_PlayerTank.collision.isToRightOf(ft3_floorCol_1) ||
                    TD_PlayerTank.collision.isToRightOf(ft4_floorCol_1) ||
                    TD_PlayerTank.collision.isToRightOf(ft4_floorCol_2) ||
                    TD_PlayerTank.collision.isToRightOf(ft5_floorCol_1) ||
                    TD_PlayerTank.collision.isToRightOf(ft5_floorCol_2))
                {
                    TD_PlayerTank.isLeftCol = true;
                }
                else
                {
                    TD_PlayerTank.isLeftCol = false;
                }

                // Right side collision of the Tank.
                if (TD_PlayerTank.collision.isToLeftOf(ft1_floorCol_3) ||
                    TD_PlayerTank.collision.isToLeftOf(ft2_floorCol_3) ||
                    TD_PlayerTank.collision.isToLeftOf(ft2_floorCol_4) ||
                    TD_PlayerTank.collision.isToLeftOf(ft3_floorCol_2) ||
                    TD_PlayerTank.collision.isToLeftOf(ft4_floorCol_2) ||
                    TD_PlayerTank.collision.isToLeftOf(ft4_floorCol_3) ||
                    TD_PlayerTank.collision.isToLeftOf(ft5_floorCol_4))
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

        public override void Draw(GameTime gametime)
        {
            if (TD_Game.Instance.level_No == 1)
            {
                // Draw the Level Images.
                TD_Game.Instance.spriteBatch.Draw(floorTile_0, levelPos_0, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_1, levelPos_1, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_2, levelPos_2, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_3, levelPos_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_4, levelPos_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(endGame, endGame_pos, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_5, levelPos_5, Color.White);
                TD_Game.Instance.spriteBatch.Draw(floorTile_6, levelPos_6, Color.White);

                // Flag to make the health invisible if it's picked up.
                if (isPickedUp == false)
                {
                    TD_Game.Instance.spriteBatch.Draw(health_img_1, healthPick_pos, Color.White);
                }
            }
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
