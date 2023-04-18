using System.Collections.Concurrent;

namespace BlockingCollectionTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestCantidadElementos()
        {
            var cola = new BlockingCollection<int>(5);

            // Iniciamos el productor y el consumidor en subprocesos separados
            var productor = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    cola.Add(i);
                }
            });

            var consumidor = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    int elemento = cola.Take();
                }
            });

            productor.Start();
            consumidor.Start();

            // Esperamos a que ambos subprocesos terminen
            productor.Join();
            consumidor.Join();

            // Comprobamos que la cantidad de elementos en la cola es cero
            Assert.Equal(0, cola.Count);
        }
    }
}