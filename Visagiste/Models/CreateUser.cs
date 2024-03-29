﻿using System.ComponentModel.DataAnnotations;

namespace Visagiste.Models
{
    public class CreateUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }   

        [Required]
        public string Password { get; set; }
    }
}
