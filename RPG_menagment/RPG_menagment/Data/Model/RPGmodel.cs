using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace RPG_menagment.Data.Model
{
    internal class RPGmodel
    {
        public class User
        {
            public int UserID
            { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            public string Nickname { get; set; }
            public string Role { get; set; }

            public User()
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                Role = "logged";
                Nickname = $"Guest{randomNumber}";
            }
        }

        public class FightingCharacter
        {
            public int CharacterID { get; set; }
            public int Power { get; set; }
            public string Name { get; set; }

            public string UserName { get; set; }

        }

        //TODO: pomyslec jak wyswietlac wszystkie elementy dodane w apce
        public class LandscapeElements
        {
            public int ElementID { get; set; }

        }

        public class Dragon
        {
            public int DragonID { get; set; }
            public string Name { get; set; }

            public float Wingspan { get; set; }

            public enum Spiecies
            {
                Fiery, Stone, Bloody
            };

            public int Power { set; get; }

            public int FighterID { get; set; }
        }

        public class Magician
        {
            public int MagicianID { get; set; }
            public string Name { get; set; }

            public int Power { get; set; }

            public enum Spiecies
            {
                Old, Elf, Dwarf
            };


            public int FighterID { get; set; }
        }

        public class Soldier
        {
            public int SoldierID { get; set; }
            public string Name { get; set; }

            public int Power { get; set; }

            public string Swordname { get; set; }


            public int FighterID { get; set; }
        }

        public class Orc
        {
            public int OrcID { get; set; }
            public string Name { get; set; }

            public int Power { get; set; }

            public enum Tribe
            {
                BlackRock, BlackTooth, Frostwolf
            }

            public int FighterID { get; set; }
        }

        public class Cave
        {
            public int CaveID { get; set; }
            public string Name { get; set; }

            public float Area { get; set; }

        }

        public class Tower
        {
            public int TowerID { get; set; }
            public string Name { get; set; }
            public float Height { get; set; }
            public string Material { get; set; }

        }

        public class River
        {
            public int RiverID { get; set; }
            public string Name { get; set; }
            public float Length { get; set; }

        }

        public class Forest
        {
            public int ForestID { get; set; }
            public string Name { get; set; }
            public float Area { get; set; }
        }


    }
}
