using System.Threading.Tasks;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Exceptions;

namespace VibbraTest.Domain.Users
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> InsertAsync(InsertUserCommand command)
        {
            var user = new User
            {
                Nome = command.Nome,
                CompanyName = command.CompanyName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Cnpj = command.Cnpj,
                Password = command.Password,
            };
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, UpdateUserCommand command)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                throw new EntityNotFoundException("Usuário não encontrado");

            user.Nome = command.Nome;
            user.PhoneNumber = command.PhoneNumber;
            user.Email = command.Email;
            user.CompanyName = command.CompanyName;
            user.Cnpj = command.Cnpj;
            if (command.Password != null)
                user.Password = command.Password;

            await _userRepository.SaveChangesAsync();
            return user;
        }
    }
}
