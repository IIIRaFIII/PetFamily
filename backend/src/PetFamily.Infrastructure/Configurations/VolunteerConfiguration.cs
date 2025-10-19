using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.PetContext.Entities;
using PetFamily.Domain.PetContext.ValueObjects.VolunteerVO;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.Property(v => v.Id)
                .HasConversion(
                    id => id.Value,
                    value => VolunteerId.Create(value)) 
                .HasColumnName("id");

            builder.OwnsOne(v => v.FullName, fb =>
            {
                fb.Property(f => f.FirstName)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("first_name");

                fb.Property(f => f.LastName)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("last_name");

                fb.Property(f => f.Surname)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("surname");
            });

            builder.OwnsOne(v => v.Email, eb =>
            {
                eb.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("email");
            });

            builder.OwnsOne(v => v.Description, db =>
            {
                db.Property(d => d.Value)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_LONG_TEXT)
                    .HasColumnName("description");
            });

            builder.OwnsOne(v => v.Experience, xb =>
            {
                xb.Property(x => x.Value)
                    .IsRequired()
                    .HasColumnName("experience");
            });

            builder.Property(v => v.PetsWithHomeCount)
                .HasColumnName("pets_with_home_count");

            builder.Property(v => v.PetsTryFindHomeCount)
                .HasColumnName("pets_try_find_home_count");

            builder.Property(v => v.PetsUnderTreatmentCount)
                .HasColumnName("pets_under_treatment_count");

            builder.OwnsOne(v => v.PhoneNumber, pb =>
            {
                pb.Property(p => p.Value)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("phone_number");
            });

            builder.OwnsOne(v => v.SocialNetwork, sb =>
            {
                sb.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("social_network_name");

                sb.Property(s => s.Link)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_LONG_TEXT)
                    .HasColumnName("social_network_link");
            });

            builder.OwnsOne(v => v.TransferDetails, tb =>
            {
                tb.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                    .HasColumnName("transfer_name");

                tb.Property(t => t.Description)
                    .IsRequired()
                    .HasMaxLength(TextLength.MAX_LONG_TEXT)
                    .HasColumnName("transfer_description");
            });

            builder.HasMany(v => v.AllOwnedPets)
                .WithOne()
                .HasForeignKey("volunteer_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
