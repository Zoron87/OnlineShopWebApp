using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RoleController : Controller
    {
        private readonly IRoleStorage roleStorage;

        public RoleController(IRoleStorage roleStorage)
        {
            this.roleStorage = roleStorage;
        }
        public ActionResult GetRoles()
        {
            var roles = roleStorage.GetAll();
            return View(roles);
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            var roles = roleStorage.GetAll();
            if (roles.Any(r => r.Name.ToLower() == role.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"Роль {role.Name} уже существует");
            }

            if (ModelState.IsValid)
            {
                roleStorage.Add(role);
                return RedirectToAction("GetRoles");
            }
            return View(role);
        }

        public ActionResult DeleteRole(string name)
        {
            roleStorage.Delete(name);
            return RedirectToAction("GetRoles");
        }
    }
}
