using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.NPC
{

    public class Enemy : Basic2d

    {
        public bool done;
        public Vector2 direction;
        public float speed;
        public Unit owner;
        public McTimer timer;
        public Enemy(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false, float ROT = 1.57F) : base(PATH, POS, X, Y, W, H, SCALE, FLIP, ROT)
        {
            done = false;
            speed = 2.0f;
            if (flip)
            {
                direction = new Vector2(pos.X + 70, pos.Y - 400);
            }
            else
            {
                direction = new Vector2(pos.X, pos.Y + 400);
            }

            direction.Normalize();
        }
        public override void Update(GameTime gameTime)
        {
            //Debug.WriteLine(pos);

            if (flip)
            {
                pos.Y += direction.Y * speed;
            }
            else
            {
                pos.Y -= direction.Y * speed;
            }


            if (pos.Y <= 740)
            {
                flip = true;
            }
            if (pos.Y >= 1420)
            {
                flip = false;
            }


        }
        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }

}
