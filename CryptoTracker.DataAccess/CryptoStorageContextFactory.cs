using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess
{
    public class CryptoStorageContextFactory : IDesignTimeDbContextFactory<CryptoStorageContext>
    {
        public CryptoStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CryptoStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CryptoStorage;Integrated Security=True");
            return new CryptoStorageContext(optionsBuilder.Options);
        }
    }
}
