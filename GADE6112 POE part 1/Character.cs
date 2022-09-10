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

        public Character[,] currentVision;  // Vision Array - stores N S E W for vision meant to be used to validate the movement

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




        public virtual void Attack(Character target) //Used to attack enemies
        {
            Hero hero = new Hero();
            int targetHp, heroDamage;
            targetHp = target.getHP(); // gets target Hp 
            heroDamage = hero.getDamage();
            CheckRange(target);//Checks if target is in range for an attack
            if(CheckRange(target) == true)//when target is in range
            {
                targetHp = targetHp - heroDamage; // Enemy health - damage
                target.setHP(targetHp);
            }
        }
        public virtual bool CheckRange(Character target)//add target
        {
            if (DistanceTo(target) <= 2)// if distance to target is less than 2(max range) then returns true(is within range)
            {
                return true;
            }
            else
                return false;//any other range is unnacceptable and therefore not in range
        }
        private int DistanceTo(Character target)//Wants the number of tiles in between hero and target
        {
            Hero hero = new Hero();

            int targetX , targetY,distance;
            targetX = target.getX();
            targetY = target.getY();
            if (targetX > hero.getX() && targetY > hero.getY())
            {
                distance = (targetX + targetY) - (hero.getX() + hero.getX());
                return distance;
            }
            if (targetX < hero.getX() && targetY < hero.getY())
            {
                distance = (hero.getX() + hero.getY() - (targetX + targetY));
                return distance;
            }
            else
                distance = 0;
                    return distance;

                //Calculate distance to a certain grid
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
        
       

        public bool isDead()
        {
            Hero hero = new Hero();
            SwampCreature creature = new SwampCreature();
            int heroHp = hero.getHP();
            int enemyHp = creature.getHP();
            bool dead = false;
            if (heroHp <= 0 || enemyHp <= 0)
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



