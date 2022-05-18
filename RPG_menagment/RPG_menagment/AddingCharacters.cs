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
    public partial class AddingCharacters : Form
    {
        public string characterToModify;
        public AddingCharacters(string characterValue)
        {
            InitializeComponent();
            characterToModify = characterValue;
        }

        public Boolean checkIfDragonTextboxesAreNull()
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowDragonControl()
        {
            //Magician hide
            label2.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            comboBox2.Visible = false;

            //Soldier hide
            label3.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            //Orc hide
            label4.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox3.Visible = false;

        }

        public void ShowMagicianControl()
        {
            //Dragon hide
            label1.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;

            //Soldier hide
            label3.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            //Orc hide
            label4.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox3.Visible = false;

        }

        public void ShowSoldierControl()
        {
            //Dragon hide
            label1.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;

            
            //Orc hide
            label4.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox3.Visible = false;

            //Magician hide
            label2.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            comboBox2.Visible = false;

        }

        public void ShowOrcControl()
        {
            //Dragon hide
            label1.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;

            //Soldier hide
            label3.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            //Magician hide
            label2.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            comboBox2.Visible = false;

        }

        private void AddingCharacters_Load(object sender, EventArgs e)
        {
            if(characterToModify == "Dragon")
            {
                this.ShowDragonControl();
            }
            if (characterToModify == "Magician")
            {
                this.ShowMagicianControl();
            }
            if (characterToModify == "Soldier")
            {
                this.ShowSoldierControl();
            }
            if (characterToModify == "Orc")
            {
                this.ShowOrcControl();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label1.Visible && !this.checkIfDragonTextboxesAreNull())
            {
                Dragon dragon = new Dragon();
                dragon.Name = textBox1.Text;
                dragon.Wingspan = (textBox2.Text);
               
                foreach(DragonSpicies enum_ in Enum.GetValues(typeof(DragonSpicies)))
                {
                    if (enum_.Equals(comboBox1.Text))
                    {
                        dragon.dragonSpicies = enum_;
                    }
                }
                dragon.Power = int.Parse(textBox3.Text);
                dragon.UserID = LoggedUser.ID;

                ContextActions.addDragonToDB(dragon);


                
            }
        }
    }
}
