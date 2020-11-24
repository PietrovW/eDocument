using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Notifikation.Api.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifikation.Api.Extensions
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
    }
}
