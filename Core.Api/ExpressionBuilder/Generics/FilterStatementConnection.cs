﻿using Core.Api.ExpressionBuilder.Common;
using Core.Api.ExpressionBuilder.Interfaces;

namespace Core.Api.ExpressionBuilder.Generics
{
    /// <summary>
    /// Connects to FilterStatement together.
    /// </summary>
	public class FilterStatementConnection : IFilterStatementConnection
    {
        private readonly IFilter _filter;
        private readonly IFilterInfo _statement;

        internal FilterStatementConnection(IFilter filter, IFilterInfo statement)
        {
            this._filter = filter;
            this._statement = statement;
        }

        /// <summary>
		/// Defines that the last filter statement will connect to the next one using the 'AND' logical operator.
		/// </summary>
		public IFilter And
        {
            get
            {
                this._statement.Connector = Connector.And;
                return this._filter;
            }
        }

        /// <summary>
        /// Defines that the last filter statement will connect to the next one using the 'OR' logical operator.
        /// </summary>
		public IFilter Or
        {
            get
            {
                this._statement.Connector = Connector.Or;
                return this._filter;
            }
        }
    }
}