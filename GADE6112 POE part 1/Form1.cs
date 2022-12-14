
namespace GADE6112_POE_part_1
{
    public partial class mainForm : Form
    {
        TextBox[,] textBoxes = new TextBox[9, 7];
        public mainForm()
        {
            InitializeComponent();
        }

        Map mapLand;
        GameEngine gameEngine = new GameEngine();
        Hero hero;
        Tile[,] landArray;
        Item[] items;
        Enemy[] enemyArr;
        Shop shop;
        Weapon [] weapons;




        private void mainForm_Load(object sender, EventArgs e)
        {
            mapLand = gameEngine.getMap();
            hero = mapLand.getHero();
            shop = gameEngine.getShop();
            weapons = shop.getWeapons();
            landArray = mapLand.getLand();
            items = mapLand.getItems();
            MapAssignment(); // Calls MapAssigment class - to assign text Boxes to Land array in map
            MapGeneration();
            BorderCreation();
            EnemyCreation();
            HeroCreation();
            ItemCreation();
            ShopMethod();
            gameEngine.getMap().UpdateVision(); // Updates vision array for all as the game starts






        }
        public void MapAssignment()
        {

            //Map array [ Row , Column ] = TextBox[ X , Y]
            //First Column
            //First Row 
            textBoxes[0, 0] = textBox00;
            textBoxes[0, 1] = textBox01;
            textBoxes[0, 2] = textBox02;
            textBoxes[0, 3] = textBox03;
            textBoxes[0, 4] = textBox04;
            textBoxes[0, 5] = textBox05;
            textBoxes[0, 6] = textBox06;

            //textBoxes[hero.getX(), hero.getY()].Text = hero.getHeroSymbol().ToString();

            //Second Row
            textBoxes[1, 0] = textBox10;
            textBoxes[1, 1] = textBox11;
            textBoxes[1, 2] = textBox12;
            textBoxes[1, 3] = textBox13;
            textBoxes[1, 4] = textBox14;
            textBoxes[1, 5] = textBox15;
            textBoxes[1, 6] = textBox16;
            //Third Row
            textBoxes[2, 0] = textBox20;
            textBoxes[2, 1] = textBox21;
            textBoxes[2, 2] = textBox22;
            textBoxes[2, 3] = textBox23;
            textBoxes[2, 4] = textBox24;
            textBoxes[2, 5] = textBox25;
            textBoxes[2, 6] = textBox26;
            //Fourth Row
            textBoxes[3, 0] = textBox30;
            textBoxes[3, 1] = textBox31;
            textBoxes[3, 2] = textBox32;
            textBoxes[3, 3] = textBox33;
            textBoxes[3, 4] = textBox34;
            textBoxes[3, 5] = textBox35;
            textBoxes[3, 6] = textBox36;
            //Fifth
            textBoxes[4, 0] = textBox40;
            textBoxes[4, 1] = textBox41;
            textBoxes[4, 2] = textBox42;
            textBoxes[4, 3] = textBox43;
            textBoxes[4, 4] = textBox44;
            textBoxes[4, 5] = textBox45;
            textBoxes[4, 6] = textBox46;
            //Sixth Row
            textBoxes[5, 0] = textBox50;
            textBoxes[5, 1] = textBox51;
            textBoxes[5, 2] = textBox52;
            textBoxes[5, 3] = textBox53;
            textBoxes[5, 4] = textBox54;
            textBoxes[5, 5] = textBox55;
            textBoxes[5, 6] = textBox56;
            //Seventh Row
            textBoxes[6, 0] = textBox60;
            textBoxes[6, 1] = textBox61;
            textBoxes[6, 2] = textBox62;
            textBoxes[6, 3] = textBox63;
            textBoxes[6, 4] = textBox64;
            textBoxes[6, 5] = textBox65;
            textBoxes[6, 6] = textBox66;
            //Eigth Row
            textBoxes[7, 0] = textBox70;
            textBoxes[7, 1] = textBox71;
            textBoxes[7, 2] = textBox72;
            textBoxes[7, 3] = textBox73;
            textBoxes[7, 4] = textBox74;
            textBoxes[7, 5] = textBox75;
            textBoxes[7, 6] = textBox76;
            //Ninth Row
            textBoxes[8, 0] = textBox80;
            textBoxes[8, 1] = textBox81;
            textBoxes[8, 2] = textBox82;
            textBoxes[8, 3] = textBox83;
            textBoxes[8, 4] = textBox84;
            textBoxes[8, 5] = textBox85;
            textBoxes[8, 6] = textBox86;

            //map.setLand(land); // Assigns textboxes to fill Map array, Change setLand to textbox to make work again


            //how to inherit in windows

            // Possibly add text boxes into array

            //how to inherit in windows

            // Possibly add text boxes into array

        }
        public void MapGeneration()
        {
            mapLand = gameEngine.getMap();
            int landVertical = mapLand.getLand().GetLength(0);
            int landHorizontal = mapLand.getLand().GetLength(1);

            for (int i = landVertical; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {


                    textBoxes[i, j].Visible = false; // Sets textBoxes visible based on randomly Generated Map and Map class ( Deals in X axis)
                }

            }
            for (int c = landHorizontal; c < textBoxes.GetLength(1); c++)
            {
                for (int z = 0; z < textBoxes.GetLength(0); z++)
                {

                    textBoxes[z, c].Visible = false; // Deals in Y Axis
                }

            }
        }
        public void BorderCreation()
        {
            for (int x = 0; x < landArray.GetLength(0); x++)
            {
                for (int y = 0; y < landArray.GetLength(1); y++)
                {

                    landArray[x, y].getTileType();
                    if (landArray[x, y].getTileType() == Tile.TileType.Barrier)
                    {
                        textBoxes[x, y].Text = "X";// gets X and Y position of Enemy object in enemyArray and uses them to output their location on the map
                    }
                }

                //textBoxes[enemyArr[x].getX(), enemyArr[x].getY()].Text = creature.getEnemySym().ToString();
            }

        }
        public void EnemyCreation() // Calls enemy array from Map to be compared and added to main TextBox output array
        {

            for (int x = 0; x < landArray.GetLength(0); x++)
            {
                for (int y = 0; y < landArray.GetLength(1); y++)
                {
                    enemyArr = mapLand.getEnemies();
                   // textBoxes[x, y].Text = landArray[x, y].getTileType().ToString();// USED TO CHECK TILE TYPES OF TEXTBOXES 
                    landArray[x, y].getTileType();
                    if (landArray[x, y].getTileType() == Tile.TileType.Enemy)
                    {
                        for (int i = 0; i < mapLand.getEnemies().Length; i++)
                        {
                            // if (landArray[x, y].getX() == enemyArr[i].getX() && landArray[x, y].getY() == enemyArr[i].getY())


                            if (enemyArr[i].GetType() == typeof(SwampCreature)) // if enemyArr[at location] returns type SwampCreature then it runs the following code
                            {
                                textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = "SC";// gets X and Y position of Enemy object in enemyArray and uses them to output their location on the map
                                // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                                //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                            }
                            if (enemyArr[i].GetType() == typeof(Mage))
                            {
                                textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = "M";
                                //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                                // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                            }
                            if (enemyArr[i].GetType() == typeof(Leader))
                            {
                                textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = "L";
                                //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                            }
                            //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr.ToString();


                        }
                        //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr.ToString();


                        //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[].ToString();


                    }

                }

                //textBoxes[enemyArr[x].getX(), enemyArr[x].getY()].Text = creature.getEnemySym().ToString();
            }
            richTextBox1.Text = hero.ToString();
            for(int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }
        }
        public void HeroCreation()
        {


            int landVertical = mapLand.getLand().GetLength(0);
            int landHorizontal = mapLand.getLand().GetLength(1);
            for (int i = 0; i < landVertical; i++)
            {
                for (int x = 0; x < landHorizontal; x++)
                {
                    landArray[i, x].getTileType();
                    if (landArray[i, x].getTileType() == Tile.TileType.Hero)

                        textBoxes[landArray[i, x].getX(), landArray[i, x].getY()].Text = "H";

                }
            }
            gameEngine.getMap().UpdateVision();
        }
        public void ItemCreation()
        {
            for (int x = 0; x < mapLand.getLand().GetLength(0); x++)
            {
                for (int y = 0; y < mapLand.getLand().GetLength(1); y++)
                {
                    if (landArray[x, y].getTileType() == Tile.TileType.Gold)
                    {
                        textBoxes[landArray[x, y].getX(), landArray[x, y].getY()].Text = "G";
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Weapon)
                    {
                        textBoxes[landArray[x, y].getX(), landArray[x, y].getY()].Text = "W";
                    }
                }
            }
        }

        public void UpdateMap() // Loops through map and updates their locations actively written in the text boxes
        {
            for (int x = 0; x < mapLand.getLand().GetLength(0); x++)
            {
                for (int y = 0; y < mapLand.getLand().GetLength(1); y++)
                {
                    if (landArray[x, y].getTileType() == Tile.TileType.Hero)
                    {
                        textBoxes[x, y].Text = "H";
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Clear)
                    {
                        textBoxes[x, y].Text = String.Empty;
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Barrier)
                    {
                        textBoxes[x, y].Text = "X";
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Gold)
                    {
                        textBoxes[x, y].Text = "G";
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Weapon)
                    {
                        textBoxes[x, y].Text = "W";
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Enemy)
                    {
                        if (landArray[x, y].getTileType() == Tile.TileType.Enemy)
                        {
                            for (int i = 0; i < mapLand.getEnemies().Length; i++)
                            {
                                // if (landArray[x, y].getX() == enemyArr[i].getX() && landArray[x, y].getY() == enemyArr[i].getY())

                                if (enemyArr[i] != null)
                                {
                                    if (enemyArr[i].GetType() == typeof(SwampCreature)) // if enemyArr[at location] returns type SwampCreature then it runs the following code
                                    {
                                        textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = "SC";// gets X and Y position of Enemy object in enemyArray and uses them to output their location on the map
                                                                                                      // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                                                                                                      //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                                    }
                                    if (enemyArr[i].GetType() == typeof(Mage))
                                    {
                                        textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = "M";
                                        // richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                                        // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                                    }
                                    if (enemyArr[i].GetType() == typeof(Leader))
                                    {
                                        textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = "L";
                                        // richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                                        // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        public void ShopMethod()
        {
            if (shop.CanBuy(0)) // if the hero can afford item 1 then enable the button
            {
                shopB1.Enabled = true;// Makes the button pressable
            }
            else shopB1.Enabled = false; // else grey it out until the player can afford the item
            if (shop.CanBuy(1))
            {
                shopB2.Enabled = true;
            }
            else shopB2.Enabled = false;
            if (shop.CanBuy(2))
            {
                shopB3.Enabled = true;
            }
            else shopB3.Enabled = false;
            itemLabel1.Text = shop.DisplayWeapon(0); // Displays Weapons stored in Weapons array in shop
            itemLabel2.Text = shop.DisplayWeapon(1);
            itemLabel3.Text = shop.DisplayWeapon(2);
            shopB1.Text = "Buy";
            shopB2.Text = "Buy";
            shopB3.Text = "Buy";
        }



        private void textBox00_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            gameEngine.getMap().UpdateVision();//Updates vision for all characters to insure no issues
            hero.setMovement(Character.Movement.up);// Sets the movement corresponding to button pressed
            gameEngine.MovePlayer(Character.Movement.up); // Calls Move player method which changes the X and Y accordingly 
            gameEngine.getMap().UpdateVision(); // Updates vision based on new movement
            heroGoldLabel1.Text = "Hero Gold: " + hero.getGoldPurse().ToString(); // Updates heros gold label in shop
            gameEngine.MoveEnemies(); // Calling it in hero PlayerMove in GameEngine
            gameEngine.getMap().UpdateVision(); // Updates vision again
            UpdateMap(); // Updates the map after all movement
            richTextBox1.Text = hero.ToString(); // outputs hero stats
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString(); // Adds all enemy stats to output after hero
                }
            }
            comboBox1.Items.Clear();//Resets combo Box to not cont add same items
            for (int i = 0; i < enemyArr.Length; i++) //loops through enemyArr
            {
                if (enemyArr[i] != null)
                {
                    if (hero.CheckRange(enemyArr[i]) == true) // Checks if creature is within range
                    {
                        comboBox1.Items.Add(enemyArr[i].ToString()); // Adds item to combo Box if within range
                    }
                }
            }
            /*for (int x = 0; x < landArray.GetLength(0); x++)
            {
                for (int y = 0; y < landArray.GetLength(1); y++)
                {
                    textBoxes[x,y].Text = landArray[x, y].getTileType().ToString();// USED TO CHECK TILE TYPES OF TEXTBOXES 
                }
            }
            */
            ShopMethod(); // Updates the shop with gold and weapons , also updates labels
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            gameEngine.getMap().UpdateVision();
            hero.setMovement(Character.Movement.left);
            gameEngine.MovePlayer(Character.Movement.left);
            gameEngine.getMap().UpdateVision();
            heroGoldLabel1.Text = "Hero Gold: " + hero.getGoldPurse().ToString();
            gameEngine.MoveEnemies(); // Calling it in hero PlayerMove in GameEngine
            gameEngine.getMap().UpdateVision();
            UpdateMap();
            richTextBox1.Text = hero.ToString();
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }
            comboBox1.Items.Clear();//Resets combo Box to not cont add same items
            for (int i = 0; i < enemyArr.Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    if (hero.CheckRange(enemyArr[i]) == true) // Checks if creature is within range
                    {
                        comboBox1.Items.Add(enemyArr[i].ToString());
                    }
                }
            }
            ShopMethod();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            gameEngine.getMap().UpdateVision();
            hero.setMovement(Character.Movement.right);
            gameEngine.MovePlayer(Character.Movement.right);
            gameEngine.getMap().UpdateVision();
            heroGoldLabel1.Text = "Hero Gold: " + hero.getGoldPurse().ToString();
            gameEngine.MoveEnemies(); // Calling it in hero PlayerMove in GameEngine
            gameEngine.getMap().UpdateVision();
            UpdateMap();
            richTextBox1.Text = hero.ToString();
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }
            comboBox1.Items.Clear();//Resets combo Box to not cont add same items
            for (int i = 0; i < enemyArr.Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    if (hero.CheckRange(enemyArr[i]) == true) // Checks if creature is within range
                    {
                        comboBox1.Items.Add(enemyArr[i].ToString());
                    }
                }
            }
            ShopMethod();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            gameEngine.getMap().UpdateVision();
            hero.setMovement(Character.Movement.down);
            gameEngine.MovePlayer(Character.Movement.down);
            gameEngine.getMap().UpdateVision();
            heroGoldLabel1.Text = "Hero Gold: " + hero.getGoldPurse().ToString();
            gameEngine.MoveEnemies(); // Calling it in hero PlayerMove in GameEngine
            gameEngine.getMap().UpdateVision();
            UpdateMap();
            richTextBox1.Text = hero.ToString();
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }
            comboBox1.Items.Clear();//Resets combo Box to not cont add same items
            for (int i = 0; i < enemyArr.Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    if (hero.CheckRange(enemyArr[i]) == true) // Checks if creature is within range
                    {
                        comboBox1.Items.Add(enemyArr[i].ToString());
                    }
                }
            }
            ShopMethod();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAttack_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < enemyArr.Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    if (hero.CheckRange(enemyArr[i]) == true) // Checks if creature is within range
                    {

                        hero.Attack(enemyArr[i]); // Creature hp - hero damage. Then sets new Creature hp
                       // richTextBox1.Text = richTextBox1.Text + enemyArr[i].ToString();
                        if (enemyArr[i].isDead())
                        {
                            landArray[enemyArr[i].getX(), enemyArr[i].getY()] = new EmptyTile(enemyArr[i].getX(), enemyArr[i].getY()); // enemy gone from map
                            enemyArr[i].setDamage(0); // Fixes a bug where enemy can still do damage even when set null
                            enemyArr[i] = null; // Kills the enemy
                            UpdateMap(); // Updates map after death
                            DeathMessage(); // Checks number of enemies left and ends game if there are none
                        }
                        /* if (enemyArr[i].ToString() == comboBox1.SelectedText.ToString()) // Attempt to attack selected Location
                         {
                             hero.Attack(enemyArr[i]);
                         }
                        */
                    }
                    if (enemyArr[i] != null && enemyArr[i].CheckRange(hero) == true)
                    {
                        enemyArr[i].Attack(hero);
                        if(hero.isDead())
                        {
                            DeathMessage(); //Checks if hero is dead , if so it ends the game
                        }
                    }
                }
            }
            
            for (int i = 0; i < enemyArr.Length; i++)
            {
                if(enemyArr[i] != null)

                richTextBox1.Text = hero.ToString() + " \n " + enemyArr[i].ToString();
            }
            UpdateMap();
            //gameEngine.EnemyAttack(creature.CheckRange(hero), hero, creature);
            //gameEngine.EnemyAttack(mage.CheckRange(hero), hero, mage);


        }
        public void DeathMessage()
        {
            int numCount = 0;
            if (hero.isDead()) // checks if the hero is dead once calld
            {
                string message = "Hero has died! You lose";
                string title = "GAME OVER";
                DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.OK); // Outputs strings in order of message then caption and then button
                if (dialogResult == DialogResult.OK)
                {
                    Application.Restart(); // Restarts the application
                }
            }
            int enemyNullCount = 0;
            for(int i = 0; i < enemyArr.Length; i++) // Checks which enemies are still alive
            {
                if (enemyArr[i] != null)
                {
                    enemyNullCount++;
                    numCount = i;
                }
                
            }
            if(enemyNullCount < 1) // if all enemies are dead then output the following
            {
                string message = "Your ending stats were:\n"+ hero.ToString();
                string title = "GAME OVER | YOU WON";
                DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
            

            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            gameEngine.Save();//calling save method from GameEngine class
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for(int c = 0; c < textBoxes.GetLength(1); c++)
                {
                    textBoxes[i, c].Text = String.Empty; // Resets the map to be overwritten by new map
                }
            }
            gameEngine.Load();//calls Load method from GameEngine class
            MapAssignment(); // Calls MapAssigment class - to assign text Boxes to Land array in map
            MapGeneration();
            BorderCreation();
            EnemyCreation();
            HeroCreation();
            ItemCreation();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void shopB1_Click(object sender, EventArgs e)
        {
             shop.Buy(0); // Buys the item at the first array location
            richTextBox1.Text = hero.ToString();
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }

        }

        private void shopB2_Click(object sender, EventArgs e)
        {
            shop.Buy(1); // Buys the item at the second array location
            richTextBox1.Text = hero.ToString();
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }
        }

        private void shopB3_Click(object sender, EventArgs e)
        {
            shop.Buy(2); // Buys the item at the third array location
            richTextBox1.Text = hero.ToString();
            for (int i = 0; i < mapLand.getEnemies().Length; i++)
            {
                if (enemyArr[i] != null)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n\n" + enemyArr[i].ToString();
                }
            }
        }

        private void costLabel1_Click(object sender, EventArgs e)
        {

        }

        private void costLabel2_Click(object sender, EventArgs e)
        {

        }

        private void costLabel3_Click(object sender, EventArgs e)
        {

        }

        private void heroGoldLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}