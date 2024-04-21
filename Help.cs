using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal static class Help
    {
        internal static void PrintHelpDesk(string[] args)
        {
            Dictionary<string, List<string>> keyValues = new Dictionary<string, List<string>>();

            for (int i = 0; i < args.Length; i++)
            {
                List<string> chains = new List<string>();
                for (int j = i + 1; j <= i + args.Length / 2; j++)
                {
                    if (args.Length - j < args.Length / 2) chains.Add(args[j % args.Length]);
                    else chains.Add(args[j]);
                }
                keyValues.Add(args[i], chains);
            }

            // Задаем размеры таблицы
            int rows = args.Length + 1;
            int columns = args.Length + 1;

            string[,] tableData = new string[rows, columns];

            // Заполняем таблицу произвольными данными
            tableData[0, 0] = "USER/PC";
            for (int i = 1; i < columns; i++)
            {
                tableData[0, i] = args[i-1];
            }
            for (int i = 1;i < rows; i++)
            {
                string users = tableData[i,0] = args[i-1];
                for (int j = 1; j < columns; j++)
                {
                    string comps = tableData[0,j] = args[j-1];
                    tableData[i, j] = IsUserWins(keyValues, users, comps);
                }
            }

            // Выводим таблицу в командную строку с границами столбцов
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("| " + tableData[i, j].PadRight(20)); // Добавляем границу слева и выравниваем по ширине
                }
                Console.Write("|"); // Закрываем последний столбец границей справа
                Console.WriteLine(); // Переходим на новую строку для следующей строки таблицы

                // Выводим горизонтальную границу между строками таблицы
                if (i < rows - 1)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write("+---------------------"); // Добавляем горизонтальные границы
                    }
                    Console.Write("+");
                    Console.WriteLine(); // Переходим на новую строку
                }
            }
            Console.Write("\n\nPress any key to continue...");
            Console.ReadLine();
        }
        private static string IsUserWins(Dictionary<string, List<string>> keyValues, string users, string comps)
        {
            foreach (var item in keyValues)
            {
                if (users == comps) return "Draw";
                if (item.Key == users)
                    if (item.Value.Contains(comps)) return "Win";
                if (item.Key == comps)
                    if (item.Value.Contains(users)) return "Lose";
            }
            return "";
        }
    }

}
