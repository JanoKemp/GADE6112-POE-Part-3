using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Hero:Character 
    {

        public Hero(int x, int y, int hP, int maxHP, TileType type, int damage): base(x, y, type)
        {
            this.x = x;
            this.y = y;
            this.hP = hP;
            this.maxHP = 20;
            this.damage = 2;
        }

        override public Movement ReturnMove(Movement move = 0)
        {
           
            return move;
        }

        override public string ToString()
        {
            return ToString();
        }
    }
}
