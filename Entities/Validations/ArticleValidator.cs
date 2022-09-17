using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validations
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Etiket Boş olamaz");
        }
    }
}
