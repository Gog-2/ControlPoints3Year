using Massive;

namespace ControlPoints3Year
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntArrayList intArray = new IntArrayList();
            intArray.Capacity = 10;
            intArray.PushBack(5);
            Console.WriteLine(intArray.Count);
            intArray.TryGetAt(0, out int value);
            Console.WriteLine(value);
            Console.WriteLine(intArray.Find(5));
        }
    }
}
