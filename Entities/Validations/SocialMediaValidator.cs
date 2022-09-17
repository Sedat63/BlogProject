using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validations
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon zorunludur");
            RuleFor(x => x.Link).NotEmpty().WithMessage("Link zorunludur");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Etiket zorunludur");
            RuleFor(x => x.ClassName).NotEmpty().WithMessage("Class ismi zorunludur");

        }
    }
}
