﻿using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web.Models
{
    public class SignInInput
    {
        [Required]
        [Display(Name ="Email Adresiniz")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }
    }
}
