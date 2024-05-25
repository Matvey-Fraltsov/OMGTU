namespace PolishNotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string polishNotation = "33 2 + 2 /";
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
                        case '-': result = num2 - num1; stack.Push(num2 - num1); break;
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
            Console.WriteLine(result);

        }
    }
}
