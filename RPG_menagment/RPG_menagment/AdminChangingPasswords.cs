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
    public partial class AdminChangingPasswords : Form
    {
        public AdminChangingPasswords()
        {
            InitializeComponent();
        }

        private void AdminChangingPasswords_Load(object sender, EventArgs e)
        {
            foreach(string user in ContextActions.getAllUsers())
            {
                comboBox1.Items.Add(user);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.Text != "" && textBox1.Text != "")
            {
                string[] emails = comboBox1.Text.Split('-');
                string email = emails[1];
                ContextActions.changeUserPassword(email, textBox1.Text);
                MessageBox.Show("Password was changed successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fill all the blanks", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

    }
}
