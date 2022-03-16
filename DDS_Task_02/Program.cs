using System;

namespace DDS_Task_02
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа запущена.\nДля завершения программы введите \"exit\"");
            string p;
            do
            {
                Console.Write("Введите слово: ");
                p = Console.ReadLine();
            }
            while (p != "exit");
            Console.WriteLine("Программа завершена.");
        }
    }
}
