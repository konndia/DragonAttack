using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonAttack.Game
{
    class FireBomb : Transform, IGameObject
    {
        int speed;
        int speedOfset;
        int curSpeed;
        Scene scene;
        Random random = new Random();
        public FireBomb(int sx, int sy, int speed, int offsetSpeed, Scene scene)
        {
            this.scene = scene;
            SetSize(new Vector(sx, sy));
            this.speed = speed;
            this.speedOfset = offsetSpeed;
            NextDragon();
        }
        public void NextDragon()
        {
            curSpeed = speed + random.Next(-speedOfset, speedOfset);
            SetPosition(scene.dragons[random.Next(0, scene.dragons.Count)].Position);
        }
        public void Draw(Graphics g)
        {
            AddPosition(new Vector(0, curSpeed));
            g.DrawImage(Resources.GetFrame("Bomb"),
            Position.X, Position.Y, Size.X, Size.Y);
            if (Position.Y > Render.Resolution.Y)
                NextDragon();
        }
        public void Break()
        {
            scene.UseEffect(Position);
            NextDragon();            
        }
    }
}
