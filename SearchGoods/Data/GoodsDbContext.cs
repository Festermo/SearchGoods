using Microsoft.EntityFrameworkCore;
using SearchGoods.Models;

namespace SearchGoods.Data
{
    public class GoodsDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public GoodsDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<GoodsModel> Goods => Set<GoodsModel>();
        public DbSet<CategoryModel> Categories => Set<CategoryModel>();
    }
}