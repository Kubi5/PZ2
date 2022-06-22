using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProjectMain
{
    public partial class Form1 : Form
    {
        Register register;
        MainApp mainApp;
        public Form1()
        {
            InitializeComponent();

            //ClientOperations.AddAdmin();
        }


        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            register = new Register();
            register.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClientOperations.sentUserDataToServiceSignIn(textBox1.Text, textBox2.Text) == true)
            {
                //Todo: dorobic wyjmowanie roli za pomoca maila
                LoggedUser.Email = textBox1.Text;
                LoggedUser.Role = ClientOperations.getUserRole(LoggedUser.Email);
                LoggedUser.ID = ClientOperations.getUserID(LoggedUser.Email);

                ClientOperations.clearUserBooks(LoggedUser.ID);
                ClientOperations.fillUserBooks(LoggedUser.ID);

                mainApp = new MainApp(LoggedUser.Role);
                mainApp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = true;
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                checkBox1.Checked = false;
                textBox2.UseSystemPasswordChar = false;
            }
            
        }
    }
}
