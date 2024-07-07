using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                    // Manav Kategorisi için ürünler
                    new Product
                    {
                        Id = 1,
                        Name = "Elma",
                        Price = 2.5,
                        Quantity = 100,
                        CategoryId = 1 // Manav kategorisi
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Armut",
                        Price = 3.0,
                        Quantity = 80,
                        CategoryId = 1 // Manav kategorisi
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Domates",
                        Price = 1.75,
                        Quantity = 120,
                        CategoryId = 1 // Manav kategorisi
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Salatalık",
                        Price = 1.5,
                        Quantity = 90,
                        CategoryId = 1 // Manav kategorisi
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Portakal",
                        Price = 3.25,
                        Quantity = 70,
                        CategoryId = 1 // Manav kategorisi
                    },

                    // Teknoloji Kategorisi için ürünler
                    new Product
                    {
                        Id = 6,
                        Name = "Laptop",
                        Price = 3500,
                        Quantity = 50,
                        CategoryId = 2 // Teknoloji kategorisi
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Akıllı Telefon",
                        Price = 2500,
                        Quantity = 80,
                        CategoryId = 2 // Teknoloji kategorisi
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Tablet",
                        Price = 1500,
                        Quantity = 60,
                        CategoryId = 2 // Teknoloji kategorisi
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "Oyun Konsolu",
                        Price = 2000,
                        Quantity = 40,
                        CategoryId = 2 // Teknoloji kategorisi
                    },
                    new Product
                    {
                        Id = 10,
                        Name = "Kulaklık",
                        Price = 100,
                        Quantity = 200,
                        CategoryId = 2 // Teknoloji kategorisi
                    },

                    // Şarküteri Kategorisi için ürünler
                    new Product
                    {
                        Id = 11,
                        Name = "Sucuk",
                        Price = 20,
                        Quantity = 30,
                        CategoryId = 3 // Şarküteri kategorisi
                    },
                    new Product
                    {
                        Id = 12,
                        Name = "Peynir",
                        Price = 15,
                        Quantity = 50,
                        CategoryId = 3 // Şarküteri kategorisi
                    },
                    new Product
                    {
                        Id = 13,
                        Name = "Zeytin",
                        Price = 10,
                        Quantity = 80,
                        CategoryId = 3 // Şarküteri kategorisi
                    },
                    new Product
                    {
                        Id = 14,
                        Name = "Bal",
                        Price = 25,
                        Quantity = 40,
                        CategoryId = 3 // Şarküteri kategorisi
                    },
                    new Product
                    {
                        Id = 15,
                        Name = "Reçel",
                        Price = 12,
                        Quantity = 60,
                        CategoryId = 3 // Şarküteri kategorisi
                    }
                );
        }
    }
}
