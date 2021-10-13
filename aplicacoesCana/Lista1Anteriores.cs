using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Lista1Anteriores
    {

        //questão do heap mínimo
        public static void HeapMinimo(ref int[] A)
        {
            BuildMinHeap(ref A); //***

            int n = A.Length;
            for (int i = n - 1; i >= 1; i--)
            {
                Util.troca(A, i, 0);
                n--;
                MinHeapify(A, 0, n);
            }

            //com o heap minimo vem invertido
            int troca = A[0];
            int ultimo = A.Length - 1;
            int[] B = new int[A.Length];
            for (int i = 0; i <= A.Length - 1; i++)
            {
                B[i] = A[ultimo];
                ultimo--;
            }
        }
        private static void BuildMinHeap(ref int[] A)
        {
            int n = A.Length;
            for (int i = (n / 2) - 1; i >= 0; i--)
                MinHeapify(A, i, n); 
        }
        private static void MinHeapify(int[] A, int i, int n)
        {
            //i: posicao no heap
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int menor = 0; 

            if ((l < n) && (A[l] < A[i])) 
                menor = l;
            else
                menor = i;

            if ((r < n) && (A[r] < A[menor])) 
                menor = r;

            if (menor != i)
            {
                Util.troca(A, i, menor);
                MinHeapify(A, menor, n);
            }
        }


        //questão do item mais popular; n/3+1
        internal static object Popular(object[] A, int p, int r)
        {
            if (p < r)
            {
                //verifica o popular em cada terço
                int q = r-p+1; //tamanho

                object y = Popular(A, p, p+(int)q/3-1);
                object z = Popular(A, p+(int)q/3, p+(int)2*q/3-1);
                object x = Popular(A, p+(int)2*q/3, r);

                //conta quantos de cada
                int ny = 0;
                int nz = 0;
                int nx = 0;

                if (y != null)
                    ny = Util.Conta(A, p, r, y);
                if (z != null)
                    nz = Util.Conta(A, p, r, z);
                if (x != null)
                    nx = Util.Conta(A, p, r, x);

                //se algum é maior que a 1/3 +1, devolve como popular
                int qtdePopular = (int)(r - p + 1) / 3;
                if (ny > qtdePopular)
                    return y;
                if (nz > qtdePopular)
                    return z;
                if (nx > qtdePopular)
                    return x;

                return null;
            }
            else
            {
                //se tem só 1, ele é o majoritário
                if (p == r)
                    return A[p];
                else
                    return null;
            }
        }

    }
}
