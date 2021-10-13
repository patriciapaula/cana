using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplicacoesCana
{
    public partial class FormLista2 : Form
    {
        public FormLista2()
        {
            InitializeComponent();
        }

        // --- lista:

        //lista - quadrado ou cubo perfeito
        private void button1_Click(object sender, EventArgs e)
        {
            string S = "125271448164";
            bool res = Lista2.quebraNums_outra(S);
            bool res2 = Lista2.quebraNums(S);

            S = "161";
            res = Lista2.quebraNums_outra(S);
            res2 = Lista2.quebraNums(S);

            S = "125481";
            res = Lista2.quebraNums_outra(S);
            res2 = Lista2.quebraNums(S);

            string temp = "";
        }

        //lista - soma de subconjuntos
        private void button5_Click(object sender, EventArgs e)
        {
            int t = 5;
            int[] S = { 4, 2, 1, 3 }; //tem

            /*
            int t=14;
            int[] S = { 1,3,8 }; //nao tem
            */
            
            int q = Lista2.soma(S, t);

            string temp = "";
        }

        //lista - parenteses com as operacoes
        private void button4_Click(object sender, EventArgs e)
        {
            //double[] x = { 0.3,1,4,0.7,0.2 };
            //string[] op = { "+","*","+","*" };

            double[] x = { 2,4,5,3 };
            string[] op = { "*", "+", "^" };

            Lista2.parenteses(x,op);

            string temp = "";
        }

        //lista - parenteses com as operacoes (2)
        private void button6_Click(object sender, EventArgs e)
        {
            //double[] x = { 0.3,1,4,0.7,0.2 };
            //string[] op = { "+","*","+","*" };

            double[] x = { 2, 4, 5, 3, 2, 400 };
            string[] op = { "*", "+", "^", ":", "-" };

            Lista2.parentesesMaior(x, op);

            string temp = "";
        }

        //lista - balsa: ok
        private void button3_Click(object sender, EventArgs e)
        {
            int L = 3;
            int[] t = {1,2,1};
            int n = t.Length;

            int res1 = Lista2.balsa(t, L, n);
            
            string temp = "";
        }

        // --- questoes vistas em sala:

        //Linha de montagem: ok
        private void button10_Click(object sender, EventArgs e)
        {
            int n=6;
            int[] ent = {2,4};
            int[] saida = {3,2};

            int[,] a = new int[2,6];
            int[,] t = new int[2,5];

            a[0, 0] = 7;
            a[0, 1] = 9;
            a[0, 2] = 3;
            a[0, 3] = 4;
            a[0, 4] = 8;
            a[0, 5] = 4;

            a[1, 0] = 8;
            a[1, 1] = 5;
            a[1, 2] = 6;
            a[1, 3] = 4;
            a[1, 4] = 5;
            a[1, 5] = 7;
            
            t[0, 0] = 2;
            t[0, 1] = 3;
            t[0, 2] = 1;
            t[0, 3] = 3;
            t[0, 4] = 4;
            
            t[1, 0] = 2;
            t[1, 1] = 1;
            t[1, 2] = 2;
            t[1, 3] = 2;
            t[1, 4] = 1;

            PD_LinhaMontagem.linhaMontagem2(a, t, ent, saida, n);

            string temp = "";

        }

        //LCS: ok
        private void button8_Click(object sender, EventArgs e)
        {
            string x = "ACCGGTCGAGTGCGCGGAAGCCGGCCGAA";
            string y = "GTCGTTCGGAATGCCGTTGCTCTGTAAA";

            int res = PD_LCS.lcs(x, y);

            string temp = "";
        }

        //mult cadeia de matrizes: ok
        private void button2_Click(object sender, EventArgs e)
        {
            int[] P = { 30,35,15,5,10,20,25 }; 

            //int[] P = { 50,20,1,10,100 }; //ok

            int res = PD_MultiplicacaoMatrizes.multm(P);

            string temp = "";
        }

        //menor caminho: ok
        private void button11_Click(object sender, EventArgs e)
        {
            int[,] w = new int[5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    w[i, j] = 100000000; // infinito;

            w[0, 1] = 3;
            w[2, 1] = 4;
            w[3, 2] = -5;
            w[4, 3] = 6;
            w[0, 4] = -4;
            w[0, 2] = 8;
            w[2, 4] = 7;
            w[1, 3] = 1;
            w[3, 0] = 2;

            int[,] res = PD_MenorCaminho.FloydWarshal(w, 5, 1,0);
                        
        }

        // --- questoes de prova antiga 1:

        //1 linha de montagem: ok
        private void button9_Click(object sender, EventArgs e)
        {
            int n=3;
            int[] ent = {2,4,3};
            int[] saida = {3,2,3};

            int[,] a = new int[4,4];
            int[,,] t = new int[4,4,3];

            a[0,0]=7;
            a[0,1]=9;
            a[0,2]=3;
            a[1,0]=3;
            a[1,1]=5;
            a[1,2]=7;
            a[2,0]=9;
            a[2,1]=1;
            a[2,2]=8;

            t[0, 1, 0] = 4;
            t[0, 1, 1] = 3;
            t[0, 2, 0] = 3;
            t[0, 2, 1] = 2;
            t[1, 0, 0] = 1;
            t[1, 0, 1] = 4;
            t[1, 2, 0] = 2;
            t[1, 2, 1] = 3;
            t[2, 0, 0] = 1;
            t[2, 0, 1] = 2; 
            t[2, 1, 0] = 3;
            t[2, 1, 1] = 2;            

            Prova2_2010.linhaMontagem3(a, t, ent, saida, n);

            string temp = "";
        }

        //2 viagem
        private void button12_Click(object sender, EventArgs e)
        {
            //o 0 é o marco inicial, não é hotel; hotel começa no 1

            //km dos hoteis: a
            //preco das diarias: p

            int[] a = { 0, 300, 500, 750, 1200 };
            int[] p = { 0, 400, 700, 800, 500 };

            //int[] a = { 0, 404, 800, 900, 1200 };
            //int[] p = { 0, 500, 400, 700, 500 }; 

            int[] hoteis = Prova2_2010.GastoViagem(a, p);
        }

        //3 grafo: + -
        private void button7_Click(object sender, EventArgs e)
        {
            int n = 0;
            int res = 0;
                        
            //soma:29
            n = 5;
            int[,] p1 = new int[n, n];
            p1[0, 1] = 3;
            p1[0, 2] = 8;
            p1[0, 3] = 2;
            p1[0, 4] = 4;
            p1[1, 0] = 3;
            p1[1, 2] = 4;
            p1[1, 3] = 1;
            p1[1, 4] = 7;
            p1[2, 0] = 8;
            p1[2, 1] = 4;
            p1[2, 3] = 5;
            p1[2, 4] = 0;
            p1[3, 0] = 2;
            p1[3, 1] = 1;
            p1[3, 2] = 5;
            p1[3, 4] = 6;
            p1[4, 0] = 4;
            p1[4, 1] = 7;
            p1[4, 2] = 0;
            p1[4, 3] = 6;
            res = Prova2_2010.Grafo(p1, n);

            //soma:48
            n = 5;
            int[,] p2 = new int[n, n];
            p2[0, 1] = 6;
            p2[0, 2] = 4;
            p2[0, 3] = 9;
            p2[0, 4] = 10;
            p2[1, 0] = 6;
            p2[1, 2] = 2;
            p2[1, 3] = 11;
            p2[1, 4] = 8;
            p2[2, 0] = 4;
            p2[2, 1] = 2;
            p2[2, 3] = 15;
            p2[2, 4] = 0;
            p2[3, 0] = 9;
            p2[3, 1] = 11;
            p2[3, 2] = 15;
            p2[3, 4] = 6;
            p2[4, 0] = 10;
            p2[4, 1] = 8;
            p2[4, 2] = 0;
            p2[4, 3] = 6;
            res = Prova2_2010.Grafo(p2, n);
            
            //soma: 12
            n = 4;
            int[,] p3 = new int[n, n];
            p3[0, 1] = 2;
            p3[0, 2] = 6;
            p3[0, 3] = 3;
            p3[1, 0] = 2;
            p3[1, 2] = 5;
            p3[1, 3] = 0;
            p3[2, 0] = 6;
            p3[2, 1] = 5;
            p3[2, 3] = 4;
            p3[3, 0] = 3;
            p3[3, 1] = 0;
            p3[3, 2] = 4;
            res = Prova2_2010.Grafo(p3, n);

            string temp = "";
        }

        //4 quimica
        private void button13_Click(object sender, EventArgs e)
        {

        }

        // --- questoes de prova antiga 1:

        //1 soma T
        private void button14_Click(object sender, EventArgs e)
        {
            int n = 6;
            string[] s = new string[n];

            s[0]="1492";
            s[1]="22";
            s[2]="45919";
            s[3]="2";
            s[4]="57";
            s[5]="3021";

            int res = Prova2_2012.concatenar(s, n);

            string temp = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int[] v = { 1,4,9,2,5,3 };
            int soma = 7;

            bool res = Prova2_2012.soma(v, soma);

            string temp = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string x = "deovoara";
            string y = "labalovo";

            Prova2_2012.palindromo(x, y);

            string temp = "";
        }
                        
    }
}
