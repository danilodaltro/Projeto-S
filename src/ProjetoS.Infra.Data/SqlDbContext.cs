using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using ProjetoS.Domain.Aggregate;

namespace ProjetoS.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class SqlDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Cidade> Cidade { get; set; }

        public SqlDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfiguration());
            modelBuilder.Entity<Pessoa>();
            modelBuilder.Entity<Cidade>();
        }
    }

    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> orderConfiguration)
        {
            orderConfiguration.ToTable("Pessoa", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Nome).IsRequired().HasMaxLength(300);
            orderConfiguration.Property(o => o.CPF).IsRequired().HasMaxLength(11);
            orderConfiguration.Property(o => o.IdCidade).IsRequired().HasColumnName("Id_Cidade");
            orderConfiguration.Property(o => o.Idade).IsRequired();
        }
    }

    public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> orderConfiguration)
        {
            orderConfiguration.ToTable("Cidade", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Nome).IsRequired().HasMaxLength(200);
            orderConfiguration.Property(o => o.UF).IsRequired().HasMaxLength(2);
        }
    }
}
