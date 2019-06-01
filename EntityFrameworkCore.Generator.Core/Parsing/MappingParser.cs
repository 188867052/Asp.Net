﻿using System.IO;
using EntityFrameworkCore.Generator.Core.Metadata.Parsing;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Generator.Core.Parsing
{
    public class MappingParser
    {
        private readonly ILogger _logger;

        public MappingParser(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<MappingParser>();
        }

        public ParsedEntity ParseFile(string mappingFile)
        {
            if (string.IsNullOrEmpty(mappingFile) || !File.Exists(mappingFile))
            {
                return null;
            }

            this._logger.LogDebug(
                "Parsing Mapping File: '{0}'",
                Path.GetFileName(mappingFile));

            var code = File.ReadAllText(mappingFile);
            return this.ParseCode(code);
        }

        public ParsedEntity ParseCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)syntaxTree.GetRoot();

            var visitor = new MappingVisitor();
            visitor.Visit(root);

            var parsedEntity = visitor.ParsedEntity;

            if (parsedEntity == null)
            {
                return null;
            }

            this._logger.LogDebug(
                "Parsed Mapping Class: '{0}'; Properties: {1}; Relationships: {2}",
                parsedEntity.MappingClass,
                parsedEntity.Properties.Count,
                parsedEntity.Relationships.Count);

            return parsedEntity;
        }
    }
}
