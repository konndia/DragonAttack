using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonAttack.Engine
{
    class GameOver
    {
        static public bool isGameOver = false;
        static public void DrawGameOverScreen(Graphics g)
        {
            g.DrawString($"GAME OVER \n Time: { Convert.ToInt32(Time.GetMinutes())}:{Time.GetSeconds()}", new Font("Stencil", 25),
                new SolidBrush(Color.Red), Render.Resolution.X / 2 - 100, Render.Resolution.Y / 2 - 100);
        }
    }
}
