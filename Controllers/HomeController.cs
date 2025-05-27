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
        Ahorcado juego = new Ahorcado();
        juego.empezarJuego(palabraEnviada);
        HttpContext.Session.SetString("juego",Objetos.convertirObjetoAString(juego));
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
            Juego = HttpContexto.Session.GetString("juego");
            Juego = Objeto.
            Juego.aumentarIntentos(letraTirada);
            
        }
        ViewBag.Largo = Juego.Palabra.Length;
        ViewBag.LetrasUsadas = Juego.LetrasUsadas;
        ViewBag.letrasEncontradas = Juego.PosicionesEncontradas;
        ViewBag.palabra = Juego.Palabra;
        ViewBag.intentos = Juego.Intentos;
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(juego));
        return View("juegoAhorcado");
    }
    public IActionResult palabra(string palabraArriesgada)
    {
        string direccion = "juegoAhorcado";
        Juego = HttpContexto.Session.GetString("juego");
       if(Juego.ArriesgarPalabra(palabraArriesgada))
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
