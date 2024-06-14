using System;

namespace Primzahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            Console.Title = "Primzahlen";
            Console.BackgroundColor = ConsoleColor.White;
            int zahl1, zahl2;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Bitte geben Sie zwei ganze Zahlen ein,");
                Console.WriteLine("für die Primzahlen berechnet werden sollen...\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Die erste Zahl muss größer 1 sein, da 0 und 1 keine Primzahlen sind!");
                Console.WriteLine("Die zweite Zahl muss größer / gleich der ersten Zahl sein!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                
                do
                {
                    Console.Write("Zahl 1: ");
                    Int32.TryParse(Console.ReadLine(), out zahl1);
                    if (zahl1 <= 1) Console.WriteLine("Fehler, Zahl 1 muss größer 1 sein!");
                } while (zahl1 <= 1);
                
                Console.Write("Zahl 2: ");
                Int32.TryParse(Console.ReadLine(), out zahl2);
                if (zahl2 >= zahl1)
                {
                    string[] primeArray = PrimeNumbers(zahl1, zahl2);
                    if (primeArray.Length == 0) Console.WriteLine("In dem gewählten Intervall gibt es keine Primzahlen.");
                    foreach (string prime in primeArray)
                    {
                        Console.Write("{0}, ", prime);
                    }
                }
                else
                {
                    Console.WriteLine("Fehler, Zahl 2 muss größer / gleich Zahl 1 sein!");
                }
                Console.WriteLine("\nESC zum Abbrechen");
                //Console.WriteLine("Beliebige Taste für Neustart");
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Escape);
        }

        static string[] PrimeNumbers(int from, int to)
        {
            string result = "";

            for(int i = from; i <= to; i++)
            {
                bool isPrime = true;

                for (int x = 2; x < i; x++)
                {
                    if (i % x == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                
                if (isPrime)
                {
                    result += i + ",";
                }
            }

            return result.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}