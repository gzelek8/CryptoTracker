using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace CryptoTracker.Entities
{
    public class Cryptocurrency : EntityBase
    {
        public List<Wallet> Wallets { get; set; }
        public Transaction Transaction { get; set; }
        public List<Alert> Alerts { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Rank { get; set; }
    }
}