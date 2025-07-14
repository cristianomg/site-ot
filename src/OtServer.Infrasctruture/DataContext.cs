using Microsoft.EntityFrameworkCore;

namespace OtServer.Infrasctruture
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
