using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingWebsite.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
              
        public DateTime? Order_Date { get; set; }

       // public int OrderStatus { get; set; }
        

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int ProductId { get; set; }


        [ForeignKey("UserId")]
        public UserLogin? UserLogin { get; set; }
        public int UserId { get; set; }

        
        [ForeignKey("PaymentID")]
        public Payment? Payment { get; set; }
        public int PaymentID { get; set; }
    }
}
