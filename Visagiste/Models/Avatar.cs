using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Visagiste.Models
{
    public class Avatar
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        internal void Update(IFormFile avatarFile)
        {
            Delete();
            Save(avatarFile);
        }

        private void Save(IFormFile avatarFile)
        {
            string ext = Path.GetExtension(avatarFile.FileName);
            string avatarFullName = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images", $"author{ext}");
            using (FileStream fs = new FileStream(avatarFullName, FileMode.OpenOrCreate))
            {
                avatarFile.CopyTo(fs);
            }
        }

        private void Delete()
        {
            string avatarFullName = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images", Path.GetFileName(Url));
            File.Delete(avatarFullName);
        }
    }
}