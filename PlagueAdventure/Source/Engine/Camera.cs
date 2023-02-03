
using Microsoft.Xna.Framework;
using PlagueAdventure.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.Source.Engine
{
    public class Camera
    {
        public Matrix Transform { get; set; }
        public void Follow(Basic2d target)
        {
            if (Globals.menu || Globals.settings)
            {
                Transform = Matrix.CreateTranslation(
                    -target.pos.X - (target.h / 2),
                    -target.pos.Y - (target.w / 2),
                    0) *
                    Matrix.CreateTranslation(
                        (Game1.ScreenHeight / 2),
                        Game1.ScreenWidth / 2,
                        0);
            }
            if (Globals.start)
            {
                Transform = Matrix.CreateTranslation(
                -target.pos.X - (target.h / 2),
                -target.pos.Y - (target.w / 2),
                0) *
                Matrix.CreateTranslation(
                    (Game1.ScreenHeight / 2),
                    Game1.ScreenWidth / 2 - 400,
                    0);
            }
        }
    }
}
