namespace Market.Interface.Common
{
    public interface ISearchable<T>
    {
        Task<IEnumerable<T>> SearchAsync(T obj);
    }
}
