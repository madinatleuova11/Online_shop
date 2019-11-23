using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class Product
    {
        public int productID { get; set; }

        [Required]
        [Display(Name = "Prodcut Name")]
        [StringLength(50, ErrorMessage = "Product Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Prodcut Price")]
        public double Price { get; set; }
        [Required]
       // [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Prodcut Image")]
        public string Image { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime productDate { get; set; }

        public int categoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
