using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Obstacle : Tile
    {
        char barrierSym;
        public Obstacle (): base ()
            {
            barrierSym = getSymbols(5);
            }
        public char getBarrierSym() { return barrierSym; }
    }
   
}
