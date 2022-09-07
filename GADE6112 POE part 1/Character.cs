using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Character : Tile
    {
        protected int hP, maxHP, damage;
        
        Tile[] vision = new Tile[4]; // Vision Array  - to be updated in Map class

        public enum Movement
        {
            noMovement,
            up,
            down,
            left,
            right,

        }
        public Movement direction;
        public Character()
        {

        }

        public Character(int x, int y, Tile.TileType type)
        {
            this.y = y;
            this.x = x;
            this.type = type;

        }

        public int HP { get { return hP; } set { this.hP = value; } }
        public int MaxHP { get { return maxHP; } set { this.maxHP = value; } }
        public int Damage { get { return damage; } set { this.damage = value; } }
        public Tile[] Vision { get { return vision; } set { this.vision = value; } }
        public Movement Direction { get { return direction; } set { this.direction = value; } }


        public virtual void Attack(Character target)
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
        public void Move(Movement direction, int x, int y)
        {
            
            x++;
            y++;//Modify to be able to move left right up or down for both the x and the y later use when buttons are added
        }
        public abstract Movement ReturnMove(Movement direction = 0);

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



