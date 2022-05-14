using RPG_menagment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RPG_menagment.Data.Model.RPGmodel;

namespace RPG_menagment
{
    internal class ContextActions
    {
        static RPGcontext context = new RPGcontext();

        public static void AddUsertoDB(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("You are part of our community now!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool IsEmailAlreadyinDatabase(string email)
        {
            var user = context.Users
                            .Where(x => x.email == email);

            return user.Any();
        }

        public static bool isEmailandPasswordinDB(string email, string password)
        {
            var userpassword = context.Users
                            .Where(x => x.email == email)
                            .Select(x => x.password);

            foreach (string var in userpassword)
            {
                return password.Equals(var);
            }

            return false;
        }
    }
}
