using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Mage: Enemy
    {
        char mageSym;
        public Mage()
        {

        }
        public Mage(int x, int y)
        {
            this.x = getX();// gets X and Y
            this.y = getY();
            this.mageSym = getSymbols(4); 
            this.hp = 5;
            this.damage = 5;
            
        }

        public override Movement ReturnMove(Movement direction = 0)
        {

            return Movement.noMovement;
        }
        public char getMageSym() { return mageSym; }
        public override bool CheckRange(Character target)
        {
            int targetX, targetY;
            targetX = target.getX();
            targetY = target.getY();
            Mage mage = new Mage(x, y);
            if (targetX == mage.x + 1 || targetX == mage.x - 1 || targetY == mage.y - 1 || targetY == mage.y + 1) // Checks if enemy is within the 1 block up, down,left,right
            {
                return true;
            }
            //Checks the four diagonal blocks , top right , left , bottom left, right
            if (targetX == mage.x +1 && targetY == mage.y +1 || targetX == mage.x + 1 && targetY == mage.y -1 || targetX == mage.x -1 && targetY == mage.y -1 || targetX == mage.x-1 && targetY == mage.y+1)
            {
                return true;
            }

            else return false;
            
        }
    }
}
