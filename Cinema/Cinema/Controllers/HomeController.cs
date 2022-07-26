﻿using Cinema.Data;
using Cinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CinemaContext _context;

        public HomeController(ILogger<HomeController> logger, CinemaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Filmes()
        {
            return View();
        }

        [Authorize(Roles ="Administrador")]
        public IActionResult OnlyAdmins()
        {
            return View();
        }

        [Authorize(Roles = "Funcionário")]
        public IActionResult OnlyFuncionario()
        {
            return View();
        }

        [Authorize(Roles = "Cliente")]
        public IActionResult OnlyCliente()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Funcionário")]
        public IActionResult OnlyAdminsFuncionario()
        {
            return View();
        }

        [Authorize(Roles = "Cliente, Funcionário")]
        public IActionResult OnlyAdminsCliente()
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
