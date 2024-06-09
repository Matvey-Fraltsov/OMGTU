Menu menu = new Menu();
menu.Start();


class Menu
{
    string choice_type;
    string choice_operation;
    string ChoiceType { get; set; }
    string ChoiceOperation { get; set; }
    public Menu(string choice_type = "0", string choice_operation = "0") { }
    public void Start()
    {
        Menu menu = new Menu();
        Console.WriteLine("Выберите тип данных(цифру): \n1. Целочисленные \n2. Вещественные");
        Console.Write("Ввод: ");
        choice_type = menu.ChoiceType = Console.ReadLine();
        Console.WriteLine("\nВыберите операцию(цифру): \n1. + \n2. - \n3. * \n4. /");
        Console.Write("Ввод: ");
        choice_operation = menu.ChoiceOperation = Console.ReadLine();
        Console.WriteLine("\nВведите построчно два числа: ");
        if (choice_type == "1")
        {
            switch (choice_operation)
            {
                case "1":
                    Console.WriteLine("Результат: " + Operations<int>.Plus(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    break;
                case "2":
                    Console.WriteLine("Результат: " + Operations<int>.Minus(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    break;
                case "3":
                    Console.WriteLine("Результат: " + Operations<int>.Umn(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    break;
                case "4":
                    Console.WriteLine("Результат: " + Operations<int>.Del(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    break;
                default:
                    Console.WriteLine("Неверно выбрана операция");
                    break;
            }
        }
        else if (choice_type == "2")
        {
            switch (choice_operation)
            {
                case "1":
                    Console.WriteLine("Результат: " + Operations<double>.Plus(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
                    break;
                case "2":
                    Console.WriteLine("Результат: " + Operations<double>.Minus(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
                    break;
                case "3":
                    Console.WriteLine("Результат: " + Operations<double>.Umn(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
                    break;
                case "4":
                    Console.WriteLine("Результат: " + Operations<double>.Del(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
                    break;
                default:
                    Console.WriteLine("Неверно выбрана операция");
                    break;
            }
        }
        else Console.WriteLine("Неправильно выбран тип данных");
    }
}


class Operations<T>
{
    static public T Plus(T a1, T y)
    {
        dynamic x = a1;
        return x + y;
    }
    static public T Minus(T a1, T y)
    {
        dynamic x = a1;
        return x - y;
    }
    static public T Umn(T a1, T y)
    {
        dynamic x = a1;
        return x * y;
    }
    static public T Del(T a1, T y)
    {
        dynamic x = a1;
        return x / y;
    }
}
