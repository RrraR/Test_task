using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test_task.Models;

namespace test_task.Controllers;

public class HomeController : Controller
{
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

    [HttpPost]
    public IActionResult Index(string StrInput)
    {
        string StrOutput = StringReverse(StrInput);
        ViewData["StrOutput"] = StrOutput;
        return View();
    }
    
    public static string StringReverse(string str)
    {
        if (str.Length > 0)
            return str[^1] + StringReverse(str[..^1]);
        else
            return str;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}