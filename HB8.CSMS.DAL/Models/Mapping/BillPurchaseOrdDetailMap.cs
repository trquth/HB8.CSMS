using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class BillPurchaseOrdDetailMap : EntityTypeConfiguration<BillPurchaseOrdDetail>
    {
        public BillPurchaseOrdDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Qty, t.QtyProm, t.QtyPromAmt, t.AmtProm, t.TaxAmt, t.Amount });

            // Properties
            this.Property(t => t.POrderNo)
                .HasMaxLength(20);

            this.Property(t => t.StaffId)
                .HasMaxLength(20);

            this.Property(t => t.InvtID)
                .HasMaxLength(20);

            this.Property(t => t.Qty)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StockID)
                .HasMaxLength(20);

            this.Property(t => t.QtyProm)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.QtyPromAmt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AmtProm)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TaxAmt)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Amount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BillPurchaseOrdDetail");
            this.Property(t => t.POrderNo).HasColumnName("POrderNo");
            this.Property(t => t.StaffId).HasColumnName("StaffId");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.PurchasePrice).HasColumnName("PurchasePrice");
            this.Property(t => t.StockID).HasColumnName("StockID");
            this.Property(t => t.QtyProm).HasColumnName("QtyProm");
            this.Property(t => t.QtyPromAmt).HasColumnName("QtyPromAmt");
            this.Property(t => t.AmtProm).HasColumnName("AmtProm");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.Amount).HasColumnName("Amount");

            // Relationships
            this.HasOptional(t => t.Inventory)
                .WithMany(t => t.BillPurchaseOrdDetails)
                .HasForeignKey(d => d.InvtID);
            this.HasOptional(t => t.BillPurchaseOrder)
                .WithMany(t => t.BillPurchaseOrdDetails)
                .HasForeignKey(d => d.POrderNo);
            this.HasOptional(t => t.Staff)
                .WithMany(t => t.BillPurchaseOrdDetails)
                .HasForeignKey(d => d.StaffId);
            this.HasOptional(t => t.Stock)
                .WithMany(t => t.BillPurchaseOrdDetails)
                .HasForeignKey(d => d.StockID);

        }
    }
}
