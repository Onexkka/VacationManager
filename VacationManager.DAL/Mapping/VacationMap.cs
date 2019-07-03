using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using VacationManager.Data.Entities;

namespace VacationManager.DAL.Mapping
{
    public class VacationMap : EntityTypeConfiguration<Vacation>
    {
        public VacationMap()
        {
            HasKey(v => v.Id);   // set Primary key
            Property(v => v.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(v => v.Id).HasColumnType("UniqueIdentifier");
        }
    }
}
