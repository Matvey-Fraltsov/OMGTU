public class BankCount
{
    int bill;
    string fio;
    string phone;
    double income;
    double expense;
    double taxes;
    public int Bill { get => bill; }
    public string Fio { get => fio; }
    public string Phone { get => phone; }
    public double Income { get => income; }
    public double Expense { get => expense; }
    public double Taxes { get => taxes; }
    public BankCount(int bill, string fio, string phone, double income, double expense)
    {
        this.bill = bill;
        this.fio = fio;
        this.phone = phone;
        this.income = income;
        this.expense = expense;
        this.taxes = income * 0.05;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        BankCount[] bank_data = new BankCount[6]
        {
        new BankCount(101, "Светлана", "8-101-101-0101", 123.1, 100),
        new BankCount(102, "Алина", "8-102-102-0202", 380.1, 50),
        new BankCount(103, "Андрей", "8-103-103-0303", 103, 73),
        new BankCount(104, "Виолетта", "8-104-104-0404", 90.5, 45.9),
        new BankCount(105, "Данил", "8-105-105-0505", 100.87, 114),
        new BankCount(106, "Дарья", "8-106-106-0606", 136.71, 79.12),
        };

        int poors = (from b in bank_data
                     where b.Income - b.Expense - b.Taxes < 0
                     select b).Count();

        Console.WriteLine($"Количество клиентов с отрицательным балансом - {poors}");

        var richest = from client in bank_data
                      where (client.Income - client.Expense - client.Taxes) ==
                          (from b in bank_data
                           select b.Income - b.Expense - b.Taxes).Max()
                      select client.Fio;

        Console.WriteLine($"Клиент с наибольшим балансом - {richest.ToArray()[0]}");

        double aver_income = (from b in bank_data
                              select b.Income).Average();

        Console.WriteLine($"Средний доход = {aver_income}");

        double sum_taxes = (from b in bank_data
                            select b.Taxes).Sum();

        Console.WriteLine($"Сумма налогов = {sum_taxes}");
    }
}
