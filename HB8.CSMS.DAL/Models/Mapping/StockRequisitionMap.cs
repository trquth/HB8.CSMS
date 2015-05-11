using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StockRequisitionMap : EntityTypeConfiguration<StockRequisition>
    {
        public StockRequisitionMap()
        {
            // Primary Key
            this.HasKey(t => t.OutStockID);

            // Properties
            this.Property(t => t.OutStockID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StaffID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StockID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Note)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("StockRequisition");
            this.Property(t => t.OutStockID).HasColumnName("OutStockID");
            this.Property(t => t.StaffID).HasColumnName("StaffID");
            this.Property(t => t.StockID).HasColumnName("StockID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.Note).HasColumnName("Note");

            // Relationships
            this.HasRequired(t => t.Staff)
                .WithMany(t => t.StockRequisitions)
                .HasForeignKey(d => d.StaffID);
            this.HasRequired(t => t.Stock)
                .WithMany(t => t.StockRequisitions)
                .HasForeignKey(d => d.StockID);

        }
    }
}
