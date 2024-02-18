using Microsoft.EntityFrameworkCore;

namespace TalkToDoc.Models;

public class DocumentContext(DbContextOptions<DocumentContext> options) : DbContext(options)
{
    public DbSet<Document> Documents { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>().HasKey(e => e.Id);
    }

}
