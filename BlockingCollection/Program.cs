using BlockingCollection;
using System.Collections.Concurrent;

class Program
{
    static void Main(string[] args)
    {
        // Creamos la cola de mensajes compartida entre los subprocesos
        var colaMensajes = new BlockingCollection<Mensaje>();

        // Iniciamos el Productor y el Consumidor en subprocesos separados
        var productor = new Productor(colaMensajes);
        var consumidor = new Consumidor(colaMensajes);
        new Thread(() => productor.Iniciar()).Start();
        new Thread(() => consumidor.Iniciar()).Start(); 
    }
}