using System.ComponentModel.DataAnnotations;

namespace WebIdentity.Models
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir!")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Lütfen bir email formatı giriniz!")]
        [Required(ErrorMessage = "Email gereklidir!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir!")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Şifreler eşleşmiyor!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Cinsiyet gereklidir!")]
        public string Gender { get; set;}
    }
}
