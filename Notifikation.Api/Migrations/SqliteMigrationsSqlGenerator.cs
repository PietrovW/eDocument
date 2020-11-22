﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;

namespace Notifikation.Api.Migrations
{
    public class SqliteMigrationsSqlGenerator : MigrationsSqlGenerator
    {
        public SqliteMigrationsSqlGenerator
            (MigrationsSqlGeneratorDependencies options) :base(options)
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
                .Append("CREATE USER ")
                .Append(sqlHelper.DelimitIdentifier(operation.Name))
                .Append(" WITH PASSWORD = ")
                .Append(stringMapping.GenerateSqlLiteral(operation.Password))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }

}
}
