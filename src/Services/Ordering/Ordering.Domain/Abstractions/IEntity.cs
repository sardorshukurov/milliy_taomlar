namespace Ordering.Domain.Abstractions;

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}

public interface IEntity
{
    DateTime? CreatedAt { get; set; }

    string? CreatedBy { get; set; }

    DateTime? LastModifiedAt { get; set; }

    string? LastModifiedBy { get; set; }
}
