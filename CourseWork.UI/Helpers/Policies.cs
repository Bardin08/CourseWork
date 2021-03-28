using Microsoft.AspNetCore.Authorization;

namespace CourseWork.UI.Helpers
{
    internal static class Policies
    {
        public const string IsAdmin = "IsAdmin";
        public const string IsUser = "IsUser";

        public static AuthorizationPolicy IsAdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }

        public static AuthorizationPolicy IsUserPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        }
    }
}