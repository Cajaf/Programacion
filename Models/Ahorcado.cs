public class Ahorcado
{
public string Palabra {get;private set;}
public int Intentos{get;private set;}
public bool[] PosicionesEncontradas{get;private set;}
public List<char> LetrasUsadas{get;private set;}
public bool Vivo {get;private set;}
public void empezarJuego(string nomPalabra)
{
    Intentos = 0;
    nomPalabra = nomPalabra.ToLower();
Palabra = nomPalabra;
PosicionesEncontradas = new bool[Palabra.Length];
for(int i = 0;i < PosicionesEncontradas.Length;i ++)
{
    PosicionesEncontradas[i] = false;
}
LetrasUsadas = new List<char>();
Vivo = true;
}

public void aumentarIntentos(string letra)
{
    if(letra.Length == 1)
    {
    letra = letra.ToLower();
    char letraNueva = char.Parse(letra);
    if(buscarLetra(letraNueva))
    {
    Intentos++;     
    LetrasUsadas.Add(letraNueva);
    List<int> lista = buscarLetraEnPalabra(letraNueva);

        if(lista.Count > 0)
        {
            foreach (int item in lista)
            {
             PosicionesEncontradas[item] = true;

            } 
    
        }
    }
    }
} 

public bool buscarLetra(char letra)
{
letra = char.ToLower(letra);
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
public List<int> buscarLetraEnPalabra(char letra)
{
int contador = 0;
letra = char.ToLower(letra);
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
public bool ArriesgarPalabra(string palabraArriesgada)
{


bool ganaste = false;

palabraArriesgada = palabraArriesgada.ToLower();
if(palabraArriesgada == Palabra)
{
    ganaste = true;
}else
{
    Intentos = Intentos*2;
}

return ganaste;


}


}



