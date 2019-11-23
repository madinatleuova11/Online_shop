using IShop.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class User
    {
        [Display(Name = "UserID")]
        public int userID { get; set; }

        [Display(Name = "FullName")]
        [Required]
        [CheckIfEnteredBothName(ErrorMessage = "You should Enter First Name and Last Name")]
        public string FullName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Card")]
        public int cardID { get; set; }

        public virtual DiscountCard discountCard { get; set; }
        public virtual Address Address { get; set; }


    }
}
