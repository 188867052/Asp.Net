﻿namespace EntityFrameworkCore.Generator.Core.Options
{
    /// <summary>
    /// View model mapper class options.
    /// </summary>
    /// <seealso cref="ClassOptionsBase" />
    public class MapperClassOptions : ClassOptionsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperClassOptions"/> class.
        /// </summary>
        public MapperClassOptions(VariableDictionary variables, string prefix)
            : base(variables, AppendPrefix(prefix, "Mapper"))
        {
            this.Generate = false;
            this.Namespace = "{Project.Namespace}.Domain.Mapping";
            this.Directory = @"{Project.Directory}\Domain\Mapping";

            this.BaseClass = "AutoMapper.Profile";
            this.Name = "{Entity.Name}Profile";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this option is generated.
        /// </summary>
        /// <value>
        ///   <c>true</c> to generate; otherwise, <c>false</c>.
        /// </value>
        public bool Generate { get; set; }

        /// <summary>
        /// Gets or sets the mapper class name template.
        /// </summary>
        /// <value>
        /// The mapper class name template.
        /// </value>
        public string Name
        {
            get => this.GetProperty();
            set => this.SetProperty(value);
        }

        /// <summary>
        /// Gets or sets the base class to inherit from.
        /// </summary>
        /// <value>
        /// The base class.
        /// </value>
        public string BaseClass
        {
            get => this.GetProperty();
            set => this.SetProperty(value);
        }
    }
}