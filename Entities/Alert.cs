namespace CryptoTracker.Entities
{
    public class Alert : EntityBase
    {
        public decimal PriceAlert { get; set; }
        public int? CryptocurrencyId { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}