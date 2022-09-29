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
            RuleFor(x => x.Title).NotEmpty().WithMessage("Makale Başlığı zorunludur");
            RuleFor(x => x.ArticleCategories).NotNull().WithMessage("Kategori Zorunludur");
            RuleFor(x => x.ArticleTags).NotNull().WithMessage("Kategori Zorunludur");
            RuleFor(x => x.ContentText).NotEmpty().WithMessage("Text İçerik zorunludur");
            RuleFor(x => x.ContentHtml).NotEmpty().WithMessage("Html İçerik zorunludur");

            //RuleFor(x => x.PublishDate).NotEmpty().WithMessage("İçerik zorunludur");


        }
    }
}
