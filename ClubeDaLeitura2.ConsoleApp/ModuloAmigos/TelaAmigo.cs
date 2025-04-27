using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.Util;
using System.Collections;

namespace ClubeDaLeitura2.ConsoleApp.ModuloAmigos
{
    public class TelaAmigo : TelaBase
    {

        public RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo) : base ("Amigo", repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }
       

        public override char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Amigo");
            Console.WriteLine("2 - Editar Amigo");
            Console.WriteLine("3 - Excluir Amigo");
            Console.WriteLine("4 - Visualizar Amigo");
            Console.WriteLine("5 - Visualizar Empréstimo do Amigo");


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
            Console.WriteLine("Cadastrando Amigo");
            Console.WriteLine("----------------------------");


            Console.WriteLine();

            Amigo novoAmigo = (Amigo)ObterDados();

            repositorioAmigo.CadastrarRegistro(novoAmigo);
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Amigo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID do amigo que deseja selecionar");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Amigo amigoEditado = (Amigo)ObterDados();

            bool conseguiuEditar = repositorioAmigo.EditarRegistro(idAmigo, amigoEditado);

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
            Console.WriteLine("Editando Amigo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID do amigo que deseja selecionar");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            bool conseguiuExcluir = repositorioAmigo.ExcluirRegistro(idAmigo);


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

            Console.WriteLine("Visualizando Amigos");
            Console.WriteLine("----------------------");

            Console.WriteLine();


            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                "Id", "Nome Amigo", "Nome Responsavel", "Telefone"
                );

            ArrayList registros = repositorioAmigo.SelecionarRegistros();

            foreach (Amigo a in registros)
            {
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                    a.Id, a.Nome, a.Responsavel, a.Telefone
                    );


            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }


        public override EntidadeBase ObterDados()
        {
            Console.WriteLine("Digite o nome do Amigo");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do Responsavel");
            string responsavel = Console.ReadLine();

            Console.WriteLine("Digite o telefone do Amigo");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo(nome, responsavel, telefone);

            return amigo;
        }

        
    }
}
