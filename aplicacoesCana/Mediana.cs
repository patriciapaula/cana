using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplicacoesCana
{
    class Mediana
    {

        internal static int SelecaoAleat(int[] A, int p, int r, int i)
        {
            //só há 1 elemento
            if (p == r)
                return A[p];

            //retorna pos do pivo
            int q = ParticaoAleatoria(A, p, r);

            //posicao esperada do pivo, em relacao a p
            int k = q - p + 1;

            //se posicao pedida é igual a k
            if (i == k)
                return A[q];

            //se está na antes do pivo
            if (i < k)
                return SelecaoAleat(A, p, q - 1, i);

            //atualiza o valor de i para contar a partir do pivo
            else //se maior q k
                return SelecaoAleat(A, q+1, r, i-k);
        }

        private static int ParticaoAleatoria(int[] A, int p, int r)
        {
            //sorteia um valor para pivo e joga para final do vetor
            Random rnd = new Random();
            int x = rnd.Next(p, r);
            A[x] = A[r];
            //devolve vetor particionado
            return Particao(A, p, r);
        }

        private static int Particao(int[] A, int p, int r)
        {
            int pivo = A[r];
            int i = p-1;
            int troca;
            for (int j = p; j <= r - 1; j++)
            {
                if (A[j] <= pivo)
                {
                    i++;
                    troca = A[i];
                    A[i] = A[j];
                    A[j] = troca;
                }
            }
            troca = A[i+1];
            A[i+1] = A[r];
            A[r] = troca;
            return i + 1;
        }

    }
}
