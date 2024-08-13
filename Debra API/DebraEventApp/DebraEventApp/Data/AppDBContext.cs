using DebraEventApp.Model;
using Microsoft.EntityFrameworkCore;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<AddEvent> AddEvents { get; set; }
    public DbSet<AddTicket> AddTickets { get; set; }
    public DbSet<PartnerRegister> PartnerRegisters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddEvent>()
            .HasOne<PartnerRegister>()
            .WithMany()
            .HasForeignKey(e => e.PartnerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AddTicket>()
            .Property(p => p.Price).HasColumnType("decimal(18,2)");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = @"Data Source=MSI\SQLCHAMU;User ID=sa;Password=chamu2005;Connect Timeout=30;Encrypt=False;
Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        optionsBuilder.UseSqlServer(conn);
    }
}