using Microsoft.AspNetCore.Mvc;

namespace API_Pruebas.Controllers;

public class ConsultaController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public ConsultaController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }
}