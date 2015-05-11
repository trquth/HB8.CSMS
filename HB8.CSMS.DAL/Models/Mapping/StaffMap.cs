using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HB8.CSMS.DAL.Models.Mapping
{
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            // Primary Key
            this.HasKey(t => t.StaffID);

            // Properties
            this.Property(t => t.StaffID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.StaffName)
                .HasMaxLength(100);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(100);

            this.Property(t => t.NumberPhone)
                .HasMaxLength(12);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Staff");
            this.Property(t => t.StaffID).HasColumnName("StaffID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.StaffName).HasColumnName("StaffName");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.NumberPhone).HasColumnName("NumberPhone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Staffs)
                .HasForeignKey(d => d.UserId);

        }
    }
}
