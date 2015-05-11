using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StkTransDetailMap : EntityTypeConfiguration<StkTransDetail>
    {
        public StkTransDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Qty, t.Amount });

            // Properties
            this.Property(t => t.TransID)
                .HasMaxLength(20);

            this.Property(t => t.InvtID)
                .HasMaxLength(20);

            this.Property(t => t.Qty)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Amount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("StkTransDetail");
            this.Property(t => t.TransID).HasColumnName("TransID");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.Amount).HasColumnName("Amount");

            // Relationships
            this.HasOptional(t => t.Inventory)
                .WithMany(t => t.StkTransDetails)
                .HasForeignKey(d => d.InvtID);
            this.HasOptional(t => t.StockTransfer)
                .WithMany(t => t.StkTransDetails)
                .HasForeignKey(d => d.TransID);

        }
    }
}
