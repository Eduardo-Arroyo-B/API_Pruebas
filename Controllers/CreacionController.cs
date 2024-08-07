using Microsoft.AspNetCore.Mvc;

namespace API_Pruebas.Controllers;

public class CreacionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}