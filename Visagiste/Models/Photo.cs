using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visagiste.Models
{
    public class Photo
    {
        public long Id { get; set; }

        public string Url { get; set; }

        public List<string> Tags { get; set; }
    }
}
