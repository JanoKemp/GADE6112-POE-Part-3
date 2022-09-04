using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Character
    {
        protected int hP, maxHP, damage;
        Tile[] vision = new Tile[4];

        public enum Movement
        {
            noMovement,
            up,
            down,
            left,
            right,

        }
        public Character(int x, int y, Tile.TileType type)
        {

        }

        public virtual void Attack()
        {

        }
        public bool isDead(int hp)
        {
            bool dead = false;
            if (hp <= 0)
            {
                dead = true;
            }
            else
            {
                dead = false;
            }
            return dead;
            
        }
    }
}



