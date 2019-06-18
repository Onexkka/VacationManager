using Microsoft.AspNet.Identity.EntityFramework;
using System;
using VacationManager.Data.Identity;

namespace VacationManager.Data.Entities
{
    public class Role : IdentityRole<Guid, AspnetUserRole>
    {
    }
}
