using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.Entities
{
    public class User : EntityBase
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        public Wallet Wallet { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}