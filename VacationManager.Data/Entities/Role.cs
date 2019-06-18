using Microsoft.AspNet.Identity.EntityFramework;
using System;
using VacationSystem.Data.Identity;

namespace VacationSystem.Data.Entities
{
    public class Role : IdentityRole<Guid, AspnetUserRole>
    {
    }
}
