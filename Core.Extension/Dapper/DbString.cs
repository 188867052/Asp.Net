﻿using System;
using System.Data;

namespace Core.Extension.Dapper
{
    /// <summary>
    /// This class represents a SQL string, it can be used if you need to denote your parameter is a Char vs VarChar vs nVarChar vs nChar.
    /// </summary>
    public sealed class DbString : SqlMapper.ICustomQueryParameter
    {
        /// <summary>
        /// A value to set the default value of strings
        /// going through Dapper. Default is 4000, any value larger than this
        /// field will not have the default value applied.
        /// </summary>
        public const int DefaultLength = 4000;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbString"/> class.
        /// Create a new DbString.
        /// </summary>
        public DbString()
        {
            this.Length = -1;
            this.IsAnsi = IsAnsiDefault;
        }

        /// <summary>
        /// Gets or sets a value indicating whether default value for IsAnsi.
        /// </summary>
        public static bool IsAnsiDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ansi vs Unicode.
        /// </summary>
        public bool IsAnsi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether fixed length.
        /// </summary>
        public bool IsFixedLength { get; set; }

        /// <summary>
        /// Gets or sets length of the string -1 for max.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the value of the string.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Add the parameter to the command... internal use only.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        public void AddParameter(IDbCommand command, string name)
        {
            if (this.IsFixedLength && this.Length == -1)
            {
                throw new InvalidOperationException("If specifying IsFixedLength,  a Length must also be specified");
            }

            bool add = !command.Parameters.Contains(name);
            IDbDataParameter param;
            if (add)
            {
                param = command.CreateParameter();
                param.ParameterName = name;
            }
            else
            {
                param = (IDbDataParameter)command.Parameters[name];
            }
#pragma warning disable 0618
            param.Value = SqlMapper.SanitizeParameterValue(this.Value);
#pragma warning restore 0618
            if (this.Length == -1 && this.Value != null && this.Value.Length <= DefaultLength)
            {
                param.Size = DefaultLength;
            }
            else
            {
                param.Size = this.Length;
            }

            param.DbType = this.IsAnsi ? (this.IsFixedLength ? DbType.AnsiStringFixedLength : DbType.AnsiString) : (this.IsFixedLength ? DbType.StringFixedLength : DbType.String);
            if (add)
            {
                command.Parameters.Add(param);
            }
        }
    }
}
