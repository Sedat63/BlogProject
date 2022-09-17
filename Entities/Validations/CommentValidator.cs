using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olamaz");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Tam ad boş olamaz");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Metin boş olamaz");
        }
    }
}
