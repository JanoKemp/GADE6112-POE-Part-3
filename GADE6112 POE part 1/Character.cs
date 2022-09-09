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
            this.y = getY();
            this.x = getX();
            this.type = getTileType();
        }

        public Character(int x, int y, Tile.TileType type) // Must get symbol from Tile Class
        {
           

        }

        public void setHP(int hP)
        {
            this.hP = hP;
        }
        public void setMaxHP(int maxHP)
        {
            this.maxHP = maxHP;
        }
        public void setDamage(int damage)
        {
            this.damage = damage;
        }
        public void setMovement(Movement direction)
        {
            this.direction = direction;
        }
       /* public void setVision(Tile[] vision)
        {
            this.vision = vision;
        }
       */
        public int getHP() { return hP; }
        public int getMaxHP() { return maxHP; }
        public int getDamage() { return damage; }
       // public Tile[] getVision() { return vision; }
        public Movement getMovement() { return direction; }




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
        public void Move(Movement direction) //Implementation of movement by changing X and Y values for each character
        {
            int currentX;
            int currentY;
            currentX = getX();
            currentY = getY();
            if ( direction == Movement.up)
            {
                currentY = currentY + 1;
            }
            if (direction == Movement.down)
            {
                currentY = currentY -1;
            }
            if(direction == Movement.left)
            {
                currentX = currentX - 1;
            }
            if (direction==Movement.right)
            {
                currentX = currentX + 1;
            }
            //Modify to be able to move left right up or down for both the x and the y later use when buttons are added
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



