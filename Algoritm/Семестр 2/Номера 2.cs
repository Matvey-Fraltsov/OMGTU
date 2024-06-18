using System;
using System.Collections.Generic;
using System.Linq;

class Call
{
    public string CallerNumber { get; set; }
    public string ReceiverNumber { get; set; }
    public DateTime CallDate { get; set; }
    public int DurationMinutes { get; set; }
}

class Program
{
    static void Main()
    {
        List<Call> calls = new List<Call>
        {
            new Call { CallerNumber = "999-455-75-50", ReceiverNumber = "913-660-30-57", CallDate = new DateTime(2022, 1, 1), DurationMinutes = 10 },
            new Call { CallerNumber = "999-455-75-50", ReceiverNumber = "961-880-85-76", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 15 },
            new Call { CallerNumber = "999-455-75-50", ReceiverNumber = "913-660-30-57", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 20 },
            new Call { CallerNumber = "999-455-75-50", ReceiverNumber = "913-672-58-44", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 25 },
            new Call { CallerNumber = "999-455-75-50", ReceiverNumber = "913-672-58-44", CallDate = new DateTime(2022, 1, 2), DurationMinutes = 25 }
        };

        var selectedCallerNumber = "999-455-75-50";

        var mostTalkedWithInDay = calls.Where(c => c.CallerNumber == selectedCallerNumber)
                                .GroupBy(c => new { c.CallDate, c.ReceiverNumber })
                                .Select(g => new
                                {
                                    CallDate = g.Key.CallDate,
                                    ReceiverNumber = g.Key.ReceiverNumber,
                                    TotalDuration = g.Sum(call => call.DurationMinutes)
                                })
                                .GroupBy(g => g.CallDate)
                                .SelectMany(g =>
                                {
                                    var topReceiver = g.OrderByDescending(x => x.TotalDuration).FirstOrDefault();
                                    return new[]
                                    {
                                        new
                                        {
                                            CallDate = g.Key,
                                            CallerNumber = selectedCallerNumber,
                                            ReceiverNumber = topReceiver.ReceiverNumber,
                                            TotalDuration = topReceiver.TotalDuration
                                        }
                                    };
                                });

        foreach (var data in mostTalkedWithInDay)
        {
            Console.WriteLine($"Дата: {data.CallDate.ToString("d")}, Клиент {data.CallerNumber} больше всего говорил с абонентом {data.ReceiverNumber}, кол-во минут: {data.TotalDuration} ");
        }
    }
}
