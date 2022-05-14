using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPG_menagment
{
    internal class SafetySystem
    {
        public static bool isEmailValid(string email)
        {
            return Regex.IsMatch(email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        } 

        public static bool isPasswordValid(string password)
        {
            String regexPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            Regex r = new Regex(regexPattern, RegexOptions.IgnoreCase);
            return r.Match(password).Success;
        }

        public static bool arePasswordtheSame(string password1,string password2)
        {
            return password1.Equals(password2);
        }

        

    }
}
