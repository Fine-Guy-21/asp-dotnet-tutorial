using System.ComponentModel.DataAnnotations;

namespace World_of_Soccer.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get;set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
