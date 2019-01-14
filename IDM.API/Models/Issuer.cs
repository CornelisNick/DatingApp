using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDM.API.Models
{
    public partial class Issuer
    { 
        public string Id { get; set; }

        [Required]
        public string IssuerName { get; set; }

        [Required]
        public string PrivateKey { get; set; }

        [Required]
        public string ProviderId { get; set; } 

        // Navigation properties (foreign key)
        public List<User> Users { get; set; }
    }
}