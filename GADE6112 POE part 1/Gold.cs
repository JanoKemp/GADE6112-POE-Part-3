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

        public Gold()
        {
            x = getX();
            y = getY();
            Gold gold = new Gold(x, y); // Delegates to Item class // dont think thats possible ( higher class) 
        }
    }
}
