using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using OrmPerformance.Repositories.NHibernate;
using OrmPerformance.Services.NHibernate;

namespace OrmPerformance.Extension.NHibernate
{
    public static class NHibernateExtension
    {
        public static void AddNHibernate(this IServiceCollection services, string connection)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(NHibernateExtension).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connection;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            configuration.AddMapping(domainMapping);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<INHibernateRepositories, NHibernateRepositories>();
            services.AddScoped<INHibernateService, NHibernateService>();
        }
    }
}
