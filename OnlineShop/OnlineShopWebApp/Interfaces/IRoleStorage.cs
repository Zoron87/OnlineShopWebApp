using OnlineShopWebApp.Areas.Administrator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Interfaces
{
    public interface IRoleStorage
    {
        Task Add(Role role);
        Task Delete(string name);
        Task<List<Role>> GetAll();
        Task SaveAll(List<Role> roles);
    }
}
