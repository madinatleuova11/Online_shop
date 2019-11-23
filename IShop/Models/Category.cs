using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        [Required]

        public string categoryName { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        [Range(1, 100, ErrorMessage = "Enter number between 1 to 100")]
        public int Quantity { get; set; }
 
        public virtual ICollection<Product> Products { get; set; }

    }
}
