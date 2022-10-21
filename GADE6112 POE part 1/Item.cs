using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    abstract internal class Item : Tile
    {
       
        public Item(int x, int y,TileType type) :base(x,y, type)
        {
            this.x = getX();// gets X and Y
            this.y = getY();
            
        }

        public abstract string ToString(); //Overidden ToString to output the type of Item 

    }
}
