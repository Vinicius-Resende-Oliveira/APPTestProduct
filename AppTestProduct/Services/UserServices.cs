using APITestProduct.Data;
using APITestProduct.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestProduct.Services
{
    public class UserServices : IBaseServices<User>
    {
        private readonly IDataContext _context;

        public UserServices(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(User obj)
        {
            if (obj == null) throw new Exception("User is invalid");

            _context.User.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            if (Id == null || Id <= 0) throw new Exception("UserID is not valid");

            var itemToDelete = await _context.User.FindAsync(Id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.User.Remove(itemToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<User> Get(int Id)
        {
            if (Id == null || Id <= 0) throw new Exception("UserID is not valid");

            return await _context.User.FindAsync(Id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task Update(User obj)
        {
            if (obj == null) throw new Exception("User is invalid");

            if (obj.Id == null || obj.Id <= 0) throw new Exception("UserID is not valid");

            var itemToUpdate = await _context.User.FindAsync(obj.Id);
            if(itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.Name = obj.Name;
            itemToUpdate.Age = obj.Age;


            await _context.SaveChangesAsync();
        }
    }
}
