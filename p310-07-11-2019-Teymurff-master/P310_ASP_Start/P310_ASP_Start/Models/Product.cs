using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace P310_ASP_Start.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool HasDiscount { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [NotMapped]
        public IFormFile Photo{ get; set; }

        public bool IsNew {
            get {
                return (DateTime.Now - CreatedAt).Days < 14;
            }
        }
    }
}
