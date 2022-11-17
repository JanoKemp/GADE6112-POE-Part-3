using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace GADE6112_POE_part_1
{



    internal class Map

    {

        private int width;
        private int height;
        private Tile[,] land = new Tile[,] { };  // Come back and maybe make it TextBoxes
        private Enemy[] enemy;
        Item[] items;

        Random randomGen = new Random();
        private Hero hero; // Hero object


        private int horizontal, vertical, enemyNum, enemyX, enemyY, enemyGen, heroX, heroY, weaponDrops;



        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int minEnemy, int maxEnemy, int numGoldDrops, int weaponDrops)
        {

            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            land = new Tile[vertical + 1, horizontal + 1]; //one less than the map border for playable map. For borders to be done.
            heroY = randomGen.Next(1, land.GetLength(1) - 1); // random X and Y generated
            heroX = randomGen.Next(1, land.GetLength(0) - 1);


            for (int x = 0; x < land.GetLength(0); x++)
            {
                for (int y = 0; y < land.GetLength(1); y++)
                {
                    land[x, y] = new EmptyTile(x, y);
                }
            }
            for (int borderTnB = 0; borderTnB < vertical; borderTnB++) //Border top and bottom
            {


                land[borderTnB, 0] = (Obstacle)Create(Tile.TileType.Barrier);

                land[borderTnB, horizontal] = (Obstacle)Create(Tile.TileType.Barrier);


            }
            for (int borderLnR = 0; borderLnR < horizontal + 1; borderLnR++) // Border Left and Right
            {


                land[0, borderLnR] = (Obstacle)Create(Tile.TileType.Barrier);
                land[vertical, borderLnR] = (Obstacle)Create(Tile.TileType.Barrier);



            }

            Create(Tile.TileType.Hero);


            //land[heroX,heroY].setTileType(Tile.TileType.Hero);
            enemy = new Enemy[enemyNum];

            for (int i = 0; i < enemy.Length; i++) //Loops through enemy to create() new enemies in the array
            {

                enemyGen = randomGen.Next(1, 4); // Randomly picks 1 or 2 and then creates that enemy type based on selection
                if (enemyGen == 1)
                {
                    enemy[i] = (SwampCreature)Create(Tile.TileType.Enemy);
                    // enemy[i].setCurrentVision(land);
                    land[enemy[i].getX(), enemy[i].getY()] = enemy[i];//(SwampCreature)Create(Tile.TileType.Enemy);
                    //land[enemy[i].getX(), enemy[i].getY()].setTileType(Tile.TileType.Enemy);

                }
                if (enemyGen == 2)
                {
                    enemy[i] = (Mage)Create(Tile.TileType.Enemy);
                    // enemy[i].setCurrentVision(land);
                    land[enemy[i].getX(), enemy[i].getY()] = enemy[i];//(Mage)Create(Tile.TileType.Enemy);
                    //land[enemy[i].getX(), enemy[i].getY()].setTileType(Tile.TileType.Enemy);
                }
                if (enemyGen == 3)
                {
                    enemy[i] = (Leader)Create(Tile.TileType.Enemy);
                    land[enemy[i].getX(), enemy[i].getY()] = enemy[i];
                }



                //   land[enemyX, enemyY] = (SwampCreature)Create(Tile.TileType.Enemy); // Creates an identical enemy at that tile location on the map 


            }

            items = new Item[numGoldDrops + weaponDrops]; // Creates an array the size of all item drops

           
           for (int j = 0; j < numGoldDrops ; j++) // THIS IS GOLD ISSUE 
            {
                items[j] = (Gold)Create(Tile.TileType.Gold);
                land[items[j].getX(),items[j].getY()] = items[j];
            }
            for (int i = numGoldDrops; i < items.Length;i++)
            {
                    items[i] = (Weapon)Create(Tile.TileType.Weapon);
                land[items[i].getX(), items[i].getY()] = items[i];
            }
           
           // items[0] = (Gold)Create(Tile.TileType.Gold);
           // items[1] = (Gold)Create(Tile.TileType.Gold);
           // items[2] = (Gold)Create(Tile.TileType.Gold);
           // items[3] = (Weapon)Create(Tile.TileType.Weapon);
           // items[4] = (Weapon)Create(Tile.TileType.Weapon);
            //items[5] = (Weapon)Create(Tile.TileType.Weapon);// Breaks Code in order to see Debug 


            UpdateVision();

        }
        #region Gets and setters
        internal Tile getLocation(int x, int y)
        {
            return land[x, y];
        }

        public void setWidth(int width)
        {
            this.width = width;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }
        public void setHorizontal(int horizontal)
        {
            this.horizontal = horizontal;
        }
        public void setVertical(int vertical)
        {
            this.vertical = vertical;
        }
        public void setEnemyNum(int enemyNum)
        {
            this.enemyNum = enemyNum;
        }
        public void setEnemyX(int enemyX)
        {
            this.enemyX = enemyX;
        }
        public void setEnemyY(int enemyY)
        {
            this.enemyY = enemyY;
        }
        public void setLand(Tile[,] land) // Come back and make textbox if issues
        {
            this.land = land;
        }
        public void setHero(Hero hero)
        {
            this.hero = hero;
        }





        public int getWidth() { return width; }
        public int getHeight() { return height; }
        public int getHorizontal() { return horizontal; }
        public int getVertical() { return vertical; }
        public int getEnemyNum() { return enemyNum; }
        public int getEnemyX() { return enemyX; }
        public Tile[,] getLand() { return land; } // Public get accessor for Land tile array 
        public int getEnemyY() { return enemyY; }
        public Enemy[] getEnemies() { return enemy; } // gets the enemy array from map constructor
        public Item[] getItems() { return items; }

        public Hero getHero() { return hero; }

        #endregion

        private Tile Create(Tile.TileType type)// Creates Objects for the map
        {
            int randWeapon = 0;
            enemyY = randomGen.Next(1, land.GetLength(1) - 1); // random X and Y generated
            enemyX = randomGen.Next(1, land.GetLength(0) - 1);
            for (int i = 0; i < 1; i++)
            {
                 randWeapon = randomGen.Next(0, 4);
            }
             

            while (land[enemyX, enemyY].getTileType() != Tile.TileType.Clear) // If X and Y already contain an Character or Border then generate a new X and Y until there is a new clean space
            {
                enemyX = randomGen.Next(1, land.GetLength(0) - 1);
                enemyY = randomGen.Next(1, land.GetLength(1) - 1);
            }


            if (type == Tile.TileType.Enemy && enemyGen == 1) //Creates an enemy when called
            {

                SwampCreature swampEn = new SwampCreature(enemyX, enemyY); // Creates a new Enemy at the X and Y
                swampEn.setTileType(Tile.TileType.Enemy);
                swampEn.setX(enemyX); // Sets new X and Y for Creature 
                swampEn.setY(enemyY);

                return swampEn;
            }
            if (type == Tile.TileType.Enemy && enemyGen == 2) // Creates Mage on the board
            {
                Mage mageEn = new Mage(enemyX, enemyY); // Generates a new mage enemy at the generated X and Y locations
                mageEn.setTileType(Tile.TileType.Enemy);
                mageEn.setX(enemyX); // sets those locations to ensure it is set
                mageEn.setY(enemyY);

                return mageEn; // returns to be created

            }
            if (type == Tile.TileType.Enemy && enemyGen == 3)
            {
                Leader leaderEn = new Leader(enemyX, enemyY);
                leaderEn.setTileType(Tile.TileType.Enemy);
                leaderEn.setLeaderTarget(hero);
                leaderEn.setX(enemyX);
                leaderEn.setY(enemyY);
                return leaderEn;
            }

            if (type == Tile.TileType.Gold)// Creates gold item
            {
                Gold gold = new Gold(enemyX, enemyY); // gives it an X and Y and in the contructor the ammount of gold is randomised 
                gold.setTileType(Tile.TileType.Gold);
                gold.setX(enemyX);
                gold.setY(enemyY);
                land[enemyX, enemyY] = gold;
                return gold;
            }
            if (type == Tile.TileType.Clear)
            {

                EmptyTile empty = new EmptyTile(enemyX, enemyY);
                empty.setTileType(Tile.TileType.Clear);
                return empty;

            }
            if (type == Tile.TileType.Barrier)// Creates a new border at that X and Y
            {

                Obstacle bush = new Obstacle(enemyX, enemyY); // X , Y and then Tile Enum type (eg Hero , Enemy , or Obstacle)
                bush.setTileType(Tile.TileType.Barrier);

                // Add Code to Create to create border
                return bush;

            }
            if (type == Tile.TileType.Hero) // Creates the Hero at the X and Y 
            {

                hero = new Hero(enemyX, enemyY, 100, 100, 5, Tile.TileType.Hero);

                land[hero.getX(), hero.getY()] = hero;

                return hero; // Filler , fill with code to create hero 
            }
            if (type == Tile.TileType.Weapon)
            {
                if (randWeapon == 0)
                {

                    Weapon dagger = new MeleeWeapon(MeleeWeapon.Types.Dagger, enemyX, enemyY);
                    dagger.setTileType(Tile.TileType.Weapon);
                    land[enemyX, enemyY] = dagger;
                    return dagger;
                }
                if (randWeapon == 1)
                {
                    Weapon longSword = new MeleeWeapon(MeleeWeapon.Types.LongSword, enemyX, enemyY);
                    longSword.setTileType(Tile.TileType.Weapon);
                    land[enemyX, enemyY] = longSword;
                    return longSword;
                }
                if (randWeapon == 2)
                {
                    Weapon rifle = new RangedWeapon(RangedWeapon.Types.Rifle, enemyX, enemyY);
                    rifle.setTileType(Tile.TileType.Weapon);
                    land[enemyX, enemyY] = rifle;
                    return rifle;
                }
                if (randWeapon == 3)
                {
                    Weapon longBow = new RangedWeapon(RangedWeapon.Types.LongBow, enemyX, enemyY);
                    longBow.setTileType(Tile.TileType.Weapon);
                    land[enemyX, enemyY] = longBow;
                    return longBow;
                }
                else return null;
            }
            else
                return null;


        }



        public void UpdateVision() // Hero or Swampcreature is added into the params to gift Visions values and Character.Move.Example is written in to recieve moves 
        { // 0 - up , 1 - down , 2 - left , 3 right -----==== INDEX LOCATION ASSOCIATION
            if (hero.getX() >= 1 && hero.getX() <= land.GetLength(0) - 1 && hero.getY() >= 1 && hero.getY() <= land.GetLength(1) - 1) // Check for issues at the end of the array
            {
                hero.currentVision[0] = land[hero.getX() - 1, hero.getY()];
                hero.currentVision[1] = land[hero.getX() + 1, hero.getY()];
                hero.currentVision[2] = land[hero.getX(), hero.getY() - 1];
                hero.currentVision[3] = land[hero.getX(), hero.getY() + 1];
                for (int i = 0; i < enemy.Length; i++)
                {
                    if (enemy[i] != null)
                    {
                        enemy[i].currentVision[0] = land[enemy[i].getX() - 1, enemy[i].getY()];
                        enemy[i].currentVision[1] = land[enemy[i].getX() + 1, enemy[i].getY()];
                        enemy[i].currentVision[2] = land[enemy[i].getX(), enemy[i].getY() - 1];
                        enemy[i].currentVision[3] = land[enemy[i].getX(), enemy[i].getY() + 1];
                    }

                }
            }



        }


        public Item GetItemAtPosition(int x, int y)
        {
            int checkX, checkY;
            for (int g = 0; g < items.GetLength(0); g++)
            {
                checkX = items[g].getX();
                checkY = items[g].getY();
                if (checkX == x && checkY == y)
                {
                    Item item = items[g];
                    return item; // if Gold does exist then it moves on
                }
                
            }
            return null;

        }




    }
}
