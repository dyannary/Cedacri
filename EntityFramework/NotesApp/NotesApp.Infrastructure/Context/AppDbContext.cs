using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Entities;

namespace NotesApp.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    const string connectionString = "Server=CEDINT874\\SQLEXPRESS;Database=NotesApp;trusted_connection=true;Encrypt=False";
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteTag> NoteTags { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Domain.Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
