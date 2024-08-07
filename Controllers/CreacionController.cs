using API_Pruebas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Pruebas.Controllers;

public class CreacionController : Controller
{

    private readonly IHttpClientFactory _clientFactory;

    public CreacionController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PostData(CreacionModel model)
    {
        if (ModelState.IsValid)
        {
            var url = "https://arieswebapi-pre-produccion.azurewebsites.net/Contrato/rest/CrearContratoLote_MP_PC ";

            var data = new
            {
                userName = model.userName,
                password = model.password
            };
        }

        return View();
    }
}