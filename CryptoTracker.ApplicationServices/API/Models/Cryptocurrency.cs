using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.ApplicationServices.API.Domain.Models
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rank { get; set; }
    }
}
