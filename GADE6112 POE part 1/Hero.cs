using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Hero:Character 
    {
        public Hero()
        {
            this.x = getX();
            this.y = getY();
            this.hP = getHP();
            this.maxHP = getHP();
            this.damage = 2;
        }

        public Hero(int x, int y, int hP, TileType type)
        {
            
        }

        override public Movement ReturnMove(Movement move = 0)
        {
           
            return move;
        }

        override public string ToString()
        {
            String heroMessage = "Player stats:\n Hp: " + hP + "/ Max: " + maxHP + "\n Damage: " + damage + "\n [X:Y] --> [" + x + ":" + y + "]";
            return ToString();
        }

    }
}
