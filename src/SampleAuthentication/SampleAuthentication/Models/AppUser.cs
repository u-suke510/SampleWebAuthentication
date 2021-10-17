using Libs.Entities;
using Libs.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleAuthentication.Models
{
    public class AppUser : IdentityUser
    {
        public string DispName
        {
            get;
            set;
        }
    }

    public class AppUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser>
    {
        private readonly IUserRepository repository;

        public AppUserStore(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            var entity = new MUser {
                Id = user.Id,
                UserName = user.Email,
                DispName = user.DispName,
                Email = user.Email,
                PwdHash = user.PasswordHash
            };
            repository.InsMUser(entity, user.Id);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            AppUser user = null;

            var item = repository.GetItemById(userId);
            if (item != null)
            {
                user = new AppUser {
                    Id = item.Id,
                    UserName = item.UserName,
                    DispName = item.DispName,
                    Email = item.Email
                };
            }

            return Task.FromResult(user);
        }

        public Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            AppUser user = null;

            var item = repository.GetItemByUsrNm(normalizedUserName);
            if (item != null)
            {
                user = new AppUser {
                    Id = item.Id,
                    UserName = item.UserName,
                    DispName = item.DispName,
                    Email = item.Email
                };
            }

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetPwdHashById(user.Id));
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.UserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
