﻿using System.Data;
using Dapper.FastCrud;
using Smoother.IoC.Dapper.Repository.UnitOfWork.UoW;

namespace Smoother.IoC.Dapper.Repository.UnitOfWork.Data
{
    public class UnitOfWork : DbTransaction, IUnitOfWork
    {
        private readonly IDbFactory _factory;
        public SqlDialect SqlDialect { get; set; }

        public UnitOfWork(IDbFactory factory, IDbConnection session) : base(factory)
        {
            Transaction = session.BeginTransaction();
        }

        public UnitOfWork(IDbFactory factory, IDbConnection session, IsolationLevel isolationLevel) : base(factory)
        {
            Transaction = session.BeginTransaction(isolationLevel);
        }

        
    }
}
