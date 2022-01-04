using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("Başlık en az 3 karakter olabilir.");
            RuleFor(x => x.HeadingName).MaximumLength(30).WithMessage("Başlık 30 karakterden fazla olamaz");
        }
      
    }
}
