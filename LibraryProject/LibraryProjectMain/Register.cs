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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ClientOperations.sentUserDataToService(textBox1.Text, textBox2.Text, textBox3.Text) == true)
            {
                MessageBox.Show("You have logged in successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
