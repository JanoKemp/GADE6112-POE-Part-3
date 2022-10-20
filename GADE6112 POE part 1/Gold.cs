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
        char goldSymbol;
        public Gold()
        {
            x = getX();
            y = getY();
            goldSymbol = getSymbols(2);
            goldDrop = goldAm.Next(1, 6);
        }
        public Gold(int x , int y) :base(x,y)
        {
            this.x = getX();
            this.y = getY();
            goldSymbol = getSymbols(2);
            goldDrop = goldAm.Next(1,6); // Generates a number between 0-6 not including 0 or 6
        }

        public int getGoldDrop(){ return goldDrop; } // public get method for goldDrop amount
        public char getGoldSymbol(){ return goldSymbol; }

        override public string ToString()
        {
            string goldItem =  "Gold drop:"+goldDrop.ToString();
            return goldItem;
        }
    }
}
