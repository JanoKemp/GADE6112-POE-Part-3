using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class SwampCreature : Enemy
    {
         Random creatureMove = new Random();
        char enemySym; // Global variable to allow for the symbol to be gotten and returned to the main form
        public SwampCreature() // Basic constructor that sets up every enemy with and X, Y , hp of 10 , damage of 1 , symbol of "E" Stated in TIle class
        {
            this.x = getX();
            this.y = getY();
            this.hp = 10;
            this.damage = 1;
            enemySym = getSymbols(1);
            
            
        }
        public SwampCreature(int x , int y) // Allows for X and Y locations to set by programmer
        {
            this.x = getX();
            this.y=getY();
            this.hp = 10;
            this.damage = 1;
            enemySym = getSymbols(1);


        }
        public char getEnemySym() { return enemySym; } // Fetches enemy symbol to be used when outputting to the form
        override public Movement ReturnMove(Movement move = 0) // If movement is invalid then the movement is returned to its original
        {
            int moveDirection; // Local variable used for assigning random direction
            moveDirection = creatureMove.Next(4); // randomly generates a number which is then correlated with a direction.
            if (moveDirection == 0 && currentVision[x,y - 1].getTileType() == TileType.Clear ) // if random num is 0 then get tiles around Character and their respective Tiletypes. And if they are empty then move in the returned direction.
            {
                return Movement.up;
            }
            if(moveDirection == 1 && currentVision[x,y + 1].getTileType() == TileType.Clear )
            {
                return Movement.down;
            }
            if(moveDirection == 2 && currentVision[x - 1,y].getTileType() == TileType.Clear )
            {
                return Movement.left;
            }
            if(moveDirection == 3 && currentVision[x + 1,y].getTileType() == TileType.Clear )
            {
                return Movement.right;
            }
           else
                return Movement.noMovement;
        }

    }
}
