using PolymorphicTypeHierarchies.ModelsImmovable;
using PolymorphicTypeHierarchies.ModelsParents;
using PolymorphicTypeHierarchies.ModelsVehicle;

namespace PolymorphicTypeHierarchies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Property> properties = new List<Property>
            {
            new Appartment(100000, 50),
            new Appartment(150000, 70),
            new Appartment(120000, 60),
            new Car(30000, 5),
            new Car(40000, 7),
            new Car(35000, 6),
            new Boat(50000, 10),
            new Boat(60000, 12),
            new CountryHouse(200000, 150),
            new CountryHouse(250000, 200),
            };

            foreach (var property in properties)
            {
                Console.WriteLine(property.ToString());
            }
        }
    }
}
