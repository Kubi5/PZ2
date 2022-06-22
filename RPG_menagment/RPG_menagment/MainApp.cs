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
        AdminChangingPasswords adminChangingPasswords;
        public MainApp()
        {
            InitializeComponent();
            changingPassword = new ChangingPassword();
            userEquipment = new UserEquipment();
            adminChangingPasswords = new AdminChangingPasswords();
        }

        public void showWelcomeLabel()
        {
            Label label = new Label();
            if (!(LoggedUser.Nickname is null))
            {
                label.Text = $"Welcome {LoggedUser.Nickname}!";
            }
            else
            {
                label.Text = $"Welcome spectator!";
            }
            label.Location = new Point(220, 20);
            label.AutoSize = false;
            label.Size = new Size(459,61);
            label.Font = new Font("Century", 26, FontStyle.Bold | FontStyle.Underline);
            label.ForeColor = Color.White;
            this.Controls.Add(label);
        }   

        public void showLoggedUserDisplay()
        {
            label5.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }
        public void showAdminDisplay()
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;  
            comboBox1.Visible = false;
            button1.Visible = false;
            button7.Visible = false;
            button3.Visible = false;
            label4.Visible = false;
        }
        public void showSpectatorDisplay()
        {
            label5.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label4.Visible = false;
            button3.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;
            button7.Visible = false;
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
            this.showWelcomeLabel();

            switch (LoggedUser.Role)
            {
                case null:
                    this.showSpectatorDisplay();
                    break;

                case "logged":
                    this.showLoggedUserDisplay();
                    ContextActions.clearUsersItems();
                    ContextActions.setUsersItems();
                    break;
                case "ADMIN":
                    this.showAdminDisplay();
                    break;
            }
            

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

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoggedUser.Role = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminChangingPasswords.ShowDialog();
        }
    }
}
