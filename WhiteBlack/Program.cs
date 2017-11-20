using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zaprogramuj algorytm Biało-Czarne 1 opisany na wykładzie. 

//Niektóre z przedmiotów są czarne, a niektóre białe. 
//Zakładamy, że liczba czarnych przedmiotów jest nieparzysta.
//Pobieramy kolejno dwa przedmioty z S, jeżeli przedmioty są 
//różnego koloru to wstawiamy z powrotem czarny. 
//Jaki jest kolor ostatniego przedmiotu?

namespace WhiteBlack
{
    class Program
    {
        //symulujemy zbiór z elementami przy pomocy listy
        static void BialoCzarne1(List<int> zbior)
        {
            Random r = new Random();
            while (zbior.Count > 1)
            {
                //losujemy pierwszy
                int idx1 = r.Next(zbior.Count);
                int pierwszy = zbior[idx1];
                zbior.RemoveAt(idx1);
                //losujemy drugi
                int idx2 = r.Next(zbior.Count);
                int drugi = zbior[idx2];
                zbior.RemoveAt(idx2);
                Console.WriteLine("wylosowano {0} oraz {1} ", pierwszy, drugi);
                if (pierwszy != drugi)
                {
                    zbior.Add(1);
                    Console.WriteLine(" zwrócono czarny");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            if (zbior.Count == 1)
            {
                Console.WriteLine("Zosatał element " + zbior[0]);
            }
            else
            {
                Console.WriteLine("pusto!");
            }
        }

        // implementacja bez list
        static void WhiteBlack1(int white, int black)
        {
            // w , b - odpowiednio liczba białych i czarnych
            char c1 = ' ', c2 = ' '; // kolor wylosowanego przedmiotu 'w' biały 'b' czarny

            Random r = new Random();
            while (black + white > 1)
            {
                // od 0 do white-1 białe ; od white do white +black-1 czarne

                // pobieramy dwa losowo wybrane przedmioty 
                int i = r.Next(black + white);
                if (i < white) { white--; c1 = 'w'; }// wylosowano biały, white-1 zmniejszamy liczbe białych 
                else { black--; c1 = 'b'; }// wylosowano czarny, black-1 zmniejszamy liczbe czarnych 
                                           // ponownie losujemy
                i = r.Next(black + white);
                if (i < white) { white--; c2 = 'w'; }// wylosowano biały, white-1 zmniejszamy liczbe białych  
                else { black--; c2 = 'b'; }// wylosowano czarny, black-1 zmniejszamy liczbe czarnych

                // jeśli jeden z nich jest czarny a drugi biały, to wstawiamy go z powrotem              
                if (c1 != c2) black++;
            }
            Console.WriteLine("czarnych " + black + " bialych " + white);
        }

        //symulujemy zbiór z elementami przy pomocy listy
        static void BialoCzarne2(List<int> zbior)
        {
            Random r = new Random();
            while (zbior.Count > 1)
            {
                //losujemy pierwszy
                int idx1 = r.Next(zbior.Count);
                int pierwszy = zbior[idx1];
                zbior.RemoveAt(idx1);
                //losujemy drugi
                int idx2 = r.Next(zbior.Count);
                int drugi = zbior[idx2];
                zbior.RemoveAt(idx2);

                if (pierwszy == 0 || drugi == 0)
                {
                    zbior.Add(0);
                }
            }
            if (zbior.Count == 1)
            {
                Console.WriteLine("Zosatał element " + zbior[0]);
            }
            else
            {
                Console.WriteLine("pusto!");
            }
        }

        // implementacja bez list
        static void WhiteBlack2(int white, int black)
        {
            // w , b - odpowiednio liczba białych i czarnych
            char c1 = ' ', c2 = ' '; // kolor wylosowanego przedmiotu 'w' biały 'b' czarny

            Random r = new Random();
            while (black + white > 1)
            {
                // od 0 do white-1 białe ; od white do white +black-1 czarne

                // pobieramy dwa losowo wybrane przedmioty 
                int i = r.Next(black + white);
                if (i < white) { white--; c1 = 'w'; }// wylosowano biały, white-1 zmniejszamy liczbe białych 
                else { black--; c1 = 'b'; }// wylosowano czarny, black-1 zmniejszamy liczbe czarnych 
                                           // ponownie losujemy
                i = r.Next(black + white);
                if (i < white) { white--; c2 = 'w'; }// wylosowano biały, white-1 zmniejszamy liczbe białych  
                else { black--; c2 = 'b'; }// wylosowano czarny, black-1 zmniejszamy liczbe czarnych

                // if co najmniej jeden jest biały then wstaw z powrotem jeden biały              
                if (c1 == 'b' || c2 == 'b') white++;
            }
            Console.WriteLine("czarnych " + black + " bialych " + white);
        }


        static void Main(string[] args)
        {
            // 1 - czarny,  0 - biały
            List<int> zbior1 = new List<int> { 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 };
            BialoCzarne1(zbior1);
            // teraz załozenie niespelnione parzysta liczba czarnych
            List<int> zbior2 = new List<int> { 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0 };
            BialoCzarne1(zbior2);
            Console.WriteLine();
            WhiteBlack1(7, 7);
            WhiteBlack1(8, 6);

            WhiteBlack2(7, 7);
            //WhiteBlack2(8, 6);
            BialoCzarne2(zbior1);

            Console.ReadKey();
        }
    }
}
