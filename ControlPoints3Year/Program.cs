using Massive;

namespace ControlPoints3Year
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntArrayList list = new IntArrayList();
            Print(list);

            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);
            Print(list);

            list.PopBack();
            Print(list);

            Console.WriteLine(list.TryInsert(1, 10));
            Print(list);

            Console.WriteLine(list.TryInsert(0, 5));
            Print(list);

            Console.WriteLine(list.TryInsert(4, 7));
            Print(list);

            Console.WriteLine(list.TryInsert(9, 1));

            Console.WriteLine(list.TryErase(0));
            Print(list);

            Console.WriteLine(list.TryErase(10));

            Console.WriteLine(list.TryGetAt(1, out int x));
            Console.WriteLine(x);

            Console.WriteLine(list.TryGetAt(50, out x));
            Console.WriteLine(x);

            Console.WriteLine(list.Find(2));
            Console.WriteLine(list.Find(999));

            Console.WriteLine(list.TryForceCapacity(-1));
            Console.WriteLine(list.TryForceCapacity(20));
            Print(list);

            Console.WriteLine(list.TryForceCapacity(2));
            Print(list);

            list.Clear();
            Print(list);

            var empty = new IntArrayList();
            empty.PopBack();
            Print(empty);
        }
        static void Print(IntArrayList l)
        {
            Console.Write($"Count={l.Count}, Capacity={l.Capacity}: ");
            for (int i = 0; i < l.Count; i++)
                Console.Write(l[i] + " ");
            Console.WriteLine();
        }
    }
}
