using PolymorphicTypeHierarchies.ModelsParents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicTypeHierarchies.ModelsImmovable
{
    internal class Appartment : Immovable
    {
        public Appartment(int worth, int squareMeters) : base(worth, squareMeters)
        {
        }
        
        public override string ToString()
        {
            return $"Квартира: Стоимость - {Worth}, Налог - {_tax}, площадь - {_squareMeters}";
        }
    }
}
