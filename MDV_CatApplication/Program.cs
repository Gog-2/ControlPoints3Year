using MDV_CatFramework.Abstract;
using MDV_CatFramework.Models;
using System;

namespace MDV_CatApplication
{
    internal class Program
    {
        private const string OutputFilePath = "cat_info.txt";
        static void Main(string[] args)
        {
            

            Cat[] cats = GenerateRandomCats(20);
            DisplayCatInfo(cats, OutputFilePath);

        }

        private static Cat[] GenerateRandomCats(uint count)
        {
            Random random = new Random();
            
            Cat[] cats = new Cat[count];

            for (int i = 0; i < count; i++)
            {
                int fluffiness = random.Next(0, 101);
                int id = random.Next(1, 3);
                switch (id)
                {
                    case 1:

                        Tigger tigger = CreateTigger(fluffiness);

                        if (tigger != null)
                        {
                            cats[i] = tigger;
                        }

                        else
                        {
                            Console.WriteLine("Failed to create a Tigger cat.");
                            i--;
                        }

                        break;

                    case 2:

                        CuteCat cuteCat = CreateCuteCat(fluffiness);

                        if (cuteCat != null)
                        {
                            cats[i] = cuteCat;
                        }

                        else
                        {
                            Console.WriteLine("Failed to create a Cute cat.");
                            i--;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid cat type generated.");
                        break;
                }
            }
            return cats;
        }

        static private Tigger CreateTigger(int fluffiness)
        {
            Random random = new Random();
            double weight = random.NextDouble() * (200 - 50) + 50;
            try
            {
                Tigger tigger = new Tigger(weight, fluffiness);
                return tigger;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating cat: {ex.Message}");
                return null;
            }
        }

        static private CuteCat CreateCuteCat(int fluffiness)
        {
            try
            {
                CuteCat cuteCat = new CuteCat(fluffiness);
                return cuteCat;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating cat: {ex.Message}");
                return null;
            }
        }

        static private void DisplayCatInfo(Cat[] catsArr, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Cat cat in catsArr)
                {
                    writer.WriteLine(cat.ToString());
                    writer.WriteLine($"Fluffiness Check: {cat.FluffinessCheck()}");
                    writer.WriteLine();
                }
            }

        }
    }
}
