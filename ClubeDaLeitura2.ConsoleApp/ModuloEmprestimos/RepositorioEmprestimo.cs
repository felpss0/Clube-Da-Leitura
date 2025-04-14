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
