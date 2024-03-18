using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAB2
{
    public class Exercise3
    {
        //metoda do tworzenia macierzy i wypelnienia ich wartosciami losowymi z przedzialu -10 do 10 wlącznie.
        public static int[][] createMatrix(int a){

            //generator losowych wartosci - potem metoda next
            Random rnd = new Random();

            // kazdy element jednej kolumny/rzedu jest kolejna macierzą o odpowiedniej ilosci elementow,
            // aby utworzyc macierz kwadratową
            int[][] matrix = new int[a][];

            for (int i = 0; i < a; i++)
            {
                matrix[i] = new int[a];
                //przypisanie losowej wartosci do kazdego elementu macierzy kwadratowej
                for (int j = 0; j < a; j++)
                {
                    //losowanie zawartosci elementu z przedzialu od -10 do 10
                    matrix[i][j] = rnd.Next(-10, 11); 
                }
            }
            return matrix;
        }

        // metoda wypisujaca zawartosc macierzy
        public static void printMatrixValues(int[][] matrix)
        {
            //iterowanie po kazdym elemencie macierzy z osobna
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j]+" ");
                }
                Console.Write("]\n");
            }
            Console.Write("\n");
        }

        //metoda wykonujaca operacje na macierzach
        public static int[][] matrixMath(int[][] matrixA, int[][] matrixB, char type)
        {
            //utworzenie macierzy wynikowej o takich samych wymiarach jak jedna z danych macierzy
            int rows = matrixA.Length;
            int columns = matrixA[0].Length;
            int[][] resultMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                resultMatrix[i] = new int[columns];
            }

            // przeliczenie odpowiadajacych sobie elementow macierzy i przypisanie do macierzy wynikowej
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(type == '+')
                    {
                        resultMatrix[i][j] = matrixA[i][j] + matrixB[i][j];
                    }
                    else if(type == '-')
                    {
                        resultMatrix[i][j] = matrixA[i][j] - matrixB[i][j];
                    }
                    else if (type == '*')
                    {
                        resultMatrix[i][j] = matrixA[i][j] * matrixB[i][j];
                    }
                }
            }
            return resultMatrix;
        }

        public static void matrixSwitch(int[][] matrixA, int[][] matrixB)
        {
            //jeśli podane macierze maja zgodne wymiary
            if ((matrixA.Length == matrixB.Length) && (matrixA[0].Length == matrixB[0].Length))
            {
                Console.Write("Enter the type of operation [+, -, *]: ");

                //odczytanie pierwszego znaku z wczytanego rzedu maczety
                char operation = Console.ReadLine()[0];

                //w zaleznosci od uzytkownika przejscie do odpowiedniej operacji
                switch (operation)
                {
                    case '+':
                        Console.WriteLine("Addition result:");
                        printMatrixValues(matrixMath(matrixA, matrixB, '+'));
                        break;

                    case '-':
                        Console.WriteLine("Subtraction result:");
                        printMatrixValues(matrixMath(matrixA, matrixB, '-'));
                        break;

                    case '*':
                        Console.WriteLine("Multiplication result:");
                        printMatrixValues(matrixMath(matrixA, matrixB, '*'));
                        break;

                    default:
                        Console.WriteLine("Incorrect operation type, choose one from: [+, -, *]!");
                        break;
                }
            }
            // jesli rozmiary macierzy roznia sie
            else
            {
                Console.WriteLine("You have given two different sizes of matrices. Can't do any of the operations.");
            }
        }

        public static void zadanie3()
        {
            //utworzenie macierzy
            Console.Write("Enter size of sqr matrix1: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int[][] mtrxA = createMatrix(a);

            Console.Write("Enter size of sqr matrix2: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int[][] mtrxB = createMatrix(b);

            // wypisanie zawartosci macierzy
            printMatrixValues(mtrxA);
            printMatrixValues(mtrxB);

            // instrukcja zarzadzajaca operacjami matematycznymi
            // samo przeliczanie wydzielone do metody matrixMath
            matrixSwitch(mtrxA, mtrxB);
        }
    }
}