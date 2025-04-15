using ClubeDaLeitura2.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura2.ConsoleApp.ModuloCaixas
{
    public class RepositorioCaixa
    {
        public Caixa[] caixas = new Caixa[100];
        public int contadorCaixa = 0;

        public Caixa[] SelecionarCaixa()
        {
            return caixas;
        }

        public void CadastrarCaixa(Caixa novaCaixa)
        {
            novaCaixa.Id = GeradorDeId.GerarIdCaixa();
            caixas[contadorCaixa++] = novaCaixa;

        }

        public bool EditarCaixa(int idCaixa, Caixa caixaEditada)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null) continue;

                else if (caixas[i].Id == idCaixa)
                {
                    caixas[i].Etiqueta = caixaEditada.Etiqueta;
                    caixas[i].Cor = caixaEditada.Cor;
                    caixas[i].DiasDeEmprestimo = caixaEditada.DiasDeEmprestimo;


                    return true;
                }
            }
            return false;

        }

        public bool ExcluirCaixa(int idCaixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null) continue;

                else if (caixas[i].Id == idCaixa)
                {
                    caixas[i] = null;
                    return true;
                }
            }
            return false;
        }

    }
}
