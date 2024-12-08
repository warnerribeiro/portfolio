using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("Autor");

            // Definindo nome da tabela
            builder.HasKey(a => a.AuthorId);
            builder.Property(a => a.AuthorId)
                .HasColumnName("AutorId").
                UseIdentityColumn()
                .HasComment("Chave primaria auto incremente");

            // Definindo campos
            builder.Property(a => a.Name)
                .HasColumnName("Nome")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Nome do ator");


        }
    }
}
