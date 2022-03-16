using System;

namespace DDS_Task_03
{
    class Program
    {
        static void Main()
        {
            var password = "ура!";
            var sms = "Ты сумел открыть тайное сообщение. Поздравляю!";
            var count = 3;
            var pass = "";
            Console.WriteLine("Данная программа хранит тайное сообщение,\nчтобы его увидеть, введите пароль");
            do
            {
                Console.Write("Пароль: ");
                pass = Console.ReadLine();
                if (pass == password)
                {
                    Console.WriteLine(sms);
                }
                else
                {
                    count--;
                    Console.WriteLine($"Пароль не подходит\nОставшиеся попытки - {count}");
                }
            } while (count > 0 && pass != password);

            if (count == 0)
            {
                Console.WriteLine("Попытки закончились.\nПрограмма завершена.");
            }
        }
    }
}
