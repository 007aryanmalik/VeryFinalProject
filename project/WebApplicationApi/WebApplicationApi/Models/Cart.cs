using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingWebsite.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }


        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int ProductId { get; set; }

       [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public UserLogin? UserLogin { get; set; }
        public int UserId { get; set; }
    }
}
