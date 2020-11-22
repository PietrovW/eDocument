using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Notifikation.Api.Operation
{
    public class CreateUserOperation : MigrationOperation
    {
        public string Name { get; set; }
        public string Password { get; set; }

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
