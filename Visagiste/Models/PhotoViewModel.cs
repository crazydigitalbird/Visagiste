using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Visagiste.Models
{
    public class PhotoViewModel
    {
        [Required]
        public IFormFile FormFile { get; set; }

        public List<Tag> Tags { get; set; }

        public int[] SelectedTags { get; set; }
    }
}
