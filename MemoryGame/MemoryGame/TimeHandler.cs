using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class TimeHandler
    {
        private static int timeToLearnTiles = 10;
        private static int timeToDisplayPair = 2;
        public static int TimeToLearnTiles { get => timeToLearnTiles; set => timeToLearnTiles = value; }
        public static int TimeToDisplayPair { get => timeToDisplayPair; set => timeToDisplayPair = value; }
    }
}
