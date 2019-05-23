using System.Threading;
using System.Threading.Tasks;
using HADU.hem.ApplicationCore.Data;
using HADU.hem.ApplicationCore.DTOs.Users;
using HADU.hem.ApplicationCore.Entities;
using HADU.hem.ApplicationCore.Services;
using Microsoft.AspNetCore.Identity;

namespace HADU.hem.Infrastructure.Identity
{
    public class UserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {

        private readonly HemContext _dbContext;
        private readonly UserService _userService;

        public UserStore(HemContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var userCreateDto = new UserCreateDTO()
            {
                Email = user.Email,
                Nickname = user.Nickname,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash,
                BirthDate = user.BirthDate,
                Phone = user.Phone,
                Address = user.Address,
                Address2 = user.Address2,
                Zip = user.Zip,
                City = user.City,
                GuardianName = user.GuardianName,
                GuardianPhone = user.GuardianPhone
            };

            await _userService.CreateUserAsync(userCreateDto);

            return await Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (long.TryParse(userId, out long id))
            {
                var uDto = await _userService.GetUserAsync(id);
                if (uDto != null)
                    return new ApplicationUser()
                    {
                        UserId = uDto.UserId,
                        Nickname = uDto.Nickname,
                        FirstName = uDto.FirstName,
                        LastName = uDto.LastName,
                        PasswordHash = uDto.PasswordHash,
                        Email = uDto.Email,
                        BirthDate = uDto.BirthDate,
                        Phone = uDto.Phone,
                        Address = uDto.Address,
                        Address2 = uDto.Address2,
                        Zip = uDto.Zip,
                        City = uDto.City,
                        GuardianName = uDto.GuardianName,
                        GuardianPhone = uDto.GuardianPhone,
                        AccessLevel = uDto.AccessLevel
                    };
            }
            return await Task.FromResult((ApplicationUser)null);
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {

            var uDto = await _userService.GetUserByEmailAsync(normalizedUserName);
            if (uDto != null)
                return new ApplicationUser()
                {
                    UserId = uDto.UserId,
                    Nickname = uDto.Nickname,
                    FirstName = uDto.FirstName,
                    LastName = uDto.LastName,
                    PasswordHash = uDto.PasswordHash,
                    Email = uDto.Email,
                    BirthDate = uDto.BirthDate,
                    Phone = uDto.Phone,
                    Address = uDto.Address,
                    Address2 = uDto.Address2,
                    Zip = uDto.Zip,
                    City = uDto.City,
                    GuardianName = uDto.GuardianName,
                    GuardianPhone = uDto.GuardianPhone,
                    AccessLevel = uDto.AccessLevel
                };

            return await Task.FromResult((ApplicationUser)null);
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId.ToString());
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Email = normalizedName;

            return Task.FromResult((object)null);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult((object)null);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}