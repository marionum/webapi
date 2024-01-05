using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class FreeAzureSqlContext : DbContext
{
    public FreeAzureSqlContext()
    {
    }

    public FreeAzureSqlContext(DbContextOptions<FreeAzureSqlContext> options)
        : base(options)
    {
        Console.WriteLine("In constructor line 16");
    }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        optionsBuilder.UseSqlServer("Server=tcp:serverforwebapi.database.windows.net,1433;Initial Catalog=webapi;Persist Security Info=False;User ID=s2300294@edu.bc.fi@serverforwebapi;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Personid).HasName("PK__Persons__AA2CFFDDE425355D");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}