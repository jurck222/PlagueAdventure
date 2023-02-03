using Javax.Crypto.Spec;
using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.NPC
{
    public class Bird : Unit
    {
        public Vector2 direction;
        float speed;
        public McTimer timer;
        public bool done;
        

        public int power;
        public Bird(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, SCALE, FLIP)
        {
            speed = 5.0f;
            done = false;
            
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
            timer = new McTimer(4000);
        }
        public override void Update(GameTime gameTime)
        {

            if (Globals.fly)
            {
                if (flip)
                {
                    pos.Y += direction.Y * speed;
                    pos.X += direction.X * (2 * speed);
                }
                else
                {
                    pos.Y -= direction.Y * speed;
                    pos.X += direction.X * (2 * speed);
                }
                
            }
            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }
}
