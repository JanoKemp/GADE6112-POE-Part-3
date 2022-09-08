using System;
using System.Collections.Generic;
using System.Linq;
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
        Hero Hero = new Hero(0,0,20,30,Tile.TileType.Hero,2); // Hero object 

        
        public Map() // Calling Create() to be coded later to loop through and create hero and enemies on the map
        {
            int horizontal,vertical,enemyNum;

            int minWidth = 6; // playable tiles must be 4 + 2 for the borders
            int maxWidth = 7; // Max is 5 + 2 for the borders
            int minHeight = 7;//playable tiles must be 7
            int maxHeight = 9;
            int minEnemy = 3;
            int maxEnemy = 6;
            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            Tile[,] tile = new Tile[horizontal - 1, vertical - 1]; //one less than the map border for playable map. For borders to be done.
            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            //Create();
            Character [] enemy = new Character [enemyNum];
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] =  (Character)Create(Tile.TileType.Enemy); 
            }
            //UpdateVision();
            for (int i = 0; i < enemy.Length; i++)
            {
                UpdateVision();
            }
        }

        public int Width { get { return width; } set { this.width = value; } }
        public int Height { get { return height; } set { this.height = value; } }
        public TextBox[,] Land { get { return land; } set { this.land = value; } }
        public string [] Enemy { get { return enemy; } set { this.enemy = value; } }



        public void UpdateVision() 
        {
            // Vision [index]  - x -1 x + 1 y - 1 y + 1 - This will update the vision on all four sides of the character or enemy. Possibly make Vision a 2d array to store x and y
        }
        private Tile Create(Tile.TileType type)// Meant to create obstacles on the map using an array
        {

            Obstacle bush = new Obstacle(1, 1, Tile.TileType.Barrier); // X , Y and then Tile Enum type (eg Hero , Enemy , or Obstacle)
            land[0, 1].Text = "x"; 
            return bush;
        }
            



    }
}
