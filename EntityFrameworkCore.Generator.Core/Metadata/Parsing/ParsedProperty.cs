﻿using System.Diagnostics;

namespace EntityFrameworkCore.Generator.Core.Metadata.Parsing
{
    [DebuggerDisplay("Column: {ColumnName}, Property: {PropertyName}")]
    public class ParsedProperty
    {
        public string ColumnName { get; set; }

        public string PropertyName { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(this.ColumnName)
                && !string.IsNullOrEmpty(this.PropertyName);
        }
    }
}