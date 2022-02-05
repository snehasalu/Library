using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRent
    {
        Task<List<Rent>> GetAllRents();
        Task<int> AddRent(Rent rent );

        Task UpdateRent(Rent rent);
        Task<int> DeleteRent(int? id);
    }
}
