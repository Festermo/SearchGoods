using Microsoft.AspNetCore.Mvc;
using SearchGoods.Data;
using SearchGoods.Models;
using System.Collections;
using System.Diagnostics;

namespace SearchGoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly GoodsDbContext _context;

        public HomeController(GoodsDbContext context)
        {
            _context = context;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index(GoodsModel goodsForm)
        {
            IEnumerable properGoods = FindProperGoods(goodsForm.Name ?? "", goodsForm.Category ?? "");
            return View(properGoods);
        }

        private IEnumerable<GoodsModel> FindProperGoods(string name, string category)
        {
            if (name == "" && category == "") 
                return _context.Goods; //return everything
            List<GoodsModel> properGoods = new List<GoodsModel>();
            foreach (var good in _context.Goods)
            {   
                if (good.Name.ToLower().Contains(name.ToLower()) && (good.Category == category || category == ""))
                    properGoods.Add(good);
            }
            return properGoods;
        }
    }
}