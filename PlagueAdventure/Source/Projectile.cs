using Java.Time.Temporal;
using Microsoft.Xna.Framework;
using PlagueAdventure.NPC;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;

namespace PlagueAdventure.Source
{
    public class Projectile : Basic2d
    {
        public bool done;
        public Vector2 direction;
        public float speed;
        public Unit owner;
        public McTimer timer;
        public Projectile(string PATH, Vector2 POS, int X, int Y, int W, int H, Unit OWNER, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, SCALE, FLIP)
        {
            owner = OWNER;
            done = false;
            speed = 8.0f;
            if (flip)
            {
                direction = new Vector2(owner.pos.X + 70, owner.pos.Y - 400);
            }
            else
            {
                direction = new Vector2(owner.pos.X, owner.pos.Y + 400);
            }

            direction.Normalize();
            timer = new McTimer(4000);
        }
        public virtual void Update(Vector2 OFFSET, List<Unit> Unit)
        {
            if (flip)
            {
                pos.Y -= direction.Y * speed;
            }
            else
            {
                pos.Y += direction.Y * speed;
            }
            timer.UpdateTimer();
            if (timer.Test())
            {
                Debug.WriteLine("here");
                done = true;
            }
            if (Hit(Unit))
            {
                done = true;
            }
        }
        public virtual bool Hit(List<Unit> Units)
        {
            return done;
        }
        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }
}
