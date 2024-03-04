namespace ALAYSchoolGest.Domain.Shared;

public abstract class EntityBase : IEquatable<Guid>
{
    protected EntityBase() => Id = Guid.NewGuid();

    public Guid Id { get; }
    public bool Equals(Guid id) => Id == id;

    public override int GetHashCode() => Id.GetHashCode();


}