using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AppUserValidator : AbstractValidator<AppUser>
	{
		public AppUserValidator()
		{
			RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Yazar adı ve soy adı boş geçilemez.");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Yazar mail adresi boş geçilemez.");
			RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Şifre boş geçilemez.");
			RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("En az 2 karakter isim girmeniz gerekmektedir.");
			RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("En fazla 50 karakter isim girebilirsiniz.");
		}
	}
}
