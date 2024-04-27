using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace SemestralniProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            bool playAgain = true;

            while (playAgain == true) // bool, while ke konci rozhoduje, zda uživatel chce loterii spustit znova nebo ne
            {
                Menu();// Menu loterie
                int[] poleRandom = nahodnaCisla();// načtení náhodných čísel
                int[] poleInput = userInput();// userInput čísel
                WriteAll(poleInput, "Vaše vybraná čísla jsou: ");// vypíše uživatelem zadaná čísla
                Console.WriteLine();
                WriteAll(poleRandom, "Vylosovaná čísla jsou: ");// vypíše náhodně vygenerovaná čísla
                int shoda = shodnaCisla(poleInput, poleRandom);// zjistí, kolik čísel je shodných
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                vypsatVysledky(shoda);// vypíše počet shod
                Console.WriteLine("----------------------------------------\n");
                ulozeniSoubor(poleRandom);// uloží data do souborů
                playAgain = hratZnova();// zeptá se uživatele, zda chce hrát znovu nebo ukončit program
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

            while (true) //opatreni pro zmacknuti enteru pro pokracovani, popripade vypsani zadani spatneho symbolu a opakovani
            {
                ConsoleKeyInfo klavesa = Console.ReadKey();

                if (klavesa.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nZadejte platný symbol.");
                    Console.ResetColor();
                }
            }
            Console.Clear();
        } // Menu loterie

        private static int[] nahodnaCisla() //Vygeneruje náhodná čísla a uloží jej do pole
        {
            int[] poleRandom = new int[6];

            Random random = new Random();

            for (int i = 0; i < poleRandom.Length; i++)
            {

                while (true)// ošetří, aby se čísla neopakovala
                {
                    int cislo = random.Next(1, 49);

                    if (!poleRandom.Contains(cislo))
                    {
                        poleRandom[i] = cislo;
                        break;
                    }
                }
            }
            return poleRandom;// vrátí pole nahodných čísel
        }

        private static int[] userInput() // uživatelem zadaná čísla
        {
            int[] poleInput = new int[6];// vytvoří pole o 6 int
            string input;
            int x;

            Console.WriteLine("Vyberte první číslo.");

            for (int i = 0; i < poleInput.Length; i++)
            {
                while (true)// ošetří, aby čísla byla zadaná v podmínkách, což je rozmezí 1-49, jinak to vypíše chybu
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

        private static void WriteAll(int[] pole, string message)// vypíše náhodně vygenerovaná čísla a uživatelem zadaná čísla
        {
            Console.Write(message);
            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write($"{pole[i]} ");

            }

        }

        private static int shodnaCisla(int[] poleInput, int[] poleRandom)// zjistí počet shodných čísel
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

        private static void vypsatVysledky(int pocetShod)// vypíše počet shod a zajistí vypsání informace o výhře či prohře na základě shod
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

        private static bool hratZnova()// na základě inputu uživatele spustí hru znova nebo ji ukončí, také ošetřuje, aby nebyl zadán špatná symbol
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

        private static void ulozeniSoubor(int[] poleRandom)// ukládá vylosovaná čísla do textového souboru, možnost si zobrazit historii výherních čísel
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








