using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura2.ConsoleApp.ModuloRevistas
{
    public class TelaRevista
    {
        RepositorioRevista repositorioRevista;
        RepositorioCaixa repositorioCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;

        }


        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerenciador de Revistas");
            Console.WriteLine();
            Console.WriteLine("----------------------------");

        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Revistas");
            Console.WriteLine("2 - Editar Revistas");
            Console.WriteLine("3 - Excluir Revistas");
            Console.WriteLine("4 - Visualizar Revistas");


            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }

        public void CadastrarCaixa()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Cadastrando Caixa");
            Console.WriteLine("----------------------------");


            Console.WriteLine();
            Revista novaRevista = ObterDadosRevista();

            repositorioRevista.CadastrarRevista(novaRevista);
        }

        public void EditarRevista()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Revista");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRevista(true);

            Console.WriteLine("Digite o ID da Revista que deseja selecionar");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Revista revistaEditada = ObterDadosRevista();

            bool conseguiuEditar = repositorioRevista.EditarRevista(idRevista, revistaEditada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do registro...");
            }
            Console.WriteLine("O registo foi editado com sucesso");

        }
        public void ExcluirRevista()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Revista");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRevista(true);

            Console.WriteLine("Digite o ID da revista que deseja selecionar");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool conseguiuExcluir = repositorioRevista.ExcluirRevista(idRevista);


            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusao do registro...");
            }
            Console.WriteLine("O registo foi excluido com sucesso");

        }

        public void VisualizarRevista(bool exibirTitulo)
        {
            if (exibirTitulo)
                ExibirCabecalho();

            Console.WriteLine("Visualizando Revistas");
            Console.WriteLine("----------------------");

            Console.WriteLine();


            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -10} ",
            "Id", "Titulo", "Numero da Edição", "Data da publicação"
                );

            Revista[] revistasCadastradas = repositorioRevista.SelecionarRevista();

            for (int i = 0; i < revistasCadastradas.Length; i++)
            {
                Revista r = revistasCadastradas[i];

                if (r == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                    r.Id, r.Titulo, r.NumeroEdicao, r.DataPublicacao
                    );


            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar", ConsoleColor.DarkYellow);
        }

        public Revista ObterDadosRevista()
        {
            Console.WriteLine("Digite o Titulo da Revista");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o numero da edição da revista");
            string edicaoRevista = Console.ReadLine();

            Console.WriteLine("Digite a data da publicação da revista");
            DateTime dataPublicacao = Convert.ToDateTime(Console.ReadLine());

            Revista revista = new Revista(titulo, edicaoRevista, dataPublicacao);

            return revista;
        }
    }
}
