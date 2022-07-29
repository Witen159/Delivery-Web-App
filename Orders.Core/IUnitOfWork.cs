namespace Orders.Core
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}