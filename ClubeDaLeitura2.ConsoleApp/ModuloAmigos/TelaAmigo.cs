namespace ClubeDaLeitura2.ConsoleApp.ModuloAmigos
{
    public class TelaAmigo
    {

        public RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }
        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerenciador de Amigos");
            Console.WriteLine();
            Console.WriteLine("----------------------------");

        }

        public char ApresentarMenu()
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

        public void CadastrarAmigo()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Cadastrando Amigo");
            Console.WriteLine("----------------------------");


            Console.WriteLine();

            Amigo novoAmigo = ObterDadosAmigo();

            repositorioAmigo.CadastrarAmigo(novoAmigo);
        }

        public void EditarAmigo()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Amigo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarAmigo(true);

            Console.WriteLine("Digite o ID do amigo que deseja selecionar");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Amigo amigoEditado = ObterDadosAmigo();

            bool conseguiuEditar = repositorioAmigo.EditarAmigo(idAmigo, amigoEditado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do registro...");
            }
            Console.WriteLine("O registo foi editado com sucesso");

        }
        public void ExcluirAmigo()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Amigo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarAmigo(true);

            Console.WriteLine("Digite o ID do amigo que deseja selecionar");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            bool conseguiuExcluir = repositorioAmigo.ExcluirAmigo(idAmigo);


            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusao do registro...");
            }
            Console.WriteLine("O registo foi excluido com sucesso");

        }

        public void VisualizarAmigo(bool exibirTitulo)
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

            Amigo[] amigosCadastrados = repositorioAmigo.SelecionarAmigo();

            for (int i = 0; i < amigosCadastrados.Length; i++)
            {
                Amigo a = amigosCadastrados[i];

                if (a == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                    a.Id, a.Nome, a.Responsavel, a.Telefone
                    );


            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
        }


        public Amigo ObterDadosAmigo()
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
