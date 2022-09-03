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
            Hero = 1,
            Enemy = 2,
            Gold = 3, 
            Weapon = 4 ,
            Clear = 5 ,
            Barrier = 6

        }
        public Tile()
        {
            this.x = 0;
            this.y = 0;
            TileType type = TileType.Hero;
        }
        public Tile(int x, int y, int TileType)
        {
          
        }
    }
}
