using App.Domain.Registration.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EfDriver.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        // Configure the table name
        builder.ToTable("Patients");

        // Configure the primary key
        builder.HasKey(p => p.Identifier.Value);

        // Configure the HumanName value object
        builder.OwnsOne(p => p.HumanName, hn =>
        {
            hn.Property(h => h.FirstName).HasMaxLength(50).IsRequired();
            hn.Property(h => h.LastName).HasMaxLength(50).IsRequired();
        });

        // Configure the Identifier value object
        builder.OwnsOne(p => p.Identifier, id =>
        {
            id.Property(i => i.Value).HasMaxLength(100).IsRequired();
        });

        // Configure Addresses as an owned collection of Address value objects
        builder.OwnsMany(p => p.Addresses, a =>
        {
            a.ToTable("PatientAddresses");
            a.WithOwner().HasForeignKey("PatientId");
            a.Property(a => a.Street).HasMaxLength(200).IsRequired();
            a.Property(a => a.City).HasMaxLength(100).IsRequired();
            a.Property(a => a.State).HasMaxLength(100).IsRequired();
            a.Property(a => a.PostalCode).HasMaxLength(20).IsRequired();
        });

        // Configure Identifiers as an owned collection of Identifier value objects
        builder.OwnsMany(p => p.Identifiers, i =>
        {
            i.ToTable("PatientIdentifiers");
            i.WithOwner().HasForeignKey("PatientId");
            i.Property(i => i.Value).HasMaxLength(100).IsRequired();
        });
    }
}
