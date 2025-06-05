using FashionWave.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionWave.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>().HasNoKey();

            modelBuilder.Entity<ProductImage>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId);

             modelBuilder.Entity<Size>().HasData(
                 new Size { Id = 1, Name = "S", },
                 new Size { Id = 2, Name = "M", },
                 new Size { Id = 3, Name = "L", },
                 new Size { Id = 4, Name = "XL" }
             );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Черен" },
                new Color { Id = 2, Name = "Червен" },
                new Color { Id = 3, Name = "Бял" },
                new Color { Id = 4, Name = "Розов" },
                new Color { Id = 5, Name = "Син" },
                new Color { Id = 6, Name = "Бежов" },
                new Color { Id = 7, Name = "Сив" },
                new Color { Id = 8, Name = "Лилав" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category    
                {
                    Id = 1,
                    Name = "Дамско Облекло"
                }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "NUCOMO",
                Price = 89.99,
                Description = "Дамска рокля на марката NUMOCO.\r\n- V-образно деколте\r\n- връзване на талията\r\n- изработени от топъл пуловерен материал\r\nМоделът на снимката е висок 165 см и носи размер UNI (XS-2XL).\r\nМатериал: 100% акрил",
                ImageUrl = "https://i.factcool.com/cache2/1400x1400/catalog/products/60/b4/b8/60-b4-b884d8c3497-1-dwukolorowa-sukienka-z-15611.jpg"
            });
        
            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 1, ProductId = 1, ImageUrl = "https://i.factcool.com/cache2/1400x1400/catalog/products/60/f4/b8/60-f4-b8e49ba4497-1-dwukolorowa-sukienka-z-15616.jpg" },
                 new ProductImage { Id = 2, ProductId = 1, ImageUrl = "https://i.factcool.com/cache2/1400x1400/catalog/products/60/86/80/60-86-80395f09497-1-dwukolorowa-sukienka-z-15613.jpg" },
                 new ProductImage { Id = 3, ProductId = 1, ImageUrl = "https://i.factcool.com/cache2/1400x1400/catalog/products/60/15/13/60-15-134c0ee8497-1-dwukolorowa-sukienka-z-15614.jpg" },
                 new ProductImage { Id = 4, ProductId = 1, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/a5/e4/60-a5-e4374393497-1-dwukolorowa-sukienka-z-15612.jpg" },
                 new ProductImage { Id = 5, ProductId = 1, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/88/ce/60-88-ce55abd6497-1-dwukolorowa-sukienka-z-15615.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 2,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "NUCOMO",
                Price = 72.99,
                Description = "Дамска рокля на марката NUMOCO.\r\n- V-образно деколте\r\n- връзване на талията\r\n- изработени от топъл пуловерен материал\r\nМоделът на снимката е висок 165 см и носи размер UNI (XS-2XL).\r\nМатериал: 100% акрил",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/87/f6/60-87-f6694719507-1-azurowa-sweterkowa-suki-15712.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 6, ProductId = 2, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/c8/36/60-c8-363f099b507-1-azurowa-sweterkowa-suki-15713.jpg" },
                 new ProductImage { Id = 7, ProductId = 2, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/a4/d5/60-a4-d569035d507-1-azurowa-sweterkowa-suki-15716.jpg" },
                 new ProductImage { Id = 8, ProductId = 2, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/58/83/60-58-834da908507-1-azurowa-sweterkowa-suki-15717.jpg" },
                 new ProductImage { Id = 9, ProductId = 2, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/a7/4f/60-a7-4f58987e507-1-azurowa-sweterkowa-suki-15715.jpg" },
                 new ProductImage { Id = 10, ProductId = 2, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/60/37/44/60-37-44418a78507-1-azurowa-sweterkowa-suki-15711.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 3,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "TRENDYOL",
                Price = 53.99,
                Description = "Информация за модела: Измервания на модела: Височина: 180 см (5'11'') Бюст: 80 см (31 инча) Талия: 60 см (23 инча) Ханш: 89 см (35 инча);\r\nПродуктът върху манекена е с размер S/36/8;\r\nДължина на модела отпред: 125 см\r\n\r\nСъстав на материала: 100% акрил; Плетива",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/85/ae/11-85-ae72cc6c1_org_zoom.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 11, ProductId = 3, ImageUrl = "https://i.factcool.com/cachhttps://i.factcool.com/cache2/800x800/catalog/products/11/de/40/11-de-4068a6c71_org_zoom.jpg" },
                 new ProductImage { Id = 12, ProductId = 3, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/4f/d6/11-4f-d6450bb01_org_zoom.jpg" },
                 new ProductImage { Id = 13, ProductId = 3, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/25/8f/11-25-8f84079d1_org_zoom.jpg" },
                 new ProductImage { Id = 14, ProductId = 3, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/06/ac/11-06-ac0272761_org_zoom.jpg" },
                 new ProductImage { Id = 15, ProductId = 3, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/e5/53/11-e5-5394610a1_org_zoom.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 4,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "TRENDYOL",
                Price = 25.99,
                Description = "Дамска рокля Trendyol.\r\n- оребрена материя\r\n- удобна кройка\r\n- водолазка\r\nРазмери на модела: Височина: 173 см, Бюст: 79 см, Талия: 60 см, Ханш: 90 см.\r\nПродуктът на модела е с размер S/36.\r\nМатериал: 100% акрил",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/45/22/11-45-2248bc251_org_zoom.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 16, ProductId = 4, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/8a/9f/11-8a-9f956f4f2_org_zoom.jpg" },
                 new ProductImage { Id = 17, ProductId = 4, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/19/6a/11-19-6af334bd4_org_zoom.jpg" },
                 new ProductImage { Id = 18, ProductId = 4, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/24/e4/11-24-e4a72e355_org_zoom.jpg" },
                 new ProductImage { Id = 19, ProductId = 4, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/c5/12/11-c5-12d40d767_org_zoom.jpg" },
                 new ProductImage { Id = 20, ProductId = 4, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/41/fa/11-41-fa3f11351_org_zoom.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 5,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "TRENDYOL",
                Price = 23.99,
                Description = "Дамска рокля Trendyol.\r\n- оребрена материя\r\n- обло деколте\r\n- дължина: 80 см\r\n- леко скъсано на долнището и ръкавите\r\nПродуктът на модела е с размер S/36.\r\nМатериал: 100% акрил",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/31/ae/11-31-aee46a262_org_zoom.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 21, ProductId = 5, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/ac/df/11-ac-df4cc6f56_org_zoom.jpg" },
                 new ProductImage { Id = 22, ProductId = 5, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/13/1d/11-13-1de87ed18_org_zoom.jpg" },
                 new ProductImage { Id = 23, ProductId = 5, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/79/7e/11-79-7e40acf82_org_zoom.jpg" },
                 new ProductImage { Id = 24, ProductId = 5, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/e7/3b/11-e7-3b474ecf10_org_zoom.jpg" },
                 new ProductImage { Id = 25, ProductId = 5, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/b9/ff/11-b9-ffbb28f31_org_zoom.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 6,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "TRENDYOL",
                Price = 53.99,
                Description = "Дамска рокля Trendyol.\r\n- оребрена материя\r\n- обло деколте\r\n- дължинаИнформация за модела: Измервания на модела: Височина: 180 см (5'11'') Бюст: 80 см (31 инча) Талия: 60 см (23 инча) Ханш: 89 см (35 инча);\r\nПродуктът върху манекена е с размер S/36/8;\r\nДължина на модела отпред: 125 см\r\n\r\nСъстав на материала: 100% акрил; Плетива",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/fc/c9/11-fc-c9eed5581_org_zoom.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 26, ProductId = 6, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/b7/93/11-b7-93ecb7171_org_zoom.jpg" },
                 new ProductImage { Id = 27, ProductId = 6, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/1f/1a/11-1f-1a5d4ba81_org_zoom.jpg" },
                 new ProductImage { Id = 28, ProductId = 6, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/6e/54/11-6e-54ce6d341_org_zoom.jpg" },
                 new ProductImage { Id = 29, ProductId = 6, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/7d/b9/11-7d-b9786c621_org_zoom.jpg" },
                 new ProductImage { Id = 30, ProductId = 6, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/bd/94/11-bd-94fd928f1_org_zoom.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 7,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "BeWear B083",
                Price = 145.99,
                Description = "- удобна кройка\r\n\r\n- 3/4 ръкав\r\n\r\n- преден джоб\r\n\r\nМатериал: 90% памук 10% еластан",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/14/03/24/14-03-24b083_royalblue_1b.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 31, ProductId = 7, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/14/f8/cd/14-f8-cdb083_royalblue_2b.jpg" },
                 new ProductImage { Id = 32, ProductId = 7, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/14/f8/cd/14-f8-cdb083_royalblue_2b.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 8,
                CategoryId = 1,
                ProductType = "Рокли",
                ProductName = "Плетени рокли",
                BrandName = "TRENDYOL",
                Price = 54.99,
                Description = "70% акрил 30% полиестер",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/71/f6/11-71-f6c80b436_org_zoom.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 33, ProductId = 8, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/b2/0a/11-b2-0ade54c32_org_zoom.jpg" },
                 new ProductImage { Id = 34, ProductId = 8, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/1f/1a/11-1f-1a5d4ba81_org_zoom.jpg" },
                 new ProductImage { Id = 35, ProductId = 8, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/fc/39/11-fc-3910fb854_org_zoom.jpg" },
                 new ProductImage { Id = 36, ProductId = 8, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/7b/6c/11-7b-6ceafb4b7_org_zoom.jpg" },
                 new ProductImage { Id = 37, ProductId = 8, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/11/d4/f4/11-d4-f456bd348_org_zoom.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 9,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FN63•Ladies Iconic Tee",
                Price = 6.99,
                Description = "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/81/b2/15-81-b2a2e379bg_FN63_03.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 38, ProductId = 9, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/1f/64/15-1f-64109980bg_FN63_03_B.jpg" },
                 new ProductImage { Id = 39, ProductId = 9, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/34/da/15-34-da177255bg_FN63_03_S.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 10,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FN63•Ladies Iconic Tee",
                Price = 5.99,
                Description = "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/b3/06/15-b3-06f26515bg_FN63_01.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 40, ProductId = 10, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/7f/ca/15-7f-cad38d7cbg_FN63_01_B.jpg" },
                 new ProductImage { Id = 41, ProductId = 10, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/84/83/15-84-8379af09bg_FN63_01_S.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 11,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FN63•Ladies Iconic Tee",
                Price = 6.99,
                Description = "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/1e/2f/15-1e-2f16b42ebg_FN63_28.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 42, ProductId = 11, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/b8/68/15-b8-6831513abg_FN63_28_B.jpg" },
                 new ProductImage { Id = 43, ProductId = 11, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/53/d9/15-53-d920198cbg_FN63_28_S.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 12,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FN63•Ladies Iconic Tee",
                Price = 6.99,
                Description = "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/4f/9c/15-4f-9c545530bg_FN63_05.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 44, ProductId = 12, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/13/31/15-13-3103e0d7bg_FN63_05_B.jpg" },
                 new ProductImage { Id = 45, ProductId = 12, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/d8/24/15-d8-242c1f8dbg_FN63_05_S.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 13,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FN63•Ladies Iconic Tee",
                Price = 6.99,
                Description = "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/79/d4/15-79-d405a42abg_FN63_39.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 46, ProductId = 13, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/52/9d/15-52-9d6fc0d2bg_FN63_39_B.jpg" },
                 new ProductImage { Id = 47, ProductId = 13, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/e7/52/15-e7-521341e5bg_FN63_39_S.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 14,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FN63•Ladies Iconic Tee",
                Price = 6.99,
                Description = "Women's T-Shirt | Short sleeves Product features: • 100% cotton • round neckline • short sleeve • ribbed knit hem of the neckline • tapered cut",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/c1/88/15-c1-885717c9bg_FN63_15.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 48, ProductId = 14, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/18/06/15-18-068585c6bg_FN63_15_B.jpg" },
                 new ProductImage { Id = 49, ProductId = 14, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/70/ab/15-70-ab87e41cbg_FN63_15_S.jpg" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 15,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "FRUIT OF THE LOOM FU78•Lady-Fit Valueweight Tee",
                Price = 7.99,
                Description = "Product features: • 100% cotton • round neckline with ribbed hemming cotton/Lycra • reinforcing band at the neck • side seams",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/7e/c3/15-7e-c377b79ebg_FU78_01.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 50, ProductId = 15, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/9a/a1/15-9a-a1cee339bg_FU78_01_B.jpg" },
                 new ProductImage { Id = 51, ProductId = 15, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/d4/11/15-d4-11b38613bg_FU78_01_S.jpg" }
            );


            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 16,
                CategoryId = 1,
                ProductType = "Блузи",
                ProductName = "С къс ръкав",
                BrandName = "Дамска тениска B&C Basic",
                Price = 7.99,
                Description = "Дамска тениска с кръгло деколте\r\nМатериал: 100% памукк",
                ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/5f/72/15-5f-721bf5acbg_B54E_36.jpg"
            });

            modelBuilder.Entity<ProductImage>().HasData(
                 new ProductImage { Id = 52, ProductId = 16, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/01/45/15-01-45a014b3bg_B54E_36_B.jpg" },
                 new ProductImage { Id = 53, ProductId = 16, ImageUrl = "https://i.factcool.com/cache2/800x800/catalog/products/15/07/6e/15-07-6ef736f8bg_B54E_36_S.jpg" }
            );

            modelBuilder.Entity<ProductVariant>().HasData(
               new ProductVariant { Id = 1, ProductId = 1, ColorId = 1, SizeId = 1, Stock = 10 },
               new ProductVariant { Id = 2, ProductId = 2, ColorId = 3, SizeId = 2, Stock = 8 },
               new ProductVariant { Id = 3, ProductId = 3, ColorId = 3, SizeId = 3, Stock = 5 },
               new ProductVariant { Id = 4, ProductId = 4, ColorId = 2, SizeId = 4, Stock = 10 },
               new ProductVariant { Id = 5, ProductId = 5, ColorId = 6, SizeId = 3, Stock = 5 },
               new ProductVariant { Id = 6, ProductId = 6, ColorId = 2, SizeId = 2, Stock = 7 },
               new ProductVariant { Id = 7, ProductId = 7, ColorId = 5, SizeId = 1, Stock = 9 },
               new ProductVariant { Id = 8, ProductId = 8, ColorId = 6, SizeId = 3, Stock = 9 },
               new ProductVariant { Id = 9, ProductId = 9, ColorId = 1, SizeId = 4, Stock = 2 },
               new ProductVariant { Id = 10, ProductId = 10, ColorId = 3, SizeId = 2, Stock = 5 },
               new ProductVariant { Id = 11, ProductId = 11, ColorId = 4, SizeId = 3, Stock = 3 },
               new ProductVariant { Id = 12, ProductId = 12, ColorId = 2, SizeId = 3, Stock = 6 },
               new ProductVariant { Id = 13, ProductId = 13, ColorId = 8, SizeId = 1, Stock = 2 },
               new ProductVariant { Id = 14, ProductId = 14, ColorId = 3, SizeId = 1, Stock = 6 },
               new ProductVariant { Id = 15, ProductId = 15, ColorId = 3, SizeId = 1, Stock = 5 },
               new ProductVariant { Id = 16, ProductId = 16, ColorId = 8, SizeId = 1, Stock = 5 }
            );
        }
    }
}
