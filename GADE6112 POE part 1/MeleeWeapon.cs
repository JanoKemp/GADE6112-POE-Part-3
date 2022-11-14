using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GADE6112_POE_part_1
{
    internal class MeleeWeapon : Weapon // Inherits weapon attributes
    {
        public enum Types
        {
            Dagger, LongSword
        }
        public Types types;
        public MeleeWeapon(Types types, [Optional] int x, [Optional] int y) : base(x, y, Tile.TileType.Weapon)
        {
            this.types = types;
            this.y = y;
            this.x = x;
            if (types == Types.Dagger)
            {
                weaponType = "Dagger";
                durability = 10;
                damage = 3;
                cost = 3;
            }
            if (types == Types.LongSword)
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
            if (types == Types.Dagger)
            {
                meleeInfo = "Weapon Type: Melee \n  Name: "+weaponType+"\n  Damage: " + damage + "\n Cost: " + cost;
                return meleeInfo;
            }
            if (types == Types.LongSword)
            {
                meleeInfo = "Weapon Type: Melee \n  Name: "+weaponType+"\n  Damage: " + damage + "\n Cost: " + cost;
                return meleeInfo;
            }
            else return meleeInfo;
        }
        override public int getWeaponRange() { return 1; }
        

    }
}
