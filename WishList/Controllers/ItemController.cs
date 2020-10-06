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
        private readonly ApplicationDbContext dbContext;

        public ItemController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Item> items = dbContext.Items.ToList();
            return View(nameof(Index), items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(nameof(Create));
        }

        [HttpPost]
        public IActionResult Create(Item itemToAdd)
        {
            dbContext.Add(itemToAdd);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int itemId)
        {
            Item itemToDelete = dbContext.Items.Find(itemId);
            dbContext.Items.Remove(itemToDelete);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
