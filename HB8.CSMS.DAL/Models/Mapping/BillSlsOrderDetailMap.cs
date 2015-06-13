using System.ComponentModel.DataAnnotations.Schema;
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
            this.Property(t => t.InvtID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("BillSlsOrderDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SOrderNo).HasColumnName("SOrderNo");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.SalesPrice).HasColumnName("SalesPrice");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.UnitId).HasColumnName("UnitId");
            this.Property(t => t.OrderDiscForInvt).HasColumnName("OrderDiscForInvt");

            // Relationships
            this.HasRequired(t => t.BillSaleOrder)
                .WithMany(t => t.BillSlsOrderDetails)
                .HasForeignKey(d => d.SOrderNo);
            this.HasRequired(t => t.Unit)
                .WithMany(t => t.BillSlsOrderDetails)
                .HasForeignKey(d => d.UnitId);
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.BillSlsOrderDetails)
                .HasForeignKey(d => d.InvtID);

        }
    }
}
