using CryptoTracker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess
{
    public class CryptoStorageContext : DbContext
    {
        public CryptoStorageContext(DbContextOptions<CryptoStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
