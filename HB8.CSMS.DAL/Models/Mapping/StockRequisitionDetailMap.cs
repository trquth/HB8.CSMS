using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StockRequisitionDetailMap : EntityTypeConfiguration<StockRequisitionDetail>
    {
        public StockRequisitionDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OutStockID, t.InvtID, t.QtyOutStock });

            // Properties
            this.Property(t => t.OutStockID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.InvtID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.QtyOutStock)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("StockRequisitionDetail");
            this.Property(t => t.OutStockID).HasColumnName("OutStockID");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.QtyOutStock).HasColumnName("QtyOutStock");

            // Relationships
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.StockRequisitionDetails)
                .HasForeignKey(d => d.InvtID);
            this.HasRequired(t => t.StockRequisition)
                .WithMany(t => t.StockRequisitionDetails)
                .HasForeignKey(d => d.OutStockID);

        }
    }
}
