namespace HADU.hem.Infrastructure.Authorization
{
    using HADU.hem.ApplicationCore.Entities;
    using Microsoft.AspNetCore.Authorization;
    public class AccessLevelRequirement : IAuthorizationRequirement
    {
        public AccessLevel AccessLevel { get; }

        public AccessLevelRequirement(AccessLevel accessLevel)
        {
            AccessLevel = accessLevel;
        }
    }
}