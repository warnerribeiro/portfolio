using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    internal class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("LivroAutor");


            // Definindo chave primaria
            builder.HasKey(a => new { a.BookId, a.AuthorId });

            // Definindo campos
            builder.Property(a => a.BookId)
                .HasColumnName("LivroId");
            builder.Property(a => a.AuthorId).HasColumnName("AutorId");

            // Definindo index
            builder.HasIndex(a => a.BookId);
            builder.HasIndex(b => b.AuthorId);

            // Definindo relacionamento
            builder.HasOne(a => a.Author)
                .WithMany(a => a.BookAuthor)
                .HasForeignKey(a => a.AuthorId);

            builder.HasOne(a => a.Book)
                .WithMany(a => a.BookAuthor)
                .HasForeignKey(a => a.BookId);
        }
    }
}
