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
    public partial class JoinUsForm : Form
    {
        public JoinUsForm()
        {
            InitializeComponent();
        }
        private void CleanTheTextboxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ContextActions.IsEmailAlreadyinDatabase(textBox1.Text))
            {
                MessageBox.Show("Email is already in database", 
                    "You are part of us!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.CleanTheTextboxes();
                return;
            }



            if (SafetySystem.arePasswordtheSame(textBox2.Text, textBox3.Text) &&
                SafetySystem.isEmailValid(textBox1.Text) && SafetySystem.isPasswordValid(textBox2.Text))
            {
                User user = new User()
                {
                    email = textBox1.Text,
                    password = textBox2.Text,
                    nickname = textBox4.Text,
                };
                ContextActions.AddUsertoDB(user);
                this.CleanTheTextboxes();
                return;
            }
            else
            {
                MessageBox.Show("Provided data is wrong! Change your selections"
                    ,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CleanTheTextboxes();
        }

    }
}
