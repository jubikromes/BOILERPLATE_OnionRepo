namespace Shared;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedOnUtc { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
}
