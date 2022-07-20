using System.ComponentModel.DataAnnotations;

namespace Petfy.Domain.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
