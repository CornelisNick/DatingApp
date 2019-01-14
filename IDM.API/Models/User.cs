using System.ComponentModel.DataAnnotations;

namespace IDM.API.Models
{
    public partial class User
    {
        public string Id { get; set; }

        [Required]
        public string IssuerId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}