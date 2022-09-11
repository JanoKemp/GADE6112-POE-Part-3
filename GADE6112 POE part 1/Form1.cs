
namespace GADE6112_POE_part_1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        Hero hero = new Hero();
        SwampCreature creature = new SwampCreature();
        GameEngine gameEngine = new GameEngine();
        Map map = new Map();
        
        private void mainForm_Load(object sender, EventArgs e)
        {
            
            MapAssignment(); // Calls MapAssigment class - to assign text Boxes to Land array in map
            gameEngine.getMap();
            
            
        }
        public void MapAssignment()
        {
            TextBox[,] land = new TextBox[9, 7];
            


            //Map array [ Row , Column ] = TextBox[ X , Y]
            //First Column
            //First Row 
            land[0, 0] = textBox00;
            land[0, 1] = textBox01;
            land[0, 2] = textBox02;
            land[0, 3] = textBox03;
            land[0, 4] = textBox04;
            land[0, 5] = textBox05;
            land[0, 6] = textBox06;
        
            //Second Row
            land[1, 0] = textBox10;
            land[1, 1] = textBox11;
            land[1, 2] = textBox12;
            land[1, 3] = textBox13;
            land[1, 4] = textBox14;
            land[1, 5] = textBox15;
            land[1, 6] = textBox16;
            //Third Row
            land[2, 0] = textBox20;
            land[2, 1] = textBox21;
            land[2, 2] = textBox22;
            land[2, 3] = textBox23;
            land[2, 4] = textBox24;
            land[2, 5] = textBox25;
            land[2, 6] = textBox26;
            //Fourth Row
            land[3, 0] = textBox30;
            land[3, 1] = textBox31;
            land[3, 2] = textBox32;
            land[3, 3] = textBox33;
            land[3, 4] = textBox34;
            land[3, 5] = textBox35;
            land[3, 6] = textBox36;
            //Fifth
            land[4, 0] = textBox40;
            land[4, 1] = textBox41;
            land[4, 2] = textBox42;
            land[4, 3] = textBox43;
            land[4, 4] = textBox44;
            land[4, 5] = textBox45;
            land[4, 6] = textBox46;
            //Sixth Row
            land[5, 0] = textBox50;
            land[5, 1] = textBox51;
            land[5, 2] = textBox52;
            land[5, 3] = textBox53;
            land[5, 4] = textBox54;
            land[5, 5] = textBox55;
            land[5, 6] = textBox56;
            //Seventh Row
            land[6, 0] = textBox60;
            land[6, 1] = textBox61;
            land[6, 2] = textBox62;
            land[6, 3] = textBox63;
            land[6, 4] = textBox64;
            land[6, 5] = textBox65;
            land[6, 6] = textBox66;
            //Eigth Row
            land[7, 0] = textBox70;
            land[7, 1] = textBox71;
            land[7, 2] = textBox72;
            land[7, 3] = textBox73;
            land[7, 4] = textBox74;
            land[7, 5] = textBox75;
            land[7, 6] = textBox76;
            //Ninth Row
            land[8, 0] = textBox80;
            land[8, 1] = textBox81;
            land[8, 2] = textBox82;
            land[8, 3] = textBox83;
            land[8, 4] = textBox84;
            land[8, 5] = textBox85;
            land[8, 6] = textBox86;
            //map.setLand(land); // Assigns textboxes to fill Map array, Change setLand to textbox to make work again
            

            //how to inherit in windows

            // Possibly add text boxes into array

            //how to inherit in windows

            // Possibly add text boxes into array

        }

        private void textBox00_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
           
            gameEngine.MovePlayer(Character.Movement.up, hero);
            map.UpdateVision(hero, Character.Movement.up);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.left, hero);
            map.UpdateVision(hero, Character.Movement.left);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.Movement.right, hero);
            map.UpdateVision(hero, Character.Movement.right);
            

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
           
            gameEngine.MovePlayer(Character.Movement.down, hero);
            map.UpdateVision(hero, Character.Movement.down);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            hero.ToString();
            creature.ToString();
        }

        private void buttonAttack_Click(object sender, EventArgs e)
        {
            hero.Attack(creature);
        }
    }
}