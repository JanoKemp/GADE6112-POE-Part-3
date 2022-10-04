using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal class Gold : Item
    {
        private int goldDrop; // Private member variable Q2.2 ?
        private Random goldAm = new Random();

        public Gold(int x , int y)
        {
            this.x = getX();
            this.y = getY();
            Gold gold = new Gold(x, y);
            goldDrop = goldAm.Next(1,6); // Generates a number between 0-6 not including 0 or 6
        }

        public int getGoldDrop() { return goldDrop; } // public get method for goldDrop amount

        override public string ToString()
        {
            string goldItem =  "Gold drop:"+goldDrop.ToString();
            return goldItem;
        }
    }
}
