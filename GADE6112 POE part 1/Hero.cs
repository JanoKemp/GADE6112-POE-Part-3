using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Hero:Character 
    {
        char heroSym; // Used to get the symbol from Class and then Get it to the mainform
        
       /* public Hero()
        {
            // Sets heros values
            this.x = getX();
            this.y = getY();
            this.hp = 10;
            this.maxHp = getHP();
            this.damage = 2;
            heroSym = getSymbols(0); // "H" symbol
            
        }
       */

        public Hero(int x, int y, int hp, int maxHp , int damage) : base(x,y,Tile.TileType.Hero,hp,maxHp,damage)
        {
            
            heroSym = getSymbols(0); // "H" symbol
        }

        override public Movement ReturnMove(Movement move = 0) // If tile is not empty automatically returns user to previous location
        {
            
            if (move == Movement.up && north.getTileType() == Tile.TileType.Clear) // if Tile user is trying to go to is Empty then Move and accepted and carried out
            {
                return Movement.up;
            }
            if (move == Movement.down && south.getTileType() == Tile.TileType.Clear)
            {
                return Movement.down;
            }
            if (move == Movement.left && west.getTileType() == Tile.TileType.Clear)
            {
                return Movement.left;
            }
            if(move == Movement.right && east.getTileType() ==  Tile.TileType.Clear)
            {
                return Movement.right;
            }
            else 
            return Movement.noMovement;
        }
        
        public char getHeroSymbol() { return heroSym; }
        

        override public string ToString()
        {
            String heroMessage = "Player stats:\n Hp: " + hp + "/ Max: " + maxHp + "\n Damage: " + damage + "\n [X:Y] --> [" + x + ":" + y + "]\nGold: " + goldPurse;
            return heroMessage; // Outputs the heros information
        }

    }
}
