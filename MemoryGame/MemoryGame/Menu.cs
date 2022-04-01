using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Menu : Form
    {
        Form2 form2;
        Form3 form3;
        Form4 form4;
        public Menu()
        {
            InitializeComponent();
            Console.WriteLine("dd");
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                checkBox3.Checked = true;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString() + " s";
            TimeHandler.TimeToLearnTiles = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar2.Value.ToString() + " s";
            TimeHandler.TimeToDisplayPair = trackBar2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text == "")
            {
                MessageBox.Show("You didnt specify your nickname!","Error");
                return;
            }

            Player.PlayerName = textBox1.Text;


            if (checkBox1.Checked == true)
            {
                Player.DifficultyLevel = "easy";
                form2 = new Form2();
                form2.ShowDialog();
            }
            if (checkBox2.Checked == true)
            {
                Player.DifficultyLevel = "medium";
                form3 = new Form3();
                form3.ShowDialog();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            form4 = new Form4();

            form4.ShowDialog();
        }
    }
}
