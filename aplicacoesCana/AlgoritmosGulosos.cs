using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacoesCana
{
    class AlgoritmosGulosos
    {

        /// <summary>
        /// Seleciona um conjunto de atividades, de tamanho máx, mutuamente compatíveis
        /// Considera q as atividades de entrada estao organizadas em 
        /// ordem monotonicamente crescente de tempo final
        /// Tempo de ordenacao: teta(nlogn)
        /// </summary>
        /// <param name="S">Prazos iniciais das tarefas</param>
        /// <param name="F">Prazos finais das tarefas</param>
        /// <returns>Atividades selecionadas</returns>
        internal static int[] SelecaoIterativaAtiv(int[] S, int[] F)
        {
            int n = S.Length;
            int k = 0;  //indice do elem mais recente adicionado a A

            int[] A = new int[n]; //guarda atividades selecionadas

            for (int i = 0; i < n; i++) //iniciando com -1 para facilitar
                A[i] = -1;

            A[0] = S[0];

            int ind=1; //indice do prox elem a ser adicionado

            for (int m = 1; m < n; m++)
            {
                if (S[m] >= F[k])
                {
                    A[ind] = S[m];
                    k = m;  //m foi o ultimo elem adicionado
                    ind++;
                }
            }
            return A;
        }

        /// <summary>
        /// Seleciona a ordem de execução das tarefas de forma a ter a multa minimizada
        /// Considera q as tarefas estao organizadas em ordem decrescente de multa
        /// </summary>
        /// <param name="S">Tarefas de tempo unitário</param>
        /// <param name="P">Prazos das tarefas</param>
        /// <param name="M">Multas das tarefas</param>
        /// <returns>Tarefas em ordem de execução</returns>
        internal static int[] ProgramacaoAtividades(int[] S, int[] P, int[] M, ref int multa)
        {
            int n = S.Length;
            int[] tarefas = new int[n]; //guarda a ordem de exec
            bool[] slot = new bool[n]; //guarda se o local esta ocupado com uma tarefa
            int[] ordem = new int[n];

            for (int i = 0; i < n; i++) { 
                for (int j = P[i]-1; j >= 0; j--) { 
                    if (!slot[j]) { 
                        slot[j]= true; 
                        tarefas[j] = S[i]; 
                        j=-1; 
                    } 
                } 
            }

            //remove tarefas com 0 e adiciona tarefas não selecionadas ao final
            int ind=0;
            for (int i = 0; i < n; i++)
            {
                if (tarefas[i]!=0)
                {
                    ordem[ind] = tarefas[i];
                    ind++;
                }
            }            
            for (int i = 0; i < n; i++)
            {
                bool esta = false;
                for (int j = 0; j < n; j++)
                {
                    if (S[i] == tarefas[j])
                    {
                        esta = true;
                        j = n;
                    }
                }
                if (!esta)
                {
                    multa += M[i];
                    ordem[ind] = S[i];
                    ind++;
                }
            }

            return ordem;
        }

    }
}
