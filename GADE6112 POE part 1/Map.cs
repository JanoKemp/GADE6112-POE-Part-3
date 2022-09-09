using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Map
    {
        private int width;
        private int height;
        private TextBox[,] land = new TextBox[9, 7];  
        private string[] enemy = new string[5]; //Come back and check if correct later
        Random randomGen = new Random();
        Hero Hero = new Hero(0,0,20,Tile.TileType.Hero); // Hero object 
        private int horizontal, vertical, enemyNum, enemyX , enemyY;

        public Map() // Calling Create() to be coded later to loop through and create hero and enemies on the map
        {
            

            int minWidth = 6; // playable tiles must be 4 + 2 for the borders
            int maxWidth = 7; // Max is 5 + 2 for the borders
            int minHeight = 7;//playable tiles must be 7
            int maxHeight = 9;
            int minEnemy = 3;
            int maxEnemy = 6;
            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            Tile[,] playableMap = new Tile[horizontal - 1, vertical - 1]; //one less than the map border for playable map. For borders to be done.
            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            Create(Tile.TileType.Hero);
            Enemy [] enemy = new Enemy [enemyNum];
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] =  (SwampCreature)Create(Tile.TileType.Enemy);
                playableMap[enemyX,enemyY] = (SwampCreature)Create(Tile.TileType.Enemy); // Creates an identical enemy at that tile location on the map 

            }
            UpdateVision();
            for (int i = 0; i < enemy.Length; i++)
            {
                UpdateVision();
            }
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
        /*public void setLand(TextBox [,] land)
       {
           this.land = land;
       }
       public void setEnemy(string [] enemy)
       {
           this.enemy = enemy;
       }
       */


        public int getWidth() { return width; }
        public int getHeight() { return height; }
        public int getHorizontal() { return horizontal; }
        public int getVertical() { return vertical; }
        public int getEnemyNum() { return enemyNum; }
        public int getEnemyX() { return enemyX; }
        public int getEnemyY() { return enemyY; }

       



        public void UpdateVision(/*Character vision*/) 
        {
            //int north = vision.X;

            //vision.Vision[0] =;
            // Vision [index]  - x -1 x + 1 y - 1 y + 1 - This will update the vision on all four sides of the character or enemy. Possibly make Vision a 2d array to store x and y
        }
        private Tile Create(Tile.TileType type)// Creates Objects for the map
        {
            if (land[horizontal, vertical] != null) //'Index was outside the bounds of the array.'

            {
                enemyX = randomGen.Next(1, horizontal);
                enemyY = randomGen.Next(1, vertical);
            }

            if (type == Tile.TileType.Enemy) //Creates an enemy when called
            {
                
                SwampCreature swampEn = new SwampCreature(enemyX, enemyY); // generates random location on map to spawn
                
                return swampEn;
            }
            if (type == Tile.TileType.Barrier)
            {
                
                Obstacle bush = new Obstacle(0, 0, Tile.TileType.Barrier); // X , Y and then Tile Enum type (eg Hero , Enemy , or Obstacle)
                
                return bush;
                
            }
            if (type == Tile.TileType.Hero)
            {
                Hero hero = new Hero(0 ,0 , 20,Tile.TileType.Hero);
                return hero; // Filler , fill with code to create hero 
            }
            else 
                return Create(type);
            
            
        }
            



    }
}
