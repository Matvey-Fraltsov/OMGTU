using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> totalMinutes = new Dictionary<string, int>(); 

        Queue<string> callData = new Queue<string>();
        callData.Enqueue("1234567890 2022-01-01 10:15 40");
        callData.Enqueue("1234567890 2022-01-02 09:30 45");
        callData.Enqueue("9876543210 2022-01-05 14:00 20");
        callData.Enqueue("1234567890 2022-01-12 11:45 60");
        callData.Enqueue("1234567891 2022-01-12 11:45 60");

        while (callData.Count > 0)
        {
            string[] callInfo = callData.Dequeue().Split();
            string phoneNumber = callInfo[0];
            int minutes = int.Parse(callInfo[3]);

            if (totalMinutes.ContainsKey(phoneNumber)) totalMinutes[phoneNumber] += minutes;
            else totalMinutes.Add(phoneNumber, minutes);
        }

        Console.WriteLine("Месячный отчёт по общей сумме разговора каждого номера телефона:");
        foreach (var item in totalMinutes)
        {
            Console.WriteLine("Номер телефона: {0}, Общее количество минут: {1}", item.Key, item.Value);
        }
    }
}
