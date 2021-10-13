using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class QuickSort
    {

        public static void Sort(ref int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = Particione(A, p, r);
                Sort(ref A, p, q - 1);
                Sort(ref A, q + 1, r);
            }
        }

        private static int Particione(int[] A, int p, int r)
        {
            int pivo = A[r]; //pivo está no último elemento
            int i = p-1;
            int troca;

            for (int j = p; j < r; j++)
            {
                if (A[j] <= pivo)
                {
                    i++;
                    troca = A[i];
                    A[i] = A[j];
                    A[j] = troca;
                }
            }
            troca = A[i + 1];
            A[i + 1] = A[r];
            A[r] = troca;
            return i+1;
        }

        
    }
}
