using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.Entities
{
    public class Wallet : EntityBase
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Cryptocurrency> Cryptocurrencies { get; set; }
    }
}
