using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class BillSlsOrderDetailMap : EntityTypeConfiguration<BillSlsOrderDetail>
    {
        public BillSlsOrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.StaffId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SOrderNo)
                .HasMaxLength(20);

            this.Property(t => t.InvtID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("BillSlsOrderDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StaffId).HasColumnName("StaffId");
            this.Property(t => t.SOrderNo).HasColumnName("SOrderNo");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.SalesPrice).HasColumnName("SalesPrice");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.Amount).HasColumnName("Amount");

            // Relationships
            this.HasOptional(t => t.BillSaleOrder)
                .WithMany(t => t.BillSlsOrderDetails)
                .HasForeignKey(d => d.SOrderNo);
            this.HasOptional(t => t.Inventory)
                .WithMany(t => t.BillSlsOrderDetails)
                .HasForeignKey(d => d.InvtID);
            this.HasRequired(t => t.Staff)
                .WithMany(t => t.BillSlsOrderDetails)
                .HasForeignKey(d => d.StaffId);

        }
    }
}
