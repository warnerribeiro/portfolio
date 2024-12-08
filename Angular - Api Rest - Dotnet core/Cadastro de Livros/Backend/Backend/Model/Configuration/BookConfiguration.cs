using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("Livro");

            // Definindo chave primaria
            builder.HasKey(a => a.BookId);
            builder.Property(a => a.BookId)
                .HasColumnName("LivroId")
                .UseIdentityColumn()
                .HasComment("Chave primaria auto incremente");

            // Definindo campos
            builder.Property(a => a.Title)
              .HasColumnName("Titulo")
              .IsUnicode(false)
              .IsRequired()
              .HasMaxLength(40)
              .HasComment("Titulo do Livro");

            builder.Property(a => a.Publisher)
             .HasColumnName("Editora")
             .IsUnicode(false)
             .IsRequired()
             .HasMaxLength(40)
             .HasComment("Editora do Livro");

            builder.Property(a => a.Edition)
             .HasColumnName("Edicao")
             .IsUnicode(false)
             .IsRequired()
             .HasComment("Edição do Livro");

            builder.Property(a => a.YearOfPublication)
             .HasColumnName("AnoPublicacao")
             .IsUnicode(false)
             .IsRequired()
             .HasMaxLength(4)
             .HasComment("Ano de Publicação do Livro");
        }
    }
}
