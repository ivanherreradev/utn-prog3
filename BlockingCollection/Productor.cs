using System.Collections.Concurrent;

namespace BlockingCollection
{
    public class Productor
    {
        private BlockingCollection<Mensaje> _colaMensajes;

        public Productor(BlockingCollection<Mensaje> colaMensajes)
        {
            _colaMensajes = colaMensajes;
        }

        public void Iniciar()
        {
            for (int i = 0; i < 10; i++)
            {
                var mensaje = new Mensaje() { Texto = $"Mensaje {i}" };
                _colaMensajes.Add(mensaje);
                Console.WriteLine($"Productor: agregó mensaje {mensaje.Texto}");
                Thread.Sleep(1000);
            }

            // Indicamos que el Productor terminó de agregar mensajes
            _colaMensajes.CompleteAdding();
        }
    }
}
