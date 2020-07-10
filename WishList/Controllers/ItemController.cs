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
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> model = _context.Items.ToList();
            return View("Index",model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int id)
        {
            var itemTobedeleted = _context.Items.FirstOrDefault(item => item.Id == id);
            _context.Items.Remove(itemTobedeleted);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
