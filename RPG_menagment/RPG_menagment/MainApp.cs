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
        AddingNature addingNature;
        UserEquipment userEquipment;
        public MainApp()
        {
            InitializeComponent();
            changingPassword = new ChangingPassword();
            userEquipment = new UserEquipment();
        }

        public string createHeaderforTOP5()
        {
            return $"No. -- Power -- Character -- Gamer\n" +
                $"-------------------------------------------------\n";
        }

        public void createTOP5()
        {
            label1.Text = createHeaderforTOP5();
            int i = 0;
            label1.ForeColor = Color.Gold;
            foreach (var topfighter in ContextActions.getTOP5())
            {
                label1.Text += $"{i + 1}. {topfighter} \n";
                i++;
            }
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
            ContextActions.clearUsersItems();
            ContextActions.setUsersItems();

            listView1.Items.Clear();

            foreach(string item in ContextActions.showLatestUpdate(5))
            { listView1.Items.Add(item); }

            comboBox1.Items.Clear();
            AddFighters();
            createTOP5();
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
                if (checkBox1.Checked == true)
                {
                    addingCharacters = new AddingCharacters(comboBox1.Text);
                    addingCharacters.ShowDialog();

                    createTOP5();

                    listView1.Items.Clear();

                    foreach (string item in ContextActions.showLatestUpdate(5))
                    { listView1.Items.Add(item); }
                }
                else
                {
                    addingNature = new AddingNature(comboBox1.Text);
                    addingNature.ShowDialog();
                }
            }
        }

        int i = 5;


        private void button8_Click(object sender, EventArgs e)
        {
            if((i+1) > ContextActions.numbersOfRowsInFightersDB())
            {
                return;
            }
            label8.Text = (i + 1).ToString();
            listView1.Items.Clear();
            foreach(string item in ContextActions.showLatestUpdate(i + 1))
            {
                listView1.Items.Add(item);
            }
            i = i+1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((i - 1) < 0)
            {
                return;
            }
            label8.Text = (i - 1).ToString();
            listView1.Items.Clear();
            foreach (string item in ContextActions.showLatestUpdate(i - 1))
            {
                listView1.Items.Add(item);
            }
            i = i - 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userEquipment.ShowDialog();
        }
    }
}
