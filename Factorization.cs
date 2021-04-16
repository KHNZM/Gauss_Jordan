using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan
{
    class Factorization : Properties
    {
        private long getNum()
        {
            string Val = "";
            long longcheck = 0;
            Console.WriteLine("数値を入力してください。");
            while (true)
            {
                Val = "";
                longcheck = 0;
                Val = Console.ReadLine();
                if (!long.TryParse(Val, out longcheck))
                {
                    Console.WriteLine("ちゃんと数値を入力してください。");
                    continue;
                }
                Num = longcheck;
                break;
            }
            return Num;
        }
        private void createPrimeFactorization()
        {
            PrimFac = new List<long>();
            PriFacnumList = new List<long>();
            long num = getNum();
            long PriFacnum = 0;
            int ic = 0;
            long buf = 1;
            Prime prime = new Prime();
            List<long> PrimeList = new List<long>();

            ic = 2;
            buf = num;
            while (ic <= buf)
            {
                if (prime.IsPrime(ic))
                {
                    if (buf % ic == 0)
                    {
                        buf = buf / ic;
                        PriFacnum += 1;

                        if (buf % ic != 0)
                        {
                            PrimFac.Add(ic);
                            PriFacnumList.Add(PriFacnum);
                            PriFacnum = 0;
                            ic += 1;
                            continue;
                        }
                    }
                    else if (ic % 2 != 0) ic += 2;
                    else ic += 1;

                    if (buf == 1) break;
                    if (prime.IsPrime(buf) && buf != ic)
                    {
                        PrimFac.Add(buf);
                        PriFacnumList.Add(1);
                        break;
                    }
                }
                else if (ic % 2 != 0) ic += 2;
                else ic += 1;
            }
        }
        public void ShowPrimeFactorized()
        {
            createPrimeFactorization();
            if (Num == 0 || Num == 1) Console.WriteLine("{0}の素因数分解は紛れもなく{0}ですよ。", Num);
            else
            {
                Console.WriteLine("{0}の素因数分解はというと", Num);
                Console.Write("素因数：");
                for (int ic = 0; ic < PriFacnumList.Count; ic++)
                {
                    if (PriFacnumList[ic] == 0) continue;
                    Console.Write("{0:d6}", PrimFac[ic]);
                    if (ic != PriFacnumList.Count - 1) Console.Write(",");
                }
                Console.WriteLine();
                Console.Write("次数：　");
                for (int ic = 0; ic < PriFacnumList.Count; ic++)
                {
                    if (PriFacnumList[ic] == 0) continue;
                    Console.Write("{0:d6}", PriFacnumList[ic]);
                    if (ic != PriFacnumList.Count - 1) Console.Write(",");
                }
                Console.WriteLine();
            }
        }
    }
}
