public static class Ahorcado
{
public static string Palabra {get;private set;}
public static int Intentos{get;private set;}
public static bool[] ArrayBooleanos{get;private set;}
public static List<char> LetrasUsadas{get;private set;}

static public void empezarJuego(string nomPalabra)
{
Palabra = nomPalabra;
ArrayBooleanos = new bool[Palabra.Length];
}

static public void aumentarIntentos(string letra)
{
    
if(letra != null && letra.Length ==1)
{
char letraNueva;
letraNueva = char.Parse(letra);

    if(buscarLetra(letraNueva))
    {
    Intentos++;     
    LetrasUsadas.Add(letraNueva);

        if(buscarLetraEnPalabra(letraNueva))
        {
    
        }
}
} 
}
static public bool buscarLetra(char letra)
{

bool verificacion = true;
foreach(char item in LetrasUsadas)
{
    if(item == letra)
    {
    verificacion = false;
    }
}
return verificacion;

}
static public List<int> buscarLetraEnPalabra(char letra)
{
int contador = 0;
List<int> listaVerificacion = new List<int>();
foreach(char item in Palabra)
{
    if(item == letra)
    {
    listaVerificacion.Add(contador);

    }
    contador++;
}
return listaVerificacion;
}

}



