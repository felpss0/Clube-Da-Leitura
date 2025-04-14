namespace ClubeDaLeitura2.ConsoleApp.ModuloRevistas
{
    public class RepositorioRevista
    {
        public Revista[] revistas = new Revista[100];
        public int contadorRevista = 0;

        public Revista[] SelecionarRevista()
        {
            return revistas;
        }

        public Revista SelecionarPorId(int id)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].Id == id)
                {
                    return revistas[i];
                }
            }

            return null;
        }




        public void CadastrarRevista(Revista novaRevista)
        {
            novaRevista.Id = GeradorDeId.GerarIdCaixa();
            revistas[contadorRevista++] = novaRevista;
        }

        public bool EditarRevista(int idRevista, Revista revistaEditada)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null) continue;

                else if (revistas[i].Id == idRevista)
                {
                    revistas[i].Titulo = revistaEditada.Titulo;
                    revistas[i].NumeroEdicao = revistaEditada.NumeroEdicao;
                    revistas[i].DataPublicacao = revistaEditada.DataPublicacao;


                    return true;
                }
            }
            return false;
        }

        public bool ExcluirRevista(int idRevista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null) continue;

                else if (revistas[i].Id == idRevista)
                {
                    revistas[i] = null;
                    return true;
                }
            }
            return false;
        }

    }
}
