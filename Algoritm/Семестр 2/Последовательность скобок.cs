using System;
using System.Collections.Generic;

class BracketChecker
{
    public static bool IsValid(string expression)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> mapping = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        foreach (char c in expression)
        {
            if (mapping.ContainsValue(c)) stack.Push(c);
            else if (mapping.ContainsKey(c))
            {
                if (stack.Count == 0 || mapping[c] != stack.Pop()) return false; 
            }
        }
        return stack.Count == 0;
    }
    
    public static void Main()
    {
        string expr1 = "([{}])";
        string expr2 = "{[]]}";
        string expr3 = "()";
        string expr4 = "([)()]";

        Console.WriteLine(IsValid(expr1)); // True
        Console.WriteLine(IsValid(expr2)); // False
        Console.WriteLine(IsValid(expr3)); // True
        Console.WriteLine(IsValid(expr4)); // False
    }
}
