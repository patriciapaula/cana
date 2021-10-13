using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class Lista2
    {
        //questao 2
        internal static bool quebraNums_outra(string S)
        {
            string num = "";
            int n=S.Length;
            bool[] m = new bool[n];
            int[] v = new int[n];

            for (int i = 0; i < n; i++)
                v[i] = -1;

            //vazio
            if (n <= 0)
                return false;
            
            for (int i = 0; i < n; i++)
            {
                num = S.Substring(0, i+1); //numero vai de 0 a i: S[0..i]
                m[i] = eh_quadrado_cubo_perfeito(num);

                if (!m[i])
                {
                    int k = 0;
                    while(k<i)//for (int k = 0; k < i; k++)
                    {
                        int tam = i - k; //numero vai de k+1 a i: S[k+1..i]
                        num = S.Substring(k + 1, tam);

                        if (m[k] && eh_quadrado_cubo_perfeito(num))
                        {
                            m[i] = true;
                            v[i] = k;
                            k = i;
                        }
                        k++;
                    }
                }
            }
            
            //Util.escreveNums(v);
            return m[n-1];
        }
        internal static bool quebraNums(string S)
        {
            string num = "";
            int n=S.Length;
            bool[] C = new bool[n];
            string[] mem = new string[n];
            
            //vazio
            if (n <= 0)
                return false;
            
            for (int i = 0; i < n; i++)
            {
                num = S.Substring(0, i + 1); //numero vai de 0 a i: S[0..i]
                C[i] = eh_quadrado_cubo_perfeito(num);

                for (int k = 0; k < i; k++)
                {
                    int tam = i - k; //numero vai de k+1 a i: S[k+1..i]
                    num = S.Substring(k+1, tam);

                    	if (C[k] && eh_quadrado_cubo_perfeito(num))
                    {
                        C[i] = true;
                        mem[i] = num;
                    }
                }
            }

            Util.escreveNums(mem);
            return C[n-1];
        }
        internal static bool eh_quadrado_cubo_perfeito(string a)
        {
            double num = Convert.ToDouble(a);

            double raizQuad = 0.5;
            double raizCubi = 0.33333;

            //calcula raiz quadrada e cúbica de num
            double quad = Math.Round(Math.Pow(num, raizQuad), 1);
            double cubo = Math.Round(Math.Pow(num, raizCubi), 1);

            //se é igual ao int dele é pq o valor é int mesmo
            if ((quad == (int)quad) || (cubo == (int)cubo))
                return true;

            return false;
        }
        private static void imprimeNums(String S, int[] V)
        {
		    int n = S.Length-1;
		    int[] sol = new int[n+1];

            int cont = 1;
            sol[0] = n;
            int i = V[n];
            while (i > 0)
            {
                sol[cont]=i;
                i = V[i];
                cont++;
            }

		    //impressao
		    for(int k = n;k >= 0;k--){ //lendo invertido
                int inicio = sol[k];
                int fim = sol[k]+1;
                int tam = fim-inicio +1;
			    Console.Write(S.Substring(inicio,tam) + "\n");
                if (sol[k + 1] == -1)
                    k = -1;
		    }
	    }



        //questao 3
        internal static void parenteses(double[] x, string[] op)
        {
            int n = x.Length;

            double[,] Rmin = new double[n, n];
            double[,] Rmax = new double[n, n];

            int[,] smin = new int[n, n];
            int[,] smax = new int[n, n];

            //se i=j, recebe x[i]
            for (int i = 0; i < n; i++)
            {
                Rmin[i, i] = x[i];
                Rmax[i, i] = x[i];
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int y = 0; y < n; y++)
                {
                    smin[i, y] = -1;
                    smax[i, y] = -1;
                }
            }

            int j = 0;
            double qMax = 0;
            double qMin = 0;
            for (int L = 1; L < n; L++) //para L = 2 até n
            {
                for (int i = 0; i < n - L; i++) //para i = 1 até n-L+1
                {
                    j = i + L; //j = i + L - 1;
                    Rmin[i, j] = double.PositiveInfinity;
                    Rmax[i, j] = -1;
                    
                    for (int k = i; k <= j - 1; k++)
                    {
                        qMin = 0;
                        qMax = 0;

                        if (op[k] == "+")
                        {
                            qMin = Rmin[i, k] + Rmin[k + 1, j];
                            qMax = Rmax[i, k] + Rmax[k + 1, j];
                        }
                        else if (op[k] == "*")
                        {
                            qMin = Rmin[i, k] * Rmin[k + 1, j];
                            qMax = Rmax[i, k] * Rmax[k + 1, j];
                        }
                        else if (op[k] == "^")
                        {
                            qMin = Math.Pow(Rmin[i, k],Rmin[k + 1, j]);
                            qMax = Math.Pow(Rmax[i, k],Rmax[k + 1, j]);
                        }
                        
                        if (qMin < Rmin[i, j])
                        {
                            Rmin[i, j] = qMin;
                            smin[i, j] = k;
                        }
                        if (qMax > Rmax[i, j])
                        {
                            Rmax[i, j] = qMax;
                            smax[i, j] = k;
                        }
                    }
                }
            }
            double menor = Rmin[0, n-1];
            double maior = Rmax[0, n - 1];

            imprimeParenteses(Rmin, smin, op, 0, n - 1);
            imprimeParenteses(Rmax, smax, op, 0, n - 1);

            int fim = 0;
        }
        //questao 4
        internal static void parentesesMaior(double[] x, string[] op)
        {
            int n = x.Length;

            double[,] Rmin = new double[n, n];
            double[,] Rmax = new double[n, n];

            int[,] smin = new int[n, n];
            int[,] smax = new int[n, n];

            //se i=j, recebe x[i]
            for (int i = 0; i < n; i++)
            {
                Rmin[i, i] = x[i];
                Rmax[i, i] = x[i];
            }

            for (int i = 0; i < n; i++)
            {
                for (int y = 0; y < n; y++)
                {
                    smin[i, y] = -1;
                    smax[i, y] = -1;
                }
            }

            int j = 0;
            double qMax = 0;
            double qMin = 0;
            for (int L = 1; L < n; L++) //para L = 2 até n
            {
                for (int i = 0; i < n - L; i++) //para i = 1 até n-L+1
                {
                    j = i + L; //j = i + L - 1;
                    Rmin[i, j] = double.PositiveInfinity;
                    Rmax[i, j] = -1;

                    for (int k = i; k <= j - 1; k++)
                    {
                        qMin = 0;
                        qMax = 0;

                        if (op[k] == "+")
                        {
                            qMin = Rmin[i, k] + Rmin[k + 1, j];
                            qMax = Rmax[i, k] + Rmax[k + 1, j];
                        }
                        else if (op[k] == "*")
                        {
                            qMin = Rmin[i, k] * Rmin[k + 1, j];
                            qMax = Rmax[i, k] * Rmax[k + 1, j];
                        }
                        else if (op[k] == "^")
                        {
                            qMin = Math.Pow(Rmin[i, k], Rmin[k + 1, j]);
                            qMax = Math.Pow(Rmax[i, k], Rmax[k + 1, j]);
                        }
                        else if (op[k] == "-")
                        {
                            qMin = Rmin[i, k] - Rmin[k + 1, j];
                            qMax = Rmax[i, k] - Rmax[k + 1, j];
                        }
                        else if (op[k] == ":")
                        {
                            //previne div por zero
                            if (Rmin[k + 1, j] != 0)
                                qMin = Rmin[i, k] / Rmin[k + 1, j];
                            if (Rmax[k + 1, j] != 0)
                                qMax = Rmax[i, k] / Rmax[k + 1, j];
                        }

                        if (qMin < Rmin[i, j])
                        {
                            Rmin[i, j] = qMin;
                            smin[i, j] = k;
                        }
                        if (qMax > Rmax[i, j])
                        {
                            Rmax[i, j] = qMax;
                            smax[i, j] = k;
                        }
                    }
                }
            }
            double menor = Rmin[0, n - 1];
            double maior = Rmax[0, n - 1];

            imprimeParenteses(Rmin, smin, op, 0, n - 1);
            imprimeParenteses(Rmax, smax, op, 0, n - 1);

            int fim = 0;
        }
        internal static void imprimeParenteses(double[,] R, int[,] s, string[] op, int i, int j)
        {
            if (i == j)
            {
                Console.Write(R[i, j].ToString());
                if (i < op.Length)
                    Console.Write(op[i]);
            }
            else
            {
                Console.Write("(");
                imprimeParenteses(R, s, op, i, s[i, j]);
                imprimeParenteses(R, s, op, s[i, j] + 1, j);
                Console.Write(")");
            }
        }
        
        //questao 5: ok
        internal static int soma(int[] P, int t)
        {
            int n = P.Length;
            int[,] S = new int[n + 1, t + 1];

            for (int i = 0; i <= n; i++)
                S[i, 0] = 1;

            for (int b = 1; b <= t; b++)
            {
                S[0, b] = 0;

                for (int i = 1; i <= n; i++)
                {
                    int v = S[i - 1, b];
                    if ((v == 0) && (P[i-1] <= b))
                        v = S[i - 1, b - P[i-1]];
                    S[i, b] = v;
                }
            }
            return S[n, t];
        }
        
        //questao 6
        internal static int balsa(int[] t, int L, int n)
        {
            int[, ,] m = new int[n + 1, L + 1, L + 1];
            int[, ,] s = new int[n + 1, L + 1, L + 1];
            int ta = 0;
            int tb = 0;

            for (int k = n - 1; k >= 0; k--)
            {
                for (int a = 0; a <= L; a++)
                {
                    for (int b = 0; b <= L; b++)
                    {
                        ta = 0;
                        tb = 0;

                        m[k, a, b] = 0;
                        s[k, a, b] = 0;

                        int indA = a - t[k];
                        if (indA < 0) indA = 0;
                        int indB = b - t[k];
                        if (indB < 0) indB = 0;

                        if (t[k] <= a) //se cabe em a
                            ta = m[k + 1, indA, b] + 1;

                        if (t[k] <= b) //se cabe em b
                            tb = m[k + 1, a, indB] + 1;

                        if (ta + tb > 0) //se cabe em um dos 2, pega o max
                        {
                            if (ta >= tb)
                            {
                                m[k, a, b] = ta;
                                s[k, a, b] = 1;// "A";
                            }
                            else
                            {
                                m[k, a, b] = tb;
                                s[k, a, b] = 2;// "B";
                            }
                        }
                    }
                }
            }
            int total = m[0, L, L];
            imprimeCarros(t, L, n, s);

            return total;
        }
        internal static void imprimeCarros(int[] t, int L, int n, int[, ,] S)
        {
            int p1 = L;
            int p2 = L;
            for (int k = n; k >= 0; k--)
            {
                int p = S[k, p1, p2];
                if (p > 0)
                {
                    Console.Write("Carro " + k + " na pista " + p + ".\n");
                    if (p == 1)
                        p1 = p1 - t[k]; //atualiza tamanho da pista 1 -> subtrai tam do carro k
                    else
                        p2 = p2 - t[k]; //atualiza tamanho da pista 2 -> subtrai tam do carro k
                }
            }
        }

                
    }
}