﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Utilities;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    public class FirebirdRelationalCommand : RelationalCommand
    {
        public FirebirdRelationalCommand(
            IDiagnosticsLogger<DbLoggerCategory.Database.Command> logger,
            string commandText,
            IReadOnlyList<IRelationalParameter> parameters)
            : base(logger, commandText, parameters)
        {
        }

        protected override object Execute(
            IRelationalConnection connection,
            DbCommandMethod executeMethod,
            [CanBeNull] IReadOnlyDictionary<string, object> parameterValues)
        {
             

            return ExecuteAsync( connection, executeMethod, parameterValues)
                .GetAwaiter()
                .GetResult();
        }
         
    }
}
