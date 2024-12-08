using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    public class BookValueConfiguration : IEntityTypeConfiguration<BookValue>
    {
        public void Configure(EntityTypeBuilder<BookValue> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("LivroValor");

            // Definindo chave primaria
            builder.HasKey(a => new { a.BookId, a.OriginPurchaseId });

            // Definndo campos
            builder.Property(a => a.BookId).HasColumnName("LivroId");
            builder.Property(a => a.OriginPurchaseId).HasColumnName("OrigemCompraId");

            builder.Property(a => a.Value)
                .HasColumnName("Valor")
                .HasColumnType("money");

            // Definindo Index
            builder.HasIndex(a => a.BookId);
            builder.HasIndex(a => a.OriginPurchaseId);

            // Definindo relacionamentos
            builder.HasOne(a => a.Book)
                .WithMany(a => a.BookValue)
                .HasForeignKey(a => a.BookId);

            builder.HasOne(a => a.OriginPurchase)
                .WithMany(a => a.BookValue)
                .HasForeignKey(a => a.OriginPurchaseId);
        }
    }
}
