using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RentRepo : IRent
    {
        private readonly libContext _context;

        public RentRepo(libContext contaxt)
        {
            _context = contaxt;

        }
        public async Task<int> AddRent(Rent rent)
        {
            if (_context != null)
            {
                await _context.Rent.AddAsync(rent);
                await _context.SaveChangesAsync();
                return rent.Rentid;
            }
            return 0;
        }

        public async Task<int> DeleteRent(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var client = await _context.Rent.FindAsync(id);
                //check condition
                if (client != null)
                {
                    //delete
                    _context.Rent.Remove(client);
                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return 0;
        }

        public async Task<List<Rent>> GetAllRents()
        {
            if (_context != null)
                return await _context.Rent.ToListAsync();
            else
                return null;
        }

        public async  Task UpdateRent(Rent rent)
        {
            if (_context != null)
            {
                _context.Entry(rent).State = EntityState.Modified;
                _context.Rent.Update(rent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
