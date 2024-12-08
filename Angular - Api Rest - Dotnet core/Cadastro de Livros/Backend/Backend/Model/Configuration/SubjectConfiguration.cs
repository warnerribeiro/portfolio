using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("Assunto");

            // Definindo nome da tabela
            builder.HasKey(a => a.SubjectId);
            builder.Property(a => a.SubjectId).HasColumnName("AssuntoId").UseIdentityColumn().HasComment("Chave primaria auto incremente");

            // Definindo campos
            builder.Property(a => a.Description)
                .HasColumnName("Descricao")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Descrição do assunto");
        }
    }
}
