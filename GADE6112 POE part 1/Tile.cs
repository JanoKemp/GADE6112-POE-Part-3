using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Tile
    {
        protected int x, y;
        public enum TileType
        {
            Hero = 1 ,
            Enemy = 2,
            Gold = 3, 
            Weapon =4
        }

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
    }
}
