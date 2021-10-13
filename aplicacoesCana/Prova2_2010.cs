using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Prova2_2010
    {
        
        //questao 1
        internal static void linhaMontagem3(int[,] a, int[,,] t, int[] e, int[] x, int n)
        {
            //a[linha,pos]
            //t[origem,dest,posOrigem]

            //melhores tempos
            int f;
            int[] f1 = new int[n];
            int[] f2 = new int[n];
            int[] f3 = new int[n];            

            f1[0] = e[0] + a[0,0];
            f2[0] = e[1] + a[1,0];
            f3[0] = e[2] + a[2,0];

            //solucao otima
            int l;
            int[] l1 = new int[n];
            int[] l2 = new int[n];
            int[] l3 = new int[n];

            l1[0] = 1;
            l2[0] = 2;
            l3[0] = 3;

            for (int k = 1; k < n; k++)
            {
                //para linha 1
                if (f1[k - 1] <= f2[k - 1] + t[1, 0, k - 1]) //f1 menor
                {
                    if (f1[k - 1] <= f3[k - 1] + t[2, 0, k - 1])
                    {
                        //manteve na propria linha 1
                        f1[k] = f1[k - 1] + a[0, k];
                        l1[k] = 1;
                    }
                    else
                    {
                        //veio da linha 3 para a 1
                        f1[k] = f3[k - 1] + t[2, 0, k - 1] + a[0, k];
                        l1[k] = 3;
                    }
                }
                else //f2 menor
                {
                    if (f2[k - 1] + t[1, 0, k - 1] <= f3[k - 1] + t[2, 0, k - 1])
                    {
                        //veio da linha 2 para a 1
                        f1[k] = f2[k - 1] + t[1, 0, k - 1] + a[0, k]; ;
                        l1[k] = 2;
                    }
                    else
                    {
                        //veio da linha 3 para a 1
                        f1[k] = f3[k - 1] + t[2, 0, k - 1] + a[0, k];
                        l1[k] = 3;
                    }
                }

                //para linha 2
                if (f2[k - 1] <= f1[k - 1] + t[0, 1, k - 1]) //f2 menor
                {
                    if (f2[k - 1] <= f3[k - 1] + t[2, 1, k - 1])
                    {
                        //manteve na propria linha 2
                        f2[k] = f2[k - 1] + a[1, k];
                        l2[k] = 2;
                    }
                    else
                    {
                        //veio da linha 3 para a 2
                        f2[k] = f3[k - 1] + t[2, 1, k - 1] + a[1, k];
                        l2[k] = 3;
                    }
                }
                else //f1 menor
                {
                    if (f1[k - 1] + t[0, 1, k - 1] <= f3[k - 1] + t[2, 1, k - 1])
                    {
                        //veio da linha 1 para a 2
                        f2[k] = f1[k - 1] + t[0, 1, k - 1] + a[1, k]; ;
                        l2[k] = 1;
                    }
                    else
                    {
                        //veio da linha 3 para a 1
                        f2[k] = f3[k - 1] + t[2, 0, k - 1] + a[1, k];
                        l2[k] = 3;
                    }
                }

                //para linha 3
                if (f3[k - 1] <= f1[k - 1] + t[0, 2, k - 1]) //f3 menor
                {
                    if (f3[k - 1] <= f2[k - 1] + t[1, 2, k - 1])
                    {
                        //manteve na propria linha 3
                        f3[k] = f3[k - 1] + a[2, k];
                        l3[k] = 3;
                    }
                    else
                    {
                        //veio da linha 2 para a 3
                        f3[k] = f2[k - 1] + t[1, 2, k - 1] + a[2, k];
                        l3[k] = 2;
                    }
                }
                else //f1 menor
                {
                    if (f1[k - 1] + t[0, 2, k - 1] <= f2[k - 1] + t[1, 2, k - 1])
                    {
                        //veio da linha 1 para a 3
                        f3[k] = f1[k - 1] + t[0, 2, k - 1] + a[2, k]; ;
                        l3[k] = 1;
                    }
                    else
                    {
                        //veio da linha 2 para a 3
                        f3[k] = f2[k - 1] + t[1, 2, k - 1] + a[2, k];
                        l3[k] = 2;
                    }
                }
            }

            int ult = n - 1;

            //solucao otima
            if (f1[ult] + x[0] <= f2[ult] + x[1]) //f1 <= f2
            {
                if (f1[ult] + x[0] <= f3[ult] + x[2]) // e f1 <= f3
                {
                    f = f1[ult] + x[0];
                    l = 1;
                }
                else // e f3 <= f1
                {
                    f = f3[ult] + x[2];
                    l = 3;
                }
            }
            else //f2 <= f1
            {
                if (f2[ult] + x[1] <= f3[ult] + x[2]) // e f2 <= f3
                {
                    f = f2[ult] + x[1];
                    l = 2;
                }
                else // e f3 <= f2
                {
                    f = f3[ult] + x[2];
                    l = 3;
                }
            }

            imprimeMontagem(l, l1, l2, l3, n-1);
            //return
        }
        internal static void imprimeMontagem(int l, int[] l1, int[] l2, int[] l3, int n)
        {
            int i = l;
            Console.Write("Linha " + i + ", estação " + n + "\n");

            for (int j = n; j >= 1; j--)
            {
                if (i == 1)
                    i = l1[j];
                if (i == 2)
                    i = l2[j];
                if (i == 3)
                    i = l3[j];
                int pos = j - 1;
                Console.Write("Linha " + i + ", estação " + pos + "\n");
            }
        }
        
        //questao 2: ok
        internal static int[] GastoViagem(int[] a, int[] p)
        {
            int n = a.Length;
            int infinito = 1000000;
            int[] h = new int[n];
            int[,] D = new int[n, n];
            int[] tot = new int[n];

            int[,] R = new int[n, n];
            //calculo os custos de viagem entre os hoteis considerando as multas
            for (int z = 0; z < n; z++)
            {
                for (int j = z; j < n; j++)
                {
                    if (z == j)
                        R[z, j] = infinito;
                    else
                        //custo de ir do hotel i para o j: diaria de j + multa de i para j
                        R[z, j] = p[j] + CalculaMulta(a[z], a[j]);
                    h[z] = -1;
                }
            }
            
            int cont = 0;
            int i = 0;
            while (cont < n)
            {
                int indMenor = -1;
                int menor = infinito;
                for (int j = i+1; j < n; j++)
                {
                    if (R[i, j] < menor)
                    {
                        menor = R[i, j];
                        indMenor = j;
                        tot[i + 1] = tot[i] + R[i, j];
                        D[i, j] = D[i, j] + R[i, j];
                        h[i] = j;
                    }
                }
                if (indMenor != -1)
                    i = indMenor;
                cont++;
            }
            
            ImprimeHoteis(h, n);
            return h;
        }
        private static void ImprimeHoteis(int[] h, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (h[i] != -1)
                    Console.Write(" > " + h[i]);
            }
        }
        private static int CalculaMulta(int kmIni, int kmFim)
        {
            int multaKm = 0;
            int km = kmFim - kmIni;
            if ((km < 600) || (km > 600))
                multaKm = Math.Abs(600 - km);
            return multaKm;
        }
                
        //questao 3 - rever
        internal static int Grafo(int[,] D, int n)
        {
            int somaArestas = 0; // soma das arestas
            int[,] grafo = D;
            int[] marcaColuna = new int[n]; // marca colunas ja usadas
            int[] nosPercorridos = new int[n]; // nos q fazem parte da solucao

            for (int j = 0; j < n; j++)
                nosPercorridos[j] = -1;

            int i = 0;
            int cont = 0;
            while (cont < n)
            {
                int maior = 0;
                int indColuna = -1;

                // percorre os nos ainda não visitados procurando o maior peso das arestas
                for (int j = 0; j < n; j++)
                {
                    //se ainda nao pegou essa coluna, pode verificar
                    if ((marcaColuna[j] == 0) && (i != j))
                    {
                        if (grafo[i, j] > maior)
                        {
                            maior = grafo[i, j];
                            indColuna = j;
                        }
                    }
                }

                if (indColuna != -1)
                {
                    if (cont == 0)
                    {
                        //sempre começa do 0
                        nosPercorridos[0] = i;
                        marcaColuna[i] = 1;
                    }
                    nosPercorridos[cont + 1] = indColuna;
                    marcaColuna[indColuna] = 1;

                    somaArestas = somaArestas + grafo[i, indColuna];

                    //zero o inverso na matriz, já que é espelhada, para nao ter perigo de pegar o mesmo de novo
                    grafo[indColuna, i] = 0;

                    i = indColuna; //varre na linha equivalente à coluna achada
                }
                cont++;
            }
            ImprimeNos(nosPercorridos);
            return somaArestas;
        }
        internal static int Grafo2(int[,] D, int n)
        {
            int somaArestas = 0; // soma das arestas
            int[,] grafo = D;
            int[] marcaColuna = new int[n]; // marca colunas ja usadas
            int[] nosPercorridos = new int[n*2]; // nohs q fazem parte da solucao

            for (int j = 0; j < n; j++)
                nosPercorridos[j] = -1;

            int cont=0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (i != j)
                    {
                        if (grafo[i, j - 1] > grafo[i - 1, j])
                        {
                            if (grafo[i, j - 1] > grafo[i - 1, j - 1])
                            {
                                somaArestas = somaArestas + grafo[i, j - 1];
                                nosPercorridos[cont] = i;
                                nosPercorridos[cont + 1] = j - 1;
                                grafo[i, j - 1] = 0;
                                grafo[j - 1, i] = 0;
                            }
                            else
                            {
                                somaArestas = somaArestas + grafo[i - 1, j - 1];
                                nosPercorridos[cont] = i - 1;
                                nosPercorridos[cont + 1] = j - 1;
                                grafo[i - 1, j - 1] = 0;
                                grafo[j - 1, i - 1] = 0;
                            }
                        }
                        else
                        {
                            if (grafo[i - 1, j] > grafo[i - 1, j - 1])
                            {
                                somaArestas = somaArestas + grafo[i - 1, j];
                                nosPercorridos[cont] = i-1;
                                nosPercorridos[cont + 1] = j;
                                grafo[i - 1, j] = 0;
                                grafo[j, i-1] = 0;
                            }
                            else
                            {
                                somaArestas = somaArestas + grafo[i - 1, j - 1];
                                nosPercorridos[cont] = i - 1;
                                nosPercorridos[cont + 1] = j-1;
                                grafo[i - 1, j - 1] = 0;
                                grafo[j-1, i - 1] = 0;
                            }
                        }
                        cont = cont + 2;
                    }
                }
            }

            ImprimeNos(nosPercorridos);
            return somaArestas;
        }
        private static void ImprimeNos(int[] nos)
        {
            for (int i = 0; i < nos.Length; i++)
                if (nos[i]!=-1)
                    Console.Write(nos[i].ToString() + "\n");
        }


    }
}
