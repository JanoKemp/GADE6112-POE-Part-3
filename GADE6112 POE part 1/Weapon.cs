using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Weapon : Item
    {
        protected int damage, range, durability, cost;
        protected string weaponType;

        public Weapon(int x , int y , Tile.TileType type) : base (x, y, Tile.TileType.Weapon) // Learn how to use optional params
        {
            this.x = x;
            this.y = y;
            
        }
     
        public int getWeaponDamage() { return damage; }
        public virtual int getWeaponRange() { return range; } // Set as virtual to be later overridden
        public int getWeaponDurability() { return durability; }
        public int getWeaponCost() { return cost; }
        public string getWeaponType() { return weaponType; }
    }
}
