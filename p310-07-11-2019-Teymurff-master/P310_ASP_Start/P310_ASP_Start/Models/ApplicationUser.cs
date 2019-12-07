using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P310_ASP_Start.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(256)]
        public string Firstname { get; set; }

        [StringLength(256)]
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }

        [StringLength(256)]
        public string LivingPlace { get; set; }
    }
}
