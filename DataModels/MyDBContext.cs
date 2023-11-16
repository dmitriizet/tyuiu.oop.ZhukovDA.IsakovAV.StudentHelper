using Microsoft.EntityFrameworkCore;

namespace tyuiu.oop.ZhukovDA.IsakovAV.StudentHelper.DataModels
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        public DbSet<Helper> Helpers { get; set; }
    }
}
