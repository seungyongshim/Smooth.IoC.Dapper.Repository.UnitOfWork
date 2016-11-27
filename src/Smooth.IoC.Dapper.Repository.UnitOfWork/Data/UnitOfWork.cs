﻿using System;
using System.Data;
using Dapper.FastCrud;

namespace Smooth.IoC.Dapper.Repository.UnitOfWork.Data
{
    public class UnitOfWork : DbTransaction, IUnitOfWork
    {
        public SqlDialect SqlDialect { get; set; }
        private readonly Guid _guid = Guid.NewGuid();
        
        public UnitOfWork(IDbFactory factory, ISession session, IsolationLevel isolationLevel = IsolationLevel.Serializable) : base(factory)
        {
            Transaction = session.BeginTransaction(isolationLevel);
        }

        protected bool Equals(UnitOfWork other)
        {
            return _guid.Equals(other._guid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UnitOfWork) obj);
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }

        public static bool operator ==(UnitOfWork left, UnitOfWork right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitOfWork left, UnitOfWork right)
        {
            return !Equals(left, right);
        }
    }
}
