using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class HeapSort
    {

        public static void Sort(ref int[] A)
        {
            BuildMaxHeap(ref A);

            int n = A.Length;
            for (int i = n-1; i >= 1; i--)
            {
                Util.troca(A, i, 0);
                n--;
                MaxHeapify(A, 0, n); //1
            }
        }

        private static void BuildMaxHeap(ref int[] A)
        {
            int n = A.Length;
            for (int i = (n/2)-1; i >= 0; i--) //1
                MaxHeapify(A, i, n);
        }

        private static void MaxHeapify(int[] A, int i, int n) 
        {
            //i: posicao no heap
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int maior=0;

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
        
    }
}
