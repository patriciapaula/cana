using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class PD_MenorCaminho
    {

        internal static int[,] FloydWarshal(int[,] D, int n, int noOrigem, int noDest)
        {
            //floyd warshall - usando D[i,j]
            int?[,] R = new int?[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (D[i, j] < 100000000) //infinito
                        R[i, j] = i;
                }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (D[i, j] > D[i, k] + D[k, j])
                        {
                            D[i, j] = D[i, k] + D[k, j];
                            R[i, j] = R[k, j];
                        }
                    }
                }
            }
            ImprimeFloydWarshal(R, noOrigem, noDest);
            return D;
        }
        internal static void ImprimeFloydWarshal(int?[,] R, int i, int j)
        {
            if (i == j)
                Console.Write(i);
            else if (R[i, j] == null)
                Console.Write("não existe caminho de " + i + " para " + j);
            else
            {
                ImprimeFloydWarshal(R, i, (int)R[i, j]);
                Console.Write(j);
            }
        }
        
    }
}
