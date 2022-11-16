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
            move = (Movement)creatureMove.Next(5); // randomly generates a number which is then correlated with a direction.
            if (move == Movement.up && currentVision[0].GetType() == typeof(EmptyTile) || move == Movement.up && currentVision[0].getTileType() == Tile.TileType.Gold || move == Movement.up && currentVision[0].getTileType() == Tile.TileType.Weapon) // if Tile user is trying to go to is Empty then Move and accepted and carried out
            {
                setMovement(move);
                return Movement.up;

            }
            if (move == Movement.down && currentVision[1].GetType() == typeof(EmptyTile) || move == Movement.down && currentVision[1].getTileType() == Tile.TileType.Gold || move == Movement.down && currentVision[1].getTileType() == Tile.TileType.Weapon)
            {
               
                setMovement(move);
                return Movement.down;
            }
            if (move == Movement.left && currentVision[2].GetType() == typeof(EmptyTile) || move == Movement.left && currentVision[2].getTileType() == Tile.TileType.Gold || move == Movement.left && currentVision[2].getTileType() == Tile.TileType.Weapon)
            {
               
                setMovement(move);
                return Movement.left;
            }
            if (move == Movement.right && currentVision[3].GetType() == typeof(EmptyTile) || move == Movement.right && currentVision[3].getTileType() == Tile.TileType.Gold || move == Movement.right && currentVision[3].getTileType() == Tile.TileType.Weapon)
            {
                
                setMovement(move);
                return Movement.right;
            }
            else 
            {
               
                setMovement(move);
                return Movement.noMovement;
            }
        }

    }
}
