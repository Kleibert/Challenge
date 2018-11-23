using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectChallenge.Models
{
    [Table("Users")]
    public class User
    {  
        [Column("Userid")]
        public int Userid { get; set; }
        [Required(ErrorMessage ="Required")]
        [RegularExpression(@"(^[1 - 3]{0, 4}$)",ErrorMessage ="Value not valide")]
        [Column("Username")]
        public string Username { get; set; }

        [RegularExpression(@"(^[1 - 3]{0, 4}$)", ErrorMessage = "Value not valide")]
        [Column("Password")]
        public string Password { get; set; }

        [Column("ActiveState")]
        public Boolean ActiveState { get; set; }
    }
}
