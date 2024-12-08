using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Model.Configuration;

namespace Backend.Model
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }

        public DbSet<Subject> Subject { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<BookSubject> BookSubject { get; set; }

        public DbSet<BookValue> BookValue { get; set; }

        public DbSet<OriginPurchase> OriginPurchase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new BookValueConfiguration());
            modelBuilder.ApplyConfiguration(new OriginPurchaseConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.1.100,11433;Database=LivroDb;user id=sa;password=@War23ner10;Trusted_Connection=False;TrustServerCertificate=False;Encrypt=false;ConnectRetryCount=0");
        }
    }


}
