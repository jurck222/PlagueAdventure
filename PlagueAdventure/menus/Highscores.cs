using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlagueAdventure.Controls;

namespace PlagueAdventure.menus
{
    public class Highscores
    {
        public Basic2d back;
        public Highscores(){
            back = new Button("back", new Vector2(1000, 100), 0, 0, 100, 100);
        }
        public virtual void Update(GameTime gameTime, Game1 game)
        {
            if (Globals.touchState[0].Position.X > 901 & Globals.touchState[0].Position.X < 1004 & Globals.touchState[0].Position.Y > 99 & Globals.touchState[0].Position.Y < 194 & Globals.settings)
            {
                Globals.high = false;
                Globals.menu = true;
            }
            back.Update(gameTime);
        }
        public virtual void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            back.Draw(OFFSET, gameTime);
        }
    }
}
    
