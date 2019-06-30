using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Entities;

namespace VacationManager.DAL.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(u => u.Id);

            Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.LastModifiedAt).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            HasMany(u => u.Vacations)       // user has many Vacation (one-to-many)
            .WithRequired(h => h.User)      // Vacation required set User nav-property
            .WillCascadeOnDelete(false);    // 
        }
    }
}
