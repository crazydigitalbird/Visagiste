﻿using System.Collections.Generic;

namespace Visagiste.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PhotoTagJunction> PhotoTags { get; set; }
    }
}
