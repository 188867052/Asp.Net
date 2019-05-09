﻿using System;
using System.Data;

namespace Core.Extension.Dapper
{
    public static partial class SqlMapper
    {
        private struct DeserializerState
        {
            public readonly int Hash;
            public readonly Func<IDataReader, object> Func;

            public DeserializerState(int hash, Func<IDataReader, object> func)
            {
                this.Hash = hash;
                this.Func = func;
            }
        }
    }
}
