using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GADE6112_POE_part_1
{
    internal class Map : Tile
    {
        private int width;
        private int height;
        private Tile[,] land = new Tile[,] { };  // Come back and maybe make it TextBoxes
        Random randomGen = new Random();
        Hero Hero = new Hero(); // Hero object 
        private int horizontal, vertical, enemyNum, enemyX, enemyY;

        public Map() 
        {


            int minWidth = 6; // playable tiles must be 4 + 2 for the borders
            int maxWidth = 7; // Max is 5 + 2 for the borders
            int minHeight = 7;//playable tiles must be 7
            int maxHeight = 9;
            int minEnemy = 3;
            int maxEnemy = 6;
            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            land = new Tile[horizontal - 1, vertical - 1]; //one less than the map border for playable map. For borders to be done.
            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            Create(Tile.TileType.Hero);
            Enemy[] enemy = new Enemy[enemyNum];
            for (int i = 0; i < enemy.Length; i++) //Loops through enemy to create() new enemies in the array
            {

                enemy[i] = (SwampCreature)Create(Tile.TileType.Enemy);
                land[enemyX, enemyY] = (SwampCreature)Create(Tile.TileType.Enemy); // Creates an identical enemy at that tile location on the map 
                

            }
            UpdateVision();
            
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

       



        public void UpdateVision() 
        {
            Hero character = new Hero(); ; // Has the attributes of the Characters class
            Map up = new Map(); // Has the attributes of the Tile class , therefore it stores the X and Y at those locations.
            Map down = new Map();
            Map left = new Map();
            Map right = new Map();

            up.setX(character.getX());//Updates vision for Hero tiles
            up.setY(character.getY() - 1); // Y changes as its 1 above
            down.setX(character.getX());
            down.setY(character.getY() + 1);
            right.setX(character.getX() + 1);
            right.setY(character.getY());
            left.setX(character.getX() -1 );
            left.setY(character.getY());

            SwampCreature creature = new SwampCreature();

            up.setX(creature.getX());//Updates vision for enemy tiles
            up.setY(creature.getY() - 1); // Y changes as its 1 above
            down.setX(creature.getX());
            down.setY(creature.getY() + 1);
            right.setX(creature.getX() + 1);
            right.setY(creature.getY());
            left.setX(creature.getX() - 1);
            left.setY(creature.getY());

        }
        private Tile Create(Tile.TileType type)// Creates Objects for the map
        {



            enemyX = randomGen.Next(horizontal) ;
                enemyY = randomGen.Next(vertical);
            if (land[enemyX,enemyY].getTileType() != TileType.Clear)
            {
                enemyX = randomGen.Next(1,horizontal);
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
