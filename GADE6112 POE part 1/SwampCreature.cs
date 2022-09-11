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

        public SwampCreature() 
        {
            this.x = getX();
            this.y = getY();
            this.hp = 10;
            this.damage = 1;
            
        }
        public SwampCreature(int x , int y)
        {
            this.hp = 10;
            this.damage = 1;
            
            
        }
        override public Movement ReturnMove(Movement move = 0) // If movement is invalid then the movement is returned to its original
        {
            int moveDirection;
            moveDirection = creatureMove.Next(4);
            if (moveDirection == 0 && currentVision[x,y - 1].getTileType() == TileType.Clear )
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
           
                return Movement.noMovement;
        }

    }
}
