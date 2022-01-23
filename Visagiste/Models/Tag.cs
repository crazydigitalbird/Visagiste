using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Visagiste.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<PhotoTagJunction> PhotoTags { get; set; }
    }
}
