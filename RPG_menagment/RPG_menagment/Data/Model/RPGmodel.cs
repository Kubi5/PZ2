using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            public int FightingCharacterID { get; set; }
            [Required]
            public int Power { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string UserName { get; set; }

        }

        public enum DragonSpicies
        {
            Fiery, Stone, Bloody
        };

        public class Dragon
        {
            public int DragonID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Wingspan { get; set; }
            
            public DragonSpicies dragonSpicies { get; set; }

            [Required]
            public int Power { set; get; }

            /*
            [ForeignKey("FightingCharacterID")]
            public FightingCharacter fightingCharacter { get; set; }
            public int FightingCharacterID { get; set; }
            */
            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }



        }

        public enum MagicianSpicies
        {
            Old, Elf, Dwarf
        };

        public class Magician
        {
            public int MagicianID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Power { get; set; }

            public MagicianSpicies magicianSpicies { get; set; }
            /*
            [ForeignKey("FightingCharacterID")]
            public FightingCharacter fightingCharacter { get; set; }
            public int FightingCharacterID { get; set; }
            */
            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }
        }

        public class Soldier
        {
            public int SoldierID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]

            public int Power { get; set; }
            [Required]

            public string Swordname { get; set; }
            /*
            [ForeignKey("FightingCharacterID")]
            public FightingCharacter fightingCharacter { get; set; }

            public int FightingCharacterID { get; set; }
            */

            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }
        }

        public enum OrcTribe
        {
            BlackRock, BlackTooth, Frostwolf
        }

        public class Orc
        {
            public int OrcID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Power { get; set; }

            public OrcTribe OrcTribe { get; set; }
            /*
            [ForeignKey("FightingCharacterID")]
            public FightingCharacter fightingCharacter { get; set; }
            public int FightingCharacterID { get; set; }
            */
            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }
        }

        public class Cave
        {
            public int CaveID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]

            public float Area { get; set; }

        }

        public class Tower
        {
            public int TowerID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public float Height { get; set; }
            [Required]
            public string Material { get; set; }

        }

        public class River
        {
            public int RiverID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public float Length { get; set; }

        }

        public class Forest
        {
            public int ForestID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public float Area { get; set; }
        }


    }
}
