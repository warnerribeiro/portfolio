using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    public class OriginPurchaseConfiguration : IEntityTypeConfiguration<OriginPurchase>
    {
        public void Configure(EntityTypeBuilder<OriginPurchase> builder)
        {
            builder.ToTable("OrigemCompra");

            builder.HasKey(a => a.OriginPurchaseId);

            // Definindo campos
            builder.Property(a => a.OriginPurchaseId)
                .HasColumnName("OrigemCompraId")
                .UseIdentityColumn();

            builder.Property(a => a.Name)
                .HasColumnName("Nome")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(30)
                .HasComment("Nome de origem da compra");

            SeedingData(builder);
        }

        private static void SeedingData(EntityTypeBuilder<OriginPurchase> builder)
        {
            var tiposEntidade = new List<OriginPurchase>
            {
                new() { OriginPurchaseId = 1, Name="Balcão"  },
                new() { OriginPurchaseId = 2, Name="Banca"  },
                new() { OriginPurchaseId = 3, Name="Evento"  },
                new() { OriginPurchaseId = 4, Name="Internet"  },
                new() { OriginPurchaseId = 5, Name="Self-Service"  },
            };

            //builder.Property(a => a.OriginPurchaseId).HasIdentityOptions(tiposEntidade.Count + 1);
            builder.HasData(tiposEntidade);
        }
    }
}
