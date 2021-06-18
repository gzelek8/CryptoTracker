using System.Collections.Generic;

namespace CryptoTracker.Entities
{
    public class Wallet : EntityBase
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}