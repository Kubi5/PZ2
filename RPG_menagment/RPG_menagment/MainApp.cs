using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_menagment
{
    public partial class MainApp : Form
    {
        ChangingPassword changingPassword;
        AddingCharacters addingCharacters;
        public MainApp()
        {
            InitializeComponent();
            changingPassword = new ChangingPassword();
            
        }

        public void AddFighters()
        {
            comboBox1.Items.Add("Dragon");
            comboBox1.Items.Add("Magician");
            comboBox1.Items.Add("Soldier");
            comboBox1.Items.Add("Orc");
        }

        public void AddLandscape()
        {
            comboBox1.Items.Add("Cave");
            comboBox1.Items.Add("River");
            comboBox1.Items.Add("Tower");
            comboBox1.Items.Add("Forest");
        }

        public void ClearTheList()
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            
            changingPassword.ShowDialog();
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            AddFighters();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            this.ClearTheList();
            checkBox1.Checked = false;
            this.AddLandscape();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            this.ClearTheList();
            checkBox2.Checked = false;
            this.AddFighters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Choose item to modify!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                addingCharacters = new AddingCharacters(comboBox1.Text);
                addingCharacters.ShowDialog();
            }
        }
    }
}
