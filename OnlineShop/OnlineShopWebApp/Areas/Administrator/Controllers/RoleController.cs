using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly IRoleStorage roleStorage;

        public RoleController(IRoleStorage roleStorage)
        {
            this.roleStorage = roleStorage;
        }
        public ActionResult Index()
        {
            var roles = roleStorage.GetAll();
            return View(roles);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Role role)
        {
            var roles = roleStorage.GetAll();
            if (roles.Any(r => r.Name.ToLower() == role.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"Роль {role.Name} уже существует");
            }

            if (ModelState.IsValid)
            {
                roleStorage.Add(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public ActionResult Delete(string name)
        {
            roleStorage.Delete(name);
            return RedirectToAction("Index");
        }
    }
}
