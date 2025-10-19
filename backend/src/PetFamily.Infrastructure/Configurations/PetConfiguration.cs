using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.PetContext.Entities;
using PetFamily.Domain.PetContext.ValueObjects.PetVO;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value))
            .HasColumnName("id");

        builder.OwnsOne(p => p.Name, nb =>
        {
            nb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("name");
        });

        builder.OwnsOne(p => p.SpeciesBreed, sb =>
        {
            sb.Property(s => s.SpeciesId)
                .IsRequired()
                .HasColumnName("species_id");

            sb.Property(s => s.BreedId)
                .IsRequired()
                .HasColumnName("breed_id");
        });

        builder.OwnsOne(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_LONG_TEXT)
                .HasColumnName("description");
        });

        builder.OwnsOne(p => p.Color, cb =>
        {
            cb.Property(c => c.Value)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("color");
        });

        builder.OwnsOne(p => p.HealthInfo, hb =>
        {
            hb.Property(h => h.Value)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_LONG_TEXT)
                .HasColumnName("health_info");
        });

        builder.OwnsOne(p => p.Address, ab =>
        {
            ab.Property(a => a.Region)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("region");

            ab.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("city");

            ab.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("street");

            ab.Property(a => a.Building)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("building");

            ab.Property(a => a.Apartment)
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("apartment");
        });

        builder.OwnsOne(p => p.Weight, wb =>
        {
            wb.Property(w => w.Value)
                .IsRequired()
                .HasColumnName("weight");
        });

        builder.OwnsOne(p => p.Height, hb =>
        {
            hb.Property(h => h.Value)
                .IsRequired()
                .HasColumnName("height");
        });

        builder.OwnsOne(p => p.OwnerPhoneNumber, pb =>
        {
            pb.Property(pn => pn.Value)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("owner_phone_number");
        });

        builder.OwnsOne(p => p.IsCastrated, ib =>
        {
            ib.Property(i => i.Value)
                .IsRequired()
                .HasColumnName("is_castrated");
        });

        builder.OwnsOne(p => p.IsVaccinated, vb =>
        {
            vb.Property(v => v.Value)
                .IsRequired()
                .HasColumnName("is_vaccinated");
        });

        builder.OwnsOne(p => p.DateOfBirth, db =>
        {
            db.Property(d => d.Value)
                .IsRequired()
                .HasColumnName("date_of_birth");
        });

        builder.OwnsOne(p => p.HelpStatus, sb =>
        {
            sb.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_STATUS_TEXT)
                .HasColumnName("help_status");
        });

        builder.OwnsOne(p => p.TransferDetails, tb =>
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

        builder.Property(p => p.CreatedOn)
            .IsRequired()
            .HasColumnName("created_on");
    }
}
