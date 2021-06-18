using System;

namespace CryptoTracker.Entities
{
    public class Transaction : EntityBase
    {
        public DateTime Date { get; set; }
        public double CryptoAmout { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
        public int? CryptocurrencyId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}