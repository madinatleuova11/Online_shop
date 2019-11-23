using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Utilities
{
    public class CheckIfEnteredBothName: ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            //myString.Any(Char.IsWhiteSpace)

             return value.ToString().Contains(" ");
                       
        }
    }
}
