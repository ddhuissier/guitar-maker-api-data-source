﻿using StarterKit.Domain.Interfaces;


namespace StarterKit.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
