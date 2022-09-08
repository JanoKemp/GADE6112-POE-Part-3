
namespace GADE6112_POE_part_1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            MapAssignment(); // Calls MapAssigment class - to assign text Boxes to Land array in map
            
            this.Text = "test2";
            this.Text = "test branch 1";
            
        }
        public void MapAssignment()
        {
            Map map = new Map();
            
            

            //Map array [ Row , Column ] = TextBox[ X , Y]
            //First Column
            //First Row 
            map.Land[0, 0] = textBox00;
            map.Land[0, 1] = textBox01;
            map.Land[0, 2] = textBox02;
            map.Land[0, 3] = textBox03;
            map.Land[0, 4] = textBox04;
            map.Land[0, 5] = textBox05;
            map.Land[0, 6] = textBox06;
            
            


            //Second Row
            map.Land[1, 0] = textBox10;
            map.Land[1, 1] = textBox11;
            map.Land[1, 2] = textBox12;
            map.Land[1, 3] = textBox13;
            map.Land[1, 4] = textBox14;
            map.Land[1, 5] = textBox15;
            map.Land[1, 6] = textBox16;
            //Third Row
            map.Land[2, 0] = textBox20;
            map.Land[2, 1] = textBox21;
            map.Land[2, 2] = textBox22;
            map.Land[2, 3] = textBox23;
            map.Land[2, 4] = textBox24;
            map.Land[2, 5] = textBox25;
            map.Land[2, 6] = textBox26;
            //Fourth Row
            map.Land[3, 0] = textBox30;
            map.Land[3, 1] = textBox31;
            map.Land[3, 2] = textBox32;
            map.Land[3, 3] = textBox33;
            map.Land[3, 4] = textBox34;
            map.Land[3, 5] = textBox35;
            map.Land[3, 6] = textBox36;
            //Fifth
            map.Land[4, 0] = textBox40;
            map.Land[4, 1] = textBox41;
            map.Land[4, 2] = textBox42;
            map.Land[4, 3] = textBox43;
            map.Land[4, 4] = textBox44;
            map.Land[4, 5] = textBox45;
            map.Land[4, 6] = textBox46;
            //Sixth Row
            map.Land[5, 0] = textBox50;
            map.Land[5, 1] = textBox51;
            map.Land[5, 2] = textBox52;
            map.Land[5, 3] = textBox53;
            map.Land[5, 4] = textBox54;
            map.Land[5, 5] = textBox55;
            map.Land[5, 6] = textBox56;
            //Seventh Row
            map.Land[6, 0] = textBox60;
            map.Land[6, 1] = textBox61;
            map.Land[6, 2] = textBox62;
            map.Land[6, 3] = textBox63;
            map.Land[6, 4] = textBox64;
            map.Land[6, 5] = textBox65;
            map.Land[6, 6] = textBox66;
            //Eigth Row
            map.Land[7, 0] = textBox70;
            map.Land[7, 1] = textBox71;
            map.Land[7, 2] = textBox72;
            map.Land[7, 3] = textBox73;
            map.Land[7, 4] = textBox74;
            map.Land[7, 5] = textBox75;
            map.Land[7, 6] = textBox76;
            //Ninth Row
            map.Land[8, 0] = textBox80;
            map.Land[8, 1] = textBox81;
            map.Land[8, 2] = textBox82;
            map.Land[8, 3] = textBox83;
            map.Land[8, 4] = textBox84;
            map.Land[8, 5] = textBox85;
            map.Land[8, 6] = textBox86;
            

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

        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {

        }
    }
}