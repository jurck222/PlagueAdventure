using Android.Media;
using Java.Time.Temporal;
using Microsoft.Xna.Framework;
using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.NPC
{
    public class Rat : Enemy
    {
        public Vector2 direction;
        float speed;
        public McTimer timer;
        public McTimer timer2;
        public bool done;
        public int power;
        public bool foundPlayer;
        
       

        public Rat(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, SCALE, FLIP)
        {
            
            speed = 2.0f;
            done = false;
            power = 15;
            foundPlayer = false;
            if (flip)
            {
                direction = new Vector2(pos.X + 70, pos.Y - 400);
            }
            else
            {
                direction = new Vector2(pos.X, pos.Y);
            }
            direction.Normalize();
            timer = new McTimer(2000);
            
        }
        public override void Update(GameTime gameTime)
        {
            //Debug.WriteLine(pos);
            
            if (foundPlayer && Math.Abs(Globals.PlayerPos.Y - pos.Y) > 160)
            {
                if (Globals.PlayerPos.Y - pos.Y < 0)
                {
                    if (flip)
                    {
                        flip = false;
                    }
                    pos.Y -= direction.Y * speed;
                }
                else
                {
                    if (!flip)
                    {
                        flip = true;
                    }
                    pos.Y += direction.Y * speed;
                }
            }
            else if (!foundPlayer)
            {
                if (flip)
                {
                    pos.Y += direction.Y * speed;
                }
                else
                {
                    pos.Y -= direction.Y * speed;
                }

                timer.UpdateTimer();
                if (timer.Test())
                {
                    flip = !flip;
                    timer = new McTimer(2000);
                }
                
            }
            if (Math.Abs(Globals.PlayerPos.Y - pos.Y) <= 500)
            {
                foundPlayer = true;
                speed = 3.0f;
                
                if (Math.Abs(Globals.PlayerPos.Y - pos.Y) < 160)
                {
                    timer.UpdateTimer();
                    if (timer.Test())
                    {
                        //Globals.attack.Play();
                        if (Globals.hero_health > 0)
                        {
                            Globals.hero_health -= 15;
                            timer2 = new McTimer(500);
                        }
                        else if(Globals.hero_health <= 0)
                        {
                            Globals.start = false;
                            Globals.menu = true;
                            Globals.reset = true;
                            
                        }
                        

                        timer = new McTimer(4000);
                    }
                    

                }

            }
            else
            {
                foundPlayer = false;
                speed = 2.0f;
            }

        }
        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            base.Draw(OFFSET, gameTime);
        }
    }
}
