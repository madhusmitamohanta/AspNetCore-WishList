using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<Item> model = _context.Items.ToList();
            return View("Index",model);
        }

        [HttpGet]
        public IActionResult create()
        {
            return View("create");
        }
        [HttpPost]
        public IActionResult create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var itemToBeDeleted = _context.Items.Where(data => data.Id == Id).FirstOrDefault();
            _context.Items.Remove(itemToBeDeleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
