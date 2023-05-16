using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using DragonAttack.Engine;

namespace DragonAttack
{
    class Resources
    {
        static Dictionary<string, Image> frames = new Dictionary<string, Image>();
        static Dictionary<string, SoundPlayer> sounds = new Dictionary<string, SoundPlayer>();
        static public void InitializationResources()
        {
            frames = FileSystem.LoadFrames("Res.int");
            sounds = FileSystem.LoadSound("Sound.int");
        }
        static public Image GetFrame(string key) => frames[key];
        static public SoundPlayer GetSound(string key) => sounds[key];
    }
}
