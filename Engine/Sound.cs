using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonAttack.Engine
{
    class Sound
    {
        static public void Play(string key) => Resources.GetSound(key).Play();
    }
}
