using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.InvtID);

            // Properties
            this.Property(t => t.InvtID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.InvtName)
                .HasMaxLength(50);

            this.Property(t => t.StInventoryId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.StaffId)
                .HasMaxLength(20);

            this.Property(t => t.StockID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Inventory");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.InvtName).HasColumnName("InvtName");
            this.Property(t => t.ClassId).HasColumnName("ClassId");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.QtyStock).HasColumnName("QtyStock");
            this.Property(t => t.SlsTax).HasColumnName("SlsTax");
            this.Property(t => t.StInventoryId).HasColumnName("StInventoryId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StaffId).HasColumnName("StaffId");
            this.Property(t => t.StockID).HasColumnName("StockID");

            // Relationships
            this.HasRequired(t => t.Class)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.ClassId);
            this.HasOptional(t => t.Staff)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.StaffId);
            this.HasRequired(t => t.StatusIventory)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.StInventoryId);
            this.HasOptional(t => t.Stock)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.StockID);

        }
    }
}
