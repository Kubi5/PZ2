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
        public SignInForm()
        {
            InitializeComponent();
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
                //TODO : wyswietl nowego forma z apka docelowa
                MessageBox.Show("Fine");
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
