namespace Parking.Domain.Abstractions;

public abstract class Entity
{
    protected Entity()
        : this(Guid.NewGuid())
    {
    }

    private Entity(Guid id) => Id = id;

    public virtual Guid Id { get; private set; }
}