using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            // Primary Key
            this.HasKey(t => t.StatusId);

            // Properties
            this.Property(t => t.StatusId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.StatusName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Status");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.StatusName).HasColumnName("StatusName");
        }
    }
}
