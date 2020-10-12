using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Products_Catergories.Models;


namespace Products_Catergories.Controllers     
{
    public class HomeController : Controller  
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }
        
        [HttpGet("")]      
        public IActionResult Index()
        {
            List<Product> Products = _context.Products
                .Include(p => p.Associations)
                .ThenInclude(a => a.Category)
                .ToList();
            return View("Index", Products);
            
        }

        [HttpPost("")]
        public IActionResult CreateProduct(Product FromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(FromForm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateChef");
            }

        }

        [HttpGet("/catergories")]      
        public IActionResult ShowCategories()
        {
            List<Catergory> Catergories = _context.Catergories
                .Include(p => p.Associations)
                .ThenInclude(a => a.Product)
                .ToList();
            return View("ShowCategories", Catergories);         
        }

        [HttpPost("/catergories")]
        public IActionResult CreateCategory(Catergory FromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(FromForm);
                _context.SaveChanges();
                return RedirectToAction("catergories");
            }
            else
            {
                return View("CreateCatergory");
            }

        }
    }
}
