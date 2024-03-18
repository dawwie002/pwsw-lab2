using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    public class Exercise2
    {
        internal static double average(double[] array)
        {// metoda wyliczajaca srednia wartosci dla podanej tablicy
            double avg=0;
            foreach (var element in array) avg += element;
            avg /= array.Length;

            return avg;
        }

        internal static double findMax(double[] array)
        {// metoda wyznaczajaca maksymalna wartosc
            double max = array[1];
            foreach(var element in array)
            {
                if (element > max) max = element;
            }
            return max;
        }

        internal static double findMin(double[] array)
        {// metoda wyznaczajaca minimalna wartosc
            double min = array[1];
            foreach (var element in array)
            {
                if (element < min) min = element;
            }
            return min;
        }

        internal static void hlThanAvg(double[] array, double avg)
        {//wypisanie wartosci wyzszych lub nizszych niż srednia
            Console.Write("Values higher than the average: ");
            foreach (var element in array)
            {
                if (element > avg)Console.Write(element + "; ");
            }
            Console.Write("\nValues lower than the average: ");
            foreach (var element in array)
            {
                if(element < avg)Console.Write(element + "; ");
            }
            Console.Write("\n");
        }
        internal static void countOfEach(double[] array, double[] valuesPattern)
        {// metoda zliczajaca liczbe wystapien kazdego z elementow
            foreach (var element in valuesPattern)
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (element == array[i]) count++;
                }
                Console.WriteLine("Occurences of " + element + ": " + count);
            }
        }

        internal static double stdDeviation(double[] array, double avg)
        {// metoda wyznaczajaca odchylenie standardowe
            double sum=0;
            foreach ( var element in array) sum += Math.Pow(element-avg,2);
            sum /= array.Length;
            sum = Math.Sqrt(sum);
            return sum;
        }

        public static void zadanie2()
        {// metoda glowna klasy Exercise2
            double[] possibleValues = { 2, 3, 3.5, 4, 4.5, 5 };
            Random rnd = new Random();
            int elementsCount;

            Console.Write("How many elements?: ");
            //weryfikacja czy uzytkownik podal integer
            if (int.TryParse(Console.ReadLine(), out elementsCount))
            {
                // utworzenie tablicy i wypelnienie jej dopuszczalnymi wartosciami
                double[] array = new double[elementsCount];
                for(int i = 0; i < elementsCount; i++)
                {
                    array[i] = possibleValues[rnd.Next(0, possibleValues.Length)];
                }

                // wypisanie wylosowanych wartosci znajdujacych sie w tablicy
                Console.Write("Values of generated array: [ ");
                foreach(var element in array)
                {
                    Console.Write(element+"; ");
                }
                Console.Write("]\n");

                //wywolanie poszczegolnych metod dla funkcjonalnosci opisanych w zadaniu

                Console.WriteLine("Average of values for given array: " + average(array));
                Console.WriteLine("Max value for given array: " + findMax(array));
                Console.WriteLine("Min value for given array: " + findMin(array));

                hlThanAvg(array, average(array));

                Console.WriteLine("Count of occurences of each element for given array: ");
                countOfEach(array,possibleValues);

                Console.WriteLine("Standard deviation of array: "+ stdDeviation(array, average(array)));
            }

            //uzytkownik nie podal integer'a do ilosci elementow tablicy
            else
            {
                Console.WriteLine("Please provide an integer.");
            }
        }
    }
}
