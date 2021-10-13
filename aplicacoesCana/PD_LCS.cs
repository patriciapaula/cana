using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class PD_LCS
    {

        internal static int lcs(string x, string y)
        {
            int m = x.Length;
            int n = y.Length;
            int[,] C = new int[m, n];
            string[,] cam = new string[m, n];

            for (int i = 0; i < m; i++)
                C[i, 0] = 0;

            for (int j = 0; j < n; j++)
                C[0, j] = 0;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (x[i] == y[j])
                    {
                        C[i, j] = C[i - 1, j - 1] + 1;
                        cam[i,j]="\\";
                    }
                    else if (C[i-1,j]>C[i,j-1])
                    {
                        C[i,j]=C[i-1,j];
                        cam[i, j] = "|";
                    }
                    else
                    {
                        C[i,j]=C[i,j-1];
                        cam[i, j] = "-";
                    }
                }
            }

            int a = m - 1;
            int b = n - 1;
            imprimeLCS(cam, x, ref a, ref b);

            return C[m - 1, n - 1];
        }

        internal static void imprimeLCS(string[,] cam, string x, ref int i, ref int j)
        {
            if ((i==0)||(j==0))
                return;

            if (cam[i,j]=="\\")
            {
                int a = i - 1;
                int b = j - 1;
                imprimeLCS(cam, x, ref a, ref b);
                Console.Write(x.Substring(i, 1));
            }
            else if (cam[i, j] == "|")
            {
                int a = i - 1;
                imprimeLCS(cam, x, ref a, ref j);
            }
            else
            {
                int b = j - 1;
                imprimeLCS(cam, x, ref i, ref b);
            }
        }
        
    }
}
