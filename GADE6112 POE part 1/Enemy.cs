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

        public Enemy(int hP, int maxHP, int damage)
        {

        }
    }
}
