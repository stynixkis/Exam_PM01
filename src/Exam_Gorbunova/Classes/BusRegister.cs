using System;
using System.Collections.Generic;
using System.IO;

namespace Exam_Gorbunova.Classes
{
    class BusRegister
    {
        public List<Bus> LibraryBus = new List<Bus>();
        public void SortBus()
        {
            for (int i = 0; i < LibraryBus.Count - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < LibraryBus.Count; j++)
                {
                    if (LibraryBus[j].CountStoped > LibraryBus[maxIndex].CountStoped)
                    {
                        maxIndex = j;
                    }
                    else if (LibraryBus[j].CountStoped == LibraryBus[maxIndex].CountStoped)
                    {
                        if (LibraryBus[j].NumberMarshrut > LibraryBus[maxIndex].NumberMarshrut)
                        {
                            maxIndex = j;
                        }
                    }
                }
                if (i != maxIndex)
                {
                    Bus Temp = LibraryBus[i];
                    LibraryBus[i] = LibraryBus[maxIndex];
                    LibraryBus[maxIndex] = Temp;
                }
            }
        }
        public void SaveToFile(string path)
        {
            string text = "";
            foreach (var item in LibraryBus)
            {
                text += $"Номер маршрута: {item.NumberMarshrut}; Конечная остановка №1: {item.EndStopedNumderOne}; " +
                    $"Конечная остановка №2: {item.EndStopedNumderTwo}; Число остановок: {item.CountStoped}\n";
            }
            if (string.IsNullOrEmpty(text.Trim()))
            {
                Console.WriteLine("\nВ списке нет данных!");
                return;
            }
            try
            {
                using (FileStream str = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] textStream = System.Text.Encoding.Default.GetBytes(text);
                    str.Write(textStream, 0, textStream.Length);
                    str.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex}");
            }
        }

    }
}
