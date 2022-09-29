using Microsoft.AspNetCore.Http;

namespace Entities.Dto.UserDtos
{
    public class ProfileAdminRequestDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}




