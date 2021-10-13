using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class SandBox
    {
        /*
         internal static int KEsimo(int[] X, int[] Y, int k)
        {
            // se posicao é maior que o tamanho dos 2 vetores somados, não existe
            if (k > X.Length + Y.Length + 1)//+1 pq é base 0
                return -1;

            // se um deles é vazio, considera  posição do 2o
            if ((X.Length == 0)&&(k<Y.Length))
                return Y[k];
            else if ((Y.Length == 0) && (k < X.Length))
                return X[k];

            int meioX = (int)(X.Length / 2) - 1; //-1 pq é base 0
            int meioY = (int)(Y.Length / 2) - 1; //-1 pq é base 0

            if (meioX < 0) meioX = 0; //pq é base 0
            if (meioY < 0) meioY = 0; //pq é base 0

            //se está no meio
            if (meioX + meioY == k)
            {
                if (X[meioX] <= Y[meioY])
                    return X[meioX];
                else
                    return Y[meioY];
            }

            // pos meio de X + pos meio de Y é maior que k
            if (meioX + meioY > k)
            {
                // se elemento do meio de X é maior que o elem do meio de Y
                if (X[meioX] > Y[meioY])
                {
                    int[] vetorTemp = PedacoVetor(X, 0, meioX); //X[0, meioX]
                    return KEsimo(vetorTemp, Y ,k); 
                }
                else
                {
                    // ignora 1a metade de X e ajusta k
                    int[] vetorTemp = PedacoVetor(Y, 0, meioY); //Y[0, meioY]
                    return KEsimo(X, vetorTemp, k); 
                }
            }
            else
            {
                // se elemento do meio de X é maior que o elem do meio de Y
                if (X[meioX] > Y[meioY])
                {
                    int[] vetorTemp = PedacoVetor(Y, meioY+1, Y.Length); //Y[meioY+1,Y.Lenght]
                    return KEsimo(X,vetorTemp, k -meioY-1);
                }
                else
                {
                    int[] vetorTemp = PedacoVetor(X, meioX+1, X.Length); //X[meioX+1, X.Length]
                    return KEsimo(vetorTemp,Y, k-meioX-1);
                }
            }
        }
         * /

        /*internal static object AchaMajoritario(object[] A, int ini, int fim)
        {
         * //funcionava mas era mais complexo
            if (ini > fim)
                return null; // não achou majoritário

            else if (ini == fim)
                return A[ini]; // há apenas um elemento - ele é o majoritário

            else
            {
                int meio = ini + (fim - ini) / 2; //divide ao meio

                //tenta achar o majoritario na 1a parte
                object x = AchaMajoritario(A, ini, meio);

                //tenta achar o majoritario na 2a parte
                object y = AchaMajoritario(A, meio + 1, fim);

                if (x == y)
                    return x; // x e y = null ou majoritario

                if (x != null) // x é majoritario na 1a metade: vê se qtde de x é > metade+1
                    if (Conta(A, ini, fim, x) > (fim - ini + 1) / 2)
                        return x;

                if (y != null) // y é majoritario na 2a metade: vê se qtde de y é > metade+1
                    if (Conta(A, ini, fim, y) > (fim - ini + 1) / 2)
                        return y;

                return null;
            }
        }*/

        //Dado um inteiro x e um vetor inteiro crescente A[1..n], encontrar j tal que  A[j−1] < x ≤ A[j].
        //tempo: log n
        internal static int BuscaBinariaIterativa(int[] A, int n, int x)
        {
            int p = 0;
            int r = n + 1;
            int q;
            while (p < r - 1)
            {
                q = (int)(p + r) / 2;
                if (A[q] < x)
                    p = q;
                else
                    r = q;
            }
            return r;
        }

    }
}
