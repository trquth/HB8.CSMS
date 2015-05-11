using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StockMap : EntityTypeConfiguration<Stock>
    {
        public StockMap()
        {
            // Primary Key
            this.HasKey(t => t.StockID);

            // Properties
            this.Property(t => t.StockID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StockName)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Stock");
            this.Property(t => t.StockID).HasColumnName("StockID");
            this.Property(t => t.StockName).HasColumnName("StockName");
            this.Property(t => t.Address).HasColumnName("Address");
        }
    }
}
