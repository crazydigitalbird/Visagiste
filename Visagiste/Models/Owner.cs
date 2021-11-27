using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Visagiste.Models
{
    public class Owner
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public Contact Contact { get; set; }

        public Avatar Avatar { get; set; }

        public List<string> Banners { get; set; } 

        public string AboutMe { get; set; }
    }
}
