using HotelReservation.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.WebApi.Infrastructure.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
  public void Configure(EntityTypeBuilder<Hotel> builder)
  {
    builder.ToTable("hotel");
    builder.HasKey(h => h.Id);
    builder.OwnsOne(h => h.Address, address =>
    {
      address.Property(ad => ad.Number).IsRequired();
      address.Property(ad => ad.Street).HasMaxLength(100).IsRequired();
      address.Property(ad => ad.City).HasMaxLength(50).IsRequired();
      address.Property(ad => ad.State).HasMaxLength(50).IsRequired();
      address.Property(ad => ad.Country).HasMaxLength(50).IsRequired();
      address.Property(ad => ad.ZipCode).HasMaxLength(20).IsRequired();
    });
    builder.Property(h => h.Active)
      .HasColumnType("boolean")
      .HasDefaultValue(true)
      .IsRequired();
    builder.Property(h => h.CreatedAt)
      .HasColumnType("timestamptz")
      .IsRequired();
    builder.Property(h => h.UpdatedAt)
      .HasColumnType("timestamptz")
      .IsRequired();
  }
}
