using RPG_menagment.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RPG_menagment.Data.Model.RPGmodel;

namespace RPG_menagment
{
    public partial class Form1 : Form
    {
        JoinUsForm joinUsForm;
        SignInForm signInForm;
        MainApp mainapp;

        RPGcontext context = new RPGcontext();

        public Form1()
        {
            InitializeComponent();
            joinUsForm = new JoinUsForm();
            signInForm = new SignInForm();
            mainapp = new MainApp();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainapp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signInForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            joinUsForm.ShowDialog();
        }
    }
}
