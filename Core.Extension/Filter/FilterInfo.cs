﻿using System;
using System.Collections.Generic;
using Core.Extension.ExpressionBuilder.Common;
using Core.Extension.ExpressionBuilder.Interfaces;

namespace Core.Extension.Filter
{
    public class FilterInfo<TPropertyType> : IFilterInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterInfo{TPropertyType}"/> class.
        /// Instantiates a new <see cref="FilterInfo{TPropertyType}" />.
        /// </summary>
        /// <param name="propertyId">propertyId.</param>
        /// <param name="operation">operation.</param>
        /// <param name="value">value.</param>
        /// <param name="value2">value2.</param>
        /// <param name="connector">connector.</param>
        public FilterInfo(string propertyId, IOperation operation, TPropertyType value, TPropertyType value2, Connector connector = default)
        {
            this.PropertyName = propertyId;
            this.Connector = connector;
            this.Operation = operation;
            this.SetValues(value, value2);

            // Validate();
        }

        /// <summary>
        /// Establishes how this filter statement will connect to the next one.
        /// </summary>
        public Connector Connector { get; set; }

        /// <summary>
        /// Property identifier conventionalized by for the Expression Builder.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Express the interaction between the property and the constant value defined in this filter statement.
        /// </summary>
        public IOperation Operation { get; set; }

        /// <summary>
        /// Constant value that will interact with the property defined in this filter statement.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Constant value that will interact with the property defined in this filter statement when the operation demands a second value to compare to.
        /// </summary>
        public object Value2 { get; set; }

        private void SetValues(TPropertyType value, TPropertyType value2)
        {
            if (typeof(TPropertyType).IsArray)
            {
                if (!this.Operation.SupportsLists)
                {
                    throw new ArgumentException("It seems the chosen operation does not support arrays as parameters.");
                }

                var listType = typeof(List<>);
                var constructedListType = listType.MakeGenericType(typeof(TPropertyType).GetElementType());
                this.Value = value != null ? Activator.CreateInstance(constructedListType, value) : null;
                this.Value2 = value2 != null ? Activator.CreateInstance(constructedListType, value2) : null;
            }
            else
            {
                this.Value = value;
                this.Value2 = value2;
            }
        }
    }
}