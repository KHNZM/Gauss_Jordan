using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan
{
    class Determinant : Properties
    {
        private double[] ConvertArray(double[,] Array2Dim)
        {
            int Dim1cnt = 0;
            double[] Array1Dim = new double[N * N];
            for (int ic = 1; ic <= N; ic++)
            {
                for (int jc = 1; jc <= N; jc++)
                {
                    Array1Dim[Dim1cnt] = Array2Dim[ic, jc];
                    Dim1cnt += 1;
                }
            }
            return Array1Dim;
        }
        private void SWAP(double a, double b)
        {
            double buf = a;
            a = b;
            b = buf;
        }
        public double createDeterminant()
        {
            double ElementBufSum = Math.Sqrt(Mat.Length - 2 * N - 1);
            int ElementSum = (int)ElementBufSum;
            double[] m = ConvertArray(Mat);
            int x, y, i;
            double det = 1, r;

            // 上三角行列に変換しつつ、対角成分の積を計算する。
            for (y = 0; y < ElementSum - 1; y++)
            {
                if (m[y * ElementSum + y] == 0)
                {
                    // 対角成分が0だった場合は、その列の値が0でない行と交換する
                    for (i = y + 1; i < ElementSum; i++)
                    {
                        if (m[i * ElementSum + y] != 0)
                        {
                            break;
                        }
                    }
                    if (i < ElementSum)
                    {
                        for (x = 0; x < ElementSum; x++)
                        {
                            SWAP(m[i * ElementSum + x], m[y * ElementSum + x]);
                        }
                        // 列を交換したので行列式の値の符号は反転する。
                        det = -det;
                    }
                }
                for (i = y + 1; i < ElementSum; i++)
                {
                    r = m[i * ElementSum + y] / m[y * ElementSum + y];
                    for (x = y; x < ElementSum; x++)
                    {
                        m[i * ElementSum + x] -= r * m[y * ElementSum + x];
                    }
                }
                det *= m[y * ElementSum + y];
            }
            det *= m[y * ElementSum + y];

            return det;
        }
    }
}
