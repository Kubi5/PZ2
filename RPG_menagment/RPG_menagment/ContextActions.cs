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

        public static void changeUserPassword(string email, string password)
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

            foreach (string pas in pass)
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

        public static void addCaveToDB(Cave cave)
        {
            context.Caves.Add(cave);


            context.SaveChanges();

        }
        public static void addTowerToDB(Tower tower)
        {
            context.Towers.Add(tower);


            context.SaveChanges();
        }
        public static void addRiverToDB(River river)
        {
            context.Rivers.Add(river);


            context.SaveChanges();
        }
        public static void addForestToDB(Forest forest)
        {
            context.Forests.Add(forest);


            context.SaveChanges();
        }


        public static int getUserID(string email)
        {
            var getid = context.Users.Where(x => x.Email == email)
                .Select(x => x.UserID).FirstOrDefault();

            return getid;
        }

        public static List<string> getTOP5()
        {
            var top5 = context.FightingCharacters
                .OrderByDescending(x => x.Power)
                .ThenBy(x => x.Name)
                .Take(5)
                .Select(x => x.Power + " -- " + x.Name + " -- " + x.UserName)
                .ToList();

            return top5;
        }

        public static List<string> showLatestUpdate(int howmany)
        {
            var list = new List<string>();

            var items = context.FightingCharacters
                .OrderByDescending(x => x.FightingCharacterID)
                .Take(howmany)
                .Select(x => x)
                .ToList();

            foreach (var item in items)
            {
                list.Add(item.ToString());
            }

            return list;
        }

        public static int numbersOfRowsInFightersDB()
        {
            return (int)context.FightingCharacters.Count();
        }

        

        public static List<string> getAllUsersCharacters()
        {
            List<string> userItems = new List<string>();

            var user = context.Users.Find(LoggedUser.ID);


            foreach (var item in user.Dragons)
            {
                userItems.Add(item.ToString());
            }
            foreach (var item in user.Magicians)
            {
                userItems.Add(item.ToString());
            }
            foreach (var item in user.Soldiers)
            {
                userItems.Add(item.ToString());
            }
            foreach (var item in user.Orcs)
            {
                userItems.Add(item.ToString());
            }

            return userItems;

        }

        public static List<string> getAllUsersNature()
        {
            List<string> userItems = new List<string>();

            var user = context.Users.Find(LoggedUser.ID);


            foreach (var item in user.Caves)
            {
                userItems.Add(item.ToString());
            }
            foreach (var item in user.Rivers)
            {
                userItems.Add(item.ToString());
            }
            foreach (var item in user.Towers)
            {
                userItems.Add(item.ToString());
            }
            foreach (var item in user.Forests)
            {
                userItems.Add(item.ToString());
            }

            return userItems;

        }
        
        public static void setUsersItems()
        {


            var dragons = context.Dragons
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x)
                .ToList();

            foreach (Dragon dragon in dragons)
            {
                context.Users.Find(LoggedUser.ID).Dragons.Add(dragon);
            }

            var magicians = context.Magicians
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (Magician magician in magicians)
            {
                context.Users.Find(LoggedUser.ID).Magicians.Add(magician);
            }

            var soldiers = context.Soldiers
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (Soldier soldier in soldiers)
            {
                context.Users.Find(LoggedUser.ID).Soldiers.Add(soldier);
            }

            var orcs = context.Orcs
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (Orc orc in orcs)
            {
                context.Users.Find(LoggedUser.ID).Orcs.Add(orc);
            }

            var caves = context.Caves
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (Cave cave in caves)
            {
                context.Users.Find(LoggedUser.ID).Caves.Add(cave);
            }

            var rivers = context.Rivers
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (River river in rivers)
            {
                context.Users.Find(LoggedUser.ID).Rivers.Add(river);
            }

            var towers = context.Towers
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (Tower tower in towers)
            {
                context.Users.Find(LoggedUser.ID).Towers.Add(tower);
            }

            var forests = context.Forests
                .Where(x => x.UserID == LoggedUser.ID)
                .Select(x => x);

            foreach (Forest forest in forests)
            {
                context.Users.Find(LoggedUser.ID).Forests.Add(forest);
            }

        }

        public static void clearUsersItems()
        {
            context.Users.Find(LoggedUser.ID).Dragons = new List<Dragon>();
            context.Users.Find(LoggedUser.ID).Magicians = new List<Magician>();
            context.Users.Find(LoggedUser.ID).Soldiers = new List<Soldier>();
            context.Users.Find(LoggedUser.ID).Orcs = new List<Orc>();
            context.Users.Find(LoggedUser.ID).Towers = new List<Tower>();
            context.Users.Find(LoggedUser.ID).Rivers = new List<River>();
            context.Users.Find(LoggedUser.ID).Caves = new List<Cave>();
            context.Users.Find(LoggedUser.ID).Forests = new List<Forest>();


            context.Users.Find(LoggedUser.ID).Dragons.Clear();
            context.Users.Find(LoggedUser.ID).Soldiers.Clear();
            context.Users.Find(LoggedUser.ID).Orcs.Clear();
            context.Users.Find(LoggedUser.ID).Magicians.Clear();
            context.Users.Find(LoggedUser.ID).Caves.Clear();
            context.Users.Find(LoggedUser.ID).Forests.Clear();
            context.Users.Find(LoggedUser.ID).Rivers.Clear();
            context.Users.Find(LoggedUser.ID).Towers.Clear();

        }
        

        public static void DeleteItem(string itemToDelete)
        {
            var dragon = context.Dragons.Where(x => x.Name == itemToDelete).Select(x => x.DragonID).FirstOrDefault();
            if (!dragon.Equals(0))
            {
                int id = context.FightingCharacters.Where(x => x.Name == itemToDelete).Select(x => x.FightingCharacterID).FirstOrDefault();

                context.Dragons.Remove(context.Dragons.Find(dragon));
                context.Users.Find(LoggedUser.ID).Dragons.Remove(context.Dragons.Find(dragon));
                context.FightingCharacters.Remove(context.FightingCharacters.Find(id));

                context.SaveChanges();
            }
            
        }

        
    }
}
