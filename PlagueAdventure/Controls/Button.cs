using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.Controls
{
    public class Button : Basic2d
    {
        public Button(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false, float ROT = 1.57F) : base(PATH, POS, X, Y, W, H, SCALE, FLIP, ROT)
        {
        }
        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public virtual void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }
}
