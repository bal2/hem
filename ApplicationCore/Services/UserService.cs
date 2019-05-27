using System;
using System.Linq;
using System.Threading.Tasks;
using HADU.hem.ApplicationCore.Data;
using HADU.hem.ApplicationCore.DTOs.Users;
using HADU.hem.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace HADU.hem.ApplicationCore.Services
{
    public class UserService
    {
        private readonly HemContext _dbContext;

        public UserService(HemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetailsDTO> GetUserAsync(long id)
        {
            return await _dbContext.User
                .Where(u => u.UserId == id)
                .Select(u => new UserDetailsDTO(u))
                .SingleOrDefaultAsync();
        }

        public async Task<UserDetailsDTO> GetUserByEmailAsync(string email)
        {
            return await _dbContext.User
                .Where(u => u.Email == email.ToLower())
                .Select(u => new UserDetailsDTO(u))
                .SingleOrDefaultAsync();
        }

        public async Task<UserDetailsDTO> GetUserByNicknameAsync(string nickname)
        {
            return await _dbContext.User
                .Where(u => u.Nickname == nickname.ToLower())
                .Select(u => new UserDetailsDTO(u))
                .SingleOrDefaultAsync();
        }

        public async Task<UserDetailsDTO> CreateUserAsync(UserCreateDTO newUser)
        {
            if (string.IsNullOrWhiteSpace(newUser.Nickname) || string.IsNullOrWhiteSpace(newUser.Email) || string.IsNullOrWhiteSpace(newUser.PasswordHash))
                throw new Exception("Missing required fields");

            var existing = await _dbContext.User.Where(u => u.Nickname == newUser.Nickname.ToLower() || u.Email == newUser.Email.ToLower()).Select(u => new { u.Email, u.Nickname }).FirstOrDefaultAsync();
            if (existing != null)
            {
                if (existing.Email == newUser.Email.ToLower())
                    throw new Exception("User with that email already exists");
                else if (existing.Nickname == newUser.Nickname.ToLower())
                    throw new Exception("User with that nickname already exists");

                throw new Exception("There already exists a user with this nickname or email");
            }
            var user = new User()
            {
                Email = newUser.Email.ToLower(),
                Nickname = newUser.Nickname.ToLower(),
                PasswordHash = newUser.PasswordHash,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                BirthDate = newUser.BirthDate,
                Phone = newUser.Phone,
                Address = newUser.Address,
                Address2 = newUser.Address2,
                Zip = newUser.Zip,
                City = newUser.City,
                GuardianName = newUser.GuardianName,
                GuardianPhone = newUser.GuardianPhone,
                AccessLevel = newUser.AccessLevel > 0 ? newUser.AccessLevel : AccessLevel.USER
            };

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new UserDetailsDTO(user);
        }
    }
}