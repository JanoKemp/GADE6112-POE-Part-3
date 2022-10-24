using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
     class Hero:Character 
    {
        char heroSym; // Used to get the symbol from Class and then Get it to the mainform


        public Hero(int x, int y, int hP, int maxHp, int damage, TileType type) : base(x,y,Tile.TileType.Hero,hP,maxHp,damage)
        {
            
           // heroSym = getSymbols(0); // "H" symbol
        }

        override public Movement ReturnMove(Movement move) // Returns if the attempted Movement is viable by checking the vision array
        {
            
            if (move == Movement.up && currentVision[0].getTileType() == Tile.TileType.Clear || move == Movement.up && currentVision[0].getTileType() == Tile.TileType.Gold) // if Tile user is trying to go to is Empty then Move and accepted and carried out
            {
                setMovement(move);
                return Movement.up; 
                
            }
            if (move == Movement.down && currentVision[1].getTileType() == Tile.TileType.Clear || move == Movement.down &&  currentVision[1].getTileType() == Tile.TileType.Gold)
            {
                setMovement(move);
                return Movement.down;
            }
            if (move == Movement.left && currentVision[2].getTileType() == Tile.TileType.Clear || move == Movement.left && currentVision[2].getTileType() == Tile.TileType.Gold)
            {
                setMovement(move);
                return Movement.left;
            }
            if (move == Movement.right && currentVision[3].getTileType() == Tile.TileType.Clear || move == Movement.right && currentVision[3].getTileType() == Tile.TileType.Gold)
            {
                setMovement(move);
                return Movement.right;
            }
            else
            {
                setMovement(Movement.noMovement);
                return Movement.noMovement;
            }
        }
        
        public char getHeroSymbol() { return heroSym; }
        

        override public string ToString()
        {
            String heroMessage = "Player stats:\n Hp: " + hp + "/ Max: " + maxHp + "\n Damage: " + damage + "\n [X:Y] --> [" + x + ":" + y + "]\nGold: " + goldPurse;
            return heroMessage; // Outputs the heros information
        }

    }
}
