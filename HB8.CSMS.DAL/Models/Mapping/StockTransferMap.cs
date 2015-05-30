using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StockTransferMap : EntityTypeConfiguration<StockTransfer>
    {
        public StockTransferMap()
        {
            // Primary Key
            this.HasKey(t => t.TransID);

            // Properties
            this.Property(t => t.TransID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FromStockID)
                .HasMaxLength(20);

            this.Property(t => t.ToStockID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("StockTransfer");
            this.Property(t => t.TransID).HasColumnName("TransID");
            this.Property(t => t.TransDate).HasColumnName("TransDate");
            this.Property(t => t.FromStockID).HasColumnName("FromStockID");
            this.Property(t => t.ToStockID).HasColumnName("ToStockID");
            this.Property(t => t.TotalAmt).HasColumnName("TotalAmt");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasOptional(t => t.Stock)
                .WithMany(t => t.StockTransfers)
                .HasForeignKey(d => d.FromStockID);

        }
    }
}
