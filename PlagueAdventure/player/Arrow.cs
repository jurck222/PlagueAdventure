using Microsoft.Xna.Framework;
using PlagueAdventure.NPC;
using PlagueAdventure.Source;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.player
{
    public class Arrow : Projectile
    {
        public Arrow(string PATH, Vector2 POS, int X, int Y, int W, int H, Unit OWNER, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, OWNER, SCALE, FLIP)
        {
        }
        public virtual void Update(Vector2 OFFSET, List<Unit> Unit, GameTime gameTime)
        {
            pos.Y -= direction.Y * speed;
            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }
            if (Hit(Unit))
            {
                done = true;
            }
        }

        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }
}
