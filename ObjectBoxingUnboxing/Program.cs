using System.Numerics;
using ObjectBoxingUnboxing.Figure;

namespace ObjectBoxingUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            BoxingUnboxing();
            
            Console.WriteLine();
            GeneralizedClassAndReset();
            
            Console.WriteLine();
            Circuls();
            
            Console.WriteLine();
            Rectangles();
        }

        public static void BoxingUnboxing()
        {
            List<object> objects = new List<object>(new object[]
            {
                67 , 
                52,
                4.2f
            });
            
            BoxingUnboxing boxingUnboxing = new BoxingUnboxing(objects);
            Console.WriteLine(boxingUnboxing.Result());
        }

        public static void GeneralizedClassAndReset()
        {
            GeneralizedClass generalizedClass = new GeneralizedClass();
            generalizedClass.Run();
        }

        public static void Circuls()
        {
            var circleInt = new Circle<int>(new Vector2(0, 0), 5);
            var circleString = new Circle<string>(new Vector2(1, 2), "7");
            var circleDouble = new Circle<double>(new Vector2(-3, 4), 3.2);
            var circleFloat = new Circle<float>(new Vector2(5, -1), 2.4f);
            
            circleInt.SetRadius(10);
            circleString.SetRadius("14");
            circleDouble.SetRadius(6.5);
            circleFloat.SetRadius(4.8f);

            Console.WriteLine($"Круг 1 (int):    Радиус = {circleInt.Radius},    Площадь = {circleInt.Area:F2}");
            Console.WriteLine($"Круг 2 (string): Радиус = {circleString.Radius},   Площадь = {circleString.Area:F2}");
            Console.WriteLine($"Круг 3 (double): Радиус = {circleDouble.Radius},  Площадь = {circleDouble.Area:F2}");
            Console.WriteLine($"Круг 4 (float):  Радиус = {circleFloat.Radius},  Площадь = {circleFloat.Area:F2}");
        }

        public static void Rectangles()
        {
            var rect1 = new Rectangle<string, int>(new Vector2(0f, 0f), "4", 2);
            
            var rect2 = new Rectangle<float, double>(new Vector2(1.5f, 2.5f), 2.5f, 3.3);
            
            var rect3 = new Rectangle<string, float>(new Vector2(-2f, 3f), "3", 4.2f);
            
            Console.WriteLine("Прямоугольник 1 (W: \"4\", H: 2, Center: (0, 0)):");
            Console.WriteLine($"  MinPoint (левый верх):  {rect1.MinPoint}");
            Console.WriteLine($"  MaxPoint (правый низ):  {rect1.MaxPoint}\n");

            Console.WriteLine("Прямоугольник 2 (W: 2.5f, H: 3.3, Center: (1.5, 2.5)):");
            Console.WriteLine($"  MinPoint (левый верх):  {rect2.MinPoint}");
            Console.WriteLine($"  MaxPoint (правый низ):  {rect2.MaxPoint}\n");

            Console.WriteLine("Прямоугольник 3 (W: \"3\", H: 4.2f, Center: (-2, 3)):");
            Console.WriteLine($"  MinPoint (левый верх):  {rect3.MinPoint}");
            Console.WriteLine($"  MaxPoint (правый низ):  {rect3.MaxPoint}");
        }
    }
}
