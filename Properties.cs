using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan
{
    class Properties
    {
        protected static long Num { set; get; }
        protected static List<long> PrimFac { set; get; }
        protected static List<long> PriFacnumList { set; get; }
        protected static int N { set; get; }
        protected static double[,] Mat { set; get; }
        protected static double[] RsideVec { set; get; }
        protected static double DetMat { set; get; }

        public void DeleteMemories()
        {
            if (PrimFac != null) PrimFac.Clear();
            if (PriFacnumList != null) PriFacnumList.Clear();
            if (Mat != null) Mat = null;
            if (RsideVec != null) RsideVec = null;
        }
    }
}
