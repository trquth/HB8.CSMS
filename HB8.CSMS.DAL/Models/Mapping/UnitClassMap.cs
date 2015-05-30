using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class UnitClassMap : EntityTypeConfiguration<UnitClass>
    {
        public UnitClassMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitClassId);

            // Properties
            this.Property(t => t.ClassName)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("UnitClass");
            this.Property(t => t.UnitClassId).HasColumnName("UnitClassId");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
        }
    }
}
