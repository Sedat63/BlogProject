using Entities.Concrete;
using FluentValidation;


namespace Entities.Validations
{
    public class SubscribeValidator : AbstractValidator<Subscribe>
    {
        public SubscribeValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Boş olamaz");
            
        }
    }
}
