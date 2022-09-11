using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Persistence.DbContexts;

namespace ZooWebShopAPI.Persistence.Seeders
{
    public class DbSeeder
    {
        private readonly CommandDbContext _context;

        public DbSeeder(CommandDbContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if (!_context.Products.Any())
            {
                var products = GetProducts();
                await _context.Products.AddRangeAsync(products);
                await _context.SaveChangesAsync();
            }

            if (!_context.Roles.Any())
            {
                var roles = GetRoles();
                await _context.Roles.AddRangeAsync(roles);
                await _context.SaveChangesAsync();
            }

            if (!_context.Categories.Any())
            {
                var categories = GetCategories();
                await _context.Categories.AddRangeAsync(categories);
                await _context.SaveChangesAsync();
            }
        }

        private List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Royal Canin Maxi Adult",
                    OriginalPrice = 18.69m,
                    Price = 18.69m,
                    ProductCategories = new List<ProductCategory>()
                    {
                        new ProductCategory
                        {
                            CategoryId = 1
                        }
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/maxi/adult/8/400/80729_pla_royalcanin_maxiadult_15kg_hs_01_8.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/maxi/adult/6/800/61093_PLA_rgb_Royal_Canin_Size_Maxi_Adult_26_15kg_6.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/maxi/adult/5/800/80729_royalcanin_maxiadult_15kg_picto_hs_03_5.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/maxi/adult/0/800/80729_royalcanin_maxiadult_15kg_krokette_hs_02_0.jpg",
                        }
                    }
                },
                new Product()
                {
                    Name = "Royal Canin Veterinary - Urinary S/O",
                    OriginalPrice = 20.99m,
                    Price = 20.99m,
                    ProductCategories = new List<ProductCategory>()
                    {
                        new ProductCategory
                        {
                            CategoryId = 2
                        }
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/veterinary/urinary/so/2/400/rc_vet_dry_caturinaryso_mv_eretailkit_de_de_2.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/veterinary/urinary/so/5/800/rc_vet_dry_caturinarysomc_eretailkit_b1_page_03_5.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/veterinary/urinary/so/7/800/rc_vet_dry_caturinarysomc_eretailkit_b1_page_04_7.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/veterinary/urinary/so/8/800/rc_vet_dry_caturinarysomc_eretailkit_b1_page_06_8.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/royal/canin/veterinary/urinary/so/2/800/1_rc_vet_dry_caturinarysomc_eretailkit_b1_page_07_2.jpg",
                        }
                    }
                },
                new Product()
                {
                    Name = "Skyline Felicia Bird Cage - Large",
                    OriginalPrice = 124.99m,
                    Price = 112.99m,
                    ProductCategories = new List<ProductCategory>()
                    {
                        new ProductCategory
                        {
                            CategoryId = 10
                        }
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/skyline/felicia/bird/cage/large/2/800/181897_pla_skyline_vogelheim_felicial_hs_01_2.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/skyline/felicia/bird/cage/large/4/800/181897_skyline_vogelheim_felicial_hs_02_4.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/skyline/felicia/bird/cage/large/0/800/181897_skyline_vogelheim_felicial_hs_03_0.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/skyline/felicia/bird/cage/large/6/800/181897_skyline_vogelheim_felicial_hs_04_6.jpg",
                        },
                        new Photo()
                        {
                            PhotoUrl = "https://shop-cdn-m.mediazs.com/bilder/skyline/felicia/bird/cage/large/5/800/181897_skyline_vogelheim_felicial_hs_05_5.jpg",
                        }
                    }
                },

            };
            return products;
        }
        private List<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
        private List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Dog food"
                },
                new Category()
                {
                    Name = "Cat food"
                },
                new Category()
                {
                    Name = "Rabbit food"
                },
                new Category()
                {
                    Name = "Bird food"
                },
                new Category()
                {
                    Name = "Fish food"
                },
                new Category()
                {
                    Name = "Dog toys"
                },
                new Category()
                {
                    Name = "Cat toys"
                },
                new Category()
                {
                    Name = "Rabbit cages"
                },
                new Category()
                {
                    Name = "Transport"
                },
                new Category()
                {
                    Name = "Bird cage"
                }
            };
            return categories;
        }
    }
}
