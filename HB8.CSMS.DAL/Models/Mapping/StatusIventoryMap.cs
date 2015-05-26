using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StatusIventoryMap : EntityTypeConfiguration<StatusIventory>
    {
        public StatusIventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.StInventoryId);

            // Properties
            this.Property(t => t.StInventoryId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.StInvetoryName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StatusIventory");
            this.Property(t => t.StInventoryId).HasColumnName("StInventoryId");
            this.Property(t => t.StInvetoryName).HasColumnName("StInvetoryName");
        }
    }
}
