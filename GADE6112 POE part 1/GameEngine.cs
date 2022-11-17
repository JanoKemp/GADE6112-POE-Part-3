using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE_part_1
{

    internal class GameEngine
    {
        private Map map;
        private Shop shop;
        Enemy[] enemyArr;
        Hero heroGame;

        public int movementDet = 0; // increments if the hero moves / used to tell enemies when to move
        public GameEngine()
        {

            map = new Map(4, 7, 6, 9, 3, 6, 3, 2); // Creates a map with overloaded constructor
            enemyArr = map.getEnemies();
            heroGame = map.getHero();
            shop = new Shop(map.getHero());

        }
        public Map getMap() { return map; } // public get accessor for the private map variable
        public Shop getShop() { return shop; }
        public bool MovePlayer(Character.Movement direction)
        {
            Hero hero;
            hero = map.getHero();
            Tile[,] LandArray = map.getLand();
            // LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(),hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
            bool movement = true;
            map.UpdateVision();
            if (hero.ReturnMove(hero.getMovement()) == direction) // Return move checks if movement is valid with Vision array , getMovement gets the players input, Hero.Move(direction) in form1 sets the Movement that getMovement is fetching
            {

                if (direction == Character.Movement.down)
                {

                    LandArray[hero.getX(), hero.getY()] = new EmptyTile(hero.getX(), hero.getY()); // Gets the current location of the hero and sets the tile type to Clear
                    //hero.setX(hero.getX() + 1); //Changes the Y position of the hero to one up from it current location
                    hero.Move(Character.Movement.down, hero);//Changes X and Y values based on Movement Param entered and of the object in param
                    if (LandArray[hero.getX(), hero.getY()].getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Weapon)
                    {
                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY()));
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
                    //hero.setX(hero.getX() - 1);
                    hero.Move(Character.Movement.up, hero);
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Weapon)
                    {
                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY()));
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
                                                                                                   // hero.setY(hero.getY() - 1);
                    hero.Move(Character.Movement.left, hero);
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Weapon)
                    {
                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY()));
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
                                                                                                   // hero.setY(hero.getY() + 1);
                    hero.Move(Character.Movement.right, hero);
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                    {

                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
                    }
                    if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Weapon)
                    {
                        hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY()));
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
                if (movementDet == 1)
                {
                    MoveEnemies();
                    map.UpdateVision();
                    EnemyAttack();
                    HealthUpdate();

                }
            }
            if (map.getLocation(hero.getX(), hero.getY()).getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
            {

                hero.PickUp(map.GetItemAtPosition(hero.getX(), hero.getY())); // Adds item to player after given movement based on its location
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
        public void MoveEnemies()
        {
            Character.Movement enemyDirection;
            Enemy[] enemyArr = map.getEnemies();
            Tile[,] LandArray = map.getLand();
            bool movement;
            
            if (movementDet == 1)
            {
                movement = true;

                for (int i = 0; i < enemyArr.Length; i++)
                {
                    if (enemyArr[i] != null)
                    { 
                        if (enemyArr[i].GetType() == typeof(SwampCreature))
                        {
                            SwampCreature creature = (SwampCreature)enemyArr[i];
                            if (creature.ReturnMove(creature.getMovement()) != Character.Movement.noMovement)
                            {
                                int oldX = creature.getX();
                                int oldY = creature.getY();
                                LandArray[oldX, oldY] = new EmptyTile(oldX, oldY); 
                                creature.Move(creature.getMovement(), creature);
                                
                                enemyArr[i] = creature;
                                LandArray[creature.getX(), creature.getY()] = creature;
                                if (LandArray[creature.getX(), creature.getY()].getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                                {

                                    creature.PickUp(map.GetItemAtPosition(creature.getX(), creature.getY())); // Adds item to player after given movement based on its location
                                }
                                if (LandArray[creature.getX(), creature.getY()].getTileType() == Tile.TileType.Weapon) // Checks current Tile where the player is currently moved onto 
                                {

                                    creature.PickUp(map.GetItemAtPosition(creature.getX(), creature.getY())); // Adds item to player after given movement based on its location
                                }
                            }
                        }
                        if (enemyArr[i].GetType() == typeof(Leader))
                        {
                            
                            Leader leader = (Leader)enemyArr[i];
                            if (leader.ReturnMove(leader.getMovement()) != Character.Movement.noMovement)
                            {
                                //creature.ReturnMove(creature.getMovement());   // Return move checks if movement is valid with Vision array , Creature.getMovement is fetching the movement set my ReturnMove. This is different to hero because enemies Random Movement rather than an input
                                int oldX = leader.getX();
                                int oldY = leader.getY();
                                LandArray[oldX, oldY] = new EmptyTile(oldX, oldY);
                                leader.Move(leader.getMovement(), leader);

                                enemyArr[i] = leader;
                                LandArray[leader.getX(), leader.getY()] = leader;
                                if (LandArray[leader.getX(), leader.getY()].getTileType() == Tile.TileType.Gold) // Checks current Tile where the player is currently moved onto 
                                {

                                    leader.PickUp(map.GetItemAtPosition(leader.getX(), leader.getY())); // Adds item to player after given movement based on its location
                                }
                                if (LandArray[leader.getX(), leader.getY()].getTileType() == Tile.TileType.Weapon) // Checks current Tile where the player is currently moved onto 
                                {

                                    leader.PickUp(map.GetItemAtPosition(leader.getX(), leader.getY())); // Adds item to player after given movement based on its location
                                }
                            }
                            
                        }
                        }
                        
                        map.setLand(LandArray);//updates the Map
                        map.UpdateVision();//updates the enemies vision
                        

                    

                }
            }
            

        }

        public void EnemyAttack()
        {
            for (int i = 0; i < map.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    Enemy enemy = enemyArr[i];
                    if (enemy.GetType() == typeof(SwampCreature))
                    {
                        if (enemy.CheckRange(heroGame))
                        {
                            enemy.Attack(heroGame);

                        }
                    }
                    if (enemy.GetType() == typeof(Mage))
                    {
                        if (enemy.CheckRange(heroGame))
                        {
                            enemy.Attack(heroGame);

                        }
                    }
                    if (enemy.GetType() == typeof(Leader))
                    {
                        if(enemy.CheckRange(heroGame))
                        {
                            enemy.Attack(heroGame);
                        }
                    }
                }
            }


        }
        public void HealthUpdate()
        {
            map.UpdateVision();
            if (heroGame != null && heroGame.isDead())
            {
                Environment.Exit(0);
            }
            for (int i = 0; i < enemyArr.Length; i++)
            {
                Enemy enemy = enemyArr[i];
                if (enemy != null)
                {
                    if (enemy.isDead())
                    {
                        Tile[,] land = map.getLand();
                        land[enemy.getX(), enemy.getY()] = new EmptyTile(enemy.getX(), enemy.getY());
                        map.setLand(land);
                    }
                }
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
