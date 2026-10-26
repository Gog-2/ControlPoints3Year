using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBoxingUnboxing
{
    internal class BoxingUnboxing
    {
        private List<object> _objects;
        private double _result = 0;

        public BoxingUnboxing(List<object> objects)
        {
            _objects = objects;
        }

        public double Result()
        {
            _result = 0;
            
            foreach (var obj in _objects)
            {
                _result += Convert.ToDouble(obj);
            }
            
            return _result;
        }
    }
}
