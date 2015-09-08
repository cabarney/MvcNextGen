using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;

namespace UserGroup.Models
{
    public class AppUserManager : UserManager<ApplicationUser>
    {
        public AppUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IEnumerable<IUserTokenProvider<ApplicationUser>> tokenProviders, ILogger<UserManager<ApplicationUser>> logger, IHttpContextAccessor contextAccessor) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, tokenProviders, logger, contextAccessor)
        {
        }

        public async override Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = await base.GetClaimsAsync(user);
            claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            return claims;
        }
    }
}