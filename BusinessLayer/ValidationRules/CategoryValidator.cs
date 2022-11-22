using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını doldurdunuz.");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("Kategori adı en az 5 karakter olmalı");
            RuleFor(x => x.CategoryName).MaximumLength(25).WithMessage("Kategori adı en fazla 25 karakter olmalı");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklmasını doldurdunuz.");
            RuleFor(x => x.CategoryDescription).MaximumLength(250).WithMessage("Kategori açıklaması en fazla 250 karakter olmalı");
            RuleFor(x => x.CategoryDescription).MinimumLength(25).WithMessage("Kategori açıklaması en az 25 karakter olmalı");
        }
    }
}
