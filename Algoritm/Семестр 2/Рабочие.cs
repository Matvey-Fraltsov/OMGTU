List<Thing> worker1Things = new List<Thing> { new Thing(3, 10), new Thing(5, 20) };
List<Thing> worker2Things = new List<Thing> { new Thing(1, 30), new Thing(3, 40) };
List<Thing> worker3Things = new List<Thing> { new Thing(4, 10), new Thing(6, 15) };
List<Thing> worker4Things = new List<Thing> { new Thing(2, 20), new Thing(3, 25) };
List<Thing> worker5Things = new List<Thing> { new Thing(1, 35), new Thing(4, 40) };

Worker worker1 = new Worker("1", "Иванов Алексей Иванович", "Высшее", "IT", 700, worker1Things);
Worker worker2 = new Worker("3", "Петрова Мария Витальевна", "Высшее", "Медицина", 200, worker2Things);
Worker worker3 = new Worker("4", "Сергеев Анталоий Петрович", "Среднее", "Продажи", 50, worker3Things);
Worker worker4 = new Worker("5", "Семёнов Николай Сергеевич", "Высшее", "Финансы", 0, worker4Things);
Worker worker5 = new Worker("6", "Морозова Ольга Александровна", "Высшее", "Образование", 45, worker5Things);
List<Worker> workers = new List<Worker> {worker1, worker2, worker3, worker4, worker5};

var smallEarn = from w in workers where (ThingsPriceSum(w) > w.Earn) select w.FullName;
foreach (var worker in smallEarn) Console.WriteLine(worker.ToString());
Console.WriteLine();

var thingsSumPerWorker = from w in workers select new { Name = w.FullName, Count = ThingsCountSum(w) };
foreach (var worker in thingsSumPerWorker) Console.WriteLine($"{worker.Name}: {worker.Count}");
Console.WriteLine();

int thingsSum = (from w in workers select ThingsCountSum(w)).Sum();
Console.WriteLine(thingsSum.ToString());
Console.WriteLine();

int midEarnCount = (from w in workers where (0.5 * (double)ThingsPriceSum(w) <= w.Earn) select w).Count();
Console.WriteLine(midEarnCount.ToString());

static int ThingsPriceSum(Worker w) => (from t in w.Things select (t.Price * t.Count)).Sum();

static int ThingsCountSum(Worker w) => (from t in w.Things select t.Count).Sum();
class Thing
{
    public int Count { get; set; }
    public int Price { get; set; }
    public Thing(int count, int price)
    {
        this.Count = count;
        this.Price = price;
    }
}

class Worker
{
    public string Number { get; set; }
    public string FullName { get; set; }
    public string Education { get; set; }
    public string Specialize { get; set; }
    public int Earn { get; set; }
    public List<Thing> Things { get; set; }

    public Worker(string number, string fullName, string education, string specialize, int earn, List<Thing> things)
    {
        this.Number = number;
        this.FullName = fullName;
        this.Education = education;
        this.Specialize = specialize;
        this.Earn = earn;
        this.Things = things;
    }
}
