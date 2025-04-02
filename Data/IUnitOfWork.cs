using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW.Models;
using UOW.Repositories;

namespace UOW.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> Persons { get; }
        Task<int> SaveChangesAsync();
    }
}
