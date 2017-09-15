/*                 
 *                    EntityFrameworkCore.FirebirdSQL
 *
 *     Permission to use, copy, modify, and distribute this software and its
 *     documentation for any purpose, without fee, and without a written
 *     agreement is hereby granted, provided that the above copyright notice
 *     and this paragraph and the following two paragraphs appear in all copies. 
 * 
 *     The contents of this file are subject to the Initial
 *     Developer's Public License Version 1.0 (the "License");
 *     you may not use this file except in compliance with the
 *     License.
 *
 *
 *     Software distributed under the License is distributed on
 *     an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either
 *     express or implied.  See the License for the specific
 *     language governing rights and limitations under the License.
 *
 *      Credits: Rafael Almeida (ralms@ralms.net)
 *                              Sergipe-Brazil
 *                  All Rights Reserved.
 */

using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities; 
using Microsoft.EntityFrameworkCore.Infrastructure.Internal; 

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
	public class FbSqlGenerationHelper : RelationalSqlGenerationHelper
	{
		private readonly IFbOptions _options;

		public FbSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies,
			IFbOptions options)
			: base(dependencies)
		{
			_options = options;
		}

		/// <summary>
		///     This API supports the Entity Framework Core infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public override string EscapeIdentifier(string identifier)
		{
			return Check.NotEmpty(identifier, nameof(identifier));
		}

		/// <summary>
		///     This API supports the Entity Framework Core infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public override void EscapeIdentifier(StringBuilder builder, string identifier)
		{
			Check.NotEmpty(identifier, nameof(identifier));
			builder.Append(identifier.MaxLength(_options.ConnectionSettings.ServerVersion.ObjectLengthName));
		}

		/// <summary>
		///     This API supports the Entity Framework Core infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public override string DelimitIdentifier(string identifier)
		{
			return
				$"\"{EscapeIdentifier(Check.NotEmpty(identifier.MaxLength(_options.ConnectionSettings.ServerVersion.ObjectLengthName), nameof(identifier)))}\"";
		}

		/// <summary>
		///     This API supports the Entity Framework Core infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public override void DelimitIdentifier(StringBuilder builder, string identifier)
		{
			Check.NotEmpty(identifier, nameof(identifier));
			builder.Append('"');
			EscapeIdentifier(builder, identifier.MaxLength(_options.ConnectionSettings.ServerVersion.ObjectLengthName));
			builder.Append('"');
		}

		//
		// Summary:
		//     Generates a valid parameter name for the given candidate name.
		//
		// Parameters:
		//   name:
		//     The candidate name for the parameter.
		//
		// Returns:
		//     A valid name based on the candidate name.
		public override string GenerateParameterName(string name)
		{
			return $"@{name.MaxLength(_options.ConnectionSettings.ServerVersion.ObjectLengthName)}";
		}


		//
		// Summary:
		//     Writes a valid parameter name for the given candidate name.
		//
		// Parameters:
		//   builder:
		//     The System.Text.StringBuilder to write generated string to.
		//
		//   name:
		//     The candidate name for the parameter.
		public override void GenerateParameterName(StringBuilder builder, string name)
		{
			builder.Append("@").Append(name.MaxLength(_options.ConnectionSettings.ServerVersion.ObjectLengthName));
		}
	}
}