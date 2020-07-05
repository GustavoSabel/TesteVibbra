using System.Threading.Tasks;
using VibbraTest.Domain.Entity;

namespace VibbraTest.Domain.Users
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task InsertAsync(InsertUserCommand user)
        {
            _userRepository.Add(new User
            {
                Nome = user.Nome,
                CompanyName = user.CompanyName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Cnpj = user.Cnpj,
                Password = user.Password,
            });
            return _userRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateUserCommand userUpated)
        {
            var user = await _userRepository.Get(id);
            user.Nome = userUpated.Nome;
            user.PhoneNumber = userUpated.PhoneNumber;
            user.Email = userUpated.Email;
            user.CompanyName = userUpated.CompanyName;

            await _userRepository.SaveChangesAsync();
        }
    }
}
