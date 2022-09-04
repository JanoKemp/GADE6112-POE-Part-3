using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Map
    {
        static private int width;
        static private int height;
        private int [,] map = new int [width,height];
        private string[] enemy = new string[5]; //Come back and check if correct later
        Random randomGen = new Random();

        Map Hero = new Map();
        public Map()
        {
            int horizontal,vertical,enemyNum;

            int minWidth = 4; // playable tiles must be 4
            int maxWidth = 9;
            int minHeight = 7;//playable tiles must be 7
            int maxHeight = 9;
            int minEnemy = 3;
            int maxEnemy = 6;
            horizontal = randomGen.Next(minWidth, maxWidth);//TOADD IF ISSUES: +1 because random gens stop 1 number before max. Eg if range is 0-9 then it will only calc between 0-8
            vertical = randomGen.Next(minHeight, maxHeight);
            Tile[,] map = new Tile[horizontal - 1, vertical - 1]; //one less than the map border for playable map. For borders to be done.
            enemyNum = randomGen.Next(minEnemy, maxEnemy);
            
        } 



    }
}
