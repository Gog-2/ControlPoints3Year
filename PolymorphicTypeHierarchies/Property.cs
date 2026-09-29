using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicTypeHierarchies
{
    internal abstract class Property
    {
        protected int _worth;
        protected int _tax;
        public int Worth
        {
            get { return _worth; }
        }

        public Property(int worth)
        {
            _worth = worth;
        }

        protected virtual void CalculateTax()
        {
            _tax = (int)(_worth * 0.1);
        }
    }
}
