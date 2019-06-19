using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;

namespace VacationManager.WEB.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserIdGuid(this IIdentity identity)
        {
            Guid result;
            return Guid.TryParse(identity.GetUserId<string>(), out result) ? result : Guid.Empty;
        }
    }
}