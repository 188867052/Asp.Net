﻿using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFrameworkCore.Generator.Core.Metadata.Parsing
{
    [DebuggerDisplay("Context: {ContextClass}")]
    public class ParsedContext
    {
        public ParsedContext()
        {
            this.Properties = new List<ParsedEntitySet>();
        }

        public string ContextClass { get; set; }

        public List<ParsedEntitySet> Properties { get; }
    }
}