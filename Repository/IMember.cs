using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IMember
    {
        Task<List<Members>> GetAllMembers();
        Task<int> AddMember(Members members);

        Task UpdateMember(Members members);
    }
}
