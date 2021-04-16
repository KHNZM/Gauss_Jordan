using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan
{
    class Prime
    {
        public bool IsPrime(long num)
        {
            if (num < 2) return false;
            else if (num == 2) return true;
            else if (num % 2 == 0) return false;

            double sqrtNum = Math.Sqrt(num);
            for (int ic = 3; ic <= sqrtNum; ic += 2)
            {
                if (num % ic == 0) return false;
            }

            return true;
        }
    }
}
