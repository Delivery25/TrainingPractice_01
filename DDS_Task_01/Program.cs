using System;

namespace DDS_Task_01
{
    class Program
    {
        public static int amountOfGold;
        public static int amountOfDiamond;
        public static int resultAmountOfGold;
        public static int resultAmountOfDiamond = 0;

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в магазин!\nЗдесь вы можете купить кристаллы за золото.\n1 кристалл стоит 10 единиц золота.\n");

            do
            {
                try
                {
                    Console.Write("Введите начальное количество золота: ");
                    amountOfGold = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    amountOfGold = 0;
                }

            } while (amountOfGold <= 0);

            Console.WriteLine($"\nВаш баланс: \nЗолото - {amountOfGold}");

        link1:
            do
            {
                try
                {
                    Console.Write("\n1 кристалл стоит 10 единиц золота.\nСколько кристаллов Вы хотите приобрести: ");
                    amountOfDiamond = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    amountOfDiamond = 0;
                }
            } while (amountOfDiamond <= 0);

            resultAmountOfGold = amountOfGold - amountOfDiamond * 10;

            while (resultAmountOfGold < 0)
            {
                Console.WriteLine($"\nНа балансе недостаточно денег для совершения покупки.\nВаш баланс:\nЗолото - {amountOfGold}\nКристаллы - {resultAmountOfDiamond}");

                Console.Write("\nЖелаете продолжить (y/n): ");
                var proceed = Console.ReadKey();
                while (proceed.Key != ConsoleKey.Y && proceed.Key != ConsoleKey.N)
                {
                    Console.Write("\rЖелаете продолжить (y/n): ");
                }

                while (proceed.Key == ConsoleKey.Y)
                {

                    goto link1;
                }

                while (proceed.Key == ConsoleKey.N)
                {
                    goto link2;
                }
            }

            while (resultAmountOfGold >= 0)
            {
                resultAmountOfDiamond += amountOfDiamond;

                Console.WriteLine($"\nПокупка успешно совершена!\nВаш баланс:\nЗолото - {resultAmountOfGold}\nКристаллы - {resultAmountOfDiamond} ");
                Console.Write("\nЖелаете продолжить (y/n): ");
                var proceed = Console.ReadKey();
                while (proceed.Key != ConsoleKey.Y && proceed.Key != ConsoleKey.N)
                {
                    Console.Write("\rЖелаете продолжить (y/n): ");
                    proceed = Console.ReadKey();
                }

                while (proceed.Key == ConsoleKey.Y)
                {
                    amountOfGold = resultAmountOfGold;
                    goto link1;
                }

                while (proceed.Key == ConsoleKey.N)
                {
                    goto link2;
                }
            }

        link2:
            Console.WriteLine("\n\nСпасибо за покупку!\nДо свидания!");
        }
    }
}
