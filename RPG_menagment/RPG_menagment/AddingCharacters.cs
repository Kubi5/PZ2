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

        public void hideMagician()
        {
            //Magician hide
            label2.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            comboBox2.Visible = false;
        }

        public void hideSoldier()
        {
            //Soldier hide
            label3.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
        }

        public void hideOrc()
        {
            //Orc hide
            label4.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox3.Visible = false;
        }

        public void hideDragon()
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
        }

        

        public Boolean checkIfDragonTextboxesAreNull()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkIfMagicianTextboxesAreNull()
        {
            if (textBox4.Text == "" || textBox5.Text == "" || comboBox2.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkIfSoldierTextboxesAreNull()
        {
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkIfOrcTextboxesAreNull()
        {
            if (textBox9.Text == "" || textBox10.Text == "" || comboBox3.Text == "")
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
            this.hideMagician();

            //Soldier hide
            this.hideSoldier();

            //Orc hide
            this.hideOrc();

            foreach (string item in Enum.GetNames(typeof(DragonSpicies)))
            {
                comboBox1.Items.Add(item);
            }

        }

        public void ShowMagicianControl()
        {
            //Dragon hide
            this.hideDragon();

            //Soldier hide
            this.hideSoldier();

            //Orc hide
            this.hideOrc();

            foreach (string item in Enum.GetNames(typeof(MagicianSpicies)))
            {
                comboBox2.Items.Add(item);
            }
        }

        public void ShowSoldierControl()
        {
            //Dragon hide
            this.hideDragon();


            //Orc hide
            this.hideOrc();

            //Magician hide
            this.hideMagician();

        }

        public void ShowOrcControl()
        {
            //Dragon hide
            this.hideDragon();

            //Soldier hide
            this.hideSoldier();

            //Magician hide
            this.hideMagician();


            foreach (string item in Enum.GetNames(typeof(OrcTribe)))
            {
                comboBox3.Items.Add(item);
            }
        }

        private void AddingCharacters_Load(object sender, EventArgs e)
        {
            if (characterToModify == "Dragon")
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
            //dragon adding
            if (label1.Visible && !this.checkIfDragonTextboxesAreNull())
            {
                Dragon dragon = new Dragon();
                dragon.Name = textBox1.Text;
                dragon.Wingspan = (textBox2.Text);

                DragonSpicies typeOftheDragon = (DragonSpicies)Enum.Parse(typeof(DragonSpicies), comboBox1.Text);
                foreach (DragonSpicies enum_ in Enum.GetValues(typeof(DragonSpicies)))
                {
                    if (enum_.Equals(typeOftheDragon))
                    {
                        dragon.dragonSpicies = enum_;
                    }
                }
                dragon.Power = int.Parse(textBox3.Text);
                dragon.UserID = LoggedUser.ID;

                ContextActions.addDragonToDB(dragon);

                MessageBox.Show($"You successfully added your {dragon.Name} into" +
                    $" world of magic!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (label1.Visible && this.checkIfDragonTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //magician adding
            if (label2.Visible && !this.checkIfMagicianTextboxesAreNull())
            {
                Magician magician = new Magician();

                magician.Name = textBox4.Text;
                magician.Power = int.Parse(textBox5.Text);

                MagicianSpicies typeOftheMagician = (MagicianSpicies)Enum.Parse(typeof(MagicianSpicies), comboBox2.Text);
                foreach (MagicianSpicies enum_ in Enum.GetValues(typeof(MagicianSpicies)))
                {
                    if (enum_.Equals(typeOftheMagician))
                    {
                        magician.magicianSpicies = enum_;
                    }
                }
                magician.UserID = LoggedUser.ID;

                ContextActions.addMagicianToDB(magician);

                MessageBox.Show($"You successfully added your {magician.Name} into" +
                $" world of magic!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            if (label2.Visible && this.checkIfMagicianTextboxesAreNull())
             {
              MessageBox.Show("Fill all the blanks", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            //soldiers adding
            if (label3.Visible && !this.checkIfSoldierTextboxesAreNull())
            {
                Soldier soldier = new Soldier();

                soldier.Name = textBox6.Text;
                soldier.Power = int.Parse(textBox7.Text);
                soldier.Swordname = textBox8.Text;
                soldier.UserID = LoggedUser.ID;

                ContextActions.addSoldierToDB(soldier);

                MessageBox.Show($"You successfully added your {soldier.Name} into" +
                $" world of magic!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (label3.Visible && this.checkIfSoldierTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //orc adding
            if (label4.Visible && !this.checkIfOrcTextboxesAreNull())
            {
                Orc orc = new Orc();

                orc.Name = textBox9.Text;
                orc.Power = int.Parse(textBox10.Text);

                OrcTribe typeOftheOrc = (OrcTribe)Enum.Parse(typeof(OrcTribe), comboBox3.Text);

                foreach (OrcTribe enum_ in Enum.GetValues(typeof(OrcTribe)))
                {
                    if (enum_.Equals(typeOftheOrc))
                    {
                        orc.OrcTribe = enum_;
                    }
                }
                orc.UserID = LoggedUser.ID;

                ContextActions.addOrcToDB(orc);

                MessageBox.Show($"You successfully added your {orc.Name} into" +
                $" world of magic!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (label4.Visible && this.checkIfOrcTextboxesAreNull())
            {
                MessageBox.Show("Fill all the blanks", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

