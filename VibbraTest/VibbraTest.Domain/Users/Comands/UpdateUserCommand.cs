﻿namespace VibbraTest.Domain.Users
{
    public class UpdateUserCommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
    }
}
