using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CoreProje.Models
{
    public class UserUpdateModelView
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad giriniz.")]
        public string NameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail giriniz.")]
        public string Mail { get; set; }
        public IFormFile imageUrl { get; set; }
        public IFormFile imageUrl2 { get; set; }
        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz.")]
        public string UserName { get; set; }
        public bool ChangePassword { get; set; }

    }
}
