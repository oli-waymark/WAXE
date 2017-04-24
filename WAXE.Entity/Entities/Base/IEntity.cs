namespace WAXE.Entity.Entities.Base
{
    public interface IEntity<out T> : IDomain
    {
        new T Id { get; }
    }
}
