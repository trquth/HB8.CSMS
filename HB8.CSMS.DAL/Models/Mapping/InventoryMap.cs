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

            this.Property(t => t.ClassName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(2);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Inventory");
            this.Property(t => t.InvtID).HasColumnName("InvtID");
            this.Property(t => t.InvtName).HasColumnName("InvtName");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.UnitRate).HasColumnName("UnitRate");
            this.Property(t => t.SalesPriceT).HasColumnName("SalesPriceT");
            this.Property(t => t.SalesPriceL).HasColumnName("SalesPriceL");
            this.Property(t => t.QtyStock).HasColumnName("QtyStock");
            this.Property(t => t.SlsTax).HasColumnName("SlsTax");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasOptional(t => t.Unit)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.UnitID);

        }
    }
}
