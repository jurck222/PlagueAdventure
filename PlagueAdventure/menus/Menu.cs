using Android.OS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using PlagueAdventure.Controls;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using System.IO;


namespace PlagueAdventure.menus
{
    public class Menu
    {
        public Basic2d Start;
        public Basic2d Settings;
        public Basic2d Exit;
        public Basic2d sound;
        Song level;
        Song main;
        public Menu()
        {
            Start = new Button("menuButtons", new Vector2(800, 100), 11, 14, 283, 118, 1.5f);
            Settings = new Button("menuButtons", new Vector2(600, 100), 22, 165, 265, 112, 1.5f);
            Exit = new Button("menuButtons", new Vector2(400, 100), 24, 315, 260, 120, 1.5f);
            main = Globals.content.Load<Song>("menu");
            level = Globals.content.Load<Song>("lvl1");
            if (Globals.vol == 0)
            {
                sound = new Button("sound", new Vector2(100, 2000), 0, 50, 50, 50, 1.5f);
            }

            else sound = new Button("sound", new Vector2(100, 2000), 0, 0, 50, 50, 1.5f);
            MediaPlayer.Play(main);
            MediaPlayer.Volume = Globals.vol/100.0f;
            MediaPlayer.IsRepeating = true;
            
        }
        public virtual void Update(GameTime gameTime, Game1 game, SaveManager saveManager)
        {
            Globals.touchState = TouchPanel.GetState();
            if (Globals.touchState.Count > 0)
            {
                if (Globals.touchState[0].State == TouchLocationState.Pressed)
                {
                    
                    if (Globals.touchState[0].Position.X > 222 & Globals.touchState[0].Position.X < 406 & Globals.touchState[0].Position.Y > 96 & Globals.touchState[0].Position.Y < 491 & Globals.menu)
                    {
                        IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("audio.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        using (StreamWriter sw = new StreamWriter(isoStream))
                        {
                            sw.Flush();
                            sw.WriteLine(Globals.vol.ToString());
                        }
                        SaveManager.Save(saveManager);
                        game.Quit();
                    }
                    if (Globals.touchState[0].Position.X > 631 & Globals.touchState[0].Position.X < 800 & Globals.touchState[0].Position.Y > 101  & Globals.touchState[0].Position.Y < 519  & Globals.menu)
                    {
                        Globals.menu = false;
                        Globals.start = true;
                        
                            MediaPlayer.Play(level);
                            MediaPlayer.IsRepeating = true;
                        

                    }
                    if (Globals.touchState[0].Position.X > 430 & Globals.touchState[0].Position.X < 601 & Globals.touchState[0].Position.Y > 96  & Globals.touchState[0].Position.Y < 494  & Globals.menu)
                    {
                        Globals.menu = false;
                        Globals.settings = true;
                    }
                    if (Globals.touchState[0].Position.X > 32 & Globals.touchState[0].Position.X < 97 & Globals.touchState[0].Position.Y > 2002  & Globals.touchState[0].Position.Y < 2072  & Globals.menu)
                    {
                        if (Globals.vol > 0)
                        {
                            sound = new Button("sound", new Vector2(100, 2000 ), 0, 0, 50, 50, 1.5f);
                            Globals.vol = 0;
                           
                        }
                        else
                        {
                            sound = new Button("sound", new Vector2(100, 2000 ), 0, 50, 50, 50, 1.5f);
                            Globals.vol = 20;
                           
                        }
                    }
                }
            }
            if (Globals.vol > 0)
            {
                sound = new Button("sound", new Vector2(100, 2000 ), 0, 0, 50, 50, 1.5f);
                

            }
            else
            {
                sound = new Button("sound", new Vector2(100, 2000 ), 0, 50, 50, 50, 1.5f);
                

            }
            MediaPlayer.Volume = Globals.vol / 100.0f;
            Start.Update(gameTime);
            Settings.Update(gameTime);
            Exit.Update(gameTime);
            sound.Update(gameTime);
        }
        public virtual void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            Start.Draw(OFFSET, gameTime);
            Settings.Draw(OFFSET, gameTime);
            Exit.Draw(OFFSET, gameTime);
            sound.Draw(OFFSET, gameTime);
        }
    }
}
