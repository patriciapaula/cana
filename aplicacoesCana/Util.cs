using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Util
    {

        public static int max(int i, int j)
        {
            if (i > j)
                return i;
            else
                return j;
        }

        public static int min(int i, int j)
        {
            if (i < j)
                return i;
            else
                return j;
        }

        //escreve elem do vetor 
        public static void escreveNums(string[] C)
        {
            try
            {
                Console.Clear();
                for (int j = 0; j < C.Length; j++)
                {
                    if ((C[j] != "-1") && (C[j] != null))
                    {
                        Console.Write(C[j]);
                        if (j < C.Length - 1)
                            Console.Write(", ");
                    }
                }
            }
            catch { }
        }


        public static void troca(int[] v, int i, int j)
        {
            int aux = v[i];
            v[i] = v[j];
            v[j] = aux;
        }

        public static int Conta(object[] A, int ini, int fim, object x)
        {
            int total = 0;
            for (int k = ini; k <= fim; k++)
                if (A[k].ToString() == x.ToString())
                    total++;
            return total;
        }

        public static int[] PedacoVetor(int[] V, int ini, int fim)
        {
            int[] vetorTemp = new int[fim - ini];
            int cont = 0;
            for (int temp = ini; temp < fim; temp++)
            {
                vetorTemp[cont] = V[temp];
                cont++;
            }
            return vetorTemp;
        }
        
    }
}
