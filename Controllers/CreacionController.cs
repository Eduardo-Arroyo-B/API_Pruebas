using System.Text;
using System.Text.Json;
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
                password = model.password,
                request = new
                {
                    Expediente = model.Expediente,
                    IdCte = model.IdCte,
                    IdConjunto = model.IdConjunto,
                    TipoContrato = model.TipoContrato,
                    FechaElaCto = model.FechaElaCto,
                    InicioMantenimiento = model.InicioMantenimiento,
                    Inmueble = new
                    {
                        Manzana = model.Manzana,
                        Lote = model.Lote
                    }
                },
                CreadoPor = model.CreadoPor
            };

            var jsonString = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(responseContent);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }

        return View(model);
    }
}