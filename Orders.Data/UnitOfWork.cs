using Orders.Core;

namespace Orders.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderContext _context;

        public UnitOfWork(OrderContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}