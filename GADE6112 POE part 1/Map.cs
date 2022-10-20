using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
        private Enemy [] enemy;
        Item[] items;  
        Random randomGen = new Random();
        Hero hero = new Hero(); // Hero object
        
        private int horizontal, vertical, enemyNum, enemyX, enemyY , enemyGen , heroX, heroY;


   
        public Map(int minWidth , int maxWidth , int minHeight , int maxHeight , int minEnemy , int maxEnemy, int numGoldDrops)
        {

            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            land = new Tile[vertical+1,horizontal+1]; //one less than the map border for playable map. For borders to be done.
            heroY = randomGen.Next(1,land.GetLength(1)- 1); // random X and Y generated
            heroX = randomGen.Next(1,land.GetLength(0) -1);
            
            for (int x = 0; x < land.GetLength(0) ; x++)
            {
                for(int y = 0; y < land.GetLength(1) ; y++)
                {
                    land[x, y] =  new EmptyTile();
                }
            }
            for (int borderTnB = 0; borderTnB < vertical; borderTnB++) //Border top and bottom
            {

                
                land[borderTnB, 0] = (Obstacle)Create(Tile.TileType.Barrier);

                land[borderTnB, horizontal ] = (Obstacle)Create(Tile.TileType.Barrier);
               
                
            }
            for (int borderLnR = 0; borderLnR < horizontal+ 1; borderLnR++) // Border Left and Right
            {

                
                land[0, borderLnR] = (Obstacle)Create(Tile.TileType.Barrier);
                land[vertical , borderLnR] = (Obstacle)Create(Tile.TileType.Barrier);
               


            }
            land[heroX,heroY] = Create(Tile.TileType.Hero);
            //land[heroX,heroY].setTileType(Tile.TileType.Hero);
             enemy = new Enemy[enemyNum];
               
            for (int i = 0; i < enemy.Length; i++) //Loops through enemy to create() new enemies in the array
            {
                
                enemyGen = randomGen.Next(1,3); // Randomly picks 1 or 2 and then creates that enemy type based on selection
                if (enemyGen == 1)
                {
                    enemy[i] = (SwampCreature)Create(Tile.TileType.Enemy);
                    land[enemy[i].getX(), enemy[i].getY()] = (SwampCreature)Create(Tile.TileType.Enemy);
                    //land[enemy[i].getX(), enemy[i].getY()].setTileType(Tile.TileType.Enemy);

                }
                if (enemyGen == 2)
                {
                    enemy[i] = (Mage)Create(Tile.TileType.Enemy);
                    land[enemy[i].getX(), enemy[i].getY()] = (Mage)Create(Tile.TileType.Enemy);
                    //land[enemy[i].getX(), enemy[i].getY()].setTileType(Tile.TileType.Enemy);
                }
               


                //   land[enemyX, enemyY] = (SwampCreature)Create(Tile.TileType.Enemy); // Creates an identical enemy at that tile location on the map 


            }

            items = new Gold[numGoldDrops];
            for(int c = 0; c < numGoldDrops; c++)
            {
                items[c] = (Gold)Create(Tile.TileType.Gold);
            }
            UpdateVision(hero, Character.Movement.noMovement);
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
        #endregion




        
        public Tile UpdateVision(Character vision, Character.Movement move) // Hero or Swampcreature is added into the params to gift Visions values and Character.Move.Example is written in to recieve moves 
        {
            switch (move) // Depending on the entered enum the following is carried out
            {
                case Character.Movement.up:
                    if (vision.getX() != 0) // Stops user from crashing Array from out of bounds
                    {
                        Tile up = land[vision.getX() - 1, vision.getY() ]; // A new tile is created above the Character 
                        up.setY(vision.getY()); // sets new Y location 
                        up.setX(vision.getX()-1); // sets new X position as one above
                        return up;
                    }
                    else
                    return vision;
                    

                case Character.Movement.down:

                    Tile down = land[vision.getX() + 1, vision.getY()];
                    down.setY(vision.getY());
                    down.setX(vision.getX() + 1);
                    return down;
                    
                case Character.Movement.left:
                    if (vision.getY() != 0)
                    {
                        Tile left = land[vision.getX(), vision.getY() - 1];
                        left.setY(vision.getY() - 1);
                        left.setX(vision.getX());
                        return left;
                    }
                    else
                    return vision;

                case Character.Movement.right:

                    Tile right = land[vision.getX(), vision.getY() + 1];
                    right.setY(vision.getY());
                    right.setX(vision.getX() +1);
                    return right;
                    
                case Character.Movement.noMovement:

                    return vision;
                    
                    default:
                    return vision;
                   



            }


        }
        private Tile Create(Tile.TileType type  )// Creates Objects for the map
        {

            enemyY = randomGen.Next(1,land.GetLength(1) - 1); // random X and Y generated
            enemyX = randomGen.Next(1,land.GetLength(0) -1);


            while (land[enemyX, enemyY].getTileType() != Tile.TileType.Clear) // If X and Y already contain an Character or Border then generate a new X and Y until there is a new clean space
            {
                enemyX = randomGen.Next(1,land.GetLength(0) -1);
                enemyY = randomGen.Next(1,land.GetLength(1) -1);
            }

         
            if (type == Tile.TileType.Enemy && enemyGen == 1) //Creates an enemy when called
            {
               
                SwampCreature swampEn = new SwampCreature(); // Creates a new Enemy at the X and Y
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
            if (type == Tile.TileType.Gold)// Creates gold item
            {
                Gold gold = new Gold(enemyX,enemyY); // gives it an X and Y and in the contructor the ammount of gold is randomised 
               gold.setTileType(Tile.TileType.Gold);
                gold.setX(enemyX);
                gold.setY(enemyY);
                land[enemyX, enemyY] = gold;
                return gold;
            }
            if (type == Tile.TileType.Clear)
            {

                EmptyTile empty = new EmptyTile();
                empty.setTileType(Tile.TileType.Clear);
                return empty;

            }
            if (type == Tile.TileType.Barrier)// Creates a new border at that X and Y
            {

                Obstacle bush = new Obstacle(); // X , Y and then Tile Enum type (eg Hero , Enemy , or Obstacle)
                bush.setTileType(Tile.TileType.Barrier);
                
                // Add Code to Create to create border
                return bush;

            }
            if (type == Tile.TileType.Hero) // Creates the Hero at the X and Y 
            {
                Hero hero = new Hero();
                hero.setTileType(Tile.TileType.Hero); 
                hero.setX(enemyX);
                hero.setY(enemyY);
                land[hero.getX(), hero.getY()] = hero;
                
                return hero; // Filler , fill with code to create hero 
            }
            else
                return null;


        }

        public Item GetItemAtPosition(int x, int y)
        {
            int checkX, checkY;
            for(int g = 0; g < items.GetLength(0); g++)
            {
              checkX = items[g].getX();
              checkY =  items[g].getY();
                if (checkX == x && checkY == y)
                {
                    return items[g]; // if Gold does exist then it moves on
                }
                else
                {
                    items[g] = null; // sets array location to null if X and Y dont add up
                    return items[g];
                }
            }
           return GetItemAtPosition((int)x, (int)y);
        }




    }
}
