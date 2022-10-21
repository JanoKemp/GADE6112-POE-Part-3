using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Obstacle : Tile
    {
        char barrierSym;
        public Obstacle (int x, int y): base (x,y,TileType.Barrier)
            {
            barrierSym = getSymbols(5);
            }
        public char getBarrierSym() { return barrierSym; }
    }
   
}
