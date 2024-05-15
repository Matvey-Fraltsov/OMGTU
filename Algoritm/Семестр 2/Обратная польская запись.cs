namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string polishNotation = "33 3 + 2 *";
            Stack<int> stack = new Stack<int>();
            int result = 0;
            string sequance = "";

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
                        stack.Push(int.Parse(Convert.ToString(sequance)));
                        sequance = "";
                    }
                }

                else
                {
                    if (stack.Count > 2 || stack.Count < 2)
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
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
                                Console.WriteLine("Попытка деления на ноль!");
                            break;
                    }
                }
            }

            Console.WriteLine(result);

        }
    }
}
double fin = Convert.ToDouble(st.Pop());
Console.WriteLine("Результат вычислений: " + fin);
