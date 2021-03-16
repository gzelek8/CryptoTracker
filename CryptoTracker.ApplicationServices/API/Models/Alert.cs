using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public decimal PriceAlert { get; set; }
        public int CryptocurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
