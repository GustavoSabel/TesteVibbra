﻿using System.Threading.Tasks;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Exceptions;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Users
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> InsertAsync(InsertUpdateUserCommand command)
        {
            var cnpj = new Cnpj(command.Cnpj);
            var email = new Email(command.Email);

            var userExisting = await _userRepository.GetByEmailAsync(email);
            if (userExisting != null)
                throw new BusinessException($"User already exists with e-mail {command.Email}");

            userExisting = await _userRepository.GetByEmailCnpj(cnpj);
            if (userExisting != null)
                throw new BusinessException($"User already exists with CNPJ {cnpj}");

            var user = new User
            {
                Name = command.Name,
                CompanyName = command.CompanyName,
                Email = email,
                PhoneNumber = command.PhoneNumber,
                Cnpj = cnpj,
                Password = command.Password,
            };
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, InsertUpdateUserCommand command)
        {
            var cnpj = new Cnpj(command.Cnpj);
            var email = new Email(command.Email);

            var user = await _userRepository.GetAsync(id);
            if (user == null)
                throw new EntityNotFoundException("User");

            if (user.Email != email)
            {
                var userExisting = await _userRepository.GetByEmailAsync(email);
                if (userExisting != null)
                    throw new BusinessException($"User already exists with e-mail {email}");
            }

            if (user.Cnpj != cnpj)
            {
                var userExisting = await _userRepository.GetByEmailCnpj(cnpj);
                if (userExisting != null)
                    throw new BusinessException($"User already exists with CNPJ {cnpj}");
            }

            user.Name = command.Name;
            user.PhoneNumber = command.PhoneNumber;
            user.Email = email;
            user.CompanyName = command.CompanyName;
            user.Cnpj = cnpj;
            if (command.Password != null)
                user.Password = command.Password;

            await _userRepository.SaveChangesAsync();
            return user;
        }
    }
}
