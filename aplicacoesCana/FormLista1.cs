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
    public partial class FormLista1 : Form
    {
        public FormLista1()
        {
            InitializeComponent();
        }
        
       
        //questão 7: existe soma (sem usar recursao)
        private void button5_Click(object sender, EventArgs e)
        {
            int[] A = { 2, 4, 1, 6, 5, 0, 9, 6, 7, 3, 1, 6 };
            int soma = 16;

            
            bool existe = Lista1.existeSoma(A,soma);

            txtRes.Text = existe.ToString();
        }

        //questão 8: decompoe vetores (sem usar recursao)
        private void button1_Click(object sender, EventArgs e)
        {
            int[] S = { 2, 4, 3, 3, 4, 5, 1, 9, 2, 5, 7 };
            int pivo = 4;
            int q1 = 0, q2 = S.Length - 1;

            int[] V = Lista1.DecompoeVetor(S, 0, S.Length - 1, pivo, ref q1, ref q2);

            string temp = "";
        }

        //questão 9: majoritario
        private void button1_Click_1(object sender, EventArgs e)
        {
            //2 é o majoritário
            //object[] A = { 2, "azul", 2, 6, 2, 2, "salada", 6, 2, 2, 8, 2 };

            //azul é o majoritário
            object[] A = { "azul", 3, "azul", "salada", "azul", "azul", 3, 6, "azul", "azul", 8, "azul" };

            //nenhum majoritário
            //object[] A = { "azul", 3, "salada", 1, 0 };

            object res = Lista1.Majoritario(A, 0, A.Length - 1);

            if (res != null)
                txtRes.Text = res.ToString();
            else
                txtRes.Text = "nenhum";
        }

        //questão 10: mediana de 2 vetores
        private void button7_Click(object sender, EventArgs e)
        {            
            //int[] A = { 1, 4, 5, 6, 8, 9 };
            //int[] B = { 2, 7, 0, 1, 3, 7 };

            int[] A = { 1, 2, 3, 4, 5, 6 };
            int[] B = { 8, 7, 9, 9, 8, 7 };

            Sort.MergeSort(ref A, 0, A.Length - 1);
            Sort.MergeSort(ref B, 0, B.Length - 1);

            int res = Lista1.Mediana(A, B, 0, A.Length - 1, 0, B.Length - 1);

            //vetor concatenado para comparar
            int[] vetConcat = A.Concat(B).ToArray();
            Sort.MergeSort(ref vetConcat, 0, vetConcat.Length - 1);

            txtRes.Text = res.ToString();
        }

        //questão 11: k-ésimo elemento de 2 vetores
        private void button6_Click(object sender, EventArgs e)
        {
            //int[] A = { 2, 4, 7, 8 };
            //int[] B = { 2, 4, 1, 6, 9, 6, 0 };
            //int k = 5;
            
            //int[] A = { 1, 4, 5, 6 };
            //int[] B = { 2, 8, 9 };
            //int k = 5;

            int[] A = { 2, 4, 7, 8, 11, 10 };
            int[] B = { 3, 4, 1, 6, 9, 6, 0 };
            int k = 9;

            Sort.MergeSort(ref A, 0, A.Length - 1);
            Sort.MergeSort(ref B, 0, B.Length - 1);
                        
            //k-1 pq é base 0
            int? res = Lista1.KEsimo(A, B, k-1);

            //vetor concatenado para comparar
            int[] vetConcat = A.Concat(B).ToArray();
            Sort.MergeSort(ref vetConcat, 0, vetConcat.Length - 1);

            txtRes.Text = res.ToString();
        }

        //questão 12: contar inversões
        private void button8_Click(object sender, EventArgs e)
        {
            int[] A = { 22, 33, 55, 77, 99, 11, 44, 66, 88 }; //num inv = 11
            
            int c = Lista1.ContaInversoes(A, 0, A.Length - 1);

            txtRes.Text = c.ToString();
        }

        //questoes de outras listas

        //heap mínimo
        private void button2_Click(object sender, EventArgs e)
        {
            int[] A = { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            Lista1Anteriores.HeapMinimo(ref A);

            string temp = "";
        }

        //elemento popular
        private void button13_Click(object sender, EventArgs e)
        {
            //2 é 1o popular
            object[] A = { 2, "azul", 2, 6, 2, 0, "salada", 6, 1, 2 };

            //azul é 1o popular
            //object[] A = { "azul", 3, "azul", "salada", "azul", 7, 3, 6, "azul", 0, 8, "azul" };

            //nenhum popular
            //object[] A = { "azul", 3, "salada", 1, 0 };

            //testes do hoog
            //object[] A = { 1, 2, 1, 2, 1, 2, 3 }; // 1 ou 2 
            //object[] A = { 1,2,3,1,2,3,1,2,3,2 }; //2

            object res = Lista1Anteriores.Popular(A, 0, A.Length - 1);

            if (res != null)
                txtRes.Text = res.ToString();
            else
                txtRes.Text = "nenhum";
        }
                
                
    }
}
