using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW.Models;
using UOW.Repositories;

namespace UOW.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<Person> Persons { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Persons = new GenericRepository<Person>(context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
