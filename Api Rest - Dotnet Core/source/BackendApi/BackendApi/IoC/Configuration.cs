namespace Web.Api.IoC
{
    using Core.Repository;
    using Core.Repository.Implementation;
    using Core.Services;
    using Core.Services.Implementation;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Model.Poco;
    using System.Data;
    using Web.Api.ApplicationService;
    using Web.Api.ApplicationService.Implementation;

    /// <summary>
    /// Configurações de injeção de dependencia
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Injeção de dependencias do .Net Core
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void DependencyInjectionCore(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryStudent, RepositoryStudent>();
            services.AddScoped<IServiceDomainStudent, ServiceDomainStudent>();
            services.AddScoped<IApplicationServiceStudent, ApplicationServiceStudent>();

            services.AddScoped<IRepositoryAccountable, RepositoryAccountable>();
            services.AddScoped<IServiceDomainAccountable, ServiceDomainAccountable>();
            services.AddScoped<IApplicationServiceAccountable, ApplicationServiceAccountable>();

            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IServiceDomainUser, ServiceDomainUser>();
            services.AddScoped<IApplicationServiceUser, ApplicationServiceUser>();
        }

        /// <summary>
        /// Injeção de dependência do SQL Server
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void DependencyInjectionSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            // Injeção da conexão para o Dapper
            services.AddScoped<IDbConnection, SqlConnection>(provider => new SqlConnection(connectionString));
            // Injeção do contexto para EntityFrameworkCore
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}