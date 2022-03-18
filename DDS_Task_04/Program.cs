using System;

namespace DDS_Task_04
{
    class Program
    {
        public static int numberSpell;
        public static int healthPlayer;
        public static int healthBoss;
        public static int move;
        public static bool doubling = false;
        public static int attackPower;
        public static bool spell4 = false;
        public static bool concealment = false;
        public static bool pacification = false;

        static void Main()
        {
            var rand = new Random();
            healthPlayer = rand.Next(1000, 1201);
            healthBoss = rand.Next(1200, 1501);
            move = rand.Next(1, 3);

            Console.WriteLine("Игра - \"Последняя битва\"");
            Console.WriteLine("Условия игры:");
            Console.WriteLine("Максимальное количество здоровья у игрока: 1200 HP");
            Console.WriteLine("Максимальное количество здоровья у Босса: 1500 HP");
            Console.WriteLine("Право первого хода определяется случайно");
            Console.WriteLine("Мощность атаки Босса на каждом ходе случайна");
            Console.WriteLine("У игрока есть арсенал из 5 заклинаний:");
            Console.WriteLine("1: Великая мощь - удваивает мощность атаки для заклинания \"Неведомая сила\"");
            Console.WriteLine("2: Зеркало - отнимает у игрока и у Босса по 200 HP");
            Console.WriteLine("3: Сокрытие - следующий ход босса не приносит вам урон. Здоровье восстанавливается на 150 единиц");
            Console.WriteLine("4: Неведомая сила - мощность атаки определяется случайным образом от 550 до 650 единиц. Может использоваться только после заклинания \"Зеркало\"");
            Console.WriteLine("5: Усмирение - наносит удар, отнимая 100 единиц здоровья. Мощность атаки Босса на один ход будет уменьшена в 2 раза");

            Console.WriteLine("\nНачальные показатели здоровья: ");
            showHealth();

            do
            {
                Console.WriteLine();
                if (move == 1)
                {
                    Console.WriteLine("ХОД ИГРОКА");
                    Console.Write("Введите номер заклинания: ");
                    try
                    {
                        numberSpell = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        numberSpell = 6;

                    }
                    castingASpell();
                    showHealth();

                    move = 2;
                }
                else
                {
                    Console.WriteLine("ХОД БОССА");
                    attackPower = rand.Next(300, 350);
                    if (concealment)
                    {
                        Console.WriteLine($"Мощность атаки: {attackPower}");
                        Console.WriteLine("Атака не проходит по игроку благодаря заклинанию \"Сокрытие\"");
                        concealment = false;
                    }
                    else if (pacification)
                    {
                        Console.WriteLine($"Мощность атаки: {attackPower / 2}");
                        healthPlayer -= attackPower / 2;
                        pacification = false;
                    }
                    else
                    {
                        Console.WriteLine($"Мощность атаки: {attackPower}");
                        healthPlayer -= attackPower;
                    }

                    move = 1;
                    showHealth();
                }
            }
            while (healthPlayer > 0 && healthBoss > 0);

            if (healthPlayer < 0)
            {
                Console.WriteLine("\nИгра окончена.\nПобедил Босс!");
            }
            else if (healthBoss < 0)
            {
                Console.WriteLine("\nИгра окончена.\nПоздравляем\nПобедил игрок!");
            }
            else if (healthBoss < 0 && healthPlayer < 0)
            {
                Console.WriteLine("\nИгра окончена.\nВ столь тяжелой битве умерли оба.");
            }

            void castingASpell()
            {
                switch (numberSpell)
                {
                    case 1:
                        doubling = true;
                        Console.WriteLine($"Мощность атаки для заклинания \"Неведомая сила\" будет удвоена");
                        break;
                    case 2:
                        Console.WriteLine($"Атака в 200 единиц прошла по игроку и Боссу");
                        healthPlayer -= 200;
                        healthBoss -= 200;
                        spell4 = true;
                        break;
                    case 3:
                        Console.WriteLine($"Игрок скрылся, повысив здоровье на 150 HP ");
                        healthPlayer += 150;
                        concealment = true;
                        break;
                    case 4:
                        if (spell4)
                        {
                            attackPower = rand.Next(550, 651);
                            if (doubling)
                            {
                                Console.WriteLine($"Удвоенная мощность атаки: {attackPower + attackPower}");
                                healthBoss -= attackPower + attackPower;
                            }
                            else
                            {
                                Console.WriteLine($"Мощность атаки: {attackPower}");
                                healthBoss -= attackPower;
                            }
                            spell4 = false;
                        }
                        else
                        {
                            Console.WriteLine("Прежде чем использовать это заклинание, воспользуйтесь заклинанием \"Зеркало\"");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Босс ослаблен, его мощность атаки снижается в два раза на ход, а здоровье уменьшилось на 100 HP");
                        healthBoss -= 100;
                        pacification = true;
                        break;
                    default:
                        Console.WriteLine("Ох, вы произнесли неправильное заклинание");
                        Console.WriteLine("Ход переходит к Боссу");
                        break;
                }
            }

            void showHealth()
            {
                Console.WriteLine($"Здоровье игрока - {healthPlayer} HP");
                Console.WriteLine($"Здоровье Босса  - {healthBoss} HP");
            }
        }
    }
}
