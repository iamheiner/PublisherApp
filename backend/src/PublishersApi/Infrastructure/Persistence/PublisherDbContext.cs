using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PublisherDbContext: DbContext, IApplicationDbContext
    {
        public PublisherDbContext(DbContextOptions<PublisherDbContext> options) : base(options)
        {

        }
        public DbSet<Publishers> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);        
        }
    }
}
