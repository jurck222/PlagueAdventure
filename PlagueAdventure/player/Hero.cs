using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using PlagueAdventure.Source.Engine;
using PlagueAdventure.NPC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Util.Logging;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using PlagueAdventure.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace PlagueAdventure.player
{
    public class Hero : Unit
    {
        int flags;
        float speed;
        int Health;
        
        float jumpVelocity;
        public Vector2 healthPos = new Vector2(900, 150);
        public Vector2 scorePos = new Vector2(1000, 150);
        public Vector2 cPos = new Vector2(800, 150);
        bool hasJumped;
        
        public Basic2d down;
        
       
        public Basic2d reset;
        public Basic2d up;
        public Basic2d left;
        public Basic2d right;
        public Basic2d shoot;
        public Vector2 direction;
       
        public McTimer timer;
        public Vector2 jumpStart;
       
        bool peaked;
        private SpriteFont font;
        private SpriteFont health;
        private SpriteFont itemC;
        Song main;
        public Basic2d backBtn;
        public SoundEffect hurt;
        public SoundEffect die;
        public SoundEffect hurt_i;
        public Hero(string PATH, Vector2 POS, int X, int Y, int W, int H, float SCALE = 1, bool FLIP = false) : base(PATH, POS, X, Y, W, H, SCALE, FLIP)
        {
            speed = 7f;
            Health = 100;
            jumpVelocity = 5.0f;
            
            hasJumped = false;
            peaked = false;
            
            if (this.flip)
            {
                direction = new Vector2(this.pos.X + 70, this.pos.Y - 400);
            }
            else
            {
                direction = new Vector2(this.pos.X, this.pos.Y + 400);
            }
            font = Globals.content.Load<SpriteFont>("Score");
            itemC = Globals.content.Load<SpriteFont>("itemCounter");
            direction.Normalize();
            timer = new McTimer(4000);
            
            main = Globals.content.Load<Song>("menu");
            health = Globals.content.Load<SpriteFont>("Health");
            SoundEffect.MasterVolume = 1f;
            hurt_i = Globals.content.Load<SoundEffect>("arrow2");
            hurt = Globals.content.Load<SoundEffect>("man-hurt");
            die = Globals.content.Load<SoundEffect>("man-die");
            backBtn = new Button("back", new Vector2(1000, 2200 - 300), 0, 0, 100, 100);
            up = new Basic2d("Controls", new Vector2(250, 630-300), 0, 50, 50, 58, 2f);
            left = new Basic2d("Controls", new Vector2(200, 500-300), 0, 150, 50, 200, 2f);
            right = new Basic2d("Controls", new Vector2(200, 700-300), 0, 100, 50, 50, 2f);
            shoot = new Basic2d("Controls", new Vector2(250, 2200-300), 50, 0, 100, 50, 3f);
            reset = new Basic2d("reset", new Vector2(1000, 2400-300), 0, 0, 50, 50, 2f);
        }
        public override void Update(GameTime gameTime)
        {
            
            
            if (this.pos.X - jumpStart.X >= 250)
            {
                peaked = true;
            }
            if (hasJumped && this.pos.X - jumpStart.X <= 250 && !peaked)
            {
                this.pos.X += direction.X * jumpVelocity;
                up.pos.X += direction.X * jumpVelocity;
                left.pos.X += direction.X * jumpVelocity;
                right.pos.X += direction.X * jumpVelocity;
                reset.pos.X += direction.X * jumpVelocity;
                shoot.pos.X += direction.X * jumpVelocity;
                backBtn.pos.X += direction.X * jumpVelocity;
                healthPos.X += direction.X * jumpVelocity;
                scorePos.X += direction.X * jumpVelocity;
                cPos.X += direction.X * jumpVelocity;
                Globals.PlayerPos = this.pos;
            }
            else if (hasJumped && peaked)
            {
                this.pos.X -= direction.X * jumpVelocity;
                up.pos.X -= direction.X * jumpVelocity;
                left.pos.X -= direction.X * jumpVelocity;
                right.pos.X -= direction.X * jumpVelocity;
                reset.pos.X -= direction.X * jumpVelocity;
                shoot.pos.X -= direction.X * jumpVelocity;
                backBtn.pos.X -= direction.X * jumpVelocity;
                healthPos.X -= direction.X * jumpVelocity;
                scorePos.X -= direction.X * jumpVelocity;
                cPos.X -= direction.X * jumpVelocity;
                Globals.PlayerPos = this.pos;
                if (this.pos.X <= jumpStart.X)
                {
                    hasJumped = false;
                    peaked = false;
                }
            }
            Globals.touchState = TouchPanel.GetState();
            if (Globals.touchState.Count > 0)
            {
                if (Globals.touchState[0].State == TouchLocationState.Pressed)
                {
                    Debug.WriteLine(Globals.touchState[0].Position);
                    if (Globals.touchState[0].Position.X > 173 - 50 & Globals.touchState[0].Position.X < 173 + 50 & Globals.touchState[0].Position.Y > 1880 - 50 & Globals.touchState[0].Position.Y < 1880 + 50)
                        if (this.flip)
                        {
                            GameGlobals.PassProjectile(new Arrow("Player", new Vector2(this.pos.X + 70, this.pos.Y - 400), 200, 300, 490, 499, this, 1f, this.flip));


                            hurt_i.Play();
                        }
                        else
                        {
                            GameGlobals.PassProjectile(new Arrow("Player", new Vector2(this.pos.X + 70, this.pos.Y + 200), 200, 300, 490, 499, this, 1f, this.flip));
                            hurt_i.Play();
                        }
                    else if (Globals.touchState[0].Position.X > 901 & Globals.touchState[0].Position.X < 1007 & Globals.touchState[0].Position.Y > 1996 & Globals.touchState[0].Position.Y < 2096)
                    {
                        Globals.reset = true;
                    }
                    else if (Globals.touchState[0].Position.X > 901 & Globals.touchState[0].Position.X < 999 & Globals.touchState[0].Position.Y > 1800 & Globals.touchState[0].Position.Y < 1897 & Globals.start)
                    {
                        Globals.start = false;
                        Globals.menu = true;
                        Globals.reset = true;
                       
                            MediaPlayer.Play(main);
                            MediaPlayer.IsRepeating = true;
                            
                        
                    }


                }
                else if (Globals.touchState[0].State == TouchLocationState.Moved || Globals.touchState[0].State == TouchLocationState.Pressed)
                {
                    if (Globals.touchState[0].Position.X > 114 & Globals.touchState[0].Position.X < 193 & Globals.touchState[0].Position.Y > 112 & Globals.touchState[0].Position.Y < 196)
                    {
                        if (!this.flip)
                        {
                            this.flip = true;
                        }
                        
                            if (this.pos.Y - direction.Y * speed > 0)
                            {
                                this.pos.Y -= direction.Y * speed;
                                up.pos.Y -= direction.Y * speed;
                                left.pos.Y -= direction.Y * speed;
                                right.pos.Y -= direction.Y * speed;
                                reset.pos.Y -= direction.Y * speed;
                                shoot.pos.Y -= direction.Y * speed;
                                backBtn.pos.Y -= direction.Y * speed;
                                healthPos.Y -= direction.Y * speed;
                                scorePos.Y -= direction.Y * speed;
                                cPos.Y -= direction.Y * speed;
                                Globals.PlayerPos = this.pos;
                                
                            }
                        
                        
                    }
                    else if (Globals.touchState[0].Position.X > 122 & Globals.touchState[0].Position.X < 195 & Globals.touchState[0].Position.Y > 313 & Globals.touchState[0].Position.Y < 383)
                    {
                        if (this.flip)
                        {
                            this.flip = false;

                        }
                        
                            this.pos.Y += direction.Y * speed;
                            up.pos.Y += direction.Y * speed;
                            left.pos.Y += direction.Y * speed;
                            right.pos.Y += direction.Y * speed;
                            reset.pos.Y += direction.Y * speed;
                            shoot.pos.Y += direction.Y * speed;
                            backBtn.pos.Y += direction.Y * speed;
                            healthPos.Y += direction.Y * speed;
                            scorePos.Y += direction.Y * speed;
                            cPos.Y += direction.Y * speed;
                            Globals.PlayerPos = this.pos;
                            
                        }
                        
                    else if (Globals.touchState[0].Position.X > 169 & Globals.touchState[0].Position.X < 240 & Globals.touchState[0].Position.Y > 235 & Globals.touchState[0].Position.Y < 296 && hasJumped == false)
                    {
                        Debug.WriteLine("start jump");
                        
                        jumpStart = this.pos;
                        jumpVelocity = 15f;
                        hasJumped = true;
                    }
                    
                }
                else playerVelocity.Y = 0f;
            }
            if (Health != Globals.hero_health)
            {
                Health = Globals.hero_health;
                hurt.Play();
            }
            if (Health == 0)
            {
                die.Play();
            }
            reset.Update(gameTime);
            left.Update(gameTime);
            shoot.Update(gameTime);
            up.Update(gameTime);
            right.Update(gameTime);
            backBtn.Update(gameTime);
           
            base.Update(gameTime);
        }
        
        public override void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            up.Draw(OFFSET, gameTime);
            left.Draw(OFFSET, gameTime);
            right.Draw(OFFSET, gameTime);
            reset.Draw(OFFSET, gameTime); 
            shoot.Draw(OFFSET, gameTime);
            backBtn.Draw(OFFSET, gameTime);
            Globals._spriteBatch.DrawString(font, "Score:" + Globals.score, scorePos, Color.Black, 1.57f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            Globals._spriteBatch.DrawString(health, "Health:" + Globals.hero_health, healthPos, Color.Black, 1.57f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            Globals._spriteBatch.DrawString(itemC, ""+Globals.bigC, cPos, Color.Black, 1.57f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            base.Draw(OFFSET, gameTime);
        }
        
    }
}
