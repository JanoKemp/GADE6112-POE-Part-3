using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Enemy: Character
    {
        protected Random rnd = new Random();  

        public Enemy(int x , int y, int hP, int maxHP, int damage) // Needs to call its symbol
        {
            this.x = x;
            this.y = y;
            this.hP = hP;
            this.maxHP = maxHP;
            this.damage = damage;
        }
        public override string ToString()
        {
            String enemyInfo = "Enemy at [" + x + "," + y + "] (" + damage + ")";
            return enemyInfo;
        }
    }

}
