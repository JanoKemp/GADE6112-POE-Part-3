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

        public TileType type;

        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
           
        }
       
        public Tile()
        {
            this.x = 0;
            this.y = 0;
            
        }

        public Tile(int x, int y, TileType type)
        {
            this.y = y;
            this.x = x;
            this.type = type;   
        }

        public int X { get { return x; } set { this.x = value; } }
        public int Y { get { return y; } set { this.y = value; } }
        public TileType Type { get { return type; } set { this.type = value; } }
        
        

    }
}
