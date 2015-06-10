using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            // Primary Key
            this.HasKey(t => t.UnitID);

            // Properties
            this.Property(t => t.UnitID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UnitName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Unit");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.UnitName).HasColumnName("UnitName");
            this.Property(t => t.UnitClassId).HasColumnName("UnitClassId");

            // Relationships
            this.HasOptional(t => t.UnitClass)
                .WithMany(t => t.Units)
                .HasForeignKey(d => d.UnitClassId);

        }
    }
}
