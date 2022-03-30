using System.ComponentModel.DataAnnotations;

namespace GoogleAuthentication.Models
{
    public class Cart
    {
        [Key]
        public int? CartId { get; set; }

        public int Quantity { get; set; }
    }
}
