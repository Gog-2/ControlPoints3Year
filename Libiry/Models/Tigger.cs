using MDV_CatFramework.Abstract;
using MDV_CatFramework.Exepton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDV_CatFramework.Models
{
    public class Tigger : Cat
    {
        private double _weight;
        public Tigger(double weight, int fluffiness = 50)
        {
            if (weight < 75.0 || weight > 140.0)
            {
                throw new CatException($"Unable to create a tiger with weight: {weight}");
            }
            if (fluffiness < 0 || fluffiness > 100)
            {
                throw new CatException($"Unable to create a tiger with fluffiness: {fluffiness}");
            }
            _weight = weight;
            _fluffiness = fluffiness;
        }

        public Tigger()
        {
            _weight = 50;
            _fluffiness = 50;
        }
        

        public override int Fluffiness 
        { 
            get { return _fluffiness; }
        }

        public override string FluffinessCheck()
        {
            return "Kycb";
        }
        public override string ToString()
        {
            return $"A tiger with weight: {_weight} fluffiness: {Fluffiness}";
        }
    }
}
