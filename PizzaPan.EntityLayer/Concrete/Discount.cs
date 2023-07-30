using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.EntityLayer.Concrete
{
   public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}
