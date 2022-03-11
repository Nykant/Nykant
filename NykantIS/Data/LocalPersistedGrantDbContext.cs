using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantIS.Data
{
    public class LocalPersistedGrantDbContext : PersistedGrantDbContext<LocalPersistedGrantDbContext>
    {
        public LocalPersistedGrantDbContext(DbContextOptions<LocalPersistedGrantDbContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        {

        }

        // My own entities...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // My own configurations...
        }
    }
}

