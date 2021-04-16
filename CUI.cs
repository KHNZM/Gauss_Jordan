using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan
{
    class CUI
    {
        public void ShowCUI()
        {
            Factorization factor = new Factorization();
            Gauss_Jordan gauss = new Gauss_Jordan();
            Properties properties = new Properties();
            string Val = "";
            int check = 0;
            int select = 0;
            int exitnum = 4;
            try
            {
                while (true)
                {
                    Console.WriteLine("何しましょうか？");
                    Console.WriteLine("1:素因数分解、2:逆行列の表示、3:n元一次連立方程式の解、4:終了");
                    Val = Console.ReadLine();
                    if (Int32.TryParse(Val, out check) == false)
                    {
                        Console.WriteLine("ちゃんと1～{0}の値を選択してください。", exitnum);
                        continue;
                    }
                    else if (check < 1 || check > exitnum)
                    {
                        Console.WriteLine("選択肢は1～{0}ですよ。Try again!!!", exitnum);
                        Console.WriteLine();
                        continue;
                    }
                    Int32.TryParse(Val, out select);
                    switch (select)
                    {
                        case 1:
                            factor.ShowPrimeFactorized();
                            break;
                        case 2:
                            gauss.ShowInverseMatrix();
                            break;
                        case 3:
                            gauss.ShowSolution();
                            break;
                        default:
                            break;
                    }
                    if (select == exitnum) break;
                    while (true)
                    {
                        Val = "";
                        Console.WriteLine("まだ続けますか？");
                        Console.WriteLine("y:続ける、n:やめる");
                        Val = Console.ReadLine();
                        if (Val == "n" || Val == "y") break;
                    }
                    properties.DeleteMemories();
                    if (Val == "y") continue;
                    if (Val == "n") break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
