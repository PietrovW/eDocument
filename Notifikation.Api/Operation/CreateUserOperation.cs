using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Notifikation.Api.Operation
{
    public class CreateUserOperation : MigrationOperation
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
