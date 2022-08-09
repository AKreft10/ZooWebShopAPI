using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Models;
using ZooWebShopAPI.Persistence.DbContexts;

namespace ZooWebShopAPI.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly AppDbContext _context;

        public DataAccess(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _context
                .Products
                .ToListAsync();

            return result;
        }

        public async Task<Product> AddNewProduct(string firstName, decimal price)
        {
            var product = new Product()
            {
                Name = firstName,
                Price = price
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _context
                .Products
                .Include(z => z.Photos)
                .FirstOrDefaultAsync(z => z.Id == id);

            return product;
        }

        public async Task AddNewCategory(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }
    }
}
