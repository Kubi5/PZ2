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
            public string email { get; set; }
            [Required]
            public string password { get; set; }
            public string nickname { get; set; }
            public string role { get; set; }

            public User()
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                role = "logged";
                nickname = $"Guest{randomNumber}";
            }
        }

    }
}
