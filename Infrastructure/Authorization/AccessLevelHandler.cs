using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HADU.hem.Infrastructure.Authorization
{
    public class AccessLevelHandler : AuthorizationHandler<AccessLevelRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessLevelRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "AccessLevel"))
                return Task.CompletedTask;

            var accessLevel = Convert.ToInt32(
                context.User.FindFirst(c => c.Type == "AccessLevel").Value
            );

            if (accessLevel >= (int)requirement.AccessLevel)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}