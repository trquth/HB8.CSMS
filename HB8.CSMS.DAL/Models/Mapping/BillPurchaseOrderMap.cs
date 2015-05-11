using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class BillPurchaseOrderMap : EntityTypeConfiguration<BillPurchaseOrder>
    {
        public BillPurchaseOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.POrderNo);

            // Properties
            this.Property(t => t.POrderNo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.OrderType)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("BillPurchaseOrder");
            this.Property(t => t.POrderNo).HasColumnName("POrderNo");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.OverdueDate).HasColumnName("OverdueDate");
            this.Property(t => t.DiscAmt).HasColumnName("DiscAmt");
            this.Property(t => t.PromAmt).HasColumnName("PromAmt");
            this.Property(t => t.ComAmt).HasColumnName("ComAmt");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.TotalAmt).HasColumnName("TotalAmt");
        }
    }
}
