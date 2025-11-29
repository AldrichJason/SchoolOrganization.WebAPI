using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization.Integration.Manager
{
    public interface IGenericManager<T> where T : class
    {
        Task<T> Post();
        Task<T> Get();
        Task<T> GetById(int id);
        Task<T> Put(int id);
        Task<T> Patch(int id);
    }
}
