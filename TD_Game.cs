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
    public enum GameState { MainMenu, options, game };

    public class TD_Game : Microsoft.Xna.Framework.Game
    {

        public static GameState gameState = GameState.MainMenu;

        public bool Start_game = false;

        // Variables | Instances
        public Vector2 crossHair_Pos;

        //finish level timer
        public float finishWait;

        // Game Instance.
        private static TD_Game instance;

        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        // Lists<> for Game Actors, Dinos and Bullets.
        public List<TD_GameActor> Actor_List = new List<TD_GameActor>();

        //public List<TD_GameActor> temp_Actor_List = new List<TD_GameActor>();

        public List<TD_GameActor> Bad_Guys1 = new List<TD_GameActor>();
        public List<TD_GameActor> Bad_Guys2 = new List<TD_GameActor>();
        public List<TD_GameActor> Bullets = new List<TD_GameActor>();
        public List<TD_GameActor> BGBullets = new List<TD_GameActor>();
        public List<TD_GameActor> FPS_BadGuys = new List<TD_GameActor>();

        //public List<TD_Dino_3> Dino_3 = new List<TD_Dino_3>();

        // SpriteFont for GameOver and EndGame.
        public SpriteFont GameOver { get; set; }
        public SpriteFont EndGame { get; set; }

        // TD_GameActor instances.
        public TD_GameActor playerTank;
        public TD_GameActor turret;
        public TD_GameActor level_1;
        public TD_GameActor level_2;
        public TD_GameActor level_3;
        public Texture2D MainMenu;
        public Texture2D Options;

        // Steve the rocket dude.
        public TD_GameActor tempDino2;
        public TD_GameActor tempDino3;
        public TD_GameActor tempDino4;
        public TD_GameActor tempDino5;
        public TD_GameActor tempDino6;
        public TD_GameActor tempDino7;
        public TD_GameActor tempDino8;
        public TD_GameActor tempDino9;
        public TD_GameActor tempDino10;
        public TD_GameActor tempDino11;




        //dino-3's
        public TD_Dino_3 Dino_3_1;
        public TD_Dino_3 Dino_3_2;
        public TD_Dino_3 Dino_3_3;
        public TD_Dino_3 Dino_3_4;
        public TD_Dino_3 Dino_3_5;
        public TD_Dino_3 Dino_3_6;
        public TD_Dino_3 Dino_3_7;
        public TD_Dino_3 Dino_3_8;
        public TD_Dino_3 Dino_3_9;
        public TD_Dino_3 Dino_3_10;
        public TD_Dino_3 Dino_3_11;
        public TD_Dino_3 Dino_3_12;
        public TD_Dino_3 Dino_3_13;
        public TD_Dino_3 Dino_3_14;
        public TD_Dino_3 Dino_3_15;
        public TD_Dino_3 Dino_3_16;
        public TD_Dino_3 Dino_3_17;
        public TD_Dino_3 Dino_3_18;
        public TD_Dino_3 Dino_3_19;
        public TD_Dino_3 Dino_3_20;


        // int variables
        public int level_No;

        // Creating the TD_Game instance.
        public static TD_Game Instance
        {
            get
            {
                return instance;
            }
        }

        // Creating the TD_Game instance.
        public TD_Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 832;
            graphics.PreferredBackBufferHeight = 512;
            Content.RootDirectory = "Content";
            instance = this;
        }

        protected override void Initialize()
        {
            playerTank = new TD_PlayerTank();
            level_1 = new TD_Level_1();
            level_2 = new TD_Level_2();
            level_3 = new TD_Level_3();
            turret = new TD_Turret();

            int S = 100;
            #region Spawning Shooty Dinos;
            tempDino2 = new TD_Dino_2(new Vector2(S,100));
            S += 500;

            tempDino3 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino4 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino5 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino6 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino7 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino8 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino9 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino10 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;
            tempDino11 = new TD_Dino_2(new Vector2(S, 100));
            S += 500;

            #endregion

            Dino_3_1 = new TD_Dino_3(100, 100);
            Dino_3_2 = new TD_Dino_3(250, 400);
            Dino_3_3 = new TD_Dino_3(400, 125);
            Dino_3_4 = new TD_Dino_3(780, 425);
            Dino_3_5 = new TD_Dino_3(640, 360);
            Dino_3_6 = new TD_Dino_3(120, 280);
            Dino_3_7 = new TD_Dino_3(340, 120);
            Dino_3_8 = new TD_Dino_3(500, 320);
            Dino_3_9 = new TD_Dino_3(310, 210);
            Dino_3_10 = new TD_Dino_3(750, 490);

            // playerTank is element 0, turret is 1 and level_1 is 2.
            Actor_List.Add(playerTank);
            Actor_List.Add(turret);
            Actor_List.Add(level_1);
            Actor_List.Add(level_2);
            Actor_List.Add(level_3);

            FPS_BadGuys.Add(Dino_3_1);
            FPS_BadGuys.Add(Dino_3_2);
            FPS_BadGuys.Add(Dino_3_3);
            FPS_BadGuys.Add(Dino_3_4);
            FPS_BadGuys.Add(Dino_3_5);
            FPS_BadGuys.Add(Dino_3_6);
            FPS_BadGuys.Add(Dino_3_7);
            FPS_BadGuys.Add(Dino_3_8);
            FPS_BadGuys.Add(Dino_3_9);
            FPS_BadGuys.Add(Dino_3_10);



            // Spawning Dinos across the level.
            for (int i = 100; i < 10000; i += 500)
            {
                Bad_Guys1.Add(new TD_Dino_1(new Vector2(i, 100)));
                
            }

            Bad_Guys2.Add(tempDino2);
            Bad_Guys2.Add(tempDino3);
            Bad_Guys2.Add(tempDino4);
            Bad_Guys2.Add(tempDino5);
            Bad_Guys2.Add(tempDino6);
            Bad_Guys2.Add(tempDino7);
            Bad_Guys2.Add(tempDino8);
            Bad_Guys2.Add(tempDino9);
            Bad_Guys2.Add(tempDino10);
            Bad_Guys2.Add(tempDino11);
         
                                                
            this.Bullets = turret.Bullets;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Crosshair Position
            crossHair_Pos = new Vector2(416, 256);
            
            //testing for level two
            level_No = 0;
            
            MainMenu = TD_Game.Instance.Content.Load<Texture2D>("mainMenu");
            Options = TD_Game.Instance.Content.Load<Texture2D>("options");

            // Load the content within the Actor List through a loop.
            for (int i = 0; i < Actor_List.Count; i++)
            {
                Actor_List[i].LoadContent();
            }

            
                // Load the content within the Bad_Guys List through a loop.
                for (int i = 0; i < Bad_Guys1.Count; i++)
                {
                    Bad_Guys1[i].LoadContent();
                }

           
                // Load the content within the Bad_Guys List through a loop.
                for (int i = 0; i < Bad_Guys2.Count; i++)
                {
                    Bad_Guys2[i].LoadContent();
                }

            

            for (int i = 0; i < FPS_BadGuys.Count; i++)
            {
                FPS_BadGuys[i].LoadContent();
            }

            // Loading a song for the game.
            Song song = Content.Load<Song>("Background_Music");  // Put the name of your song in instead of "song_title"
            MediaPlayer.Play(song);
            
            // Loading the Font to be used.
            GameOver = TD_Game.Instance.Content.Load<SpriteFont>("Arial");
            EndGame = TD_Game.Instance.Content.Load<SpriteFont>("Arial");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {

            this.Bullets = turret.Bullets;
            

                GamePadState Controler = GamePad.GetState(PlayerIndex.One);

                if (gameState == GameState.game && Controler.Buttons.Back == ButtonState.Pressed)
                {
                    TD_Game.Instance.Exit();
                }

                if (level_No == 3)
                {
                    if (Controler.ThumbSticks.Right.X > 0)
                    {
                        crossHair_Pos.X = crossHair_Pos.X + 10;
                    }

                    if (Controler.ThumbSticks.Right.X < 0)
                    {
                        crossHair_Pos.X = crossHair_Pos.X - 10;
                    }

                    if (Controler.ThumbSticks.Right.Y > 0)
                    {
                        crossHair_Pos.Y = crossHair_Pos.Y - 10;
                    }

                    if (Controler.ThumbSticks.Right.Y < 0)
                    {
                        crossHair_Pos.Y = crossHair_Pos.Y + 10;
                    }
                }


                // Checking if a bullet is flagged as not alive, and then removes
                // that bullet from it's position in the List.
                for (int i = 0; i < turret.Bullets.Count; i++)
                {
                    if (turret.Bullets[i].isAlive == false)
                    {
                        turret.Bullets.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        turret.Bullets[i].Update(gameTime);
                    }
                }

                #region Dino Shoot Code
                //BGBullets = tempDino2.Bullets;
                if(level_No == 2)
                {
                    //BAD GUY BULLET LIST
                    for (int i = 0; i < tempDino2.Bullets.Count; i++)
                    {
                        if (tempDino2.Bullets[i].isAlive == false)
                        {
                            tempDino2.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino2.Bullets[i].Update(gameTime);
                        }
                    }


                    for (int i = 0; i < tempDino3.Bullets.Count; i++)
                    {
                        if (tempDino3.Bullets[i].isAlive == false)
                        {
                            tempDino3.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino3.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino4.Bullets.Count; i++)
                    {
                        if (tempDino4.Bullets[i].isAlive == false)
                        {
                            tempDino4.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino4.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino5.Bullets.Count; i++)
                    {
                        if (tempDino5.Bullets[i].isAlive == false)
                        {
                            tempDino5.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino5.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino6.Bullets.Count; i++)
                    {
                        if (tempDino6.Bullets[i].isAlive == false)
                        {
                            tempDino6.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino6.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino7.Bullets.Count; i++)
                    {
                        if (tempDino7.Bullets[i].isAlive == false)
                        {
                            tempDino7.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino7.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino8.Bullets.Count; i++)
                    {
                        if (tempDino8.Bullets[i].isAlive == false)
                        {
                            tempDino8.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino8.Bullets[i].Update(gameTime);
                        }
                    }
                    for (int i = 0; i < tempDino9.Bullets.Count; i++)
                    {
                        if (tempDino9.Bullets[i].isAlive == false)
                        {
                            tempDino9.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino9.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino10.Bullets.Count; i++)
                    {
                        if (tempDino10.Bullets[i].isAlive == false)
                        {
                            tempDino10.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino10.Bullets[i].Update(gameTime);
                        }
                    }

                    for (int i = 0; i < tempDino11.Bullets.Count; i++)
                    {
                        if (tempDino11.Bullets[i].isAlive == false)
                        {
                            tempDino11.Bullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            tempDino11.Bullets[i].Update(gameTime);
                        }
                    }


        }
                

                #endregion

                    // Checking if Actors or the Tank are flagged as not alive,
                // or if the Tank(player) has completed the Level, and then removes
                // them from it's position in the List.
                    for (int i = 0; i < Actor_List.Count; i++)
                    {
                        if ((Actor_List[i].isAlive == false || playerTank.bFinish == true))
                        {

                            Actor_List.RemoveAt(i);
                            i--;

                        }
                        else if (Actor_List.Count > 0)
                        {
                            Actor_List[i].Update(gameTime);
                        }
                    }
               
            

                // Checking if Enemies are flagged as not alive,
                // and then removes them from it's position in the List.
                        for (int i = 0; i < Bad_Guys1.Count; i++)
                        {
                            if (Bad_Guys1[i].isAlive == false || playerTank.bFinish == true)
                            {
                                Bad_Guys1.RemoveAt(i);
                                i--;
                            }
                            else
                            {
                                Bad_Guys1[i].Update(gameTime);
                            }
                        }

                        for (int i = 0; i < Bad_Guys2.Count; i++)
                        {
                            if (Bad_Guys2[i].isAlive == false || playerTank.bFinish == true)
                            {
                                Bad_Guys2.RemoveAt(i);
                                i--;
                            }
                            else
                            {

                                Bad_Guys2[i].Update(gameTime);
                            }
                        }

                if (level_No == 3)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        if (FPS_BadGuys.Count <= 0)
                        {
                            break;
                        }

                        if (FPS_BadGuys[i].isAlive == false)
                        {
                            //FPS_BadGuys.RemoveAt(i);
                            //i--;
                        }
                        else
                        {
                            FPS_BadGuys[i].Update(gameTime);
                        }
                    }
                }



                if (playerTank.bFinish == true)
                {
                    

                  //level_No = 2;

                  //playerTank.bFinish = false;

                    
                }

                if (level_No == 1)
                {
                    level_1.Update(gameTime);
                }
                if (level_No == 2)
                {
                    level_2.Update(gameTime);
                }
                if (level_No == 3)
                {
                    //level_3.Update(gameTime);
                }
                base.Update(gameTime);
            }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (gameState == GameState.MainMenu)
            {
                TD_Game.Instance.spriteBatch.Draw(MainMenu, new Vector2(0, 0), Color.White);
            }
            else if (gameState == GameState.options)
            {
                TD_Game.Instance.spriteBatch.Draw(Options, new Vector2(0, 0), Color.White);
            }
            else if (gameState == GameState.game && level_No == 1)
            {

                #region LEVEL 1


                // Background 1
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_1, new Vector2(0, 0), Color.White);

                // Background 2
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_0, TD_Level_1.backPos_0, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_1, TD_Level_1.backPos_1, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_2, TD_Level_1.backPos_2, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_3, TD_Level_1.backPos_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_4, TD_Level_1.backPos_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_5, TD_Level_1.backPos_5, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_2_6, TD_Level_1.backPos_6, Color.White);

                // Background 3
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_0, TD_Level_1.backPos_0_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_1, TD_Level_1.backPos_1_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_2, TD_Level_1.backPos_2_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_3, TD_Level_1.backPos_3_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_4, TD_Level_1.backPos_4_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_5, TD_Level_1.backPos_5_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_3_6, TD_Level_1.backPos_6_3, Color.White);

                // Background 4
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_0, TD_Level_1.backPos_0_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_1, TD_Level_1.backPos_1_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_2, TD_Level_1.backPos_2_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_3, TD_Level_1.backPos_3_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_4, TD_Level_1.backPos_4_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_5, TD_Level_1.backPos_5_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_1.background_4_6, TD_Level_1.backPos_6_4, Color.White);

                level_1.Draw(gameTime);


                // Draw all contents of the Actor_List who are alive.
                for (int i = 0; i < Actor_List.Count; i++)
                {
                    if (Actor_List[i].isAlive == true)
                    {
                        Actor_List[i].Draw(gameTime);
                    }
                }

                if (level_No == 1 || level_No == 2)
                {
                    // Draw all Enemies who are alive.
                    for (int i = 0; i < Bad_Guys1.Count; i++)
                    {
                        if (Bad_Guys1[i].isAlive == true)
                        {
                            Bad_Guys1[i].Draw(gameTime);
                        }
                    }
                }

                if (level_No == 2)
                {

                    for (int i = 0; i < Bad_Guys2.Count; i++)
                    {
                        if (Bad_Guys2[i].isAlive == true)
                        {
                            Bad_Guys2[i].Draw(gameTime);
                        }
                    }
                }

                // Show "Game Over" if the player has died.
                if (playerTank.isAlive == false)
                {
                    TD_Game.Instance.spriteBatch.DrawString(GameOver, "Game Over", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "Score: " + turret.score.ToString(), new Vector2(832 / 2 - 150, 360), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }

                // Show "You Won!" if the player has beaten the level.
                if (playerTank.bFinish == true)
                {
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "You Won!", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "Score: " + turret.score.ToString(), new Vector2(832 / 2 - 150, 360), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                    finishWait = gameTime.ElapsedGameTime.Seconds;
                    
                        
                    //level_No = 2;

                    
                    
                }

                for (int i = 0; i < turret.Bullets.Count; i++)
                {
                    if (turret.Bullets[i].isAlive == true)
                    {
                        turret.Bullets[i].Draw(gameTime);
                    }
                }

                #endregion
            }
            else if(gameState == GameState.game && level_No == 2)
            {
                #region LEVEL 2


                // Background 1
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_1, new Vector2(0, 0), Color.White);

                // Background 2
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_0, TD_Level_2.backPos_0, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_1, TD_Level_2.backPos_1, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_2, TD_Level_2.backPos_2, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_3, TD_Level_2.backPos_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_4, TD_Level_2.backPos_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_5, TD_Level_2.backPos_5, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_2_6, TD_Level_2.backPos_6, Color.White);
                 

                // Background 3
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_0, TD_Level_2.backPos_0_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_1, TD_Level_2.backPos_1_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_2, TD_Level_2.backPos_2_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_3, TD_Level_2.backPos_3_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_4, TD_Level_2.backPos_4_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_5, TD_Level_2.backPos_5_3, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_3_6, TD_Level_2.backPos_6_3, Color.White);

                // Background 4
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_0, TD_Level_2.backPos_0_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_1, TD_Level_2.backPos_1_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_2, TD_Level_2.backPos_2_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_3, TD_Level_2.backPos_3_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_4, TD_Level_2.backPos_4_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_5, TD_Level_2.backPos_5_4, Color.White);
                TD_Game.Instance.spriteBatch.Draw(TD_Level_2.background_4_6, TD_Level_2.backPos_6_4, Color.White);

                level_2.Draw(gameTime);

                

                foreach (TD_GameActor shoot in Bad_Guys2)
                {
                    BGBullets = shoot.Bullets;

                    //Bad guy bullets
                    for (int i = 0; i < BGBullets.Count; i++)
                    {
                        if (BGBullets[i].isAlive == true)
                        {
                            BGBullets[i].Draw(gameTime);
                        }

                    }
                }

                // Draw all contents of the Actor_List who are alive.
                for (int i = 0; i < Actor_List.Count; i++)
                {
                    if (Actor_List[i].isAlive == true)
                    {
                        Actor_List[i].Draw(gameTime);
                    }
                }

                if (level_No == 1 || level_No == 2)
                {
                    // Draw all Enemies who are alive.
                    for (int i = 0; i < Bad_Guys1.Count; i++)
                    {
                        if (Bad_Guys1[i].isAlive == true)
                        {
                            Bad_Guys1[i].Draw(gameTime);
                        }
                    }
                }

                if (level_No == 2)
                {
                    // Draw all Enemies who are alive.
                    for (int i = 0; i < Bad_Guys2.Count; i++)
                    {
                        if (Bad_Guys2[i].isAlive == true)
                        {
                            Bad_Guys2[i].Draw(gameTime);
                        }
                    }
                }

                // Show "Game Over" if the player has died.
                if (playerTank.isAlive == false)
                {
                    TD_Game.Instance.spriteBatch.DrawString(GameOver, "Game Over", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "Score: " + turret.score.ToString(), new Vector2(832 / 2 - 150, 360), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }

                // Show "You Won!" if the player has beaten the level.
                if (playerTank.bFinish == true)
                {
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "You Won!", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "Score: " + turret.score.ToString(), new Vector2(832 / 2 - 150, 360), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }

                // Draw bullets that are alive.
                for (int i = 0; i < turret.Bullets.Count; i++)
                {
                    if (turret.Bullets[i].isAlive == true)
                    {
                        turret.Bullets[i].Draw(gameTime);
                    }
                }

                #endregion

            }
            else if (gameState == GameState.game && level_No == 3)
            {
                #region LEVEL 3

                level_3.Draw(gameTime);

                for (int i = 0; i < 1; i++)
                {
                    if (FPS_BadGuys.Count <= 0)
                    {
                        break;
                    }

                    if (FPS_BadGuys[i].isAlive == true)
                    {
                        FPS_BadGuys[i].Draw(gameTime);
                    }
                    else
                    {
                        FPS_BadGuys.RemoveAt(i);
                        //i--;
                    }
                }

                
                TD_Game.Instance.spriteBatch.Draw(TD_Level_3.crossHair, crossHair_Pos, Color.White);

                /*
                if (TD_PlayerTank.tank_health <= 0)
                {
                    TD_Game.Instance.spriteBatch.DrawString(GameOver, "Game Over", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }
                */

                // Show "You Won!" if the player has beaten the level.
                if (FPS_BadGuys.Count <= 0)
                {
                    //TD_Game.Instance.spriteBatch.DrawString(EndGame, "You Won!", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }
                #endregion
            }

            

            spriteBatch.End();

            base.Draw(gameTime);

                
        }
    }
}
