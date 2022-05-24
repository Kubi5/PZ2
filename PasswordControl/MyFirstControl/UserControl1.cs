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
            
    }
}
