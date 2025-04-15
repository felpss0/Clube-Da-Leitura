using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo
    {
        Emprestimo[] emprestimos = new Emprestimo[100];
        public int contadorEmprestimo = 0;

        public Emprestimo[] SelecionarEmprestimo()
        {
            return emprestimos;
        }

        //public Emprestimo DataDevolucao(TimeSpan diferenca)
        //{
        //    if (diferenca.TotalDays > 3)
        //    {
        //        double multaPorDia = 2.00; // valor da multa por dia de atraso
        //        int diasDeAtraso = (int)(diferenca.TotalDays - 3);
        //        double valorMulta = diasDeAtraso * multaPorDia;

        //        Console.WriteLine($"Livro devolvido com {diasDeAtraso} dia(s) de atraso.");
        //        Console.WriteLine($"Valor da multa: R$ {valorMulta:F2}");
        //    }
        //    else
        //        Console.WriteLine("Livro devolvido no prazo. Sem multa.");
            


        //    return null;
        //}

        public void CadastrarEmprestimo(Emprestimo novoEmprestimo)
        {
            novoEmprestimo.Id = GeradorDeId.GerarIdEmprestimo();
            emprestimos[contadorEmprestimo++] = novoEmprestimo;
        }


        public bool EditarEmprestimo(int idEmprestimo, Emprestimo emprestimoEditado)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null) continue;

                else if (emprestimos[i].Id == idEmprestimo)
                {
                    emprestimos[i].Amigo = emprestimoEditado.Amigo;
                    emprestimos[i].Revista = emprestimoEditado.Revista;
                    emprestimos[i].DataEmprestimo = emprestimoEditado.DataEmprestimo;
                    emprestimos[i].DataDevolucao = emprestimoEditado.DataDevolucao;
                    emprestimos[i].SituacaoEmprestimo = emprestimoEditado.SituacaoEmprestimo;



                    return true;
                }
            }
            return false;
        }

        public bool ExcluirEmprestimo(int idEmprestimo)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null) continue;

                else if (emprestimos[i].Id == idEmprestimo)
                {
                    emprestimos[i] = null;
                    return true;
                }
            }
            return false;
        }

    }
}
