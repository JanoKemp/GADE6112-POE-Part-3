using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class MeleeWeapon : Weapon // Inherits weapon attributes
    {
        public enum Types
        {
            dagger, longSword
        }
        public Types types;
        public MeleeWeapon(Types types, int x, int y) : base(x, y, Tile.TileType.Weapon)
        {
            this.types = types;
            this.y = y;
            this.x = x;
            if (types == Types.dagger)
            {
                weaponType = "Dagger";
                durability = 10;
                damage = 3;
                cost = 3;
            }
            if (types == Types.longSword)
            {
                weaponType = "LongSword";
                durability = 6;
                damage = 4;
                cost = 5;
            }
        }
        public override string ToString()
        {
            string meleeInfo;
            meleeInfo = "No information added";
            if (types == Types.dagger)
            {
                meleeInfo = "Weapon Type: Melee \n  Name: "+weaponType+"\n  Damage: " + damage + "\n Cost: " + cost;
                return meleeInfo;
            }
            if (types == Types.longSword)
            {
                meleeInfo = "Weapon Type: Melee \n  Name: "+weaponType+"\n  Damage: " + damage + "\n Cost: " + cost;
                return meleeInfo;
            }
            else return meleeInfo;
        }
        override public int getWeaponRange() { return 1; }
        

    }
}
