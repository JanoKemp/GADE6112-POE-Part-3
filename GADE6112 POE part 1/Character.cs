using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Character : Tile
    {
        protected int hp, maxHp, damage, goldPurse;

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

        public void setHP(int hp)
        {
            this.hp = hp;
        }
        public void setMaxHP(int maxHp)
        {
            this.maxHp = maxHp;
        }
        public void setDamage(int damage)
        {
            this.damage = damage;
        }
        public void setMovement(Movement direction)
        {
            this.direction = direction;
        }
        public void setGoldPurse(int goldPurse)
        {
            this.goldPurse = goldPurse;
        }
       /* public void setVision(Tile[] vision)
        {
            this.vision = vision;
        }
       */
        public int getHP() { return hp; }
        public int getMaxHP() { return maxHp; }
        public int getDamage() { return damage; }
       // public Tile[] getVision() { return vision; }
        public Movement getMovement() { return direction; }
        public int getGoldPurse() { return goldPurse; }



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

            int targetX , targetY,distance; // Local variables created for assigning Target X and Y values to be checked against distance
            targetX = target.getX();
            targetY = target.getY();
            if (targetX > hero.getX() && targetY > hero.getY()) // Ensures distance cannot be negative
            {
                distance = (targetX + targetY) - (hero.getX() + hero.getX()); // Adds X and Y of each object and then subtracts from the bigger X and Y. Gives a distance to be used , later for checking
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
                currentX = currentX - 1; 
            }
            if (direction == Movement.down)
            {
                currentX = currentX  + 1;
            }
            if(direction == Movement.left)
            {
                currentY = currentY - 1;
            }
            if (direction == Movement.right)
            {
                currentY = currentY + 1;
            }
            else
                direction = Movement.noMovement; // No movement , used for mage class as it never moves.
            
           
            //Modify to be able to move left right up or down for both the x and the y later use when buttons are added
        }
        public abstract Movement ReturnMove(Movement direction = 0);

        public abstract override string ToString();
        
       

        public bool isDead(Hero hero , Enemy enemy) // Checks the Heros Hp and Enemies Hp and returns a Bool value based on if statement.
        {
            int heroHp = hero.getHP();
            int enemyHp = enemy.getHP();
            bool dead = false;
            if (heroHp <= 0 || enemyHp <= 0)
            {
                dead = true;
                hero.setTileType(Tile.TileType.Clear);
            }
            else
            {
                dead = false;

            }
            return dead;
            
        }
        public void PickUp(Item item) // Check if is correct ( Question 3.2)
        {
            
            if (item.getTileType() == Tile.TileType.Gold)
            {
                Gold item2 = new Gold(x, y);
                int goldPickUp = item2.getGoldDrop();
                goldPurse = goldPurse + goldPickUp;
            }
        }
    }
}



