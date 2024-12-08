using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    public class BookSubjectConfiguration : IEntityTypeConfiguration<BookSubject>
    {
        public void Configure(EntityTypeBuilder<BookSubject> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("LivroAssunto");

            // Definindo chave primaria
            builder.HasKey(a => new { a.BookId, a.SubjectId });

            // Definindo index
            builder.HasIndex(a => a.BookId);
            builder.HasIndex(a => a.SubjectId);

            //Definindo campos
            builder.Property(a => a.BookId).HasColumnName("LivroId");
            builder.Property(a => a.SubjectId).HasColumnName("AssuntoId");

            // Definindo relacionamento
            builder.HasOne(a => a.Book)
                .WithMany(a => a.BookSubject)
                .HasForeignKey(a => a.BookId);

            builder.HasOne(a => a.Subject)
                .WithMany(a => a.BookSubject)
                .HasForeignKey(a => a.SubjectId);
        }
    }
}
