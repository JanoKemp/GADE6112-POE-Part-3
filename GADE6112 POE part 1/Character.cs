using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Character : Tile
    {
        protected int hp, maxHp, damage, goldPurse;
        protected Weapon weapon;

        public Tile[] currentVision; // Index locations | 0 - North , 1 - South , 2 - West , 3 - East |

        public enum Movement
        {
            noMovement,
            up,
            down,
            left,
            right,

        }
        public Movement direction;


        public Character(int x, int y, Tile.TileType type, int hp, int maxHp, int damage) : base(x, y, type)// Must get symbol from Tile Class
        {
            this.hp = hp;
            this.damage = damage;
            this.maxHp = maxHp;
            this.type = getTileType();
            this.currentVision = new Tile[4];

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
        public void setCurrentVision(Tile[] vision)
        {
            currentVision = vision;
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
        public Tile[] getCurrentVision() { return currentVision; } // gets the contents of the vision array
        public Weapon getWeapon() { return weapon; } // Fetches the characters current weapon

       
        public virtual bool CheckRange(Character target)//add target
        {
            if (DistanceTo(target) < 2)// if distance to target is less than 2(max range) then returns true(is within range)
            {
                return true;
            }
            else
                return false;//any other range is unnacceptable and therefore not in range
        }
        private int DistanceTo(Character target)//Wants the number of tiles in between hero and target
        {


            int targetX, targetY, distance; // Local variables created for assigning Target X and Y values to be checked against distance
            targetX = target.getX();
            targetY = target.getY();

            if (targetX > x && targetY > y) // Ensures distance cannot be negative
            {
                distance = (targetX + targetY) - (x + y); // Adds X and Y of each object and then subtracts from the bigger X and Y. Gives a distance to be used , later for checking
                return distance;
            }
            if (targetX < x && targetY < y)
            {
                distance = (x + y - (targetX + targetY));
                return distance;
            }
            else
                distance = 0;
            return distance;

            //Calculate distance to a certain grid
        }
        public virtual void Attack(Character target) //Used to attack enemies
        {
            target.hp -= damage;
            

        }
        public void Move(Movement direction, Character character) //Implementation of movement by changing X and Y values for each character
        {
            int currentX;
            int currentY;
            currentX = character.getX();
            currentY = character.getY();
            if (direction == Movement.up)
            {
                currentX = currentX - 1;
                character.setX(currentX);
            }
            if (direction == Movement.down)
            {
                currentX = currentX + 1;
                character.setX(currentX);
            }
            if (direction == Movement.left)
            {
                currentY = currentY - 1;
                character.setY(currentY);
            }
            if (direction == Movement.right)
            {
                currentY = currentY + 1;
                character.setY(currentY);
            }
            else
                direction = Movement.noMovement; // No movement , used for mage class as it never moves.


            //Modify to be able to move left right up or down for both the x and the y later use when buttons are added
        }


        public abstract Movement ReturnMove(Movement move = 0);
        



        public bool isDead() // Checks the Heros Hp and Enemies Hp and returns a Bool value based on if statement.
        {

            if (hp <= 0)
            {
                return true;
            }
            else return false;
        }
        public void PickUp(Item i) 
        {
            
            if (i.getTileType() == Tile.TileType.Gold)
            {
                Gold gold = (Gold)i;
                goldPurse = goldPurse + gold.getGoldDrop();
                /*
                item = new Gold(item.getX(),item.getY());
                Gold item2  = new Gold(item.getX(),item.getY());
                int goldPickUp = item2.getGoldDrop();
                goldPurse = goldPurse + goldPickUp;
                */
            }
            if(i.getTileType() == Tile.TileType.Weapon)
            {
                
                Equip((Weapon)i); // Casts the item to Weapon as the based on the tileType. Weapon is then set to Characters weapon
            }
            
           
        }
        private void Equip(Weapon W)
        {
            weapon = W;
        }
    }
}



