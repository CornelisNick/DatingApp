using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDM.API.Models
{
    public partial class Provider
    { 
        public string Id { get; set; }

        [Required]
        public string ProviderName { get; set; }

        public string Params { get; set; }

        // Navigation properties (foreign key)
        public List<Issuer> Issuers { get; set;}
    }
}