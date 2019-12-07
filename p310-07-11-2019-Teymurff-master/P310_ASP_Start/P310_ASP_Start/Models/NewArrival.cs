using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace P310_ASP_Start.Models
{
    public class NewArrival
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Image { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }
    }
}
