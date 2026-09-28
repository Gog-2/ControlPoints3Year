using MDV_CatFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDV_CatFramework.Models
{
    public class CuteCat : Cat
    {
        public CuteCat()
        {
            _fluffiness = 50;
        }
        public CuteCat(int fluffiness)
        {
            if (fluffiness <= 0 && fluffiness >= 140)
            {
                throw new ArgumentOutOfRangeException($"Unable to create a cute cat with fluffiness: {fluffiness}");
            }
            _fluffiness = fluffiness;
        }
        public override int Fluffiness 
        { 
            get { return _fluffiness; }
        }

        public override string FluffinessCheck()
        {
            switch (Fluffiness)
            {
                case 0:
                    return "Sphynx";

                case < 20:
                    return "Slightly";

                case < 50:
                    return "Medium";

                case < 75:
                    return "Heavy";

                case > 75:
                    return "OwO";

                default:
                    return "Unknown";
            }
        }
        public override string ToString()
        {
            return $"A cute cat with fluffiness: {Fluffiness}";
        }
    }
}
