using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(h => h.HeadingName).NotEmpty().WithMessage("Başlık adı boş geçilemez.");
            RuleFor(h => h.HeadingDate).NotEmpty().WithMessage("Başlık tarihi boş geçilemez.");
            RuleFor(h => h.HeadingName).MinimumLength(2).WithMessage("Başlık adı en az 2 karakter içermeli.");
        }
    }
}
