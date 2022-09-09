using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Tile
    {
        protected int x, y;
        protected char[] symbols = new char[6] { 'H', 'E', 'G', 'W', 'C', 'X' }; // Symbols to tell which character to put on the map
        
        public enum TileType
        {
            Hero ,
            Enemy,
            Gold, 
            Weapon,
            Clear,
            Barrier

        }
        public TileType type;

        public Tile()
        {
            this.x = 0;
            this.y = 0;
            this.type = TileType.Clear;
            

        }

        public Tile(int x, int y, TileType type)
        {
         
        }

        public int X { get { return x; } set { this.x = value; } }
        public int Y { get { return y; } set { this.y = value; } }
        public TileType Type { get { return type; } set { this.type = value; } }
    }
}
