using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    public class Exercise1
    {
        //metoda wyswietlajaca zawartosc tablicy
        internal static void printArrayValues(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write(element + ", ");
            }
            Console.WriteLine("\n");
        }

        public static void zadanie1()
        {
            do
            {
                // pobranie rozmiaru tablicy
                Console.Write("How many values do you want to bubble sort?: ");
                int elementsCount = Convert.ToInt16(Console.ReadLine());

                //utworzenie tablicy o ilosci elementow zadeklarowanej przez uzytkownika
                int[] array = new int[elementsCount];

                // pobranie wartosci do tablicy
                for(int i=0; i<elementsCount; i++){
                    Console.Write("Provide value for #"+(i+1)+" element: ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("\nArray before bubble sort:");
                printArrayValues(array);

                // sortowanie bąbelkowe
                // elementsCount - 1 = tablice iterują od zera
                // iterowanie po elementach tablicy
                for(int i=0; i < elementsCount-1; i++)
                {
                    for(int j=0; j < elementsCount - i - 1; j++)
                    {
                        //jesli nastepny element jest mniejszy od poprzedniego
                        if (array[j] > array[j + 1])
                        {
                            // zamiana wartosci z wykorzystaniem zmiennej tymczasowej
                            int tmp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tmp;
                        }
                    }
                }

                Console.WriteLine("\nArray after bubble sort:");
                printArrayValues(array);

            } while (true);       
        }
    }
}
