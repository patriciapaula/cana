using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class PD_MultiplicacaoMatrizes
    {

        internal static int multm(int[] p)
        {
            int n = p.Length;
            int[,] m = new int[n, n];
            int[,] sol = new int[n, n];
            
            //zera diag principal
            for (int i = 0; i < n; i++)
                m[i, i] = 0;
            
            int j = 0;
            int q = 0;
            for (int L = 1; L < n; L++) //para L = 2 até n
            {
                for (int i = 0; i < n - L; i++) //para i = 1 até n-L+1
                {
                    j = i + L; //j = i + L - 1;
                    m[i, j] = 100000;
                    q = 0;

                    for (int k = i; k <= j - 1; k++)
                    {
                        if (i > 0)
                            q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];

                        if (q < m[i, j])
                        {
                            m[i, j] = q;
                            sol[i, j] = k;
                        }
                    }
                }
            }
            
            imprimeParenteses(sol, 1, n - 1);

            int melhor = m[1, n - 1];
            return (int)melhor;
        }
        internal static void imprimeParenteses(int[,] s, int i, int j)
        {
            if (i == j)
                Console.Write("A"+i);
            else
            {
                Console.Write("(");
                imprimeParenteses(s, i, s[i, j]);
                imprimeParenteses(s, s[i, j] + 1, j);
                Console.Write(")");
            }
        }


    }
}
