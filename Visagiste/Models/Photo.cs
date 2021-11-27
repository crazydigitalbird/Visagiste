using System.Collections.Generic;

namespace Visagiste.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<string> Tags { get; set; }
    }
}
