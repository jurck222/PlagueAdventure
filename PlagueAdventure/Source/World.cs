using PlagueAdventure.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Android.OS;
using Debug = System.Diagnostics.Debug;


using Microsoft.Xna.Framework.Input.Touch;
using PlagueAdventure.NPC;
using PlagueAdventure.Controls;
using PlagueAdventure.player;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;



namespace PlagueAdventure.Source
{


    public class World
    {
        Vector2 offset;
        public bool drawKid = true;
        public bool drawBrd = true;
        public bool run = false;
        public Boolean flown = false;
        public Basic2d hero;
     
        public Basic2d lamp;
       
        public Basic2d tree;
        public Basic2d tree2;
        public Basic2d tree3;
        public Basic2d cloud;
        public Basic2d cloud2;
        public Basic2d cloud3;
        public Basic2d rock;
        public Basic2d rock2;
        public Basic2d rock3;
       
        
        
        public int c = 0;
        public Basic2d rat;
        public Basic2d bird;
        public SoundEffect hurt_i;
        public Basic2d dirt1;
        public Basic2d fin;
        public Basic2d dirt2;
        public Basic2d wall;
        public Basic2d kid;
        public List<Projectile> projectiles = new List<Projectile> ();
        public List<Enemy> enemies = new List<Enemy>();
        public List<Basic2d> tiles = new List<Basic2d>();
        Song level;
        Song main;

        public World()
        {


            hero = new Hero("Player", new Vector2((Game1.ScreenHeight / 2) - 256 / 2, ((Game1.ScreenWidth / 2) - 165 / 2)-300), 25, 256, 165, 219, 1f);
           
            Debug.WriteLine(hero.pos);
            fin = new Basic2d("finish", new Vector2(hero.pos.X - 230, hero.pos.Y), 0, 0, 100, 100, 1f, false, 1.57f);
            main = Globals.content.Load<Song>("menu");
            wall = new Basic2d("wall2", new Vector2(1080 + 80, -1000), 0, 0, 1080, 1080, 1f, false, 1.57f);
            bird = new Bird("bird", new Vector2(570, 1600), 0, 75, 40, 25, 2f);
            
            dirt1 = new Basic2d("tile2", new Vector2(hero.pos.X - 230, hero.pos.Y), 0, 0, 100, 100, 1f, false, 1.57f);
            
           
            
            rat = new Rat("rat_enemy", new Vector2(340, 1000), 25, 300, 200, 75, 2.5f, false);
            kid = new Civilian("kid", new Vector2(470, 3100), 0, 0, 100, 100, 3f);
            
            hurt_i = Globals.content.Load<SoundEffect>("rat-deth");
            
            Game1.camera = new Camera();
            lamp = new Basic2d("environment_objects", new Vector2(540, 1600), 250, 0, 125, 250, 1.5f, true);
            
            tree = new Basic2d("environment_objects", new Vector2(660, 4600), 125, 250, 125, 250,2f);
            rock = new Basic2d("environment_objects", new Vector2(275, 5100), 375, 63, 464-375, 135-63, 2f);
            rock = new Basic2d("environment_objects", new Vector2(275, 5100), 375, 63, 464 - 375, 135 - 63, 2f);
            rock2 = new Basic2d("environment_objects", new Vector2(275, 5600), 375, 63, 464 - 375, 135 - 63, 2f);
            rock3 = new Basic2d("environment_objects", new Vector2(275, 7100), 375, 63, 464 - 375, 135 - 63, 2f);
            cloud = new Basic2d("environment_objects", new Vector2(1000, 4000), 134, 53, 226 - 134, 134 - 53, 2f);
            cloud2 = new Basic2d("environment_objects", new Vector2(700, 5000), 134, 53, 226 - 134, 134 - 53, 3f);
            cloud3 = new Basic2d("environment_objects", new Vector2(1000, 6500), 134, 53, 226 - 134, 134 - 53, 2f);

            tree2 = new Basic2d("environment_objects", new Vector2(660, 6600), 125, 250, 125, 250, 2f);
            tree3 = new Basic2d("environment_objects", new Vector2(660, 7600), 125, 250, 125, 250, 2f);
            
            Globals.fly = false;
            Globals.kidRun = false;
            offset = new Vector2(0, 0);
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassEnemy= AddEnemy;
            for (int i = 0; i<7; i++)
            {
                rat = new Rat("rat_enemy", new Vector2(340, 1000+1000*i), 25, 300, 200, 75, 2.5f, false); ;
                GameGlobals.PassEnemy(rat);
            }
            GameGlobals.PassTile = AddTile;
            for(int i=0; i<100; i++)
            {
                if (i == 80 || i == 81)
                {
                    GameGlobals.PassTile(fin);
                }
                else
                {
                    GameGlobals.PassTile(dirt1);
                }
            }
            
           
            level = Globals.content.Load<Song>("lvl1");
            
                MediaPlayer.Play(level);
                MediaPlayer.IsRepeating = true;
            
           }
        
