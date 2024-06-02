namespace SetTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Set();
        }
        static void Set()
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> set3 = new HashSet<int>();

            void AddSet(HashSet<int> set)
            {
                Console.Write("Элементов в множестве: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Перечислите элементы через Enter: ");
                for (int i = 0; i < n; i++) set.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine();
            }

            AddSet(set1);
            AddSet(set2);
            AddSet(set3);

            HashSet<int> union = set1.Union(set2).ToHashSet<int>();
            union = union.Union(set3).ToHashSet<int>();

            Console.WriteLine("Объединение множеств");
            if (union.Count > 0)
            {
                foreach (int i in union) Console.Write(i + " ");
                Console.WriteLine("\n");
            }
            else Console.WriteLine("Пустое множество\n");
            HashSet<int> intersect = set1.Intersect(set2).ToHashSet<int>();
            intersect = intersect.Intersect(set3).ToHashSet<int>();

            Console.WriteLine("Пересечение множеств");
            if (intersect.Count > 0)
            {
                foreach (int i in intersect) Console.Write(i + " ");
                Console.WriteLine("\n");
            }
            else Console.WriteLine("Пустое множество\n");

            HashSet<int> except1 = union.Except(set1).ToHashSet<int>();
            HashSet<int> except2 = union.Except(set2).ToHashSet<int>();
            HashSet<int> except3 = union.Except(set3).ToHashSet<int>();

            int j = 1;
            foreach (HashSet<int> ex in new HashSet<int>[] { except1, except2, except3 })
            {
                Console.WriteLine($"Дополнение множества {j}");
                if (ex.Count > 0)
                {
                    foreach (int el in ex) Console.Write(el + " ");
                    Console.WriteLine("\n");
                }
                else Console.WriteLine("Пустое множество\n");
                j++;
            }
        }
    }
}
