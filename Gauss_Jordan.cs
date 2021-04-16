using System;

namespace Gauss_Jordan
{
    class Gauss_Jordan : Properties
    {
        private int getDim()
        {
            string Val = "";
            int intcheck = 0;
            Console.WriteLine("次数を入力してください。");
            int TempN = 0;
            while (true)
            {
                Val = "";
                intcheck = 0;
                Val = Console.ReadLine();
                if (Int32.TryParse(Val, out intcheck) == false)
                {
                    Console.WriteLine("ちゃんと数値を入力してください。");
                    continue;
                }
                else if (Val == "0")
                {
                    Console.WriteLine("正の数を入力してください。");
                    continue;
                }
                else
                {
                    Int32.TryParse(Val, out TempN);
                    N = TempN;
                    break;
                }
            }
            return N;
        }

        private double[,] getMat()
        {
            string Val = "";
            double check = 0;
            double[,] TempMat = new double[N + 1, N + 1];
            Mat = new double[N + 1, N + 1];
            for (int ic = 1; ic <= N; ic++)
            {
                for (int jc = 1; jc <= N; jc++)
                {
                    Console.WriteLine("第{0}行{1}列の値を入力してください。", ic, jc);
                    while (true)
                    {
                        Val = "";
                        check = 0;
                        Val = Console.ReadLine();
                        if (Double.TryParse(Val, out check) == false)
                        {
                            Console.WriteLine("ちゃんと数値を入力してください。");
                            continue;
                        }
                        else
                        {
                            Double.TryParse(Val, out TempMat[ic, jc]);
                            Array.Copy(TempMat, Mat, TempMat.Length);
                            break;
                        }
                    }
                }
            }
            return Mat;
        }

        private double[] getRside()
        {
            string Val = "";
            double check = 0;
            double[] TempRside = new double[N + 1];
            RsideVec = new double[N + 1];
            for (int ic = 1; ic <= N; ic++)
            {
                Console.WriteLine("右辺の列ベクトル第{0}成分を入力してください。", ic);
                while (true)
                {
                    Val = "";
                    check = 0;
                    Val = Console.ReadLine();
                    if (Double.TryParse(Val, out check) == false)
                    {
                        Console.WriteLine("ちゃんと数値を入力してください。");
                        continue;
                    }
                    else
                    {
                        Double.TryParse(Val, out TempRside[ic]);
                        Array.Copy(TempRside, RsideVec, TempRside.Length);
                        break;
                    }
                }
            }
            return RsideVec;
        }
        private int Gauss_JordanElimination(int n, double[,] Matrix, double[] RsideVector)
        {
            int ipv, i, j;
            double inv_pivot, temp;
            double big;
            int pivot_row = 1;
            int[] row = new int[N + 1];

            for (ipv = 1; ipv <= n; ipv++)
            {
                /* ---- 最大値探索 ---------------------------- */
                big = 0.0;
                for (i = ipv; i <= n; i++)
                {
                    if (Math.Abs(Matrix[i, ipv]) > big)
                    {
                        big = Math.Abs(Matrix[i, ipv]);
                        pivot_row = i;
                    }
                }
                if (big == 0.0) { return 0; }
                row[ipv] = pivot_row;

                /* ---- 行の入れ替え -------------------------- */
                if (ipv != pivot_row)
                {
                    for (i = 1; i <= n; i++)
                    {
                        temp = Matrix[ipv, i];
                        Matrix[ipv, i] = Matrix[pivot_row, i];
                        Matrix[pivot_row, i] = temp;
                    }
                    temp = RsideVector[ipv];
                    RsideVector[ipv] = RsideVector[pivot_row];
                    RsideVector[pivot_row] = temp;
                }

                /* ---- 対角成分=1(ピボット行の処理) ---------- */
                inv_pivot = 1.0 / Matrix[ipv, ipv];
                Matrix[ipv, ipv] = 1.0;
                for (j = 1; j <= n; j++)
                {
                    Matrix[ipv, j] *= inv_pivot;
                }
                RsideVector[ipv] *= inv_pivot;

                /* ---- ピボット列=0(ピボット行以外の処理) ---- */
                for (i = 1; i <= n; i++)
                {
                    if (i != ipv)
                    {
                        temp = Matrix[i, ipv];
                        Matrix[i, ipv] = 0.0;
                        for (j = 1; j <= n; j++)
                        {
                            Matrix[i, j] -= temp * Matrix[ipv, j];
                        }
                        RsideVector[i] -= temp * RsideVector[ipv];
                    }
                }
            }

            /* ---- 列の入れ替え(逆行列) -------------------------- */
            for (j = n; j >= 1; j--)
            {
                if (j != row[j])
                {
                    for (i = 1; i <= n; i++)
                    {
                        temp = Matrix[i, j];
                        Matrix[i, j] = Matrix[i, row[j]];
                        Matrix[i, row[j]] = temp;
                    }
                }
            }
            return 1;
        }

        public void ShowSolution()
        {
            try
            {
                N = getDim();
                Mat = getMat();
                RsideVec = getRside();
                Determinant determin = new Determinant();
                DetMat = determin.createDeterminant();
                if (DetMat == 0)
                {
                    Console.WriteLine("その連立方程式の解は存在しません。");
                    Console.WriteLine();
                    return;
                }
                Gauss_JordanElimination(N, Mat, RsideVec);
                Console.Write(Environment.NewLine);
                if (N == 1) Console.WriteLine("解X_1は、");
                else if (N == 2) Console.WriteLine("解X_1, X_2は、");
                else Console.WriteLine("解X_1,...,X_{0}は、", N);
                Console.Write(Environment.NewLine);
                for (int ic = 1; ic <= N; ic++)
                {
                    Console.WriteLine("X_{0} = {1}", ic, RsideVec[ic]);
                }
                Console.Write(Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private double[] getOptionalVector()
        {
            RsideVec = new double[N + 1];
            for (int ic = 1; ic <= N; ic++)
            {
                RsideVec[ic] = 1;
            }
            return RsideVec;
        }
        public void ShowInverseMatrix()
        {
            N = getDim();
            Mat = getMat();
            RsideVec = getOptionalVector();
            Determinant determin = new Determinant();
            DetMat = determin.createDeterminant();
            if (DetMat == 0)
            {
                Console.WriteLine("その行列の逆行列は存在しません。");
                Console.WriteLine();
                return;
            }

            int check = Gauss_JordanElimination(N, Mat, RsideVec);
            if (check == 0)
            {
                Console.WriteLine("逆行列の計算に失敗しました。");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("逆行列は、");
            for (int ic = 1; ic <= N; ic++)
            {
                for (int jc = 1; jc <= N; jc++)
                {
                    if (jc == N) Console.WriteLine("{0}", Mat[ic, jc]);
                    else Console.Write("{0} ", Mat[ic, jc]);
                }
            }
        }
    }
}
