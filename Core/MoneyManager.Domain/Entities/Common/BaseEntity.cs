namespace MoneyManager.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual DateTime? UpdatedDate { get; set; }
}