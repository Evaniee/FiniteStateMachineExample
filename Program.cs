using System;
using System.Threading;

namespace FiniteStateMachineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new monster and select its moves until it dies
            Monster myMonster = new Monster();
            while (myMonster.State != null) myMonster.Iterate();

            // Wait for keypress before exit
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
