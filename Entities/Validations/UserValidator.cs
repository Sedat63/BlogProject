using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage($"{nameof(User.Username)} zorunludur");
            RuleFor(x => x.Title).NotEmpty().WithMessage($"{nameof(User.Title)} zorunludur");
            RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(User.Password)} zorunludur");
            RuleFor(x => x.Description).NotEmpty().WithMessage($"{nameof(User.Description)} zorunludur");
            RuleFor(x => x.FullName).NotEmpty().WithMessage($"{nameof(User.FullName)} zorunludur");
        }
    }
}
