using System;

namespace DDS_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuItem;
            string[] arrName = Array.Empty<string>();
            string[] arrPosition = Array.Empty<string>();
            int numberDossier;
            string lastName;

            displayMenu();
            menuNavigation();

            void menuNavigation()
            {
                switch (menuItem)
                {
                    case 1:
                        string name = String.Empty;
                        string position;
                        Console.WriteLine("Добавление досье: ");
                        Console.Write("Введите фамилию: ");
                        name += Console.ReadLine() + " ";
                        Console.Write("Введите имя: ");
                        name += Console.ReadLine() + " ";
                        Console.Write("Введите отчество: ");
                        name += Console.ReadLine();
                        Console.Write("Введите должность: ");
                        position = Console.ReadLine();

                        addDossier(ref arrName, name, ref arrPosition, position);
                        Console.WriteLine("\nДосье успешно добавлено! ");

                        exitToMenu();
                        menuNavigation();
                        break;

                    case 2:
                        Console.WriteLine("Вывод всех досье: ");
                        if (arrName.Length <= 0)
                        {
                            Console.WriteLine("Список досье пуст");
                        }
                        else
                        {
                            for (int i = 0; i < arrName.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}: {arrName[i]}\t - {arrPosition[i]}");
                            }
                        }

                        Console.WriteLine();
                        exitToMenu();
                        menuNavigation();
                        break;

                    case 3:

                        Console.Write("Выберите номер досье для удаления: ");

                        do
                        {
                            try
                            {
                                numberDossier = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                numberDossier = -1;
                            }
                        }
                        while (numberDossier < 0 && numberDossier > arrName.Length);


                        if (numberDossier > 0 && numberDossier < arrName.Length)
                        {
                            deleteDossier(ref arrName, ref arrPosition, numberDossier);
                            Console.WriteLine("\nДосье успешно удалено! ");
                        }
                        else
                        {
                            Console.WriteLine("Такого номера досье не существует");

                        }

                        Console.WriteLine();
                        exitToMenu();
                        menuNavigation();
                        break;
                    case 4:
                        Console.Write("Введите фамилию для поиска: ");
                        lastName = Console.ReadLine();

                        searchByLastName(arrName, arrPosition, lastName);
                        exitToMenu();
                        menuNavigation();
                        break;

                    case 5:
                        Console.WriteLine("Программа завершена");
                        break;

                }
            }

            void exitToMenu()
            {
                Console.Write("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                displayMenu();
            }

            void displayMenu()
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Отдел кадров");
                    Console.WriteLine("1: добавить досье");
                    Console.WriteLine("2: вывести все досье");
                    Console.WriteLine("3: удалить досье");
                    Console.WriteLine("4: поиск по фамилии ");
                    Console.WriteLine("5: выход");
                    Console.Write("\nВыберите пункт меню: ");
                    try
                    {
                        menuItem = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        menuItem = 0;
                    }
                    Console.WriteLine();
                }
                while (menuItem < 1 || menuItem > 5);
            }

            void addDossier(ref string[] arrName, string name, ref string[] arrPosition, string position)
            {
                string[] newArrName = new string[arrName.Length + 1];
                string[] newArrPosition = new string[arrPosition.Length + 1];

                for (int i = 0; i < arrName.Length; i++)
                {
                    newArrName[i] = arrName[i];
                    newArrPosition[i] = arrPosition[i];

                }
                newArrName[^1] = name;
                newArrPosition[^1] = position;

                arrName = newArrName;
                arrPosition = newArrPosition;
            }

            void deleteDossier(ref string[] arrName, ref string[] arrPosition, int numberDossier)
            {
                string[] newArrName = new string[arrName.Length - 1];
                string[] newArrPosition = new string[arrPosition.Length - 1];
                bool success = true;

                for (int i = 0; i < arrName.Length; i++)
                {
                    if (i + 1 != numberDossier && success)
                    {
                        newArrName[i] = arrName[i];
                        newArrPosition[i] = arrPosition[i];
                    }
                    else
                    {
                        for (int j = i; j < arrName.Length - 1; j++)
                        {
                            newArrName[j] = arrName[j + 1];
                            newArrPosition[j] = arrPosition[j + 1];
                        }
                        success = false;
                    }
                }

                arrName = newArrName;
                arrPosition = newArrPosition;
            }

            void searchByLastName(string[] arrName, string[] arrPosition, string lastName)
            {
                var result = String.Empty;


                int count = 0;

                for (int i = 0; i < arrName.Length; i++)
                {
                    if (arrName[i].StartsWith(lastName))
                    {
                        result += $"{count + 1}: {arrName[i]}\t - {arrPosition[i]}\n";
                        count++;
                    }
                }

                if (count > 0)
                {

                    string[] resultName = result.Split('\n');
                    foreach (var item in resultName)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine($"Количество сотрудников с фамилией {lastName} - {count}\n");
                }
                else
                {
                    Console.WriteLine("\nСотрудников с такой фамилией нет\n");
                }

            }
        }
    }
}


