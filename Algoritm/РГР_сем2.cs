class PolishNotation
{
    public void PolNot()
    {
        Console.Write("Введите выражение записанное в обратной польской нотации.\n" +
                      "Ввод каждого символа через пробел. Пример: 3 3 + 2 *\n" +
                      "\nВвод: ");
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
                    Console.WriteLine("Неккоретная запись!\n");
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
                            Console.WriteLine("Попытка деления на ноль!\n");
                            notError = false;
                            break;
                        }
                        break;
                }
            }
        }

        if (notError)
            Console.WriteLine($"Значение выражения равно: {result}\n");
    }
}

class SequenceBrackets
{
    public void SeqBra()
    {
        bool flag = false;
        Console.Write("Введите последовательность скобок.\n" +
                          "Пример: ([){)\nВвод: ");
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
            Console.WriteLine("Последовательность скобок задана некорректно\n");
        else
            Console.WriteLine("Последовательность скобок задана корректно\n");
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
            Console.Write("Выберите пункт:\n" +
                "1 - Автор\n" +
                "2 - Подсчёт значения обратной польской записи\n" +
                "3 - Проверка скобочной последовательности на корректность\n" +
                "4 - Выход\n" +
                "\nВвод: ");
            int point = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (point)
            {
                case 1:
                    Console.WriteLine("Автор:\nФральцов Матвей Андреевич\n" +
                                        "Студент 1-го курса, ФИТ-231\n");
                    break;

                case 2:
                    while (true)
                    {
                        Console.Write("Выберите действие:\n1 - Данные о задаче\n" +
                                            "2 - Подсчёт значения выражения, предоставленного " +
                                            "в виде обратной польской записи\n" +
                                            "3 - Вернуться в главное меню\n" +
                                            "\nВвод: ");
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
                        else if (secondPoint == 3)
                            break;
                        else
                            Console.WriteLine("Ошибка в выборе действия, попробуйте ещё раз\n");
                    }
                    break;

                case 3:
                    while (true)
                    {
                        Console.Write("Выберите действие:\n1 - Данные о задаче\n" +
                                            "2 - Проверить скобочную последовательность " +
                                            "на корректность\n" +
                                             "3 - Вернуться в главное меню\n" +
                                            "\nВвод: ");
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
                        else if (secondPoint == 3)
                            break;
                        else
                            Console.WriteLine("Ошибка в выборе действия, попробуйте ещё раз\n");
                    }
                    break;

                case 4:
                    Console.WriteLine("Выход из программы");
                    flag = true;
                    break;

                default:
                    Console.WriteLine("Ошибка в выборе пункта, попробуйте ещё раз\n");
                    break;

            }
            if (flag)
                break;
        }
    }
}
