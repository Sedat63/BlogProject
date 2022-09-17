using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto.CategoryDtos
{
    public class CategoryAddOrUpdateRequestDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
