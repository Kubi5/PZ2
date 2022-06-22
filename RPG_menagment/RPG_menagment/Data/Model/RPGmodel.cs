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
            public int UserID { get; set; }
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

            public IList<Dragon> Dragons {get ; set;}
            public IList<Soldier> Soldiers {get ; set;}
            public IList<Magician> Magicians {get ; set;}
            public IList<Orc> Orcs {get ; set;}
            public IList<Cave> Caves {get ; set;}
            public IList<Forest> Forests {get ; set;}
            public IList<River> Rivers {get ; set;}
            public IList<Tower> Towers {get ; set;}

            public override string ToString()
            {
                return $"ID: {UserID}, Email: -{Email}-, Nickname: {Nickname}";
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
            public override string ToString()
            {
                return $"Character Name :{this.Name} \n" +
                    $"Power :{this.Power} \n" +
                    $"Owner: {this.UserName}";
            }

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

            public override string ToString()
            {
                return $"-{this.Name}- Wingspan: {this.Wingspan} Spicies:{this.dragonSpicies} Power:{this.Power}";
            }


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

            public override string ToString()
            {
                return $"-{this.Name}- Power:{this.Power} Spiecies:{this.magicianSpicies}";
            }
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

            public override string ToString()
            {
                return $"-{this.Name}- Power:{this.Power} Sword name:{this.Swordname}";
            }
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

            public override string ToString()
            {
                return $"-{this.Name}- Power:{this.Power} Tribe: {this.OrcTribe}";
            }
        }

        public class Cave
        {
            public int CaveID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Area { get; set; }

            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }

            public override string ToString()
            {
                return $"-{this.Name}- Area:{this.Area}";
            }

        }

        public class Tower
        {
            public int TowerID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Height { get; set; }
            [Required]
            public string Material { get; set; }

            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }

            public override string ToString()
            {
                return $"-{this.Name}- Height:{this.Height} Material:{this.Material}";
            }

        }

        public class River
        {
            public int RiverID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Length { get; set; }

            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }

            public override string ToString()
            {
                return $"-{this.Name}- Lenght:{this.Length}";
            }

        }

        public class Forest
        {
            public int ForestID { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Area { get; set; }

            [ForeignKey("UserID")]
            public User user { get; set; }
            public int UserID { get; set; }

            public override string ToString()
            {
                return $"-{this.Name}- Area:{this.Area}";
            }
        }


    }
}
