using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicTypeHierarchies.ModelsParents
{
    internal class Immovable : Property
    {
        protected int _squareMeters;

        public Immovable(int worth, int squareMeters) : base(worth)
        {
            _squareMeters = squareMeters;
            CalculateTax();
        }
        protected override void CalculateTax()
        {
            switch (_squareMeters)
            {
                case < 100:
                    _tax = (int)(_worth * 0.05);
                    break;
                case < 300:
                    _tax = (int)(_worth * 0.002857);
                    break;
                case >= 300:
                    _tax = (int)(_worth * 0.04);
                    break;
            }
        }
        public override string ToString() 
        { 
            return $"Недвижимость: Стоимость - {Worth}, Налог - {_tax}, кубатура - {_squareMeters}";
        }
    }
    
}
