using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TesteXD.Data;
using TesteXD.Models;

namespace TesteXD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Posts.OrderByDescending(p => p.Data).ToList());
        }
        [Authorize]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPost(Post post)
        {

          if(post != null){
                post.Likes = 0;
                post.Data = DateTime.Now;
                post.UserName = User.Identity.Name;

                _context.Add(post);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
          else return RedirectToAction("Index");
          
        }

        public async Task<string> AddLike(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);

            post.Likes += 1;

            _context.Update(post);
            await _context.SaveChangesAsync();

            return post.Likes.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
