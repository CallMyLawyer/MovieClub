using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MovieClub.Migrations.Migrations;

const string connectionString = "Server=.;Database=MovieClub;Trusted_Connection=True;" +
                                "TrustServerCertificate=True;Integrated Security=true";

var serviceCollection = new ServiceCollection()
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb.AddSqlServer()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(_202404031537_Monday).Assembly).For.Migrations())
    .BuildServiceProvider();
serviceCollection.GetRequiredService<IMigrationRunner>().MigrateUp();