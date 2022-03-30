using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderingWebsite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity  { get;set;    }
        public string? ProductPicture { get; set; }



    }
}
