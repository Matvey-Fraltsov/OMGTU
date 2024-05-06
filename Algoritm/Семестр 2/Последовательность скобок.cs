using System;
using System.Collections.Generic;

class ReversePolishNotation
{
    public static bool IsValid(string sequence)
    {
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
                if (stack.Count == 0 || mapping[c] != stack.Pop()) return false;
            }
        }
        return stack.Count == 0;
    }

    public static void Main()
    {
        string seq1 = "(}])";
        string seq2 = "{[]}";
        string seq3 = "{}";
        string seq4 = "([){)";

        Console.WriteLine(IsValid(seq1)); // False
        Console.WriteLine(IsValid(seq2)); // True
        Console.WriteLine(IsValid(seq3)); // True
        Console.WriteLine(IsValid(seq4)); // False
    }
}
