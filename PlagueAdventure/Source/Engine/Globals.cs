using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace PlagueAdventure.Source.Engine
{
    public delegate void PassObject(Object i);
    public delegate object PassObjectAndReturn(object i); 
    public class Globals
    {
        public static TouchCollection touchState;
        public static bool menu = true;
        public static bool start = false;
        public static bool settings = false;
        public static bool high = false;
        
        public static int vol = 20;
        public static ContentManager content;
        public static SpriteBatch _spriteBatch;
       
        public static int score = 0;
        public static int bigC = 0;
        
        public static int hero_health = 100;
        public static GameTime gameTime;
        public static bool fly = false;
        public static bool kidRun = false;
        public static Vector2 closestHouse;
        public static bool reset = false;
        public static Vector2 PlayerPos = Vector2.Zero; 
        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            
            return (float)Math.Sqrt(Math.Pow(pos.X-target.X,2) + Math.Pow(pos.Y-target.Y, 2));
        }
    }
}
