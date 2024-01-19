using Microsoft.EntityFrameworkCore;
using PeopleLib;

namespace PeopleApi.Data;
public class PeopleContext : DbContext
{
    public PeopleContext(DbContextOptions<PeopleContext> options)
           : base(options)
    {
    }

    public DbSet<Renter> Renters { get; set; } = null!;
    
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<RentalPicture> RentalPictures { get; set; } = null!;
    public DbSet<RentalInstrument> RentalInstruments { get; set; } = null!;
    public DbSet<RentalInstrumentPicture> RentalInstrumentPictures { get; set; } = null!;
    public DbSet<ProfileDefaultPicture> ProfileDefaultPictures { get; set; } = null!;
}