using Android.Locations;
using Android.Media;

using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.NPC
{
    public class Civilian : Unit
    {
        public Vector2 direction;
        float speed;
        public bool run;
        public McTimer timer;
        public bool done;
        public float door;
        public bool left;
        public int power;
        
        public Civilian(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, SCALE, FLIP)
        {
            speed = 10.0f;
            done = false;

            run = false;
            power = 15;
            if (flip)
            {
                direction = new Vector2(pos.X + 70, pos.Y - 400);
            }
            else
            {
                direction = new Vector2(pos.X, pos.Y);
            }
            direction.Normalize();
        }
        public override void Update(GameTime gameTime)
        {

            if (Globals.kidRun)
            {
                pos.Y += direction.Y * speed;
            }
                

            }
        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }
}
