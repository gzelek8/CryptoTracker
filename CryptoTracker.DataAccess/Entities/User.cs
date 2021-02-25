using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.DataAccess.Entities
{
    public class User : EntityBase
    {
        [MaxLength(50)]
        public string Nick { get; set; }
        public Wallet Wallet { get; set; }
        public List<Alert> Alerts { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
