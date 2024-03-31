using System;
using System.IO;
using System.Xml;

namespace SemestralniProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {



            bool playAgain = true;

            while (playAgain == true)
            {
                Menu();
                int[] poleRandom = nahodnaCisla();
                int[] poleInput = userInput();
                WriteAll(poleInput, "Vaše vybraná čísla jsou: ");
                Console.WriteLine();
                WriteAll(poleRandom, "Vylosovaná čísla jsou: ");
                int shoda = shodnaCisla(poleInput, poleRandom);
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                vypsatVysledky(shoda);
                Console.WriteLine("----------------------------------------\n");
                ulozeniSoubor(poleRandom);
                playAgain = hratZnova();
                
            }
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

        private static int shodnaCisla(int[] poleInput, int[] poleRandom)
        {
            int shoda = 0;
            for (int i = 0; i < poleInput.Length; i++)
            {
                if (poleInput[i] == poleRandom[i])
                {
                    shoda++;
                }
            }
            return shoda;
        }

        private static void vypsatVysledky(int pocetShod)
        {
            Console.WriteLine($"Váš počet shodných čísel je: {pocetShod}");

            if (pocetShod == 6)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vyhrál jsi JACKPOT!!!");
                Console.ResetColor();
            }
            else if (pocetShod >= 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vyhrál jsi!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nevyhrál jsi, zkus to znova!");
                Console.ResetColor();
            }
        }

        private static bool hratZnova()
        {
            bool playAgain;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Chcete hrát znovu? y/n");
                string input = Console.ReadLine();

                if (input == "y")
                {
                    playAgain = true;
                    break;
                }
                else if (input == "n")
                {
                    playAgain = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zadejte platný symbol.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.Clear();
            return playAgain;
        }

        private static void ulozeniSoubor(int[] poleRandom)
        {
            using (StreamWriter sw = new StreamWriter(@"loterie.txt", true))
            {
                sw.Write("Vylosovaná čísla jsou: ");

                for (int i = 0; i < poleRandom.Length; i++)
                {
                    sw.Write($"{poleRandom[i]} ");
                }

                sw.WriteLine("");
            }
        }
    }
}








