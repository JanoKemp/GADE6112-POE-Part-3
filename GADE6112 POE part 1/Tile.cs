using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Tile
    {
        protected int x, y; // X is column , Y is row
        protected char[] symbols = new char[6] { 'H', 'E', 'G', 'W', 'C', 'X' }; // Symbols to tell which character to put on the map
        
        public enum TileType // Different Types of Tiles
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
            this.x = getX();
            this.y = getY();
            this.type = TileType.Clear;
            

        }

        
        // Gets and Sets 
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }

        public void setTileType(TileType type)
        {
            this.type = type;
        }
        
        public int getX() { return x; }
        public int getY() { return y; }
        public TileType getTileType() { return type; }
        public char getSymbols(int s) {  return symbols[s]; } 

      
    }
}
