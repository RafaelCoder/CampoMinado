using System;
using CampoMinadoLibrary.Model;
using System.Globalization;

namespace CampoMinadoTeste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Match m = new Match();
            Console.WriteLine(" - - - - - - Campo inicial - - - - - - ");
            m.ShowFields();
            bool bombFounded = false;
            while(!bombFounded | m.Winner())
            {
                Console.WriteLine(" - - - - - - - - - - - - - -");
                Console.Write("Coord X: ");
                int x = int.Parse(Console.ReadLine(), NumberStyles.Number);

                Console.Write("Coord Y: ");
                int y = int.Parse(Console.ReadLine(), NumberStyles.Number);

                Console.Clear();
                Console.WriteLine($" X={x} | Y={y} ");
                bombFounded = m.Reveal(x, y);
                m.ShowFields();
            }
            if (bombFounded)
                Console.WriteLine("\n \n \n Você Mamou! \n \n \n");
            else Console.WriteLine("\n \n \n YOU WIN! \n \n \n");
            string line = Console.ReadLine();

        }
    }
}
