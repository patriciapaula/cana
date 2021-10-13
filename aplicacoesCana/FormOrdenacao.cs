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
    public partial class FormOrdenacao : Form
    {
        public FormOrdenacao()
        {
            InitializeComponent();
        }

        //insertionsort
        private void button10_Click(object sender, EventArgs e)
        {
            int[] A = { 2, 5, 1, 8, 11, 10 };
            int[] B = { 3, 4, 1, 6, 9, 6, 0 };

            int[] res = Sort.InsertionSort(A, A.Length - 1);
            int[] res2 = Sort.InsertionSort(B, B.Length - 1);

            string temp = "";
        }

        //mergesort
        private void button9_Click(object sender, EventArgs e)
        {
            int[] A = { 2, 5, 1, 8, 11, 10 };
            int[] B = { 3, 4, 1, 6, 9, 6, 0 };

            Sort.MergeSort(ref A, 0, A.Length - 1);
            Sort.MergeSort(ref B, 0, B.Length - 1);

            string temp = "";
        }

        //quicksort
        private void button4_Click(object sender, EventArgs e)
        {
            int[] A = { 2, 4, 1, 6, 5, 0, 9, 6, 7, 0, 1, 6 };
            int[] B = { 3, 4, 1, 6, 9, 6, 0 };

            Sort.QuickSort(ref A, 0, A.Length - 1);
            Sort.QuickSort(ref B, 0, B.Length - 1);

            string temp = "";
        }

        //heapsort
        private void button11_Click(object sender, EventArgs e)
        {
            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Sort.HeapSort(ref A);

            string temp = "";
        }

        //counting sort
        private void button12_Click(object sender, EventArgs e)
        {
            int[] A = { 2, 4, 1, 6, 5, 0, 9, 6, 7, 0, 1, 6 };
            int[] B = new int[A.Length];

            int[] C = Sort.CountingSort(A, ref B, A.Max());

            string temp = "";
        }


    }
}
