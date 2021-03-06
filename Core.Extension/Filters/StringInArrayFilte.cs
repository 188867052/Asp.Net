﻿using System;
using System.Linq.Expressions;

namespace Core.Extension.Filters
{
    public class StringInArrayFilte<T> : BaseInArrayFilte<T>
    {
        public StringInArrayFilte(Expression<Func<T, string>> expression, string[] value) : base(expression.GetPropertyName(), value)
        {
        }
    }
}
