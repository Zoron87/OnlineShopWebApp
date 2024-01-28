using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Avatar
{
    public class AvatarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly UserViewModel _userViewModel;

        public AvatarViewComponent(UserManager<User> userManager, UserViewModel userViewModel)
        {
            _userManager = userManager;
            _userViewModel = userViewModel;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.IsAuthenticated ? (await _userManager.GetUserAsync(HttpContext.User)).Id : _userViewModel.Id.ToString();
            var user = await _userManager.FindByIdAsync(userId);
            return View("Avatar", user?.AvatarImagepath ?? "");
         }
    }
}
