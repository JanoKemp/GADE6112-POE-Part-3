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
        
        public int movementDet = 0; // increments if the hero moves / used to tell enemies when to move
        public GameEngine()
        {
            
           map = new Map(4,7,6,9,3,6,3); // Creates a map with overloaded constructor
            
            
         
        }
        public Map getMap() { return map; } // public get accessor for the private map variable
        public bool MovePlayer(Character.Movement direction)
        {
            Hero hero;
            hero = map.getHero();
            Tile [, ] LandArray = map.getLand();
           // LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(),hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
            bool movement = true;
            
           if (hero.ReturnMove(hero.getMovement()) == direction) // Return move checks if movement is valid with Vision array , getMovement gets the players input
           {
               
                if (direction == Character.Movement.down)
                {
                    LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(), hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
                    hero.setX(hero.getX() + 1); //Changes the Y position of the hero to one up from it current location
                    if (LandArray[hero.getX(),hero.getY()].getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    LandArray[hero.getX(), hero.getY()] = hero;
                    map.setLand(LandArray);
                    movementDet = 1;
                    movement = true;
                    
                    return movement;
                    
                }
                if (direction == Character.Movement.up)
                {
                    LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(), hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
                    hero.setX(hero.getX() - 1);
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    LandArray[hero.getX(), hero.getY()] = hero;
                    movementDet = 1;
                    map.setLand(LandArray);
                    movement = true;
                    return movement;
                }
                if (direction == Character.Movement.left)
                {
                    LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(), hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
                    hero.setY(hero.getY() - 1);
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    LandArray[hero.getX(), hero.getY()] = hero;
                    movementDet = 1;
                    map.setLand(LandArray);
                    movement = true;
                    return movement;
                }
                if (direction == Character.Movement.right)
                {
                    LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(), hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
                    hero.setY(hero.getY() + 1);
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    LandArray[hero.getX(), hero.getY()] = hero;
                    movementDet = 1;
                    map.setLand(LandArray);
                    movement = true;
                    return movement;
                }
                if (direction == Character.Movement.noMovement)
                {
                   
                    movementDet = 0;
                    movement = false;
                    return movement;
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

            LandArray[hero.getX(), hero.getY()].setTileType(Tile.TileType.Hero); // Gets the new position of the hero and sets its Tile type to Clear ( empty) 

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
                        enemyArr[i].Move(enemyDirection, enemyArr[i]); //Moves the X and Y location
                        map.UpdateVision();//Updates the vision array of the enemy at the new location
                        
                    }
                    
                }
            }
            map.getLand();// gets 2d map array
            return MoveEnemies(hero,enemyDirection,swamp,mage,gameEngine);
        }

        public void EnemyAttack(bool status, Hero hero , Enemy enemy)
        {
           if(status = true)
            {
                hero.setHP(hero.getHP() - enemy.getDamage());
            }    
           else if (status = false)
            {

            }
                
            
        }
        public void Save() //method to save map class and the varibales that it contains
            {
                FileStream outFile = new FileStream("gameSave.bin", FileMode.Create, FileAccess.Write);//creating file
                BinaryWriter save = new BinaryWriter(outFile);
                save.Write(map.getEnemyNum());//saving enemyNum to file
                save.Write(map.getHero().getX());//saving x position of hero to file
                save.Write(map.getHero().getY());//saving Y position of hero to file
                for (int i = 0; i < map.getEnemies().GetLength(0); i++)
                {
                    Enemy[] enemyArr = map.getEnemies();
                    save.Write(enemyArr[i].getX());//saving x postion of enemies
                    save.Write(enemyArr[i].getY());//saving Y position of enemies
                }
                save.Write(map.getHorizontal());//saving map height to file
                save.Write(map.getVertical());//saving map length to file
                save.Close();//closing file
                outFile.Close();
            
        }
        public void Load()
        {
            FileStream outFile = new FileStream("gameSave.bin", FileMode.Open);//opening file
            BinaryReader load = new BinaryReader(outFile);
            map.setEnemyNum(load.ReadInt32());//retrieving number of enemies from file
            map.getHero().setX(load.ReadInt32());//retrieving X position of hero from file
            map.getHero().setY(load.ReadInt32());//retrieving Y position of hero from file
            for (int i = 0; i < map.getEnemies().GetLength(0); i++)
            {
                Enemy[] enemyArr = map.getEnemies();
                enemyArr[i].setX(load.ReadInt32());//retrieving x postion of enemies from file
                enemyArr[i].setY(load.ReadInt32());//retrieving Y position of enemies from file

            }
            map.setHorizontal(load.ReadInt32());//retrieving map height from file
            map.setVertical(load.ReadInt32());//retrievig maop length from file
            load.Close();//closing file
            outFile.Close();
        }
    }
}
