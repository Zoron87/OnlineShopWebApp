using Newtonsoft.Json;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class RoleStorageInJson : IRoleStorage
    {
        private List<Role> roles;
        private string filePath = "Storages/Roles.json";

        public RoleStorageInJson()
        {
            roles = new List<Role>();
        }

        public void Add(Role role)
        {
            roles = GetAll();
            roles.Add(role);
            SaveAll(roles);
        }

        public void Delete(string name)
        {
            roles = GetAll();
            var role = roles.FirstOrDefault(role => role.Name == name);
            if (role != null)
                roles.Remove(role);
            SaveAll(roles);
        }

        public void SaveAll(List<Role> roles)
        {
            FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(roles, Formatting.Indented));
        }

        public List<Role> GetAll() 
        {
            var oldRoles = FileProvider.GetInfo(filePath);
            if (!string.IsNullOrEmpty(oldRoles))
                return JsonConvert.DeserializeObject<List<Role>>(oldRoles);
            return roles;
        }
    }
}
