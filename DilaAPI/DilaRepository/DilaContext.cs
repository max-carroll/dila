using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DilaRepository
{

    public interface IDilaContext
    {
        DbSet<Word> Word { get; set; }
        Task<int> SaveChangesAsync();
    }
    public class DilaDbContext : DbContext, IDilaContext
    {

        public DbSet<Word> Word { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            // If ever we want to get rid of the quotations from the database we can use this
            // https://stackoverflow.com/a/51124087/2423207
            // https://stackoverflow.com/questions/39095495/rename-all-columns-from-all-tables-with-specific-column-name-in-postgresql
            // https://www.dbrnd.com/2017/07/postgresql-generate-alter-statements-to-rename-table-and-column-name-in-lower-case-sensitive/
        }

        public DilaDbContext(DbContextOptions<DilaDbContext> options) : base(options)
        {

        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await base.SaveChangesAsync();
            return result;
        }


    }
}
