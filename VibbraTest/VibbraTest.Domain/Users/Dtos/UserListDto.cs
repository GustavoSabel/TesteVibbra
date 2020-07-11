using System.Collections.Generic;

namespace VibbraTest.Domain.Users.Dtos
{
    public class UserListDto
    {
        public UserListDto(List<UserDto> users)
        {
            Users = users;
        }

        public int Count => Users.Count;
        public List<UserDto> Users { get; set; }
    }
}
