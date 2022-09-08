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
        // Random creatureMove = new Random();

        public SwampCreature(int x , int y ) 
        {
            this.x = x;
            this.y = y;
            this.hP = 10;
            this.damage = 1;

        }
        override public Movement ReturnMove(Movement move = 0)
        {
           //creatureMove.Next(x,y); Random number generator that randomly moves the creature in a direction on its move
           // Add if statements to check if there is an obstacle and if there is regenerate the number to move in a valid position

            return move;
        }

    }
}
