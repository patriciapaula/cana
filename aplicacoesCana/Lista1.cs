using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Lista1
    {

        //Questao 7
        internal static bool existeSoma(int[] A, int x)
        {
            Sort.MergeSort(ref A, 0, A.Length - 1);

            int l = 0;
            int r = A.Length-1;

            //enquanto o elemento final for maior que a soma procurada 
            //e indice do fim > que indice do inicio, decrementa
            while ((A[r] > x) && (r > l))
                r--;

            while (l < r)
            {
                if (A[l] + A[r] == x)
                    return true;
                //se é > maior decrementa o indice da direita
                if (A[l] + A[r] > x)
                    r--;
                //se é < maior incrementa o indice da esquerda
                if (A[l] + A[r] < x)
                    l++;
            }
            return false;
        }        


        //Questao 8
        internal static int[] DecompoeVetor(int[] S, int p, int r, int pivo, ref int q1, ref int q2)
        {
            int[] V = new int[r - p + 1];

            for (int j = p; j <= r; j++)
            {
                //se menor que o pivô, joga para o início
                if (S[j] < pivo)
                {
                    V[q1] = S[j];
                    q1++;
                }
                else
                {
                    //se maior que o pivô, joga para o fim
                    if (S[j] > pivo)
                    {
                        V[q2] = S[j];
                        q2--;
                    }
                }
            }

            //preenche entre q1 e q2 com o elemento pivô
            for (int m = q1; m <= q2; m++)
                V[m] = pivo;

            return V;
        }


        //Questao 9
        internal static object Majoritario(object[] A, int p, int r)
        {
            if (p < r)
            {
                //verifica o majoritário em cada metade
                int q = (int)(p + r) / 2;
                object y = Majoritario(A, p, q);
                object z = Majoritario(A, q + 1, r);
                
                //conta quantos de cada
                int ny = 0;
                int nz = 0;
                if (y != null)
                    ny = Util.Conta(A, p, r, y);
                if (z != null)
                    nz = Util.Conta(A, p, r, z);

                //se algum é maior que a metade +1, devolve como majoritário
                int qtdeMaj=(int)(r-p+1)/2;
                if (ny > qtdeMaj)
                    return y;
                if (nz > qtdeMaj)
                    return z;

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
        

        //Questao 10
        internal static int Mediana(int[] X, int[] Y, int xini, int xfim, int yini, int yfim)
        {
            //acha a mediana de cada vetor
            int mx = (int)(xini + xfim) / 2;
            int my = (int)(yini + yfim) / 2;

            //só tem um elemento em cada, devolve o menor
            if ((xini == xfim) && (yini == yfim))
                if (X[mx] < Y[my])
                    return X[mx];
                else
                    return Y[my];

            //se elemento mediano de X é menor que o de Y
            if (X[mx] < Y[my])
            {
                if ((yfim - my) > (mx - xini))
                    mx++;
                //busca a mediana no fim de X e no início de Y
                return Mediana(X, Y, mx, xfim, yini, my);
            }
            else
            {
                if ((xfim - mx) > (my - yini))
                    my++;
                //busca a mediana no início de X e no fim de Y
                return Mediana(X, Y, xini, mx, my, yfim);
            }
        }                                
        

        //Questao 11
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

            //k está no meio
            if (meioX + meioY == k)
            {
                if (X[meioX] <= Y[meioY])
                    return X[meioX];
                else
                    return Y[meioY];
            }

            // pos meio de X + pos meio de Y é menor que k
            if (meioX + meioY < k)
            {
                // se elemento do meio de X é maior que o elem do meio de Y
                if (X[meioX] > Y[meioY])
                {
                    int[] vetorTemp = Util.PedacoVetor(Y, meioY + 1, Y.Length); //Y[meioY+1,Y.Lenght]
                    return KEsimo(X, vetorTemp, k - meioY - 1);
                }
                else
                {
                    int[] vetorTemp = Util.PedacoVetor(X, meioX + 1, X.Length); //X[meioX+1, X.Length]
                    return KEsimo(vetorTemp, Y, k - meioX - 1);
                }
            }
            else
            {
                // se elemento do meio de X é maior que o elem do meio de Y
                if (X[meioX] > Y[meioY])
                {
                    int[] vetorTemp = Util.PedacoVetor(X, 0, meioX); //X[0, meioX]
                    return KEsimo(vetorTemp, Y, k);
                }
                else
                {
                    // ignora 1a metade de X e ajusta k
                    int[] vetorTemp = Util.PedacoVetor(Y, 0, meioY); //Y[0, meioY]
                    return KEsimo(X, vetorTemp, k);
                }
                
            }
        }


        //Questao 12
        internal static int ContaInversoes(int[] A, int p, int r)
        {
            int a = 0, b = 0, c = 0;
            if (A.Length == 1)
                return 0;
            if (p < r)
            {
                int q = (int)(p + r) / 2;
                a = ContaInversoes(A, p, q);
                b = ContaInversoes(A, q + 1, r);
                c = IntercalaContaInversoes(ref A, p, q, r);
            }
            return (a + b + c);
        }
        private static int IntercalaContaInversoes(ref int[] A, int p, int q, int r)
        {
            int[] B = new int[A.Length];
            int i;
            int j;
            int k;
            int cont;

            for (i = p; i <= q; i++) //1a parte: p até q
                B[i] = A[i];
            for (j = q + 1; j <= r; j++) //2a parte: q+1 até r
                B[r + q + 1 - j] = A[j];

            i = p; //contador do início do vetor
            j = r; //contador do fim do vetor
            cont = 0; //contador de inversões

            for (k = p; k <= r; k++)
            {
                if (B[i] <= B[j])
                {
                    A[k] = B[i];
                    i++; 
                }
                else
                {
                    //houve inversão, pois B[i]>B[j]
                    A[k] = B[j];
                    j--; 
                    //conta inversão: como está ordenado, conta com todos os maiores que ele
                    cont = cont + (q - i + 1);
                }
            }
            return cont;
        }

                        
    }
}