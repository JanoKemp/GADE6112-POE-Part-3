using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class EmptyTile : Tile
    {
        public EmptyTile(int x , int y,TileType type): base() // Used for creating Empty tiles across the Map
        {
            type = TileType.Clear;
        }
    }
}
