using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class MergeSort
    {

        public static void Sort(ref int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = (int)(p + r) / 2;
                Sort(ref A, p, q);
                Sort(ref A, q + 1, r);
                Intercala(ref A, p, q, r);
            }
        }

        internal static void Intercala(ref int[] A, int p, int q, int r)
        {
            int[] B = new int[A.Length];

            int i;
            for (i = p; i <= q; i++)
                B[i] = A[i];

            int j;
            for (j = q+1; j <= r; j++)
                B[r + q + 1 - j] = A[j];

            i = p;
            j = r;

            int k;
            for (k = p; k <= r; k++)
            {
                if (B[i] <= B[j])
                {
                    A[k] = B[i];
                    i++;
                }
                else
                {
                    A[k] = B[j];
                    j--;
                }
            }
        }

        //intercala visto em sala:
        internal static void Intercala2(ref int[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1+1];
            int[] R = new int[n2+1];
            L[n1] = Int16.MaxValue;
            R[n2] = Int16.MaxValue;

            int i;
            for (i = 0; i <= n1 - 1; i++)
                L[i] = A[p + i];

            int j;
            for (j = 0; j <= n2 - 1; j++)
            {
                R[j] = A[q + j+1];
            }

            //volta ao inicio
            i = 0;
            j = 0;

            int k;
            for (k = p; k <= r; k++)
            {
                if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }
                else
                {
                    A[k] = R[j];
                    j++;
                }
            }
        }


    }
}
