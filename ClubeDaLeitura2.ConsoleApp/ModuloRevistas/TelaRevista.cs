using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura2.ConsoleApp.Util;
using System.Collections;

namespace ClubeDaLeitura2.ConsoleApp.ModuloRevistas
{
    public class TelaRevista : TelaBase
    {
        public RepositorioRevista repositorioRevista;
        public RepositorioCaixa repositorioCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base ("Revista", repositorioRevista)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;

        }


        public override char ApresentarMenu()
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

        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Cadastrando Caixa");
            Console.WriteLine("----------------------------");


            Console.WriteLine();
            Revista novaRevista = (Revista)ObterDados();

            repositorioRevista.CadastrarRegistro(novaRevista);
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Revista");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID da Revista que deseja selecionar");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Revista revistaEditada = (Revista)ObterDados();

            bool conseguiuEditar = repositorioRevista.EditarRegistro(idRevista, revistaEditada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do registro...");
            }
            Console.WriteLine("O registo foi editado com sucesso");

        }
        public override void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Revista");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID da revista que deseja selecionar");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool conseguiuExcluir = repositorioRevista.ExcluirRegistro(idRevista);


            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusao do registro...");
            }
            Console.WriteLine("O registo foi excluido com sucesso");

        }

        public override void VisualizarRegistros(bool exibirTitulo)
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

            ArrayList registros = repositorioRevista.SelecionarRegistros();

            foreach (Revista r in registros)
            {
                
                    Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                    r.Id, r.Titulo, r.NumeroEdicao, r.DataPublicacao
                    );

            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar", ConsoleColor.DarkYellow); ;
        }

        public override EntidadeBase ObterDados()
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
