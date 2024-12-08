namespace Model.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Poco;

    /// <summary>
    /// Classe de configuração da tabela de aluno
    /// </summary>
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("Aluno");

            // Definições Chave primaria
            builder.HasKey(a => a.StudentId);
            builder.Property(a => a.StudentId)
                .HasColumnName("AlunoId")
                .UseIdentityColumn()
                .HasComment("Chave Primaria auto incremente");

            // Definições de campos
            builder.Property(a => a.Name)
                .HasColumnName("Nome")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome do aluno");

            builder.Property(a => a.BirthDate)
                .HasColumnName("DataNascimento")
                .HasColumnType("DATE")
                .HasComment("Data de Nascimento do aluno");

            builder.Property(a => a.ProfilePicture)
                .HasColumnName("ImagemPerfil")
                .HasComment("Imagem de perfil do aluno");

            builder.Property(a => a.Email)
                .IsUnicode(false)
                .HasMaxLength(60)
                .HasComment("Email do aluno");

            builder.Property(a => a.Segment)
                .HasColumnName("Segmento")
                .IsUnicode(false)
                .HasMaxLength(35)
                .HasComment("Segmento do aluno, infantil ou médio");
        }
    }
}