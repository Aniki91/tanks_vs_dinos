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

        //finish level timer
        public float finishWait;

        // Game Instance.
        private static TD_Game instance;

        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        // Lists<> for Game Actors, Dinos and Bullets.
        public List<TD_GameActor> Actor_List = new List<TD_GameActor>();

        //public List<TD_GameActor> temp_Actor_List = new List<TD_GameActor>();

        public List<TD_GameActor> Bad_Guys = new List<TD_GameActor>();
        public List<TD_GameActor> Bullets = new List<TD_GameActor>();
        public List<TD_GameActor> BGBullets = new List<TD_GameActor>();

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
        public TD_GameActor tempDino2;

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
            tempDino2 = new TD_Dino_2();


            // playerTank is element 0, turret is 1 and level_1 is 2.
            Actor_List.Add(playerTank);
            Actor_List.Add(turret);
            Actor_List.Add(level_1);
            Actor_List.Add(level_2);
            Actor_List.Add(level_3);


            

            // Spawning Dinos across the level.
            for (int i = 100; i < 10000; i += 500)
            {
                Bad_Guys.Add(new TD_Dino_1(new Vector2(i, 100)));
                
            }

            Bad_Guys.Add(tempDino2);

            //spawning Steve The Rocket Guy across the level
            for (int i = 100; i < 10000; i += 500)
            {
                Bad_Guys.Add(new TD_Dino_2(new Vector2(i, 100)));
            }

            

            //BGBullets = tempDino2.Bullets;
                                                
            this.Bullets = turret.Bullets;

            base.Initialize();


        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
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
            for (int i = 0; i < Bad_Guys.Count; i++)
            {
                Bad_Guys[i].LoadContent();
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


                foreach (TD_GameActor shooty in Bad_Guys)
                {
                    
                    BGBullets = shooty.Bullets;

                    //BAD GUY BULLET LIST
                    for (int i = 0; i < BGBullets.Count; i++)
                    {
                        if (BGBullets[i].isAlive == false)
                        {
                            BGBullets.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            BGBullets[i].Update(gameTime);
                        }
                    }
                }

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
                    else if(Actor_List.Count > 0)
                    {
                        Actor_List[i].Update(gameTime);
                    }
                }

            

                // Checking if Enemies are flagged as not alive,
                // and then removes them from it's position in the List.
                for (int i = 0; i < Bad_Guys.Count; i++)
                {
                    if (Bad_Guys[i].isAlive == false || playerTank.bFinish == true)
                    {
                        Bad_Guys.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        Bad_Guys[i].Update(gameTime);
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
                   // level_3.Update(gameTime);
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

                // Draw bullets that are alive.
                for (int i = 0; i < turret.Bullets.Count; i++)
                {
                    if (turret.Bullets[i].isAlive == true)
                    {
                        turret.Bullets[i].Draw(gameTime);
                    }
                }

                foreach (TD_GameActor shooty in Bad_Guys)
                {
                    BGBullets = shooty.Bullets;

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

                // Draw all Enemies who are alive.
                for (int i = 0; i < Bad_Guys.Count; i++)
                {
                    if (Bad_Guys[i].isAlive == true)
                    {
                        Bad_Guys[i].Draw(gameTime);
                    }
                }

                // Show "Game Over" if the player has died.
                if (playerTank.isAlive == false)
                {
                    TD_Game.Instance.spriteBatch.DrawString(GameOver, "Game Over", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }

                // Show "You Won!" if the player has beaten the level.
                if (playerTank.bFinish == true)
                {
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "You Won!", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                    finishWait = gameTime.ElapsedGameTime.Seconds;
                    
                        
                    //level_No = 2;
                    

                    
                }
            }
            else if(gameState == GameState.game && level_No == 2)
            {
                
                

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

                // Draw bullets that are alive.
                for (int i = 0; i < turret.Bullets.Count; i++)
                {
                    if (turret.Bullets[i].isAlive == true)
                    {
                        turret.Bullets[i].Draw(gameTime);
                    }
                }


                foreach (TD_GameActor shooty in Bad_Guys)
                {
                    BGBullets = shooty.Bullets;

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

                
                // Draw all Enemies who are alive.
                for (int i = 0; i < Bad_Guys.Count; i++)
                {
                    if (Bad_Guys[i].isAlive == true)
                    {
                        Bad_Guys[i].Draw(gameTime);
                    }
                }

                // Show "Game Over" if the player has died.
                if (playerTank.isAlive == false)
                {
                    TD_Game.Instance.spriteBatch.DrawString(GameOver, "Game Over", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }

                // Show "You Won!" if the player has beaten the level.
                if (playerTank.bFinish == true)
                {
                    TD_Game.Instance.spriteBatch.DrawString(EndGame, "You Won!", new Vector2(832 / 2 - 150, 256), Color.Black, 0f, new Vector2(), 3, SpriteEffects.None, 0);
                }
            }
            else if (gameState == GameState.game && level_No == 3)
            {
                level_3.Draw(gameTime);
            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
