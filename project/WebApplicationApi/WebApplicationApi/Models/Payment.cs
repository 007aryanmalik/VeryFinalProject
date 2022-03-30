using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodOrderingWebsite.Models
{
    public class Payment
    {    
            [Key]
            public int PaymentID { get; set; }

            public string? Name { get; set; }
            

            //public int? FKUserID { get; set; }
            //[ForeignKey("FKUserID")]
            //public virtual UserLogin user { get; set; }


        }
    }

