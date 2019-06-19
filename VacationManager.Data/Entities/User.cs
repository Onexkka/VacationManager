using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities.Base;
using VacationManager.Data.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VacationManager.Data.Entities
{
    public class User : IdentityUser<Guid, AspnetUserLogin, AspnetUserRole, AspnetUserClaim>, IGuidId, ICreatedAt, ILastModifiedAt
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Last Application Login DateTime
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public virtual ICollection<Vacation> Vacations { get; set; }

    }
}
