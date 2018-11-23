using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectChallenge.Models
{
    [Table("Tokens")]
    public class Token
    {

        [Column("TokenId")]
        public int TokenId { get; set; }
        [Column("Token")]
        public string TokenCreate { get; set; }
        [Column("ValideDate")]
        public DateTime ValideDate { get; set; }
       
        [Column("UserId")]
        public int UserId { get; set; }
      

       
        public string CreateToken()
        {

            return string.Concat(Guid.NewGuid().ToString(), ValideDate.Day.ToString(), ValideDate.Month.ToString(),
                                 ValideDate.Year.ToString(), Guid.NewGuid().ToString());
        }
    }
}
