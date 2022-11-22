using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoreProje.Models
{
    public class AddProfileImage
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad giriniz.")]
        public string nameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz.")]
        public string Password { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail giriniz.")]
        public IFormFile imageUrl { get; set; }
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz.")]
        public string UserName { get; set; }
    }
}
