using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P310_ASP_Start.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products{ get; set; }
    }
}
