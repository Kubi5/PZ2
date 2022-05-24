using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstControl
{
    internal class Checking
    {

        public static Boolean LengthControl(string password,int number)
        {
            if(password.Length >= number)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public static Boolean SpecialCharacterControl(string password, char[] list)
        {
            
            foreach (var item in list)
            {
                if (password.Contains(item))
                {
                    return true;
                }
            }
            return false;
            
        }

        public static Boolean OneCapitalLetterControl(string password)
        {
            var passList = password.ToCharArray();

            foreach(char item in passList)
            {
                if (Char.IsUpper(item))
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean OneDigitControl(string password)
        {
            var passList = password.ToCharArray();

            foreach (char item in passList)
            {
                if (Char.IsDigit(item))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
