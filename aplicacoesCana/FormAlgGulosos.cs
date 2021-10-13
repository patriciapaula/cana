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
    public partial class FormAlgGulosos : Form
    {
        public FormAlgGulosos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //As atividades de entrada estao organizadas
            //em ordem monotonicamente crescente de tempo final
            int[] S = { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
            int[] F = { 4, 5, 6, 7, 9, 9, 10, 11, 12, 14, 16 };

            int[] res = AlgoritmosGulosos.SelecaoIterativaAtiv(S,F);

            string temp = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //as tarefas estao ordenadas em ordem decrescente de multa
            int[] S = { 7, 6, 5, 4, 3, 2, 1 };
            int[] P = { 4, 2, 4, 3, 1, 4, 6 };
            int[] M = { 70, 60, 50, 40, 30, 20, 10 };
            int multa = 0;

            int[] res = AlgoritmosGulosos.ProgramacaoAtividades(S, P, M, ref multa);

            string temp = "";
        }

    }
}
