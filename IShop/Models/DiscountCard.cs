using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class DiscountCard
    {
        [Key]
        [Display(Name = "Card ID")]
        public int CardID { get; set; }

        [Display(Name = "Card Type")]
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Card Type cannot be longer than 40 characters and less than 3 characters")]
        public string type { get; set; }

    }
}
