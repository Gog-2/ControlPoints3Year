using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDV_CatFramework.Abstract
{
    public abstract class Cat
    {
        protected int _fluffiness = 0;
        public abstract int Fluffiness
        {
            get;
        }
        public abstract string FluffinessCheck();

        public override string ToString()
        {
            return $"A cat with fluffiness: {Fluffiness}";
        }
    }
}
