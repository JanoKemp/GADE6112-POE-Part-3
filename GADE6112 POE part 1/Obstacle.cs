using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Obstacle : Tile
    {
        public Obstacle (int x , int y)
            {
            Tile type = new Tile(x, y, 6);
            }
    }
}
