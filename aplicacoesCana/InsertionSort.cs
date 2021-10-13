using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class InsertionSort
    {

        public static int[] Sort(int[] A, int n)
        {
            //2 até n
            for (int j = 1; j <= n; j++)
            {
                int carta = A[j];
                int i = j - 1;

                //i>=1 -> i>=0
                while ((i >= 0) && (A[i] > carta))
                {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = carta;
            }
            return null;
        }

    }
}
