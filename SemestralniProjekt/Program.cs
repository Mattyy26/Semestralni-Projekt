using System;
using System.IO;

namespace SemestralniProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
            int[] poleInput = userInput();
            int[] poleRandom = nahodnaCisla();
            WriteAll(poleInput, "Vaše vybraná čísla jsou: ");
            WriteAll(poleRandom, "Vylosovaná čísla jsou: ");
            Console.ReadLine();

        }

        private static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------");
            Console.WriteLine("          LOTERIE          ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Vyberte 6 čísel ( 1 - 49 ).");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Stiskněte enter pro start");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

        }

        private static int[] nahodnaCisla()
        {
            int[] poleRandom = new int[6];

            Random random = new Random();

            for (int i = 0; i < poleRandom.Length; i++)
            {

                while (true)
                {
                    int cislo = random.Next(1, 49);

                    if (!poleRandom.Contains(cislo))
                    {
                        poleRandom[i] = cislo;
                        break;
                    }
                }
            }
            return poleRandom;
        }

        private static int[] userInput()
        {
            int[] poleInput = new int[6];
            string input;
            int x;

            Console.WriteLine("Vyberte první číslo.");

            for (int i = 0; i < poleInput.Length; i++)
            {
                while (true)
                {
                    input = Console.ReadLine();
                    if (int.TryParse(input, out x))
                    {
                        x = int.Parse(input);
                        if (x > 0 && x < 50)
                        {
                            Console.WriteLine($"Vaše vybrané {i + 1}. číslo je {x}.\n");
                            Console.WriteLine($"Vyberte {i + 2} číslo.");
                            break;
                        }

                    }
                    Console.WriteLine("Zadejte správné číslo.");
                }
                poleInput[i] = x;
            }
            Console.Clear();
            return poleInput;
            
        }

        private static void WriteAll(int[] pole, string message)
        {
            Console.Write(message);
            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write($"{pole[i]} ");

            }
            
        }

        private static void shodnaCisla(int[] poleInput, int[] poleRandom)
        {
            for (int i = 0; i < poleInput.Length; i++)
            {

                


            }



        }
    }
}








