namespace VibbraTest.Domain.Users.Dtos
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
