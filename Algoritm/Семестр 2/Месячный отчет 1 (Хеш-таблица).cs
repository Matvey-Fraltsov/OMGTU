using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Queue dataQueue = new Queue(); 

        dataQueue.Enqueue(new CallData("123456789", "2022-01-01", "09:00", 30));
        dataQueue.Enqueue(new CallData("987654321", "2022-01-02", "12:00", 45));
        dataQueue.Enqueue(new CallData("123456789", "2022-01-01", "14:00", 10));
        dataQueue.Enqueue(new CallData("123456789", "2022-01-03", "14:00", 15));
        dataQueue.Enqueue(new CallData("987654321", "2022-01-02", "14:00", 20));
        

        Hashtable callMinutes = new Hashtable();

        while (dataQueue.Count > 0)
        {
            CallData call = (CallData)dataQueue.Dequeue();
            string phoneNumber = call.PhoneNumber;
            int callDuration = call.Duration;

            if (callMinutes.ContainsKey(phoneNumber)) callMinutes[phoneNumber] = (int)callMinutes[phoneNumber] + callDuration;
            else callMinutes.Add(phoneNumber, callDuration);

        }

        Console.WriteLine("Месячный отчёт по общей сумме разговора каждого номера телефона:");
        foreach (DictionaryEntry entry in callMinutes)
        {
            Console.WriteLine("Номер телефона: {0}, Общее количество минут: {1}", entry.Key, entry.Value);
        }
    }
}

class CallData
{
    public string PhoneNumber { get; private set; }
    public string Date { get; private set; }
    public string StartTime { get; private set; }
    public int Duration { get; private set; }

    public CallData(string phoneNumber, string date, string startTime, int duration)
    {
        PhoneNumber = phoneNumber;
        Date = date;
        StartTime = startTime;
        Duration = duration;
    }
}
