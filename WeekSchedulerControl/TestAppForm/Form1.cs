using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAppForm
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void userControl11_Notify(object sender, EventArgs e)
        {
            MessageBox.Show("Masz nadchodzące wydarzenie!","Event",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
    }
}
