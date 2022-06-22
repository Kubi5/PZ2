using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstControl
{
    public partial class PasswordValidator: UserControl
    {
        private int numberOfBigLetters = 8;
        private char[] specialCharacterList = { '/', '?', '!' };
        Boolean showNumberLetters = true;
        Boolean showSpecialChars = true;
        Boolean showCapitalLet = true;
        Boolean showDigit = true;
        

        [
        Category("Big letters needed") 
        ]
        public int Bigletters
        {
            get {
                return numberOfBigLetters;
            }

            set {
                numberOfBigLetters = value;
                label7.Text = $"at least {numberOfBigLetters} characters provided";
            }

        }
        [
        Category("Special character list")
        ]
        public char[] charList
        {
            get
            {
                return specialCharacterList;
            }

            set
            {
                specialCharacterList = value;
            }

        }
        [
        Category("Show min. numbers provided")
        ]
        public Boolean ShowMinNumbers
        {
            get
            {
                return showNumberLetters;
            }

            set
            {
                showNumberLetters = value;
                if(value == true)
                {
                    label3.Visible = true;
                    label7.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                    label7.Visible = false;
                }
            }

        }
        [
        Category("Show special characters")
        ]
        public Boolean ShowSpecialChars
        {
            get
            {
                return showSpecialChars;
            }

            set
            {
                showSpecialChars = value;
                if (value == true)
                {
                    label4.Visible = true;
                    label8.Visible = true;
                }
                else
                {
                    label4.Visible = false;
                    label8.Visible = false;
                }
            }

        }
        [
        Category("Show Capital Letters")
        ]
        public Boolean ShowCapitalLetters
        {
            get
            {
                return showCapitalLet;
            }

            set
            {
                showCapitalLet = value;
                if (value == true)
                {
                    label5.Visible = true;
                    label9.Visible = true;
                }
                else
                {
                    label5.Visible = false;
                    label9.Visible = false;
                }
            }

        }
        [
        Category("Show Digit")
        ]
        public Boolean ShowDigit
        {
            get
            {
                return showDigit;
            }

            set
            {
                showDigit = value;
                if (value == true)
                {
                    label6.Visible = true;
                    label10.Visible = true;
                }
                else
                {
                    label6.Visible = false;
                    label10.Visible = false;
                }
            }

        }



        public PasswordValidator()
        {
            InitializeComponent();
        }

        public void passwordControl(string textProvided) { 
            
            if (Checking.LengthControl(textProvided,Bigletters))
            {
                label3.BackColor = Color.Green;
            }
            else
            {
                label3.BackColor = Color.Red;
            }

            if (Checking.SpecialCharacterControl(textProvided,charList))
            {
                label4.BackColor = Color.Green;
            }
            else
            {
                label4.BackColor = Color.Red;
            }

            if (Checking.OneCapitalLetterControl(textProvided))
            {
                label5.BackColor = Color.Green;
            }
            else
            {
                label5.BackColor = Color.Red;
            }

            if (Checking.OneDigitControl(textProvided))
            {
                label6.BackColor = Color.Green;
            }
            else
            {
                label6.BackColor = Color.Red;
            }
            

        }

        private void PasswordValidator_Load(object sender, EventArgs e)
        {
            //label7.Text = $"at least {numberOfBigLetters} characters provided";
        }
    }
}
