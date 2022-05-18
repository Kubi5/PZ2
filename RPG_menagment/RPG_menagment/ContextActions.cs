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
                            .Where(x => x.Email == email);

            return user.Any();
        }

        public static bool isEmailandPasswordinDB(string email, string password)
        {
            var userpassword = context.Users
                            .Where(x => x.Email == email)
                            .Select(x => x.Password);

            string hashedPassword = SafetySystem.hashingPassword(password);
            
            foreach (string var in userpassword)
            {
                return hashedPassword.Equals(var);
            }

            return false;
        }

        public static string getUserRole(string email)
        {
            var list = context.Users.Where(x => x.Email == email).Select(x => x.Role);
            return list.FirstOrDefault();
        }

        public static string getUserNickname(string email)
        {
            var list = context.Users.Where(x => x.Email == email).Select(x => x.Nickname);
            return list.FirstOrDefault();
        }

        public static void changeUserPassword(string email,string password)
        {
            var user = context.Users.Where(x => x.Email == email)
                .FirstOrDefault();

            user.Password = SafetySystem.hashingPassword(password);
            context.SaveChanges();
        }

        public static bool isPasswordCorrect(string email, string password)
        {
            var pass = context.Users.Where(x => x.Email == email)
                .Select(x => x.Password);

            string hashedPassword = SafetySystem.hashingPassword(password);

            foreach(string pas in pass)
            {
                return pas.Equals(hashedPassword);
            }

            return false;
            
        }

        public static void addDragonToDB(Dragon dragon)
        {
            context.Dragons.Add(dragon);

            FightingCharacter fightingCharacter = new FightingCharacter();
            fightingCharacter.Power = dragon.Power;
            fightingCharacter.Name = dragon.Name;
            fightingCharacter.UserName = LoggedUser.Nickname;

            context.FightingCharacters.Add(fightingCharacter);

            context.SaveChanges();

        }

        public static void addMagicianToDB(Magician magician)
        {
            context.Magicians.Add(magician);

            FightingCharacter fightingCharacter = new FightingCharacter();
            fightingCharacter.Power = magician.Power;
            fightingCharacter.Name = magician.Name;
            fightingCharacter.UserName = LoggedUser.Nickname;

            context.FightingCharacters.Add(fightingCharacter);

            context.SaveChanges();

        }

        public static void addSoldierToDB(Soldier soldier)
        {
            context.Soldiers.Add(soldier);

            FightingCharacter fightingCharacter = new FightingCharacter();
            fightingCharacter.Power = soldier.Power;
            fightingCharacter.Name = soldier.Name;
            fightingCharacter.UserName = LoggedUser.Nickname;

            context.FightingCharacters.Add(fightingCharacter);

            context.SaveChanges();

        }

        public static void addOrcToDB(Orc orc)
        {
            context.Orcs.Add(orc);

            FightingCharacter fightingCharacter = new FightingCharacter();
            fightingCharacter.Power = orc.Power;
            fightingCharacter.Name = orc.Name;
            fightingCharacter.UserName = LoggedUser.Nickname;

            context.FightingCharacters.Add(fightingCharacter);

            context.SaveChanges();

        }

        public static int getUserID(string email)
        {
            var getid = context.Users.Where(x => x.Email == email)
                .Select(x => x.UserID).FirstOrDefault();

            return getid;
        }

    }
}
