using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class MemberRepo : IMember
    {
        private readonly libContext _context;

        public MemberRepo(libContext contaxt)
        {
            _context = contaxt;

        }
        public async Task<int> AddMember(Members members)
        {
            if (_context != null)
            {
                await _context.Members.AddAsync(members);
                await _context.SaveChangesAsync();
                return members.Mid;
            }
            return 0;
        }

        public async Task<List<Members>> GetAllMembers()
        {
            if (_context != null)
                return await _context.Members.ToListAsync();
            else
                return null;
        }

        public async Task UpdateMember(Members members)
        {
            if (_context != null)
            {
                _context.Entry(members).State = EntityState.Modified;
                _context.Members.Update(members);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
