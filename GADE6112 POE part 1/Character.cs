﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    internal abstract class Character
    {
        protected int hP, maxHP, damage;
        Tile[] vision = new Tile[4];

        public enum Movement
        {
            noMovement,
            up,
            down,
            left,
            right,

        }
    }
}
