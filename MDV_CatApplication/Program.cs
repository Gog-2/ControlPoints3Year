using MDV_CatFramework.Abstract;
using MDV_CatFramework.Models;

namespace MDV_CatApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        private Cat[] GenerateRandomCats(uint count)
        {
            Random random = new Random();
            
            Cat[] cats = new Cat[count];

            for (int i = 0; i < count; i++)
            {
                int fluffiness = random.Next(0, 101);
                double weight = random.NextDouble() * (200 - 50) + 50;
                try
                {
                    cats[i] = new Tigger(weight, fluffiness);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating cat: {ex.Message}");
                    i--; // Retry this iteration
                }
            }
            return cats;
        }
    }
}
