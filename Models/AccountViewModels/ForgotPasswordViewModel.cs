using System.ComponentModel.DataAnnotations;

namespace DemoApplication1.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
