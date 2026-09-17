namespace THUCTAP.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}