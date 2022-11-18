using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    class Hero : Character
    {
        char heroSym; // Used to get the symbol from Class and then Get it to the mainform


        public Hero(int x, int y, int hP, int maxHp, int damage, TileType type) : base(x, y, Tile.TileType.Hero, hP, maxHp, damage)
        {
            
               
            
            // heroSym = getSymbols(0); // "H" symbol
        }

        override public Movement ReturnMove(Movement move) // Returns if the attempted Movement is viable by checking the vision array
        {

            if (move == Movement.up && currentVision[0].GetType() == typeof(EmptyTile) || move == Movement.up && currentVision[0].getTileType() == Tile.TileType.Gold || move == Movement.up && currentVision[0].getTileType() == Tile.TileType.Weapon) // if Tile user is trying to go to is Empty then Move and accepted and carried out
            {
                setMovement(move);
                return Movement.up;

            }
            if (move == Movement.down && currentVision[1].GetType() == typeof(EmptyTile) || move == Movement.down && currentVision[1].getTileType() == Tile.TileType.Gold || move == Movement.down && currentVision[1].getTileType() == Tile.TileType.Weapon)
            {
                setMovement(move);
                return Movement.down;
            }
            if (move == Movement.left && currentVision[2].GetType() == typeof(EmptyTile) || move == Movement.left && currentVision[2].getTileType() == Tile.TileType.Gold || move == Movement.left && currentVision[2].getTileType() == Tile.TileType.Weapon)
            {
                setMovement(move);
                return Movement.left;
            }
            if (move == Movement.right && currentVision[3].GetType() == typeof(EmptyTile) || move == Movement.right && currentVision[3].getTileType() == Tile.TileType.Gold || move == Movement.right && currentVision[3].getTileType() == Tile.TileType.Weapon)
            {
                setMovement(move);
                return Movement.right;
            }
            else
            {
                setMovement(Movement.noMovement);
                return Movement.noMovement;
            }
        }

        public char getHeroSymbol() { return heroSym; }
        public void setWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }
        


        override public string ToString()
        {
            //String heroMessage = "Player stats:\n Hp: " + hp + "/" + maxHp + "\n Current Damage: " + damage + "\n [X:Y] --> [" + x + ":" + y + "]\nGold: " + goldPurse;
            String heroMessage = "Player stats:\n Hp: " + hp + "/" + maxHp + "\nCurrent Weapon: Bare Hands\nWeapon Range: 1\n Weapon Damage: " + damage + "\nGold: " + goldPurse + "\n X : Y \n[" + x + " : " + y + "]";
            if (weapon != null)
            {
                if (weapon.getWeaponType() == MeleeWeapon.Types.Dagger.ToString())
                {
                    heroMessage = "Player stats:\n Hp: " + hp + "/" + maxHp + "\nCurrent Weapon:" + weapon.getWeaponType().ToString() + "\nWeapon Range:" + weapon.getWeaponRange() + "\nWeapon Damage: " + weapon.getWeaponDamage() + "\nGold: " + goldPurse + "\n X : Y \n[" + x + " : " + y + "]";
                    return heroMessage;
                }
                if (weapon.getWeaponType() == MeleeWeapon.Types.LongSword.ToString())
                {
                    heroMessage = "Player stats:\n Hp: " + hp + "/" + maxHp + "\nCurrent Weapon:" + weapon.getWeaponType().ToString() + "\nWeapon Range:" + weapon.getWeaponRange() + "\nWeapon Damage: " + weapon.getWeaponDamage() + "\nGold: " + goldPurse + "\n X : Y \n[" + x + " : " + y + "]";
                    return heroMessage;
                }
                if (weapon.getWeaponType() == RangedWeapon.Types.Rifle.ToString())
                {
                    heroMessage = "Player stats:\n Hp: " + hp + "/" + maxHp + "\nCurrent Weapon:" + weapon.getWeaponType().ToString() + "\nWeapon Range:" + weapon.getWeaponRange() + "\nWeapon Damage: " + weapon.getWeaponDamage() + "\nGold: " + goldPurse + "\n X : Y \n[" + x + " : " + y + "]";
                    return heroMessage;
                }
                if (weapon.getWeaponType() == RangedWeapon.Types.LongBow.ToString())
                {
                    heroMessage = "Player stats:\n Hp: " + hp + "/" + maxHp + "\nCurrent Weapon:" + weapon.getWeaponType().ToString() + "\nWeapon Range:" + weapon.getWeaponRange() + "\nWeapon Damage: " + weapon.getWeaponDamage() + "\nGold: " + goldPurse + "\n X : Y \n[" + x + " : " + y + "]";
                    return heroMessage;
                }
                else return heroMessage;
            }
            else
                return heroMessage; // Outputs the heros information

        }

    }
}
