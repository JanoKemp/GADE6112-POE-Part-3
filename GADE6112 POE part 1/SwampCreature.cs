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
        
        public SwampCreature(int x , int y) :base (x,y,10,10,1,TileType.Enemy) // Allows for X and Y locations to set by programmer
        {

            //enemySym = getSymbols(1);
            weapon = new MeleeWeapon(MeleeWeapon.Types.Dagger);

        }
        public char getEnemySym() { return enemySym; } // Fetches enemy symbol to be used when outputting to the form
        override public Movement ReturnMove(Movement move) // If movement is invalid then the movement is returned to its original
        {
            int moveDirection; // Local variable used for assigning random direction
            moveDirection = creatureMove.Next(5); // randomly generates a number which is then correlated with a direction.
            if (moveDirection == 0 && currentVision[0].getTileType() == Tile.TileType.Clear || moveDirection == 0 && currentVision[0].getTileType() == Tile.TileType.Gold) // if random num is 0 then get tiles around Character and their respective Tiletypes. And if they are empty then move in the returned direction.
            {
                setMovement(Movement.up);
                return Movement.up;

            }
            if (moveDirection == 1 && currentVision[1].getTileType() == Tile.TileType.Clear || moveDirection == 1 && currentVision[1].getTileType() == Tile.TileType.Gold)
            {
                setMovement(Movement.down);
                return Movement.down;
            }
            if (moveDirection == 2 && currentVision[2].getTileType() == Tile.TileType.Clear || moveDirection == 2 && currentVision[2].getTileType() == Tile.TileType.Gold)
            {
                setMovement(Movement.left);
                return Movement.left;
            }
            if  (moveDirection == 3 && currentVision[3].getTileType() == Tile.TileType.Clear || moveDirection == 3 && currentVision[3].getTileType() == Tile.TileType.Gold)
                {
                setMovement(Movement.right);
                return Movement.right;
            }
            else 
            {
                setMovement(Movement.noMovement);
                return Movement.noMovement;
            }
        }

    }
}
