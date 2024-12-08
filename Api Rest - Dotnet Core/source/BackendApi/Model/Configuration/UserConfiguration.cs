namespace Model.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Model.Poco;
    using Security;
    using System.Collections.Generic;

    /// <summary>
    /// Classe de configuração da tabela de usuario
    /// </summary>
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Classe de configuração da tabela de usuario
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Definição nome da tabela
            builder.ToTable("Usuario");

            // Definição chave primaria
            builder.HasKey(a => a.UserId);
            builder.Property(a => a.UserId)
                .HasColumnName("UsuarioId")
                .UseIdentityColumn();

            // Definição de campos
            builder.Property(a => a.UserName)
                .HasColumnName("NomeUsuario")
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Nome de usuario de logn");

            builder.Property(a => a.Salt)
                .IsUnicode(false)
                .HasComment("Salt para geração de cryptografia de senha");

            builder.Property(a => a.Role)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Papel");

            builder.Property(a => a.Password)
                .HasColumnName("Senha")
                .IsUnicode(false)
                .HasComment("Senha do usuario");

            SeedingData(builder);
        }

        /// <summary>
        /// Inicializa tabela de usuario com dados iniciais
        /// </summary>
        /// <param name="builder"></param>
        private void SeedingData(EntityTypeBuilder<User> builder)
        {
            var salt = EncryptPassword.GeneratorSalt();
            var password = EncryptPassword.Encrypt("admin123", salt);

            var user = new List<User>
            {
                new User { UserId = 1, UserName = "Administrador", Password = password, Salt = salt, Role = "ADMIN"}
            };

            builder.Property(a => a.UserId).UseSqlServerIdentityColumn(user.Count + 1);
            builder.HasData(user);
        }
    }
}