using P310_ASP_Start.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P310_ASP_Start.ViewModels
{
    public class UserRegisterModel
    {
        [Required]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public static implicit operator ApplicationUser(UserRegisterModel registerModel)
        {
            return new ApplicationUser
            {
                Firstname = registerModel.Firstname,
                Lastname = registerModel.Lastname,
                Email = registerModel.Email,
                UserName = registerModel.Username
            };
        }
    }
}
