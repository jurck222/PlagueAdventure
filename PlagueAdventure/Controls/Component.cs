using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.Controls
{
    public abstract class Component
    {
        public abstract void Draw();
        public abstract void Update();

    }
}
