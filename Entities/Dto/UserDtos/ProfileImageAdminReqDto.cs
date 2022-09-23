using Microsoft.AspNetCore.Http;

namespace Entities.Dto.UserDtos
{
    public class ProfileImageAdminReqDto
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }

    }
}
