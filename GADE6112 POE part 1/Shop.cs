using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Shop
    {
        Weapon[] weapons;
        
        Random randomNum = new Random();
        Character customer; // Who is buying and who to give gold to
        
        public Shop (Character customer)
        {
            this.customer = customer;
            weapons = new Weapon[3];
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }
        private Weapon RandomWeapon()
        {
            int randWeapon = randomNum.Next(0, 4);
            if (randWeapon == 0)
            {

                Weapon dagger = new MeleeWeapon(MeleeWeapon.Types.Dagger); //   IS FOR TESTING WILL BE ISSUES WITH ALL WEAPONS HAVING SAME ARRAY LOCATION
                return dagger;
            }
            if (randWeapon == 1)
            {
                Weapon longSword = new MeleeWeapon(MeleeWeapon.Types.LongSword);
                return longSword;
            }
            if(randWeapon == 2)
            {
                Weapon rifle = new RangedWeapon(RangedWeapon.Types.Rifle);
                return rifle;
            }
            if (randWeapon == 3)
            {
                Weapon longBow = new RangedWeapon(RangedWeapon.Types.LongBow);
                return longBow;
            }
            else return null;
        }
        public bool CanBuy(int num) //"num" is the item in the store they are selecting
        {
            int customerGold = customer.getGoldPurse();
            
            if (weapons[num].getWeaponType() == "Rifle")//Rifle -------> If the weapon at 'num' location in the weapon array is 'example' then check customers gold vs price - returns true or false;
            {
                if (customerGold >= 7) // Checks customers current gold vs price
                {
                    return true;
                }
                else return false;
            }
            if(weapons[num].getWeaponType() == "LongBow")//LongBow
            {
                if(customerGold >= 6)
                {
                    return true;
                }
                else return false;
            }
            if(weapons[num].getWeaponType() == "Dagger")//Dagger
            {
                if (customerGold >= 3)
                {
                    return true;
                }
                else return false;
            }
            if (weapons[num].getWeaponType() == "LongSword")//LongSword
            {
                if(customerGold >= 5)
                {
                    return true;
                }
                return false;
            }
            else return false;
        }
        public void Buy(int num)
        {
            int customerPurse = customer.getGoldPurse();
            if(CanBuy(num) == true) // Checks if they can buy that item - CanBuy returns true if they can
            {
                if(weapons[num].getWeaponType() == "Rifle") // Checks weapon type at that location
                {
                    customerPurse = customerPurse - 7; //Detracts gold from purse
                    customer.setGoldPurse(customerPurse);//Sets new gold purse ammount
                    customer.PickUp(weapons[num]); // Picks up weapon at the array location of 'num'
                    weapons[num] = RandomWeapon(); // Randomly Generates a new weapon at that location
                }
                if (weapons[num].getWeaponType() == "LongBow")
                {
                    customerPurse = customerPurse - 6;
                    customer.setGoldPurse(customerPurse);
                    customer.PickUp(weapons[num]);
                    weapons[num] = RandomWeapon();
                }
                if (weapons[num].getWeaponType() == "LongSword")
                {
                    customerPurse = customerPurse - 5;
                    customer.setGoldPurse(customerPurse);
                    customer.PickUp(weapons[num]);
                    weapons[num] = RandomWeapon();
                }
                if (weapons[num].getWeaponType() == "Dagger")
                {
                    customerPurse = customerPurse - 3;
                    customer.setGoldPurse(customerPurse);
                    customer.PickUp(weapons[num]);
                    weapons[num] = RandomWeapon();
                }

            }
        }
        public string DisplayWeapon(int num)
        {
            string shopOutput = "Buy " + weapons[num].getWeaponType() + "(" + weapons[num].getWeaponCost() + " Gold)";
            return shopOutput;
        }
    }
}
