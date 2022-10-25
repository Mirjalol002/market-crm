namespace Market.Interface.Common
{
    public interface IUpdateable<T>
    {
        Task<bool> UpdateAsync(int id, T obj);
    }
}
