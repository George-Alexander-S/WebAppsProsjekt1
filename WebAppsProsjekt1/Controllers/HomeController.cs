﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppsProsjekt1.ViewModels;

namespace WebAppsProsjekt1.Controllers;

public class HomeController : Controller
{
    // This logger is currently unused, as logging is not implemented.
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
