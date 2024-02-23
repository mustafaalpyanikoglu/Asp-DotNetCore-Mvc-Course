using System.ComponentModel.DataAnnotations;

namespace WebIdentity.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir!")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
