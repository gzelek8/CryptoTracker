using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.Entities
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
