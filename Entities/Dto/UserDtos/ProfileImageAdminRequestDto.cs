using Microsoft.AspNetCore.Http;

namespace Entities.Dto.UserDtos
{
    public class ProfileImageAdminRequestDto
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageName { get; set; }

    }
}
