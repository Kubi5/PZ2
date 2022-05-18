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
    public partial class SignInForm : Form
    {

        MainApp mainapp;
        public SignInForm()
        {
            InitializeComponent();
            mainapp = new MainApp();
        }
        private void CleanAlltheTextboxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ContextActions.isEmailandPasswordinDB(textBox1.Text,textBox2.Text))
            {
                LoggedUser.InitiatingTheUser(textBox1.Text,
                    ContextActions.getUserRole(textBox1.Text),
                    ContextActions.getUserNickname(textBox1.Text));
             
                mainapp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Provided data is wrong!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CleanAlltheTextboxes();
            }
        }
    }
}
