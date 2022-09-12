using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GADE6112_POE_part_1
{
    internal class Map// : Tile
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





        public Tile UpdateVision(Character vision, Character.Movement move)
        {
            switch (move)
            {
                case Character.Movement.up:

                    Tile up = land[vision.getX(), vision.getY() - 1];
                    up.setY(vision.getY() - 1);
                    up.setX(vision.getX());
                    return up;
                    

                case Character.Movement.down:

                    Tile down = land[vision.getX(), vision.getY() + 1];
                    down.setY(vision.getY() + 1);
                    down.setX(vision.getX());
                    return down;
                    
                case Character.Movement.left:

                    Tile left = land[vision.getX() - 1, vision.getY()];
                    left.setY(vision.getY());
                    left.setX(vision.getX() - 1);
                    return left;

                case Character.Movement.right:

                    Tile right = land[vision.getX() + 1, vision.getY()];
                    right.setY(vision.getY());
                    right.setX(vision.getX() - 1);
                    return right;
                    
                case Character.Movement.noMovement:

                    return vision;
                    
                    default:
                    return vision;
                   



            }


        }
        private Tile Create(Tile.TileType type  )// Creates Objects for the map
        {
            //Console.WriteLine(land);
            //Console.WriteLine("dog");
            enemyY = randomGen.Next(horizontal -1);
            enemyX = randomGen.Next(vertical -1);
            //Console.WriteLine(land);
            land[0,0] = new SwampCreature();
            while (land[0, 0].getTileType() != Tile.TileType.Clear) // Object reference not set to an instance of an object
            {
                enemyX = randomGen.Next(1, horizontal);
                enemyY = randomGen.Next(1, vertical);
            }

            //Add code to randomly generate a new location if the current generated block is not clear

            if (type == Tile.TileType.Enemy) //Creates an enemy when called
            {

                SwampCreature swampEn = new SwampCreature(); // generates random location on map to spawn
                swampEn.setX(enemyX);
                swampEn.setY(enemyY);
                return swampEn;
            }
            if (type == Tile.TileType.Barrier)
            {

                Obstacle bush = new Obstacle(0, 0, Tile.TileType.Barrier); // X , Y and then Tile Enum type (eg Hero , Enemy , or Obstacle)

                return bush;

            }
            if (type == Tile.TileType.Hero)
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
