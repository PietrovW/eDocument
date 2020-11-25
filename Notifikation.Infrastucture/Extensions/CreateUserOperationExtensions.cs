using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Notifikation.Infrastructure.Operation;
using System;

namespace Notifikation.Infrastructure.Extensions
{
    public static class CreateUserOperationExtensions
    {
        static OperationBuilder<CreateUserOperation> CreateUser(
        this MigrationBuilder migrationBuilder, string name, string password)
        {
            var operation = new CreateUserOperation
            {
                Name = name,
                Password = password
            };
            migrationBuilder.Operations.Add(operation);


            return new OperationBuilder<CreateUserOperation>(operation);
        }

        static OperationBuilder<SqlOperation> CreateUserSQL(
    this MigrationBuilder migrationBuilder,
    string name,
    string password)
        {
            switch (migrationBuilder.ActiveProvider)
            {
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    return migrationBuilder
                        .Sql($"CREATE USER {name} WITH PASSWORD '{password}';");

                case "Microsoft.EntityFrameworkCore.SqlServer":
                    return migrationBuilder
                        .Sql($"CREATE USER {name} WITH PASSWORD = '{password}';");
            }

            throw new Exception("Unexpected provider.");
        }
    }
}
