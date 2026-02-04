namespace Starter.Domain.Primitives.Entities;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.CreateVersion7();
    public uint RowVersion { get; protected set; }

    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; }
    public string? UpdatedBy { get; protected set; }

    public bool IsTransient() => RowVersion == 0;

    public override bool Equals(object? obj) => obj is Entity other && (ReferenceEquals(this, other) || Id == other.Id);

    public override int GetHashCode() => Id.GetHashCode();
}
