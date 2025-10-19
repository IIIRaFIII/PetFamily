using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;
using PetFamily.Domain.SpeciesContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Infrastructure.Configurations
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("species");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(TextLength.MAX_SHORT_TEXT)
                .HasColumnName("name");

            builder.HasMany(s => s.Breeds)
                .WithOne() 
                .HasForeignKey("species_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
