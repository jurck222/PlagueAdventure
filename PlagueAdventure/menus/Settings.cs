using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;
using PlagueAdventure.Controls;

namespace PlagueAdventure.menus
{
    public class Settings
    {
        public Basic2d plus;
        public Basic2d minus;
        public Basic2d back;
       
        private SpriteFont font;
        public Settings()
        {
            
            font = Globals.content.Load<SpriteFont>("Volume");
            plus = new Button("audioGumbi", new Vector2(700, 1000), 0, 0, 50, 50, 2f);
            minus = new Button("audioGumbi", new Vector2(400, 1000), 0, 50, 50, 50, 2f);
            back = new Button("back", new Vector2(1000, 100), 0, 0, 100, 100);
        }
        public virtual void Update(GameTime gameTime, Game1 game)
        {
            Globals.touchState = TouchPanel.GetState();
            if (Globals.touchState.Count > 0)
            {
                if (Globals.touchState[0].State == TouchLocationState.Pressed)
                {
                    if (Globals.touchState[0].Position.X > 601 & Globals.touchState[0].Position.X < 709 & Globals.touchState[0].Position.Y > 998 & Globals.touchState[0].Position.Y < 1098 & Globals.settings)
                    {
                        if (Globals.vol <= 85)
                        {
                            Globals.vol += 15;
                        }
                        else if (Globals.vol > 85)
                        {
                            Globals.vol = 100;
                        }
                    }
                    if (Globals.touchState[0].Position.X > 295 & Globals.touchState[0].Position.X < 403 & Globals.touchState[0].Position.Y > 1001 & Globals.touchState[0].Position.Y < 1104 & Globals.settings)
                    {
                        if (Globals.vol >= 15)
                        {
                            Globals.vol -= 15;
                        }
                        else if (Globals.vol < 15)
                        {
                            Globals.vol = 0;
                        }

                    }
                    if (Globals.touchState[0].Position.X > 901 & Globals.touchState[0].Position.X < 1004 & Globals.touchState[0].Position.Y > 99 & Globals.touchState[0].Position.Y < 194 & Globals.settings)
                    {
                        Globals.settings = false;
                        Globals.menu = true;
                    }
                   
                }
                
                MediaPlayer.Volume = Globals.vol / 100.0f;
                
            }
            plus.Update(gameTime);
            back.Update(gameTime);
            minus.Update(gameTime);
        }
        public virtual void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            Globals._spriteBatch.DrawString(font, "Volume: " + Globals.vol + "%", new Vector2(540, 880), Color.Black, 1.57f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            plus.Draw(OFFSET, gameTime);
            minus.Draw(OFFSET, gameTime);
            back.Draw(OFFSET, gameTime);
        }
    }
}
