using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonAttack.Engine;
namespace DragonAttack.Game
{
    class Scene : IScene
    {
        Image backGround;
        int houseOffset = 100;
        int dragonAddTime = 10;
        int dragonTimer;
        int maxDragons = 3;
        public List<House> houses = new List<House>();
        public List<Dragon> dragons = new List<Dragon>();
        public List<FireBomb> bombs = new List<FireBomb>();
        public List<Effect> effects = new List<Effect>();
        public Scene()
        {
            
            Resources.InitializationResources();
            backGround = Resources.GetFrame("Back");
            for(int i = 0; i < Render.Resolution.X / houseOffset; i++)
                houses.Add(new House(25+i* houseOffset, 280,70,70));
            Sound.Play("Siren");
        }
        public void DrawBack(Graphics g, int x, int y) => g.DrawImage(backGround, 0, 0, x, y);
        public void DrawObjects(Graphics g)
        {            
            if((dragonTimer -= Time.deltaTime) <= 0 && dragons.Count < maxDragons)
            {
                dragonTimer = dragonAddTime*1000;
                dragons.Add(new Dragon(0, 70, 70, 40, 7, 2));
                bombs.Add(new FireBomb(40, 40, 7, 2, this));
            }                
            List<IGameObject> objects = new List<IGameObject>();
            objects.AddRange(dragons);
            objects.AddRange(houses);
            objects.AddRange(bombs);
            objects.AddRange(effects);
            foreach (var i in objects)
                i.Draw(g);
            CheckBreak();
        }
        public void UseEffect(Vector pos) => effects.Add(new Effect(pos, 60, 60, this));
        public void BreakBomb(int x, int y)
        {
            foreach (var i in bombs)
                if (i.Colision(x, y))
                    i.Break();
        }
        public void CheckBreak()
        {
                
            foreach(var bomb in bombs)
            {
                int breakCount = 0;
                foreach (var i in houses)
                {
                    if (i.IsBreak)
                    {
                        breakCount++;
                        continue;
                    }
                    if (i.Colision(bomb.Position.X + bomb.Size.X / 2, bomb.Position.Y + bomb.Size.Y / 2))
                    {
                        bomb.Break();
                        i.Break();
                    }

                }
                if (breakCount == houses.Count)
                    GameOver.isGameOver = true;
            }                
        }
    }
}
