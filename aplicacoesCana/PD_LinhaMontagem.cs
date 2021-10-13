using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class PD_LinhaMontagem
    {

        internal static void linhaMontagem2(int[,] a, int[,] t, int[] e, int[] x, int n)
        {

            //melhores tempos
            int f;
            int[] f1 = new int[n];
            int[] f2 = new int[n];

            f1[0] = e[0] + a[0, 0];
            f2[0] = e[1] + a[1, 0];

            //solucao otima
            int l;
            int[] l1 = new int[n];
            int[] l2 = new int[n];

            l1[0] = 1;
            l2[0] = 2;

            for (int k = 1; k < n; k++)
            {
                //para linha 1
                if (f1[k - 1] <= f2[k - 1] + t[1, k - 1]) //f1 menor
                {
                    //manteve na propria linha 1
                    f1[k] = f1[k - 1] + a[0, k];
                    l1[k] = 1;
                }
                else //f2 menor
                {
                    //veio da linha 2 para a 1
                    f1[k] = f2[k - 1] + t[1, k - 1] + a[0, k]; ;
                    l1[k] = 2;
                }

                //para linha 2
                if (f2[k - 1] <= f1[k - 1] + t[0, k - 1]) //f2 menor
                {
                    //manteve na propria linha 2
                    f2[k] = f2[k - 1] + a[1, k];
                    l2[k] = 2;
                }
                else //f1 menor
                {
                    //veio da linha 1 para a 2
                    f2[k] = f1[k - 1] + t[0, k - 1] + a[1, k]; ;
                    l2[k] = 1;
                }

            }

            int ult = n - 1;

            //solucao otima
            if (f1[ult] + x[0] <= f2[ult] + x[1]) //f1 <= f2
            {
                f = f1[ult] + x[0];
                l = 1;
            }
            else //f2 <= f1
            {
                f = f2[ult] + x[1];
                l = 2;
            }

            imprimeMontagem(l, l1, l2, n - 1);
            //return
        }

        internal static void imprimeMontagem(int l, int[] l1, int[] l2, int n)
        {
            int i = l;
            Console.Write("Linha " + i + ", estação " + n + "\n");

            for (int j = n; j >= 1; j--)
            {
                if (i == 1)
                    i = l1[j];
                if (i == 2)
                    i = l2[j];
                int pos = j - 1;
                Console.Write("Linha " + i + ", estação " + pos + "\n");
            }
        }

    }
}
