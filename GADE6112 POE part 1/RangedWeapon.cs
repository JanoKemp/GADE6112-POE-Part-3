﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class RangedWeapon : Weapon
    {
        public enum Types
        {
            rifle , longBow
        }
        public Types types;
        public RangedWeapon(Types types, int x, int y) : base(x, y, Tile.TileType.Weapon)
        {
            this.types = types;
            this.y = y;
            this.x = x;
            if (types == Types.rifle)
            {
                weaponType = "Rifle";
                durability = 3;
                damage = 5;
                range = 3;
                cost = 7;
            }
            if (types == Types.longBow)
            {
                weaponType = "LongBow";
                durability = 4;
                range = 2;
                damage = 4;
                cost = 6;
            }
        }
        public RangedWeapon(Types types, int x, int y , int durability) : base(x, y, Tile.TileType.Weapon) // ONLY USED WHEN LOADING FORM (CONTAINS DURABILITY AS WEAPONS MAY HAVE BEEN USED)
        {
            this.types = types;
            this.y = y;
            this.x = x;
            if (types == Types.rifle)
            {
                weaponType = "Rifle";
                this.durability = durability;
                damage = 5;
                range = 3;
                cost = 7;
            }
            if (types == Types.longBow)
            {
                weaponType = "LongBow";
                this.durability = durability;
                range = 2;
                damage = 4;
                cost = 6;
            }
        }
        public override string ToString()
        {
            string meleeInfo;
            meleeInfo = "No information added";
            if (types == Types.rifle)
            {
                meleeInfo = "Weapon Type: Ranged \n  Name: "+weaponType+" \n  Damage: " + damage + "\n Cost: " + cost;
                return meleeInfo;
            }
            if (types == Types.longBow)
            {
                meleeInfo = "Weapon Type: Ranged \n  Name: "+weaponType+" \n  Damage: " + damage + "\n Cost: " + cost;
                return meleeInfo;
            }
            else return meleeInfo;
        }
        override public int getWeaponRange() { return base.range; }

    }
}
