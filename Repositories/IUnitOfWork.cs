namespace shop.Repositories
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
    }
}