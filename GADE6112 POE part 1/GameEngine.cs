using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    
    internal class GameEngine 
    {
        private Map map;
        public GameEngine()
        {
            
           map = new Map(6,7,7,9,3,6); // Creates a map with overloaded constructor
            
            
         
        }
        public Map getMap() { return map; } // public get accessor for the private map variable
        public bool MovePlayer(Character.Movement direction, Hero hero)
        {
            
            map.getLocation(hero.getX(), hero.getY()).setTileType(Tile.TileType.Clear); // Gets the current location of the hero and sets the tile type to Clear
            bool movement = true; // Possibly add this somewhere else for it to be called (unknown)
            if (hero.ReturnMove(hero.getMovement()) == direction)
            {
                if (direction == Character.Movement.down)
                {
                    hero.setX(hero.getX() + 1); //Changes the Y position of the hero to one up from it current location

                }
                if (direction == Character.Movement.up)
                {
                    hero.setX(hero.getX() - 1);
                }
                if (direction == Character.Movement.left)
                {
                    hero.setY(hero.getY() - 1);
                }
                if (direction == Character.Movement.right)
                {
                    hero.setY(hero.getY() + 1);
                }
                if (direction == Character.Movement.noMovement)
                {
                    hero.setX(hero.getX());
                    hero.setY(hero.getY());
                    movement = false;
                }
            }
            map.getLocation(hero.getX(), hero.getY()).setTileType(Tile.TileType.Hero); // Gets the new position of the hero and sets its Tile type to Clear ( empty) 

            // map.setLand(map.getLand(map.getTileType(Tile.TileType.Hero))); -------> sets new hero location to tile type hero
            //This updates the move is the movement is valid via button presses
            return movement;
        }
    }
}
