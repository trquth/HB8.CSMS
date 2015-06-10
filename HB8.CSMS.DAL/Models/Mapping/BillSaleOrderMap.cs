using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class BillSaleOrderMap : EntityTypeConfiguration<BillSaleOrder>
    {
        public BillSaleOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.SOrderNo);

            // Properties
            this.Property(t => t.CustID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.StaffID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.InvoiceType)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("BillSaleOrder");
            this.Property(t => t.SOrderNo).HasColumnName("SOrderNo");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.CustID).HasColumnName("CustID");
            this.Property(t => t.OverdueDate).HasColumnName("OverdueDate");
            this.Property(t => t.OrderDisc).HasColumnName("OrderDisc");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.TotalAmt).HasColumnName("TotalAmt");
            this.Property(t => t.Payment).HasColumnName("Payment");
            this.Property(t => t.Debt).HasColumnName("Debt");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StaffID).HasColumnName("StaffID");
            this.Property(t => t.InvoiceType).HasColumnName("InvoiceType");

            // Relationships
            this.HasRequired(t => t.InvoiceType1)
                .WithMany(t => t.BillSaleOrders)
                .HasForeignKey(d => d.InvoiceType);
            this.HasRequired(t => t.Staff)
                .WithMany(t => t.BillSaleOrders)
                .HasForeignKey(d => d.StaffID);
            this.HasOptional(t => t.Customer)
                .WithMany(t => t.BillSaleOrders)
                .HasForeignKey(d => d.CustID);

        }
    }
}
