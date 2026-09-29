using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicTypeHierarchies.ModelsParents
{
    internal class Vehicle : Property
    {
        protected int _engineCapacity;

        public Vehicle(int worth, int engineCapacity) : base(worth)
        {
            _engineCapacity = engineCapacity;
            CalculateTax();
        }

        protected override void CalculateTax()
        {
            _tax = (int)((_worth * _engineCapacity) / 3000);
        }
        public override string ToString()
        {
            return $"Транспорт: Стоимость - {Worth}, Налог - {_tax}, объём двигателя - {_engineCapacity}";
        }
    }
}
