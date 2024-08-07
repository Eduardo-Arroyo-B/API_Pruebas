using System.Text;
using System.Text.Json;
using API_Pruebas.Models;
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

    [HttpPost]
    public async Task<IActionResult> Index(ConsultaModel consulta)
    {

        var url = "https://arieswebapi-pre-produccion.azurewebsites.net/Contrato/rest/ObtenerContratoLote ";

        var data = new
        {
            userName = consulta.userName,
            password = consulta.password,
            request = new
            {
                IdConpre = consulta.IdConpre
            }
        };
        
        var jsonString = JsonSerializer.Serialize(data);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var client = _clientFactory.CreateClient();
        var response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            ViewBag.ResponseContent = responseContent;
            Console.WriteLine(responseContent);
        }
        else
        {
            ViewBag.ResponseContent = $"Error {response.Content} - {response.ReasonPhrase}";
        }
        
        return View(consulta);
    }
}