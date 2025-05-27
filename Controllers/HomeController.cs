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
        Ahorcado Juegos = new Ahorcado();
        Juegos.empezarJuego(palabraEnviada);

        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(Juegos));

        ViewBag.Largo = Juegos.Palabra.Length;
        ViewBag.LetrasUsadas = Juegos.LetrasUsadas;
        ViewBag.letrasEncontradas = Juegos.PosicionesEncontradas;
        ViewBag.palabra = Juegos.Palabra;
        ViewBag.intentos = Juegos.Intentos;
        direccion = "juegoAhorcado";
        }
        return View(direccion);
    }

    public IActionResult letra(string letraTirada)
    {
        string Juegostring  = HttpContext.Session.GetString("juego");  
        Ahorcado Juegos = Objeto.convertirStringAObjeto<Ahorcado>(Juegostring);
        if(letraTirada != null)
        {
            Juegos.aumentarIntentos(letraTirada);
            
        }
        ViewBag.Largo = Juegos.Palabra.Length;
        ViewBag.LetrasUsadas = Juegos.LetrasUsadas;
        ViewBag.letrasEncontradas = Juegos.PosicionesEncontradas;
        ViewBag.palabra = Juegos.Palabra;
        ViewBag.intentos = Juegos.Intentos;
        HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(Juegos));
        return View("juegoAhorcado");
    }
    public IActionResult palabra(string palabraArriesgada)
    {
        string direccion = "juegoAhorcado";
        string Juegostring = HttpContext.Session.GetString("juego");
        Ahorcado Juegos = Objeto.convertirStringAObjeto<Ahorcado>(Juegostring);
       if(Juegos.ArriesgarPalabra(palabraArriesgada))
       {
            direccion = "Arriesgar";
            ViewBag.palabra = Juegos.Palabra;
       }else{
        ViewBag.Largo = Juegos.Palabra.Length;
        ViewBag.LetrasUsadas = Juegos.LetrasUsadas;
        ViewBag.letrasEncontradas = Juegos.PosicionesEncontradas;
        ViewBag.palabra = Juegos.Palabra;
        ViewBag.intentos = Juegos.Intentos;
       }
       HttpContext.Session.SetString("juego",Objeto.convertirObjetoAString(Juegos));
        return View(direccion);
    }
                
}
