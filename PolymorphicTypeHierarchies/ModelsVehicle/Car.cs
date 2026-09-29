using PolymorphicTypeHierarchies.ModelsParents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicTypeHierarchies.ModelsVehicle
{
    internal class Car : Vehicle
    {
        public Car(int worth, int engineCapacity) : base(worth, engineCapacity)
        {
        }

        public override string ToString()
        {
            return $"Машина: Стоимость - {Worth}, Налог - {_tax}, объём двигателя - {_engineCapacity}";
        }
    }
}
