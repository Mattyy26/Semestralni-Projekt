using System;
using System.IO;

namespace SemestralniProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vygenerování náhodných čísel a zajištění, že nebudou stejná
            Random rand = new Random();

            int x, y, z, v, w, s;
            x = rand.Next(1, 49);
            do
            {
                y = rand.Next(1, 49);
            } while (y == x);

            do
            {
                z = rand.Next(1, 49);
            } while (z == x ^ z == y);

            do
            {
                v = rand.Next(1, 49);
            } while (v == x ^ v == y ^ v == z);

            do
            {
                w = rand.Next(1, 49);
            } while (w == x ^ w == y ^ w == z ^ w == v);

            do
            {
                s = rand.Next(1, 49);
            } while (s == x ^ s == y ^ s == z ^ s == v ^ s == w);


            //Ukládání náhodných čísel do textového souboru
            using (StreamWriter sw = new StreamWriter(@"C:\Users\matej\source\repos\Projekt\Projekt\data.txt", true))
            {
                sw.WriteLine("Vylosované čísla jsou: {0} {1} {2} {3} {4} {5}", x, y, z, v, w, s);
                //sw.Flush();
            }


            //Vypsaní náhodných čísel pro kontrolu
            
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine(v);
            Console.WriteLine(w);
            Console.WriteLine(s);
            

            Console.WriteLine("---------------------------");
            Console.WriteLine("         LOTERIE           ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Vyberte 6 čísel ( 1 - 49 ).");
            Console.WriteLine("---------------------------");


            //Podmínky (ošetření vstupu)
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;
            int f = 0;
            string input;
            Console.WriteLine("Vyberte první číslo.");



            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out a))
                {
                    a = int.Parse(input);
                    if (a > 0 && a < 50)
                    {
                        Console.WriteLine("Vaše první vybrané číslo je: {0}", a);
                        break;
                    }

                }
                Console.WriteLine("Zadejte správné číslo.");
            }

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out b))
                {
                    b = int.Parse(input);
                    if (b > 0 && b < 50)
                    {
                        Console.WriteLine("Vaše druhé vybrané číslo je: {0}", b);
                        break;
                    }

                }
                Console.WriteLine("Zadejte správné číslo.");
            }

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out c))
                {
                    c = int.Parse(input);
                    if (c > 0 && c < 50)
                    {
                        Console.WriteLine("Vaše třetí vybrané číslo je: {0}", c);
                        break;
                    }

                }
                Console.WriteLine("Zadejte správné číslo.");
            }

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out d))
                {
                    d = int.Parse(input);
                    if (d > 0 && d < 50)
                    {
                        Console.WriteLine("Vaše čtvrté vybrané číslo je: {0}", d);
                        break;
                    }

                }
                Console.WriteLine("Zadejte správné číslo.");
            }

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out e))
                {
                    e = int.Parse(input);
                    if (e > 0 && e < 50)
                    {
                        Console.WriteLine("Vaše páté vybrané číslo je: {0}", e);
                        break;
                    }

                }
                Console.WriteLine("Zadejte správné číslo.");
            }

            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out f))
                {
                    f = int.Parse(input);
                    if (f > 0 && f < 50)
                    {
                        Console.WriteLine("Vaše šesté vybrané číslo je: {0}", f);
                        break;
                    }

                }
                Console.WriteLine("Zadejte správné číslo.");
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Vaše vybraná čísla jsou: {0} {1} {2} {3} {4} {5}", a, b, c, d, e, f);
            Console.WriteLine("-------------------------------------------------------------------");

            //Kontrola shodných čísel a vypsaní, zda hráč vyhrál
            if (x == a && y == b && z == c && v == d && w == e && s == f)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vyhráváte JACKPOT!!!");
            }
            else
            {
                if (x == a && y == b && z == c && v == d && w == e)
                {
                    Console.WriteLine("Výherní čísla jsou: {0} {1} {2} {3} {4} {5}.", x, y, z, v, w, s);
                    Console.WriteLine("Výhra, uhodl jste alespoň 5 stejných čísel!");
                }
                else
                {
                    if (y == b && z == c && v == d && w == e && s == f)
                    {
                        Console.WriteLine("Výherní čísla jsou: {0} {1} {2} {3} {4} {5}.", x, y, z, v, w, s);
                        Console.WriteLine("Výhra, uhodl jste alespoň 5 stejných čísel!");
                    }
                    else
                    {
                        if (x == a && y == b && z == c && v == d)
                        {
                            Console.WriteLine("Výherní čísla jsou: {0} {1} {2} {3} {4} {5}.", x, y, z, v, w, s);
                            Console.WriteLine("Výhra, uhodl jste alespoň 4 stejná čísla!");
                        }
                        else
                        {
                            if (y == b && z == c && v == d && w == e)
                            {
                                Console.WriteLine("Výherní čísla jsou: {0} {1} {2} {3} {4} {5}.", x, y, z, v, w, s);
                                Console.WriteLine("Výhra, uhodl jste alespoň 4 stejná čísla!");
                            }
                            else
                            {
                                if (z == c && v == d && w == e && s == f)
                                {
                                    Console.WriteLine("Výherní čísla jsou: {0} {1} {2} {3} {4} {5}.", x, y, z, v, w, s);
                                    Console.WriteLine("Výhra, uhodl jste alespoň 4 stejná čísla!");
                                }
                                else
                                {
                                    Console.WriteLine("Výherní čísla jsou: {0} {1} {2} {3} {4} {5}.", x, y, z, v, w, s);
                                    Console.WriteLine("Nevyhráváte, zkuste to znova!");
                                }
                            }
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
                        
                    
                

                
            
        
    
