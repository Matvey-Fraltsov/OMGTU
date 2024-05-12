using System;
using System.Collections;


Console.WriteLine("Введите польскую запись (после каждого символа - пробел)");
string s = Console.ReadLine();
if (s.Length == 0)
    throw new ArgumentException("Отсутствие элементов для выполнения действий");

string[] m = s.Split(' ');
switch (m[2])
{
    case "+":
        break;
    case "-":
        break;
    case "*":
        break;
    case "/":
        break;
    default:
        throw new ArgumentException("Результат ответа будет неоднозначен");
}

for (int i = 4; i < m.Length;)
{
    switch (m[i])
    {
        case "+":
            break;
        case "-":
            break;
        case "*":
            break;
        case "/":
            break;
        default:
            throw new ArgumentException("Результат ответа будет неоднозначен");
    }
    i += 2;
}

Stack st = new Stack();

foreach (string c in m)
{
    if (c == "+" || c == "-" || c == "*" || c == "/")
    {
        double st2 = Convert.ToDouble(st.Pop());
        double st1 = Convert.ToDouble(st.Pop());
        double res;
        switch (c)
        {
            case "+":
                res = st1 + st2;
                break;
            case "-":
                res = st1 - st2;
                break;
            case "*":
                res = st1 * st2;
                break;
            case "/":
                if (st2 == 0)
                    throw new ArgumentException("Деление на 0 невозможно");
                res = st1 / st2;
                break;
            default:
                throw new ArgumentException("Недопустимый оператор: " + c);
        }
        st.Push(res);
    }
    else
        st.Push(Convert.ToDouble(c));
}

double fin = Convert.ToDouble(st.Pop());
Console.WriteLine("Результат вычислений: " + fin);
