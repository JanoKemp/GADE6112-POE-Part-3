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
        Random randomGen = new Random();
        Hero hero = new Hero(); // Hero object
        private int horizontal, vertical, enemyNum, enemyX, enemyY;

   
        public Map(int minWidth , int maxWidth , int minHeight , int maxHeight , int minEnemy , int maxEnemy)
        {


            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            land = new Tile[vertical -1,horizontal -1]; //one less than the map border for playable map. For borders to be done.
            for(int x = 0; x < land.GetLength(0); x++)
            {
                for(int y = 0; y < land.GetLength(1); y++)
                {
                    land[x, y] = new SwampCreature();
                }
            }    
            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            Create(Tile.TileType.Hero);
            Enemy[] enemy = new Enemy[enemyNum];
            Console.WriteLine("dog");
            for (int i = 0; i < enemy.Length; i++) //Loops through enemy to create() new enemies in the array
            {
                Console.WriteLine("dog");
                enemy[i] = (SwampCreature)Create(Tile.TileType.Enemy);


             //   land[enemyX, enemyY] = (SwampCreature)Create(Tile.TileType.Enemy); // Creates an identical enemy at that tile location on the map 


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

            enemyY = randomGen.Next(horizontal -1); // random X and Y generated
            enemyX = randomGen.Next(vertical -1);

            while (land[enemyX, enemyY].getTileType() != Tile.TileType.Clear) // If X and Y already contain an Character or Border then generate a new X and Y until there is a new clean space
            {
                enemyX = randomGen.Next(horizontal - 1);
                enemyY = randomGen.Next(vertical - 1);
            }

         
            if (type == Tile.TileType.Enemy) //Creates an enemy when called
            {

                SwampCreature swampEn = new SwampCreature(); // Creates a new Enemy at the X and Y
                swampEn.setX(enemyX); // Sets new X and Y for Creature 
                swampEn.setY(enemyY);
                return swampEn;
            }
            if (type == Tile.TileType.Barrier)// Creates a new border at that X and Y
            {

                Obstacle bush = new Obstacle(0, 0, Tile.TileType.Barrier); // X , Y and then Tile Enum type (eg Hero , Enemy , or Obstacle)

                return bush;

            }
            if (type == Tile.TileType.Hero) // Creates the Hero at the X and Y 
            {
                Hero hero = new Hero();
                hero.setX(enemyX);
                hero.setY(enemyY);
                return hero; // Filler , fill with code to create hero 
            }
            else
                return null;


        }




    }
}
