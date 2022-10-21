
namespace GADE6112_POE_part_1
{
    public partial class mainForm : Form
    {
        TextBox[,] textBoxes = new TextBox[9, 7];
        public mainForm()
        {
            InitializeComponent();
        }
        Hero hero = new Hero();
        SwampCreature creature = new SwampCreature();
        Mage mage = new Mage();
        Gold gold;
        Map mapLand;
        GameEngine gameEngine = new GameEngine();
        Obstacle barrier = new Obstacle();
        Tile[,] landArray;
        Item[] items;
        Enemy[] enemyArr;
        




        private void mainForm_Load(object sender, EventArgs e)
        {
            mapLand = gameEngine.getMap();

            landArray = mapLand.getLand();
            MapAssignment(); // Calls MapAssigment class - to assign text Boxes to Land array in map
            MapGeneration();
            BorderCreation();
            EnemyCreation();
            HeroCreation();
            GoldCreation();






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
                        textBoxes[x, y].Text = barrier.getBarrierSym().ToString();// gets X and Y position of Enemy object in enemyArray and uses them to output their location on the map
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
                    //textBoxes[x, y].Text = landArray[x, y].getTileType().ToString() ;// USED TO CHECK TILE TYPES OF TEXTBOXES 
                    landArray[x, y].getTileType();
                    if (landArray[x, y].getTileType() == Tile.TileType.Enemy)
                    {
                        for (int i = 0; i < mapLand.getEnemies().Length; i++)
                        {
                            // if (landArray[x, y].getX() == enemyArr[i].getX() && landArray[x, y].getY() == enemyArr[i].getY())


                            if (enemyArr[i].GetType() == typeof(SwampCreature)) // if enemyArr[at location] returns type SwampCreature then it runs the following code
                            {
                                textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = creature.getEnemySym().ToString();// gets X and Y position of Enemy object in enemyArray and uses them to output their location on the map
                                // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                                //richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                            }
                            if (enemyArr[i].GetType() == typeof(Mage))
                            {
                                textBoxes[enemyArr[i].getX(), enemyArr[i].getY()].Text = mage.getMageSym().ToString();
                               // richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr[i].ToString();
                                // richTextBox1.Text = richTextBox1.Text + "\n " + enemyArr[i].GetType().ToString();
                            }
                          

                        }
                       
                        
                            richTextBox1.Text = richTextBox1.Text + "\n" + enemyArr.ToString();
                        

                    }

                }

                //textBoxes[enemyArr[x].getX(), enemyArr[x].getY()].Text = creature.getEnemySym().ToString();
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

                        textBoxes[landArray[i, x].getX(), landArray[i, x].getY()].Text = hero.getHeroSymbol().ToString();

                }
            }
        }
        public void GoldCreation()
        {
            for (int x = 0; x < mapLand.getLand().GetLength(0); x++)
            {
                for (int y = 0; y < mapLand.getLand().GetLength(1); y++)
                {
                    if (landArray[x, y].getTileType() == Tile.TileType.Gold)
                    {
                        gold = new Gold(x, y);
                        items = mapLand.getItems();
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (items[i].GetType() == typeof(Gold))
                            {
                                textBoxes[items[i].getX(), items[i].getY()].Text = gold.getGoldSymbol().ToString();
                            }
                        }
                    }
                }
            }
        }
        /*public void CheckMovement()
        {
            for (int x = 0; x < mapLand.getLand().GetLength(0); x++)
            {
                for (int y = 0; y < mapLand.getLand().GetLength(1); y++)
                {
                    if (landArray[x, y].getTileType() == Tile.TileType.Hero && textBoxes[x, y].Text != hero.getHeroSymbol().ToString())
                    {
                        textBoxes[x, y].Text = hero.getHeroSymbol().ToString();
                    }
                    if (landArray[x, y].getTileType() == Tile.TileType.Clear && textBoxes[x, y].Text == hero.getHeroSymbol().ToString())
                    {
                        textBoxes[x, y].Text = String.Empty;
                    }
                }
            }
        }
        */


        private void textBox00_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUp_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(Character.Movement.up, hero); // Calls Move player method which changes the X and Y accordingly 
            gameEngine.getMap().UpdateVision(hero, Character.Movement.up); // Updates vision based on new movement
            //CheckMovement();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.left, hero);
            gameEngine.getMap().UpdateVision(hero, Character.Movement.left);
           // CheckMovement();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            gameEngine.getMap().UpdateVision(hero, Character.Movement.right);
            gameEngine.MovePlayer(Character.Movement.right, hero);
           

            //CheckMovement();

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {

            gameEngine.MovePlayer(Character.Movement.down, hero);
           // gameEngine.getMap().UpdateVision(hero, Character.Movement.down);
            //CheckMovement();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAttack_Click(object sender, EventArgs e)
        {
            if (hero.CheckRange(creature) == true) // Checks if creature is within range
            {
                hero.Attack(creature); // Creature hp - hero damage. Then sets new Creature hp
            }
            for (int i = 0; i < enemyArr.Length; i++)
            {
                richTextBox1.Text =  " \n "+ enemyArr[i].ToString();
            }
            gameEngine.EnemyAttack(creature.CheckRange(hero), hero, creature);
            gameEngine.EnemyAttack(mage.CheckRange(hero), hero, mage);


        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            gameEngine.Save();//calling save method from GameEngine class
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            gameEngine.Load();//calls Load method from GameEngine class
            MapAssignment(); // Calls MapAssigment class - to assign text Boxes to Land array in map
            MapGeneration();
            BorderCreation();
            EnemyCreation();
            HeroCreation();
            GoldCreation();
        }
    }
}