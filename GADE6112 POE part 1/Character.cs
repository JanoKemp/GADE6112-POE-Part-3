﻿using System;
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
        public virtual bool CheckRange()//add target
        {
            //DistanceTo()
            return CheckRange();//Checks range to target ( COME BACK AND ADD)
        }
        private int DistanceTo()//add target
        {
            return DistanceTo();//Calculate distance to a certain grid
        }
        public void Move(Movement move, int x , int y)
        {
            x++;
            y++;//Modify to be able to move left right up or down for both the x and the y later use when buttons are added
        }
        public abstract Movement ReturnMove(Movement move = 0);

        public abstract override string ToString();

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


