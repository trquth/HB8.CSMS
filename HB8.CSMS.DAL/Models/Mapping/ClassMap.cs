using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class ClassMap : EntityTypeConfiguration<Class>
    {
        public ClassMap()
        {
            // Primary Key
            this.HasKey(t => t.ClassId);

            // Properties
            this.Property(t => t.ClassName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Class");
            this.Property(t => t.ClassId).HasColumnName("ClassId");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
        }
    }
}
