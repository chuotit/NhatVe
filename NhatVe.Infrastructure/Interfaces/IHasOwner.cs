namespace NhatVe.Infrastructure.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}