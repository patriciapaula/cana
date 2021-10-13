using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Sort
    {


        public static int[] InsertionSort(int[] A, int n)
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
        

        public static int[] CountingSort(int[] A, ref int[] B, int k)
        {
            int n = A.Length;
            int[] C = new int[n];

            for (int i = 0; i < k; i++)
                C[i] = 0;
                        
            //depois desse for, C[i] contem elem = i
            for (int j = 0; j < n; j++)
                C[A[j]]++;

            //depois desse for, C[i] contem elem <= i
            for (int i = 1; i < k; i++)
                C[i] = C[i] + C[i-1];

            for (int j = n-1; j >= 0; j--)
            {
                B[C[A[j]]] = A[j];
                C[A[j]] = C[A[j]] - 1;
            }

            return C;
        }


        public static void QuickSort(ref int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = Particione(A, p, r);
                QuickSort(ref A, p, q - 1);
                QuickSort(ref A, q + 1, r);
            }
        }
        private static int Particione(int[] A, int p, int r)
        {
            int pivo = A[r]; //pivo está no último elemento
            int i = p - 1;
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
            return i + 1;
        }


        public static void HeapSort(ref int[] A)
        {
            BuildMaxHeap(ref A);

            int n = A.Length;
            for (int i = n - 1; i >= 1; i--)
            {
                Util.troca(A, i, 0);
                n--;
                MaxHeapify(A, 0, n); //1
            }
        }
        private static void BuildMaxHeap(ref int[] A)
        {
            int n = A.Length;
            for (int i = (n / 2) - 1; i >= 0; i--) //1
                MaxHeapify(A, i, n);
        }
        private static void MaxHeapify(int[] A, int i, int n)
        {
            //i: posicao no heap
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int maior = 0;

            if ((l < n) && (A[l] > A[i]))
                maior = l;
            else
                maior = i;

            if ((r < n) && (A[r] > A[maior]))
                maior = r;

            if (maior != i)
            {
                Util.troca(A, i, maior);
                MaxHeapify(A, maior, n);
            }
        }


        public static void MergeSort(ref int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = (int)(p + r) / 2;
                MergeSort(ref A, p, q);
                MergeSort(ref A, q + 1, r);
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
            for (j = q + 1; j <= r; j++)
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
        private static void Intercala2(ref int[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];
            L[n1] = Int16.MaxValue;
            R[n2] = Int16.MaxValue;

            int i;
            for (i = 0; i <= n1 - 1; i++)
                L[i] = A[p + i];

            int j;
            for (j = 0; j <= n2 - 1; j++)
            {
                R[j] = A[q + j + 1];
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
