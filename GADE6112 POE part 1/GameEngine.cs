﻿using System;
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
        public int movementDet = 0; // increments if the hero moves / used to tell enemies when to move
        public GameEngine()
        {
            
           map = new Map(6,7,7,9,3,6,5); // Creates a map with overloaded constructor
            
            
         
        }
        public Map getMap() { return map; } // public get accessor for the private map variable
        public bool MovePlayer(Character.Movement direction, Hero hero)
        {
            
            map.getLocation(hero.getX(), hero.getY()).setTileType(Tile.TileType.Clear); // Gets the current location of the hero and sets the tile type to Clear
            bool movement = true; // Possibly add this somewhere else for it to be called (unknown)
            if (movement = true)
            {
                movementDet = 1;
            }
            if (hero.ReturnMove(hero.getMovement()) == direction) // Return move checks if movement is valid with Vision array , getMovement gets the players input
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
            if (map.getLocation(hero.getX(),hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
            {
                
                hero.PickUp(map.GetItemAtPosition(hero.getX(),hero.getY())); // Adds item to player after given movement based on its location
            }
            if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Weapon)
            {

                hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY()));
            }
            
            map.getLocation(hero.getX(), hero.getY()).setTileType(Tile.TileType.Hero); // Gets the new position of the hero and sets its Tile type to Clear ( empty) 

            // map.setLand(map.getLand(map.getTileType(Tile.TileType.Hero))); -------> sets new hero location to tile type hero
            //This updates the move is the movement is valid via button presses
            return movement;
        }
        public bool MoveEnemies(Hero hero , Character.Movement enemyDirection , SwampCreature swamp , Mage mage ,  GameEngine gameEngine)
        {
            Enemy[] enemyArr = map.getEnemies(); 
            
            if (movementDet == 1)
            {
                for (int i = 0; i < map.getEnemies().GetLength(0); i++)
                {
                    if (enemyArr[i] != mage) // Mages cannot move therefore they must not use the following code
                    {
                        enemyDirection = swamp.ReturnMove(); // Checks if movement is valid against Vision array
                        enemyArr[i].Move(enemyDirection); //Moves the X and Y location
                        enemyArr[i] = (Enemy)map.UpdateVision(enemyArr[i],enemyDirection);//Updates the vision array of the enemy at the new location
                        
                    }
                    
                }
            }
            map.getLand();// gets 2d map array
            return MoveEnemies(hero,enemyDirection,swamp,mage,gameEngine);
        }
    }
}
