using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;

namespace Visagiste.Models
{
    public class Avatar
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int OwnerId { get; set; }

        internal async Task Update(IFormFile avatarFile)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await avatarFile.CopyToAsync(ms);
                Image = ms.ToArray();
            }
        }
    }
}