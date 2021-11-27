using System.ComponentModel.DataAnnotations;

namespace Visagiste.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string InstagramUrl { get; set; }

        [Url]
        public string VkUrl { get; set; }
    }
}