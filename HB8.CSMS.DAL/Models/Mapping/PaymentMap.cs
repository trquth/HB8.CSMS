using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class PaymentMap : EntityTypeConfiguration<Payment>
    {
        public PaymentMap()
        {
            // Primary Key
            this.HasKey(t => t.PaymentID);

            // Properties
            this.Property(t => t.PaymentNo)
                .HasMaxLength(20);

            this.Property(t => t.CustID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SalesPersonID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Payment");
            this.Property(t => t.PaymentID).HasColumnName("PaymentID");
            this.Property(t => t.PaymentNo).HasColumnName("PaymentNo");
            this.Property(t => t.PaymentDate).HasColumnName("PaymentDate");
            this.Property(t => t.PaymentAmt).HasColumnName("PaymentAmt");
            this.Property(t => t.CustID).HasColumnName("CustID");
            this.Property(t => t.SalesPersonID).HasColumnName("SalesPersonID");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Payments)
                .HasForeignKey(d => d.CustID);

        }
    }
}
