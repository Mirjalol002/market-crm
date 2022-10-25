namespace Market.Interface.Common
{
    public interface IDeleteable<T>
    {
        Task<bool> DeleteAsync(int id);
    }
}


