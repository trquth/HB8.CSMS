using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustID);

            // Properties
            this.Property(t => t.CustID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.StatusId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustID).HasColumnName("CustID");
            this.Property(t => t.CustName).HasColumnName("CustName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Overdue).HasColumnName("Overdue");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.OverdueAmt).HasColumnName("OverdueAmt");
            this.Property(t => t.DueAmt).HasColumnName("DueAmt");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.Image).HasColumnName("Image");

            // Relationships
            this.HasRequired(t => t.Status)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.StatusId);

        }
    }
}
