using CaseManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagement.Services.Users
{
    public class UsersService : UserManager<ApplicationUser>
    {
        private readonly IConfiguration configuration;

        public UsersService(IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger,
            IConfiguration configuration)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.configuration = configuration;
        }

        public async Task ResetUserPasswordByIdAsync(string userId)
        {
            ApplicationUser user = await FindByIdAsync(userId);

            await RemovePasswordAsync(user);
            await AddPasswordAsync(user, configuration["DefaultResetPassword"]);
        }

        public async Task ResetUserPasswordByEmailAsync(string userEmail)
        {
            ApplicationUser user = await FindByEmailAsync(userEmail.Trim());

            await ResetUserPasswordByIdAsync(user.Id);
        }

        public async Task UpdateUserLastActivityDateAsync(string userId)
        {
            ApplicationUser user = await FindByIdAsync(userId);
            user.LastActivity = DateTime.UtcNow;
            await UpdateAsync(user);
        }
    }
}
