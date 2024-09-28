using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoList
{
    internal class Program
    {
        static List<string> tasks = new List<string>();
        static string filePath = "tasks.txt";

        static void Main(string[] args)
        {
            LoadTasks();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("         Списък със задачи            ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Преглед на задачите");
                Console.WriteLine("2. Добавяне на задача");
                Console.WriteLine("3. Премахване на задача");
                Console.WriteLine("4. Изход");
                Console.WriteLine("========================================");
                Console.ResetColor();
                Console.Write("Изберете опция: ");

                Console.ForegroundColor = ConsoleColor.Red;
                string choice = Console.ReadLine();
                Console.ResetColor();

                switch (choice)
                {
                    case "1":
                        ShowTasks();
                        break;
                    case "2":
                        AddTask();
                        SaveTasks();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Невалиден избор! Моля, опитайте отново.");
                        break;
                }
                Console.WriteLine("\nНатиснете [Enter], за да продължите...");
                Console.ReadLine();
            }
        }

        static void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                tasks.AddRange(File.ReadAllLines(filePath));
            }
        }

        static void ShowTasks()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Вашия списък със задачи:");
            Console.WriteLine("========================================");
            Console.ResetColor();

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
            if (tasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Няма добавени задачи.");
                Console.ResetColor();
            }
        }

        static void AddTask()
        {
            Console.Clear();
            Console.Write("Въведете нова задача: ");

            Console.ForegroundColor = ConsoleColor.Red;
            string task = Console.ReadLine();
            Console.ResetColor();
            tasks.Add(task);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задачата е успешно добавена.");
            Console.ResetColor();
        }

        static void RemoveTask()
        {
            ShowTasks();
            Console.Write("\nВъведете номера на задачата, която искате да премахнете: ");

            Console.ForegroundColor = ConsoleColor.Red;
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                Console.ResetColor();
                tasks.RemoveAt(taskNumber - 1);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Задачата е успешно премахната.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("[Грешка: Въвели сте невалиден номер на задача.]");
            }
        }

        static void SaveTasks()
        {
            File.WriteAllLines(filePath, tasks);
            // Console.WriteLine("Задачите са успешно запазени.");
        }
    }
}