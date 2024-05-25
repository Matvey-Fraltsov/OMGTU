class PolishNotation
{
    public void PolNot()
    {
        Console.WriteLine("Введите выражение записанное в обратной польской нотации.\n" +
            "Ввод каждого символа через пробел. Пример: 3 3 + 2 *\n");
        string polishNotation = Console.ReadLine();
        Stack<double> stack = new Stack<double>();
        double result = 0;
        string sequance = "";
        bool notError = true;

        foreach (char elem in polishNotation)
        {
            if (elem != ' ' && elem != '+' && elem != '-' && elem != '*' && elem != '/')
            {
                sequance += elem;
                continue;
            }

            if (elem != '+' && elem != '-' && elem != '*' && elem != '/')
            {
                if (sequance != "")
                {
                    stack.Push(double.Parse(Convert.ToString(sequance)));
                    sequance = "";
                }
            }

            else
            {
                if (stack.Count > 2 || stack.Count < 2)
                {
                    Console.WriteLine("Неккоретная запись!");
                    notError = false;
                    break;
                }

                double num1 = stack.Pop();
                double num2 = stack.Pop();
                switch (elem)
                {
                    case '+': result = num1 + num2; stack.Push(num1 + num2); break;
                    case '-': result = num1 - num2; stack.Push(num1 - num2); break;
                    case '*': result = num1 * num2; stack.Push(num1 * num2); break;
                    case '/':
                        if (num1 != 0)
                        {
                            result = num2 / num1;
                            stack.Push(num2 / num1);
                        }
                        else
                        {
                            Console.WriteLine("Попытка деления на ноль!");
                            notError = false;
                            break;
                        }
                        break;

                }
            }
        }

        if (notError)
            Console.WriteLine("Значение выражения равно:" + result);
    }
}

class SequenceBrackets
{
    public void SeqBra() 
    {   
        bool flag = false;
        Console.WriteLine("Введите последовательность скобок.\n" +
            "Пример: ([){)\n");
        string sequence = Console.ReadLine();
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> mapping = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        foreach (char c in sequence)
        {
            if (mapping.ContainsValue(c)) stack.Push(c);
            else if (mapping.ContainsKey(c))
            {
                if (stack.Count == 0 || mapping[c] != stack.Pop())
                    flag = true;
                    break;
            }
        }
        if (flag)
            Console.WriteLine("Последовательность скобок задана некорректно");
        else
            Console.WriteLine("Последовательность скобок задана корректно");
    }

}

class Menu
{
    static void Main(string[] args)
    {
        int secondPoint;
        bool flag = false;
        while (true) 
        {
            Console.WriteLine(@"Выберите пункт: 1 - Автор
                2 - Подсчёт значения обратной польской записи
                3 - Проверка скобочной последовательности на корректность
                4 - Выход");
            int point = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (point)
            {
                case 1:
                    Console.WriteLine("Автор:\nФральцов Матвей Андреевич\n" +
                                        "Студент 1-го курса, ФИТ-231\n");
                    break;

                case 2:
                    Console.WriteLine("Выберите действие:\n1 - Данные о задаче\n" +
                                        "2 - Подсчёт значения выражения, предоставленного " +
                                        "в виде обратной польской записи\n");
                    secondPoint = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (secondPoint == 1)
                        Console.WriteLine("На вход подаётся выражение записанное " +
                                          "в обратной польской нотации.\n" +
                                          "Программа вычисляет значение на основе данного выражения\n");
                    else if (secondPoint == 2)
                    {
                        PolishNotation polishNotation = new PolishNotation();
                        polishNotation.PolNot();
                    }
                    break;

                case 3:
                    Console.WriteLine("Выберите действие:\n1 - Данные о задаче\n" +
                                        "2 - Проверить скобочную последовательность " +
                                        "на корректность\n");
                    secondPoint = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (secondPoint == 1)
                        Console.WriteLine("На вход подаётся последовательность скобок\n" +
                                          "Программа выявляет корректо ли задана " +
                                          "скобочная последовательность\n");
                    else if (secondPoint == 2)
                    {
                        SequenceBrackets sequenceBrackets = new SequenceBrackets();
                        sequenceBrackets.SeqBra();
                    }
                    break;

                case 4:
                    Console.WriteLine("Выход из программы");
                    flag = true;
                    break;

                default:
                    Console.WriteLine("Ошибка в выборе пункта, попробуйте ещё раз");
                    break;

            }

            if (flag)
                break;

        }

    }
}
