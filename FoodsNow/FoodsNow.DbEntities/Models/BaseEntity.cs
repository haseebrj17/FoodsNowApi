namespace FoodsNow.DbEntities.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public Guid CreatedById { get; set; }
        public Guid UpdatedById { get; set; }
    }
}