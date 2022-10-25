namespace Market.Interface.Common
{
    public interface ICreateable<T>
    {
        Task<bool> CreateAsync(T obj);
    }
}