        public virtual void Update(GameTime gameTime)
        {
            
            
            hero.Update(gameTime);
            c = 0;
            
            Game1.camera.Follow(hero);
            
            
            kid.Update(gameTime);
           
            
             
            lamp.Update(gameTime);
            
            
            bird.Update(gameTime);
            if (Math.Abs(hero.pos.Y - bird.pos.Y) < 200 && flown ==false)
            {

                Debug.WriteLine("Im flying away");
                bird = new Bird("bird", new Vector2(570, 1600), 0, 18, 40, 32, 2f);
                Globals.fly = true;
                flown = true;
            }
            
            for (int x = 0; x < enemies.Count; x++)
            {
                if (Math.Abs(enemies[x].pos.Y - hero.pos.Y) < 1500)
                {
                    if (Math.Abs(enemies[x].pos.Y - hero.pos.Y) < 1500)
                    {
                        enemies[x].Update(gameTime);
                    }
                }
            }
                for (int i = 0; i < projectiles.Count;i++)
            {
                projectiles[i].Update(offset, null);
                for (int x = 0; x < enemies.Count; x++)
                {
                    
                    if (projectiles[i].pos.Y > enemies[x].pos.Y + 100 )
                    {
      
                        projectiles[i].done = true;
                        enemies.RemoveAt(x);
                        hurt_i.Play();
                        Globals.score++;
                        x--;
                        
                    }
                    
                }
                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;

                }

            }

            for(int i = 0; i < projectiles.Count; i++)
            {
                if (Math.Abs(projectiles[i].pos.Y - kid.pos.Y) < 20)
                {
                        Globals.kidRun = true;
                    
                }
            }
            if (Math.Abs(Globals.PlayerPos.Y - kid.pos.Y) > 5000)
            {
                drawKid = false;
                Globals.kidRun = false;
            }
            
            if (bird.pos.X > 1100)
            {
                drawBrd = false;
                Globals.fly = false;
                

            }
           
            if (hero.pos.Y > 8056)
            {
                
                Globals.menu = true;
                Globals.start = false;
                Globals.reset = true;
                MediaPlayer.Play(main);
                MediaPlayer.IsRepeating = true;
            }

            
        }
        public virtual void AddProjectile(Object INFO)
        {
            projectiles.Add((Projectile)INFO);
            
        }
        public virtual void AddTile(Object INFO)
        {
            tiles.Add((Basic2d)INFO);

        }
       
        public virtual void AddEnemy(Object INFO)
        {
            enemies.Add((Enemy)INFO);

        }
        public virtual void Draw(Vector2 OFFSET, GameTime gameTime)
        {
            
            if (Math.Abs(kid.pos.Y - hero.pos.Y) < 1500)
            {
                if (drawKid)
                {
                    c++;
                    kid.Draw(OFFSET, gameTime);
                }
            }
            if (Math.Abs(tree.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                tree.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(tree2.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                tree2.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(tree3.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                tree3.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(rock.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                rock.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(rock2.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                rock2.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(rock3.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                rock3.Draw(OFFSET, gameTime);
            }
            
            if (Math.Abs(cloud.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                cloud.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(cloud2.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                cloud2.Draw(OFFSET, gameTime);
            }
            if (Math.Abs(cloud3.pos.Y - hero.pos.Y) < 1500)
            {
                c++;
                cloud3.Draw(OFFSET, gameTime);
            }

            
            for (int i = 0; i < projectiles.Count; i++)
            {

                projectiles[i].Draw(offset,gameTime);
                c++;
            }
            for(int i = 0; i<enemies.Count; i++)
            {
                enemies[i].Draw(offset,gameTime);
                c++;
            }
            
            

            if (Math.Abs(lamp.pos.Y - hero.pos.Y) < 1500)
            {
                lamp.Draw(OFFSET, gameTime);
                c++;
            }
            
            for(int i =0; i < tiles.Count; i++)
            {
                tiles[i].pos = new Vector2(175, 100 * i);
                if (Math.Abs(tiles[i].pos.Y - hero.pos.Y) < 1500)
                {
                    tiles[i].Draw(offset, gameTime);
                    c++;
                }
            }
            
                    
            if (Math.Abs(bird.pos.Y - hero.pos.Y) < 1500)
            {
                if (drawBrd)
                {
                    bird.Draw(OFFSET, gameTime);
                    c++;
                }
            }
            if (Math.Abs(wall.pos.Y - hero.pos.Y) < 1500)
            {
                wall.Draw(OFFSET, gameTime);
                c++;
            }
            hero.Draw(OFFSET, gameTime);
            Globals.bigC = c;
            


        }
        
    }
}
