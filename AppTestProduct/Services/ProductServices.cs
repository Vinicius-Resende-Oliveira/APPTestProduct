using APITestProduct.Data;
using APITestProduct.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestProduct.Services
{
    public class ProductServices : IBaseServices<Product>
    {
        private readonly IDataContext _context;

        public ProductServices(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Product obj)
        {
            _context.Product.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var itemToDelete = await _context.Product.FindAsync(Id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Product.Remove(itemToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<Product> Get(int Id)
        {
            return await _context.Product.FindAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task Update(Product obj)
        {
            var itemToUpdate = await _context.Product.FindAsync(obj.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.Name = obj.Name;
            itemToUpdate.Description = obj.Description;
            itemToUpdate.Price = obj.Price;
            itemToUpdate.Quantity = obj.Quantity;


            await _context.SaveChangesAsync();
        }
    }
}
