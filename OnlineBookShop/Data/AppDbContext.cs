using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Author and Book
            modelBuilder.Entity<Author_Book>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<Author_Book>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.Author_Books)
                .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<Author_Book>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.Author_Books)
                .HasForeignKey(ab => ab.BookId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }

    }
}
