using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RPG_menagment.Data.Model.RPGmodel;

namespace RPG_menagment
{
    public partial class AddingNature : Form
    {
        string natureToModify;
        public AddingNature(string natureToModify)
        {
            InitializeComponent();
            this.natureToModify = natureToModify;
        }

        public void hideCave()
        {
            label1.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        public void hideTower()
        {
            label2.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
        }

        public void hideRiver()
        {
            label3.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
        }

        public void hideForest()
        {
            label4.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
        }

        public void ShowCaveControl()
        {
            this.hideForest();
            this.hideRiver();
            this.hideTower();
        }
        public void ShowTowerControl()
        {
            this.hideForest();
            this.hideRiver();
            this.hideCave();
        }
        public void ShowRiverControl()
        {
            this.hideForest();
            this.hideCave();
            this.hideTower();
        }
        public void ShowForestControl()
        {

            this.hideRiver();
            this.hideCave();
            this.hideTower();
        }
        public Boolean checkIfCaveTextboxesAreNull()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkIfTowerTextboxesAreNull()
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkIfRiverTextboxesAreNull()
        {
            if (textBox6.Text == "" || textBox7.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkIfForestTextboxesAreNull()
        {
            if (textBox8.Text == "" || textBox9.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddingNature_Load(object sender, EventArgs e)
        {
            
            if (natureToModify == "Cave")
            {
                this.ShowCaveControl();
            }
            if (natureToModify == "Tower")
            {
                this.ShowTowerControl();
            }
            if (natureToModify == "River")
            {
                this.ShowRiverControl();
            }
            if (natureToModify == "Forest")
            {
                this.ShowForestControl();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adding cave
            if (label1.Visible && !this.checkIfCaveTextboxesAreNull())
            {
                Cave cave = new Cave();
                cave.Name = textBox1.Text;
                cave.Area = int.Parse(textBox2.Text);
                cave.UserID = LoggedUser.ID; 

                ContextActions.addCaveToDB(cave);

                MessageBox.Show($"You successfully added your {cave.Name} into" +
                    $" world of magic!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (label1.Visible && this.checkIfCaveTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (label2.Visible && !this.checkIfTowerTextboxesAreNull())
            {
                Tower tower = new Tower();
                tower.Name = textBox3.Text;
                tower.Height = int.Parse(textBox4.Text);
                tower.Material = textBox5.Text;
                tower.UserID = LoggedUser.ID;

                ContextActions.addTowerToDB(tower);

                MessageBox.Show($"You successfully added your {tower.Name} into" +
                    $" world of magic!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (label2.Visible && this.checkIfTowerTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (label3.Visible && !this.checkIfRiverTextboxesAreNull())
            {
                River river = new River();

                river.Name = textBox6.Text;
                river.Length = int.Parse(textBox7.Text);
                river.UserID = LoggedUser.ID;

                ContextActions.addRiverToDB(river);

                MessageBox.Show($"You successfully added your {river.Name} into" +
                    $" world of magic!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (label3.Visible && this.checkIfRiverTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (label4.Visible && !this.checkIfForestTextboxesAreNull())
            {
                Forest forest = new Forest();

                forest.Name = textBox8.Text;
                forest.Area = int.Parse(textBox9.Text);
                forest.UserID = LoggedUser.ID;

                ContextActions.addForestToDB(forest);

                MessageBox.Show($"You successfully added your {forest.Name} into" +
                    $" world of magic!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (label4.Visible && this.checkIfForestTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }
}
