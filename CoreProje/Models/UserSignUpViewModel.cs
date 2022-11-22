using System.ComponentModel.DataAnnotations;

namespace CoreProje.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad giriniz.")]
        public string nameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail giriniz.")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz.")]
        public string UserName { get; set; }
        [Display(Name = "Onaylıyorum")]
        [Required(ErrorMessage = "Sayfamıza kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekmektedir.")]
        public bool IsAcceptTheContract { get; set; }
    }
}
