
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagueAdventure.Source.Engine
{
    public class Basic2d
    {
        public Vector2 pos, dims;
        public int x, y, w, h; 
        float scale;
        public Boolean flip;
        public Vector2 playerVelocity;
        float rot;
        public Rectangle rect;
        public Texture2D myModel;
        
        public Basic2d(string PATH,Vector2 POS, int X, int Y, int W, int H, float SCALE = 1f ,Boolean FLIP=false,float ROT = 1.57f)
        {
            x = X;
            y = Y;  
            w = W;
            h = H;
            scale = SCALE;
            pos = POS;
            flip = FLIP;
            rot = ROT;
            
            myModel = Globals.content.Load<Texture2D>(PATH);
            

        }
        public virtual void Update(GameTime gameTime)
        {
            rect = new Rectangle((int)pos.X, (int)pos.Y, w, h);
        }
        public virtual void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            if(myModel != null)
            {
                
                if (flip)
                {
                    Rectangle playerRect = new Rectangle(x, y, w, h);
                    Globals._spriteBatch.Draw(myModel,
                    pos,
                    playerRect,
                    Color.White,
                    rot,
                    new Vector2(0, 0),
                    scale,
                    SpriteEffects.FlipHorizontally,
                    0);
                }
                else
                {
                    Rectangle playerRect = new Rectangle(x, y, w, h);
                    Globals._spriteBatch.Draw(myModel,
                    pos,
                    playerRect,
                    Color.White,
                    rot,
                    new Vector2(0, 0),
                    scale,
                    SpriteEffects.None,
                    0);
                }
            }
            
        }
       
    }
}
