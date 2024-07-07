using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.SeedData
{
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                    new Category
                    {
                        Id = 1,
                        Name = "Manav",
                        Description = "Sebze ve Meyve ürünleri bulunur"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Teknoloji",
                        Description = "Teknolojik ürünler bulunur"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Şarküteri",
                        Description = "Kahvaltılık ürünler bulunur"
                    }
                );

            
        }
    }
}