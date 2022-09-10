using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{
    
    internal class GameEngine 
    {
        private Map map = new Map();
        public GameEngine()
        {
         
         
        }
        public Map getMap() { return map; } // public get accessor for the private map variable
        public bool MovePlayer(Character.Movement direction, Hero hero)
        {
            Tile [,] currentTile = new Tile[hero.getX(), hero.getY()];
            currentTile[hero.getX(), hero.getY()].setTileType(Tile.TileType.Clear);
            map.setLand(currentTile);
            bool movement = true; // Possibly add this somewhere else for it to be called (unknown)
            if (hero.ReturnMove(hero.getMovement()) == direction)
            {
                if (direction == Character.Movement.down)
                {
                    hero.setY(hero.getY() - 1);
                    
                    
                }
                if (direction == Character.Movement.up)
                {
                    hero.setY(hero.getY() + 1);
                }
                if (direction == Character.Movement.left)
                {
                    hero.setX(hero.getX() - 1);
                }
                if (direction == Character.Movement.right)
                {
                    hero.setX(hero.getX() + 1);
                }
                if (direction == Character.Movement.noMovement)
                {
                    hero.setX(hero.getX());
                    hero.setY(hero.getY());
                    movement = false;
                }
            }
            Tile[,] newTile = new Tile[hero.getX(), hero.getY()];
            newTile[hero.getX(), hero.getY()].setTileType(Tile.TileType.Hero);
            map.setLand(newTile); //Sets new hero location as Hero tile type. -------> i hope
            
           // map.setLand(map.getLand(map.getTileType(Tile.TileType.Hero))); -------> sets new hero location to tile type hero
            //This updates the move is the movement is valid via button presses
            return movement;
        }
    }
}
