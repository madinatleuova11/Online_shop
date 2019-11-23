using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class Address: IValidatableObject
    {
        [Key]
        [ForeignKey("User")]
        public int userID { get; set; }
        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }


        [Required]
        [Remote(action: "IsValidCountry", controller: "Addresses")]
        public string Country { get; set; }

        public virtual User User { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (State.Length < 5)
                yield return new ValidationResult("Input 'State' should be at least 5");
        }
    }
}
