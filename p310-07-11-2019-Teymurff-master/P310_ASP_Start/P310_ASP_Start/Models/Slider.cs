using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace P310_ASP_Start.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Başlıq mütləq doldurulmalıdır")]
        [StringLength(100)]
        [MinLength(5, ErrorMessage = "Başlıq ən azı {1} simvol uzunluğunda olmaldır")]
        [Display(Name = "Başlıq")]
        public string Title { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "İkinci dərəcəli başlıq")]
        [MinLength(10, ErrorMessage = "İkinci dərəcəli başlıq ən azı {1} simvol uzunluğunda olmaldır")]
        public string SubTitle { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
