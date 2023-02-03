using Android.Graphics;
using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.NPC
{
    public class Unit : Basic2d
    {
        public float speed;
        public Unit(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, SCALE, FLIP)
        {
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
        
    }
}
