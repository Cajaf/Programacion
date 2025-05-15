using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

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
    public IActionResult Juego(string palabraEnviada)
    {
        string direccion = "Index";
        if(palabraEnviada != null)
        {
            Ahorcado.empezarJuego(palabraEnviada);
        ViewBag.Largo = Ahorcado.Palabra.Length;
        ViewBag.LetrasUsadas = Ahorcado.LetrasUsadas;
        ViewBag.letrasEncontradas = Ahorcado.PosicionesEncontradas;
        ViewBag.palabra = Ahorcado.Palabra;
        ViewBag.intentos = Ahorcado.Intentos;
        direccion = "juegoAhorcado";
        }
        return View(direccion);
    }

    public IActionResult letra(string letraTirada)
    {
        if(letraTirada != null)
        {
        Ahorcado.aumentarIntentos(letraTirada);
        }
        ViewBag.Largo = Ahorcado.Palabra.Length;
        ViewBag.LetrasUsadas = Ahorcado.LetrasUsadas;
        ViewBag.letrasEncontradas = Ahorcado.PosicionesEncontradas;
        ViewBag.palabra = Ahorcado.Palabra;
        ViewBag.intentos = Ahorcado.Intentos;
        
        return View("juegoAhorcado");
    }
    public IActionResult palabra(string palabraArriesgada)
    {
        string direccion = "juegoAhorcado";
       if(Ahorcado.ArriesgarPalabra(palabraArriesgada))
       {
            direccion = "Arriesgar";
            ViewBag.palabra = Ahorcado.Palabra;
       }else{
        ViewBag.Largo = Ahorcado.Palabra.Length;
        ViewBag.LetrasUsadas = Ahorcado.LetrasUsadas;
        ViewBag.letrasEncontradas = Ahorcado.PosicionesEncontradas;
        ViewBag.palabra = Ahorcado.Palabra;
        ViewBag.intentos = Ahorcado.Intentos;
       }
        return View(direccion);
    }
                
}
