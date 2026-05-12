using Fiorello_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContext> SliderContexts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
    }
}
