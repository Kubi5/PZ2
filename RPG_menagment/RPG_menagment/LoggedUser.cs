using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_menagment
{
    internal class LoggedUser
    {
        public static int ID { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; }

        public static string Nickname { get; set; }

        public static void InitiatingTheUser(string email, string role, string nickname)
        {
            ID = ContextActions.getUserID(email);
            Email = email;
            Role = role;
            Nickname = nickname;
        }


    }

}
