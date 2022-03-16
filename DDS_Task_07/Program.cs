using System;

namespace DDS_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            var pr = new Program();
            bool success;
            int element;
            do
            {
                Console.Write("Введите количество элементов в одномерном массиве: ");
                success = int.TryParse(Console.ReadLine(), out element);
                if (element < 2)
                {
                    success = false;
                }
            }
            while (!success);


            int[] arr = new int[element];

            Console.WriteLine("\nИсходный массив: ");
            var rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1000);
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine("\n\nПеремешанный массив: ");
            pr.Shuffle(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.ReadLine();
        }

        void Shuffle(int[] arr)
        {
            var rand = new Random();
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}
