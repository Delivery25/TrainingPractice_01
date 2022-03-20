using System;
using System.IO;
using System.Text;

namespace DDS_Task_05
{
    class Program
    {
        public static int performerX;
        public static int performerY;
        public static string[] newFile = File.ReadAllLines($"maps/labirint.txt");
        public static char[,] map;
        public static char[,] mapWithHelp;
        public static bool start = true;
        public static int progress = 0;

        static void Main()
        {
            Console.Clear();
            ReadMap(ref map, ref mapWithHelp, out performerX, out performerY);
            Console.CursorVisible = false;
            DisplayInfo();

            while (map[performerX, performerY] != map[9, 18])
            {
                Console.SetCursorPosition(0, 7);
                DrawMap(map);
                CalculateProgressBar();
                DrawProgressBar();
                MovePerfomer();
            }

            Console.SetCursorPosition(0, 7);
            DrawMap(map);
            CalculateProgressBar();
            DrawProgressBar();
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("\nПоздравляем. Вы успешно прошли лабиринт!");
        }

        static void CalculateProgressBar()
        {
            if (performerX < 3 && performerY < 5)
            {
                progress = 0;
            }
            else if (performerX > 2 && performerX < 7 && performerY > 2 && performerY < 5)
            {
                progress = 1;
            }
            else if (performerX > 2 && performerY < 3)
            {
                progress = 2;
            }
            else if (performerX == 8 && performerY > 2 && performerY < 14)
            {
                progress = 3;
            }
            else if (performerX > 2 && performerX < 9 && performerY > 5 && performerY < 8)
            {
                progress = 4;
            }
            else if (performerX < 3 && performerY > 5)
            {
                progress = 5;
            }
            else if (performerY > 8 && performerY < 11 && performerX > 2 && performerX < 7)
            {
                progress = 6;
            }
            else if (performerY > 10 && performerY < 16 && performerX > 3 && performerX < 7)
            {
                progress = 7;
            }
            else if (performerY > 15 && performerX > 3 && performerX < 6 || performerY == 19 && performerX == 6)
            {
                progress = 8;
            }
            else if (performerY > 14 && performerX > 6 && performerX < 9 || performerX == 6 && performerY == 17)
            {
                progress = 9;
            }
            else
            {
                progress = 10;
            }
        }

        static void MovePerfomer()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
            ConsoleKey key = keyInfo.Key;

            if (start && key == ConsoleKey.A)
            {
                key = ConsoleKey.W;

            }

            switch (key)
            {
                case ConsoleKey.W:
                    if (map[performerX - 1, performerY] != '█')
                    {
                        DeletePerfomer();
                        performerX -= 1;
                        DrawPerfomer();
                    }
                    break;
                case ConsoleKey.S:
                    if (map[performerX + 1, performerY] != '█')
                    {
                        DeletePerfomer();
                        performerX += 1;
                        DrawPerfomer();
                    }
                    break;
                case ConsoleKey.A:
                    if (map[performerX, performerY - 1] != '█')
                    {
                        DeletePerfomer();
                        performerY -= 1;
                        DrawPerfomer();

                    }
                    break;
                case ConsoleKey.D:
                    if (map[performerX, performerY + 1] != '█')
                    {
                        DeletePerfomer();
                        performerY += 1;
                        DrawPerfomer();
                    }
                    break;
                case ConsoleKey.H:
                    Console.SetCursorPosition(0, 7);
                    DrawMap(mapWithHelp);
                    Console.SetCursorPosition(0, 7);
                    Console.ReadKey();
                    break;
            }
        }

        static void ReadMap(ref char[,] map, ref char[,] mapWithHelp, out int performerX, out int performerY)
        {
            performerX = 0;
            performerY = 0;

            map = new char[newFile.Length, newFile[0].Length];
            mapWithHelp = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (newFile[i][j] == '.')
                    {
                        map[i, j] = ' ';
                        mapWithHelp[i, j] = newFile[i][j];
                    }
                    else
                    {
                        map[i, j] = newFile[i][j];
                        mapWithHelp[i, j] = newFile[i][j];
                    }

                    if (map[i, j] == '☻')
                    {
                        performerX = i;
                        performerY = j;
                    }
                }
            }
        }

        static void DeletePerfomer()
        {
            if (!start)
            {
                map[performerX, performerY] = ' ';
            }
            else
            {
                map[performerX, performerY] = '█';
                start = false;
            }
        }

        static void DrawPerfomer()
        {
            map[performerX, performerY] = '☻';
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void DisplayInfo()
        {
            Console.WriteLine("Добро пожаловать в игру \"Лабиринт\"");
            Console.WriteLine("Ваша задача найти выход");
            Console.WriteLine("Управление осуществляется с клавиатуры на клавиши \"W\" \"A\" \"S\" \"D\"");
            Console.WriteLine("Вы также можете видеть, насколько вы близки к успеху в прогресс-баре");
            Console.WriteLine("Чтобы увидеть правильный маршрут, нажмите клавишу \"h\",");
            Console.WriteLine("чтобы продолжить игру нажмите вновь клавишу \"h\"");
        }

        static void DrawProgressBar()
        {
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("Прогресс-бар");
            Console.SetCursorPosition(30, 11);
            var bar = new StringBuilder("[__________]");
            for (int i = 0; i < progress; i++)
            {
                bar[i + 1] = '#';
            }
            Console.Write(bar);
        }
    }
}
