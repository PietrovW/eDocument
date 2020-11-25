using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Notifikation.Infrastructure.Operation
{
    public class CreateUserOperation : MigrationOperation
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
