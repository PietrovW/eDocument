using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Notifikation.Infrastructure.Operation;

namespace Notifikation.Infrastructure.MigrationsSqlGenerators
{
    public class PostgreSQLMigrationsSqlGenerator : MigrationsSqlGenerator
    {
        public PostgreSQLMigrationsSqlGenerator
            (MigrationsSqlGeneratorDependencies options) : base(options)
        {
        }
        protected override void Generate(
        MigrationOperation operation,
        IModel model,
        MigrationCommandListBuilder builder)
        {
            if (operation is CreateUserOperation createUserOperation)
            {
                Generate(createUserOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }

        private void Generate(
            CreateUserOperation operation,
            MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;
            var stringMapping = Dependencies.TypeMappingSource.FindMapping(typeof(string));

            builder
                .Append("create user ")
                .Append(sqlHelper.DelimitIdentifier(operation.Name))
                .Append(" with encrypted password  ")
                .Append(" \'"+stringMapping.GenerateSqlLiteral(operation.Password)+"\'")
                .EndCommand();
        }
    }
}
