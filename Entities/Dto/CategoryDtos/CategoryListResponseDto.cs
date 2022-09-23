using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.CategoryDtos
{
   public class CategoryListResponseDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int ArticleCount { get; set; }
    }
}
