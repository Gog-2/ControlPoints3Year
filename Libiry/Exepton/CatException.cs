using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDV_CatFramework.Exepton
{
    internal class CatException : ArgumentException
    {
        public CatException(string message) : base(message){}
    }
}
