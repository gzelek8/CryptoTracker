using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}