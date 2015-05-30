using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class UnitDetailMap : EntityTypeConfiguration<UnitDetail>
    {
        public UnitDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UnitID, t.InvtID });

            // Properties
            this.Property(t => t.UnitID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.InvtID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("UnitDetail");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.UnitRate).HasColumnName("UnitRate");

            // Relationships
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.UnitDetails)
                .HasForeignKey(d => d.InvtID);
            this.HasRequired(t => t.Unit)
                .WithMany(t => t.UnitDetails)
                .HasForeignKey(d => d.UnitID);

        }
    }
}
