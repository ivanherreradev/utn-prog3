using System.Collections.Concurrent;

namespace BlockingCollection
{
    public class Consumidor
    {
        private BlockingCollection<Mensaje> _colaMensajes;

        public Consumidor(BlockingCollection<Mensaje> colaMensajes)
        {
            _colaMensajes = colaMensajes;
        }

        public void Iniciar()
        {
            /* bloquea el subproceso del Consumidor si la cola está vacía y se desbloquea automáticamente cuando se 
             * agrega un nuevo mensaje a la cola  */
            foreach (var mensaje in _colaMensajes.GetConsumingEnumerable())
            {
                Console.WriteLine($"Consumidor: procesando mensaje {mensaje.Texto}");
                Thread.Sleep(2000);
            }
        }
    }
}
