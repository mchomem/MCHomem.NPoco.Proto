﻿using MCHomem.NPoco.Proto.Models.Mappings;
using NPoco;
using NPoco.FluentMappings;
using NPoco.SqlServer;

namespace MCHomem.NPoco.Proto.Models.Repositories
{
    public static class TestAppContext
    {
        public static DatabaseFactory DbFactory { get; set; }

        public static Database Get()
        {
            if (DbFactory == null)
            {
                Setup();
            }

            return DbFactory.GetDatabase();
        }

        public static void Setup()
        {
            FluentConfig fluentConfig = FluentMappingConfiguration.Configure(new EmployeeMapping());

            DbFactory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new SqlServerDatabase(AppSettings.StringConnection));
                x.WithFluentConfig(fluentConfig);
                x.WithMapper(new Mapper());
            });
        }
    }
}
