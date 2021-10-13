using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Prova2_2012
    {
        
        internal static int concatenar(string[] S, int n)
        {
            int[,] C = new int[n, n];
            int[,] sol = new int[n, n];
            int[,] custo = new int[n,n];
                        
            for (int i = 0; i < n; i++)
            {
                
                C[i, i] = i;
                for (int y = 0; y < n; y++)
                {
                    custo[i, y] = custoConcatenar(S[i], S[y]); //calcula custos de concatenacao de S[i] e S[y]
                    sol[i, y] = -1;
                }
            }

            int j = 0;
            int q = 0;
            for (int L = 1; L < n; L++) //para L = 2 até n
            {
                for (int i = 0; i < n - L; i++) //para i = 1 até n-L+1
                {
                    j = i + L; //j = i + L - 1;
                    C[i, j] = 100000; //infinito
                    q = 0;

                    for (int k = i; k <= j - 1; k++)
                    {
                        q = C[i, k] + C[k + 1, j] + custo[i, k] + custo[k+1,j];

                        if (C[i, j] > q)
                        {
                            C[i, j] = q;
                            sol[i, j] = k;
                        }
                    }
                }
            }

            imprimeSubconjunto(sol, 0, n - 1);

            return C[0, n - 1];
        }
        private static int custoConcatenar(string a, string b)
        {
            int p1=a.Length ^ 7 % 11;
            int p2=b.Length ^ 5 % 29;
            int p3=a.Length * (b.Length % 7);
            return (p1 + p2 + p3);
        }
        private static void imprimeSubconjunto(int[,] sol, int i, int j)
        {
            if (i == j)
                Console.Write(i);
            else
            {
                imprimeSubconjunto(sol, i, sol[i, j]);
                Console.Write("o");
                imprimeSubconjunto(sol, sol[i, j] + 1, j);
            }
        }

        //q1
        internal static bool soma(int[] P, int t)
        {
            int infinito = 100000;
            int n = P.Length;
            bool[,] v = new bool[n + 1, t + 1]; //se soma ok
            int[,] r = new int[n + 1, t + 1];   //somas possiveis
            int[,] f = new int[n + 1, t + 1];   //funcoes

            for (int i = 0; i <= n; i++)
            {
                for (int j=0; j<=t; j++)
                {
                    v[i, j] = false;
                    f[i,j] = infinito;
                }
                v[i, 0] = true;
            }

            for (int b = 1; b <= t; b++) //b vai de 1 até a soma
            {
                v[0, b] = false;

                for (int i = 1; i < n; i++)
                {
                    if (P[i] == t) //o proprio valor é a soma
                    {
                        v[i, b] = true;
                        r[i, b] = P[i];
                        f[i, b] = funcaoQ1(P[i]);

                        //se ja existia uma funcao menor, fica com ela (sempre armazena a menor)
                        if (f[i - 1, b] < f[i, b])
                        {
                            r[i, b] = r[i - 1, b];
                            f[i, b] = f[i - 1, b];
                        }
                    }
                    else if (P[i] < b)
                    {
                                                
                        int soma = r[i - 1, b];
                        if ((soma == 0) && (P[i - 1] <= b))
                        {
                            v[i, b] = v[i - 1, b - P[i - 1]];
                            r[i, b] = r[i - 1, b - P[i - 1]];
                            f[i, b] = f[i - 1, b - P[i - 1]];
                        }
                        else
                        {
                            v[i, b] = v[i - 1, b];
                            r[i, b] = r[i - 1, b];
                            f[i, b] = f[i - 1, b];
                        }
                    }
                    else //nao achou - continua com o menor
                    {
                        v[i, b] = v[i - 1, b];
                        r[i, b] = r[i - 1, b];
                        f[i, b] = f[i - 1, b];
                    }
                }
            }
            Console.Write("v:" + v[n, t] + "\n");
            Console.Write("r:" + r[n, t] + "\n");
            Console.Write("f:" + f[n, t] + "\n");
            return v[n, t];
        }
        private static int funcaoQ1(int b)
        {
            return (int)(b ^ 3 % 7);
        }

        //Q1 alterna
        internal static int subconjunto(int[] V, int n, int T)
        {            
            int[,] M = new int[n + 1, T + 1]; //armazenará se é possível satisfazer a condição pedida
            int[,] S = new int[n + 1, T + 1]; //armazenará a soma dos módulos
            
            for (int i = 0; i < n; i++) //preenchendo 1a coluna
            {
                M[i, 0] = 1;
                S[i, 0] = V[i] ^ 3 % 7;
            }

            for (int j = 1; j < T; j++) //preenchendo o resto da matriz
            {
                M[0, j] = 1;
                S[0, j] = V[0] ^ 3 % 7;

                for (int i = 1; i < n; i++) 
                {
                    if (V[i] <= j)
                    {
                        M[i, j] = 1;
                        if (M[i - 1, j - V[i]] == 1)
                            S[i, j] = Util.min(S[i, j], S[i - 1, j - V[i]] + (V[i] ^ 3 % 7));
                    }

                    if ((V[i] == j) || (M[i - 1, j] == 1))
                    {
                        M[i, j] = 1;

                        if (V[i] == j)
                            S[i, j] = V[i] ^ 3 % 7;

                        if (M[i - 1, j] == 1)
                            S[i, j] = Util.min(S[i, j], S[i - 1, j]);
                    }
                }
            }

            string imp = imprimeSubconjunto(M, S, V, n, T);

            //retornando última posição (1 se houver subconjunto, 0 se não houver)
            return M[n-1,T-1];
        }
        private static string imprimeSubconjunto(int[,] M, int[,] N,int[] V,int n, int T)
        {
            if ( (M[n,T]==0) || (n==0) || (T<0))
                return "";

            int v1 = N[n,T];//obtendo os valores das somas nos 3 casos
            int v2=N[n-1,T];
            int v3=N[n-1,T-V[n]];

            int min = Util.min(Util.min(v1,v2),v3);

            //decidindo qual elemento adicionar dependendo do mínimo
            if (v1 == min)
                return V[n].ToString();
            else if (v2 == min)
                return imprimeSubconjunto(M,N,V,n-1,T);
            else if (v3 == min)
                return V[n].ToString() + imprimeSubconjunto(M,N,V,n-1,T);
            else
                return "";
        }

        //Q4
        internal static int palindromo(string x, string y)
        {
            int m = x.Length;
            int n = y.Length;
            int[,] C = new int[m, n];
            string[,] cam = new string[m, n];

            string[] s = new string[n];

            for (int i = 0; i < m; i++)
                C[i, 0] = 0;

            for (int j = 0; j < n; j++)
                C[0, j] = 0;

            int z=0;
                for (int i = m-1; i >0; i--)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (x[i] == y[j]) 
                        {
                            C[i, j] = C[i - 1, j - 1] + 1;
                            cam[i, j] = "\\";
                            s[z]=x[i].ToString();
                            z++;
                        }
                        else if (C[i - 1, j] > C[i, j - 1])
                        {
                            C[i, j] = C[i - 1, j];
                        }
                        else
                        {
                            C[i, j] = C[i, j - 1];
                        }
                    }
                }

            return 1;
        }

        internal static void imprimeLCS(string[,] cam, string x, int i, int j)
        {
            if ((i == 0) || (j == 0))
                return;

            if (cam[i, j] == "|")
            {
                int a = i + 1;
                int b = j - 1;
                imprimeLCS(cam, x, a, b);
                Console.Write(x.Substring(i, 1));
            }
            else if (cam[i, j] == "<")
            {
                int a = j - 1;
                imprimeLCS(cam, x, a, j);
            }
            else
            {
                int b = i+1;
                imprimeLCS(cam, x, i, b);
            }
        }


    }
}
