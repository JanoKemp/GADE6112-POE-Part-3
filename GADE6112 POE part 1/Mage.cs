using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Mage: Enemy
    {
        public Mage(int x, int y)
        {
            this.x = getX();// gets X and Y
            this.y = getY();

            this.hp = 5;
            this.damage = 5;
        }

        public override Movement ReturnMove(Movement direction = Movement.noMovement)
        {
            return direction;
        }
    }
}
