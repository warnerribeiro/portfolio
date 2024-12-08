namespace Model.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Poco;

    /// <summary>
    /// Classe de configuração da tabela de responsaveis
    /// </summary>
    internal class AccountableConfiguration : IEntityTypeConfiguration<Accountable>
    {
        public void Configure(EntityTypeBuilder<Accountable> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("Responsavel");

            // Definindo nome da tabela
            builder.HasKey(a => a.AccountableId);
            builder.Property(a => a.AccountableId)
                .HasColumnName("ResponsavelId")
                .UseIdentityColumn()
                .HasComment("Chave primaria auto incremente");

            // Definindo campos
            builder.Property(a => a.Name)
                .HasColumnName("Nome")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome do responsável");

            builder.Property(a => a.Email)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("Email do aluno, obrigatório");

            builder.Property(a => a.BirthDate)
                .HasColumnType("DATE")
                .HasColumnName("DataNascimento")
                .HasComment("Data de nascimento do aluno");

            builder.Property(a => a.Kinship)
                .HasColumnName("Parentesco")
                .IsUnicode(false)
                .HasMaxLength(25)
                .HasComment("Parentesco do responsável do aluno");

            builder.Property(a => a.Telephone)
                .HasColumnName("Telefone")
                .IsUnicode(false)
                .HasMaxLength(13)
                .HasComment("Telefone do responsável");

            builder.Property(a => a.StundentId)
                .HasColumnName("AlunoId")
                .HasComment("Chave estrangeira do aluno");

            // Definindo relacionamento
            builder
                .HasOne(a => a.Student)
                .WithMany(a => a.Accountable)
                .HasForeignKey(a => a.StundentId);
        }
    }
}