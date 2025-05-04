namespace Platinus.Domain.Entities
{
    public abstract class EntityBase
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
