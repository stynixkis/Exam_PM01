using Exam_Gorbunova.Classes;
using System;
using System.IO;

namespace Exam_Gorbunova
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа по управлению автобусными маршрутами\n" +
                "\t\tРазработчик: Горбунова А.А. ИПсп-122\n\n");

            BusRegister itemBusRegister = new BusRegister();
            bool correctInput = true;
            int countLine;
            do
            {
                correctInput = true;
                Console.Write("Введите количество записей: ");
                if (!int.TryParse(Console.ReadLine(), out countLine))
                {
                    correctInput = false;
                    Console.WriteLine("\t\tВВЕДИТЕ ЦЕЛОЧИСЛЕННОЕ ЗНАЧЕНИЕ");
                }
                if (correctInput && countLine < 0)
                {
                    correctInput = false;
                    Console.WriteLine("\t\tВВЕДИТЕ ЦЕЛОЧИСЛЕННОЕ ЗНАЧЕНИЕ БОЛЬШЕЕ 0");
                }
                if (correctInput && countLine == 0)
                {
                    correctInput = false;
                    Console.WriteLine("\t\tПрограмма завершает работу, т.к. записи вводить не нужно");
                    return;
                }
            } while (!correctInput);

            Console.WriteLine("\nДобавление данных в список --- Введите данные:\n");
            for (int i = 0; i < countLine; i++)
            {
                Bus itemBus = new Bus();
                Console.WriteLine($"Запись {i + 1}");
                int numberValue;
                do
                {
                    correctInput = true;
                    Console.Write("\tНомер маршрута: ");
                    if (!int.TryParse(Console.ReadLine(), out numberValue))
                    {
                        correctInput = false;
                        Console.WriteLine("\t\tВВЕДИТЕ ЦЕЛОЧИСЛЕННОЕ ЗНАЧЕНИЕ");
                    }
                    if (correctInput && numberValue <= 0)
                    {
                        correctInput = false;
                        Console.WriteLine("\t\tВВЕДИТЕ ЦЕЛОЧИСЛЕННОЕ ЗНАЧЕНИЕ БОЛЬШЕЕ 0");
                    }
                } while (!correctInput);
                itemBus.NumberMarshrut = numberValue;
                do
                {
                    correctInput = true;
                    Console.Write("\tКонечная остановка №1: ");
                    if (string.IsNullOrEmpty((itemBus.EndStopedNumderOne = Console.ReadLine()).Trim()))
                    {
                        correctInput = false;
                        Console.WriteLine("\t\tВВЕДИТЕ НЕ ПУСТОЕ ЗНАЧЕНИЕ");
                    }
                } while (!correctInput);
                do
                {
                    correctInput = true;
                    Console.Write("\tКонечная остановка №2: ");
                    if (string.IsNullOrEmpty((itemBus.EndStopedNumderTwo = Console.ReadLine()).Trim()))
                    {
                        correctInput = false;
                        Console.WriteLine("\t\tВВЕДИТЕ НЕ ПУСТОЕ ЗНАЧЕНИЕ");
                    }
                } while (!correctInput);

                int countStopedValue;
                do
                {
                    correctInput = true;
                    Console.Write("\tКоличество остановок: ");
                    if (!int.TryParse(Console.ReadLine(), out countStopedValue))
                    {
                        correctInput = false;
                        Console.WriteLine("\t\tВВЕДИТЕ ЦЕЛОЧИСЛЕННОЕ ЗНАЧЕНИЕ");
                    }
                    if (correctInput && countStopedValue <= 1)
                    {
                        correctInput = false;
                        Console.WriteLine("\t\tВВЕДИТЕ ЦЕЛОЧИСЛЕННОЕ ЗНАЧЕНИЕ БОЛЬШЕЕ 1");
                    }
                } while (!correctInput);
                itemBus.CountStoped = countStopedValue;
                itemBusRegister.LibraryBus.Add(itemBus);
                Console.WriteLine();
            }
            Console.WriteLine("\nСортировка массива по убыванию (поля: число остановок => номер маршрута)");
            itemBusRegister.SortBus();

            foreach (var item in itemBusRegister.LibraryBus)
            {
                Console.WriteLine($"Номер маршрута: {item.NumberMarshrut};\nКонечная остановка №1: {item.EndStopedNumderOne};\n" +
                    $"Конечная остановка №2: {item.EndStopedNumderTwo};\nЧисло остановок: {item.CountStoped}\n");
            }
            Console.WriteLine("Сохранение результата сортировки в файл\n");
            string path = "";
            do
            {
                correctInput = true;
                Console.Write("Введите путь до директории сохранения файла: ");
                if (string.IsNullOrEmpty((path = Console.ReadLine()).Trim()))
                {
                    correctInput = false;
                    Console.WriteLine("\t\tВВЕДИТЕ НЕ ПУСТОЕ ЗНАЧЕНИЕ");
                }
                if (correctInput && Path.HasExtension(path))
                {
                    correctInput = false;
                    Console.WriteLine("\t\tВВЕДИТЕ ПУТЬ, КОТОРЫЙ ВЕДЕТ ТОЛЬКО ДО ДИРЕКТОРИИ СОХРАНЕНИЯ ФАЙЛА");
                }
                if (correctInput && !Directory.Exists(path))
                {
                    correctInput = false;
                    Console.WriteLine("\t\tВВЕДИТЕ СУЩЕСТВУЮЩИЙ ПУТЬ. ПЕРЕДАННЫЙ ПУТЬ НЕ НАЙДЕН");
                }
            } while (!correctInput);

            path += "\\libraryBus.txt";
            itemBusRegister.SaveToFile(path);
            Console.WriteLine($"\nФайл сохранен успешно по пути {path}");
        }
    }
}
