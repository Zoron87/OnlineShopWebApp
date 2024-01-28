using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HomeController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = (await _databaseContext.Products.Include(p => p.ImagesPath).ToListAsync());
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel != null ? View(productsViewModel) : View("Error");
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _databaseContext.Products.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            _databaseContext.Products.Remove(item);
            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
