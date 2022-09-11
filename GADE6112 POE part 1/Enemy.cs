using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Enemy: Character
    {
        protected Random enemyRand = new Random(); 
        
        public Enemy()
        {
            this.x = getX();
            this.y = getY();
            this.hp = getHP();
            this.maxHp = getMaxHP();
            this.damage = getDamage();
        }

        public Enemy(int x , int y, int hP, int maxHP, int damage) // Needs to call its symbol
        {
           
        }
        
        
        public override string ToString()
        {
            String enemyInfo = "Enemy at [" + x + "," + y + "] (" + damage + ")";
            return enemyInfo;
        }
    }

}
