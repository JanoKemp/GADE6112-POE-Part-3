using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Shop
    {
        Weapon[] weapons;     
        Random randomNum = new Random();
        Character customer; // Who is buying and who to give gold to
        
        public Shop ( Character customer)
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

                Weapon dagger = new MeleeWeapon(MeleeWeapon.Types.dagger, 1, 1); // 1 , 1  IS FOR TESTING WILL BE ISSUES WITH ALL WEAPONS HAVING SAME ARRAY LOCATION
                return dagger;
            }
            if (randWeapon == 1)
            {
                Weapon longSword = new MeleeWeapon(MeleeWeapon.Types.longSword,1,1);
                return longSword;
            }
            if(randWeapon == 2)
            {
                Weapon rifle = new RangedWeapon(RangedWeapon.Types.rifle, 1, 1);
                return rifle;
            }
            if (randWeapon == 3)
            {
                Weapon longBow = new RangedWeapon(RangedWeapon.Types.longBow, 1, 1);
                return longBow;
            }
            else return null;
        }
        public bool CanBuy(int num)
        {
            
        }
    }
}
