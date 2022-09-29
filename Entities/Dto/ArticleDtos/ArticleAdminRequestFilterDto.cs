using Entities.Abstract;
using System;

namespace Entities.Dto.ArticleDtos
{
    public class ArticleAdminRequestFilterDto : PaginationParams
    {
        public int? TagId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? PublishDate { get; set; }
        public string ArticleTitle { get; set; }
        public bool IsOrderBy { get; set; }
        public string ColumnNameForOrder { get; set; }
    }
}
