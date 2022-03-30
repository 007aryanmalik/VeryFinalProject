using System.ComponentModel.DataAnnotations;

namespace FoodOrderingWebsite.Models
{
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Name Required")]
        public string? Name { get; set; }


        [StringLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Does not Match!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not Matched")]
        public string? ConfirmPassword { get; set; }


        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public int Mobile { get; set; } 

        public string? Address { get; set; }  
    }
}
