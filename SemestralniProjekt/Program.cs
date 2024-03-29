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
        }

        private static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------");
            Console.WriteLine("          LOTERIE          ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Vyberte 6 čísel ( 1 - 49 ).");
            Console.WriteLine("---------------------------");
            Console.ReadKey();
        }

        //private static int nahodnaCisla(int nahodna)
        //{
        //    int[] poleRandom = new int[6];

        //    for (int i = 0; i < poleRandom.Length; i++)
        //    {
        //        if (true)
        //        {

        //        }


        //    }



        //}

        private static int[] userInput(string input, int x) 
        {
            int[] poleInput = new int[6];
            

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
                            Console.WriteLine($"Vaše vybrané {i+1}. číslo je {x}.");
                            break;
                        }

                    }
                    Console.WriteLine("Zadejte správné číslo.");
                }
            }
            return x;
        }
    }
}
/*askdfjlasdf*/                        
                    
                

                
            
        
    
