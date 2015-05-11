using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class InvoiceTypeMap : EntityTypeConfiguration<InvoiceType>
    {
        public InvoiceTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.InvoiceType1);

            // Properties
            this.Property(t => t.InvoiceType1)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.TypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("InvoiceType");
            this.Property(t => t.InvoiceType1).HasColumnName("InvoiceType");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
        }
    }
}
