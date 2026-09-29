using PolymorphicTypeHierarchies.ModelsParents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicTypeHierarchies.ModelsImmovable
{
    internal class CountryHouse : Immovable
    {
        public CountryHouse(int worth, int squareMeters) : base(worth, squareMeters)
        {
        }
        
        public override string ToString()
        {
            return $"Загородный дом: Стоимость - {Worth}, Налог - {_tax}, площадь - {_squareMeters}";
        }
    }
}
