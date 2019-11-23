using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class Basket
    {
        public int ID { get; set; }

   
        public int userID { get; set; }
 
        public int productID { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

    }
}
