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
    public partial class ChangingPassword : Form
    {
        public ChangingPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(SafetySystem.arePasswordtheSame(textBox2.Text,textBox3.Text) 
                && SafetySystem.isPasswordValid(textBox2.Text)
                && ContextActions.isPasswordCorrect(LoggedUser.Email,textBox1.Text))
            {
                ContextActions.changeUserPassword(LoggedUser.Email, textBox2.Text);
                MessageBox.Show("You successfully changed your password! " ,
                    "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
            }
            else
            {
                MessageBox.Show("You provided wrong data! Correct it", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
