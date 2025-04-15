using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo
    {
        RepositorioEmprestimo repositorioEmprestimo;
        RepositorioAmigo repositorioAmigo;
        RepositorioRevista repositorioRevista;
        TelaAmigo telaAmigo;
        TelaRevista telaRevista;

        public TelaEmprestimo(
            RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista,
            TelaAmigo telaAmigo, TelaRevista telaRevista
            )
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
            this.telaAmigo = telaAmigo;
            this.telaRevista = telaRevista;
        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerenciador de Emprestimos");
            Console.WriteLine();
            Console.WriteLine("----------------------------");

        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Emprestimos");
            Console.WriteLine("2 - Editar Emprestimos");
            Console.WriteLine("3 - Excluir Emprestimos");
            Console.WriteLine("4 - Visualizar Emprestimos");
            Console.WriteLine("5 - Visualizar Revistas");
            Console.WriteLine("6 - Visualizar Amigos");
            Console.WriteLine("7 - Registrar Devolução");


            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }

        public void CadastrarEmprestimo()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Cadastrando Emprestimo");
            Console.WriteLine("----------------------------");


            Console.WriteLine();
            Emprestimo novoEmprestimo = ObterDadosEmprestimo();

            repositorioEmprestimo.CadastrarEmprestimo(novoEmprestimo);
        }

        public void EditarEmprestimo()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Emprestimo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarEmprestimo(true);

            Console.WriteLine("Digite o ID do Emprestimo que deseja selecionar");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Emprestimo emprestimoEditado = ObterDadosEmprestimo();

            bool conseguiuEditar = repositorioEmprestimo.EditarEmprestimo(idEmprestimo, emprestimoEditado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do registro...");
            }
            Console.WriteLine("O registo foi editado com sucesso");

        }
        public void ExcluirEmprestimo()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Emprestimo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarEmprestimo(true);

            Console.WriteLine("Digite o ID do emprestimo que deseja Excluir");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool conseguiuExcluir = repositorioEmprestimo.ExcluirEmprestimo(idEmprestimo);


            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusao do registro...");
            }
            Console.WriteLine("O registo foi excluido com sucesso");

        }

        public void VisualizarEmprestimo(bool exibirTitulo)
        {
            if (exibirTitulo)
                ExibirCabecalho();

            Console.WriteLine("Visualizando Emprestimo");
            Console.WriteLine("----------------------");

            Console.WriteLine();


            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -10} ",
            "Id", "Amigo", "Revista", "Data da Devolução"
                );

            Emprestimo[] emprestimoCadastrado = repositorioEmprestimo.SelecionarEmprestimo();
            Amigo[] amigoCadastrado = repositorioAmigo.SelecionarAmigo();
            Revista[] revistaCadastrada = repositorioRevista.SelecionarRevista();

            for (int i = 0; i < emprestimoCadastrado.Length; i++)
            {
                Emprestimo e = emprestimoCadastrado[i];
                Amigo a = amigoCadastrado[i];
                Revista r = revistaCadastrada[i];

                if (e == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -25} | {2, -25} | {3, -20} ",
                    e.Id, a.Nome, r.Titulo, e.ObterDataDevolucao()
                    );


            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar", ConsoleColor.DarkYellow);
        }

        public Emprestimo ObterDadosEmprestimo()
        {
            telaAmigo.VisualizarAmigo(false);

            Console.Write("Digite o id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigo = repositorioAmigo.SelecionarPorId(idAmigo);

            Console.Clear();
            telaRevista.VisualizarRevista(false);

            Console.WriteLine("Digite o Id da revista que será Emprestada");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revista = repositorioRevista.SelecionarPorId(idRevista);


            Console.Clear();

            Console.WriteLine("Digite a Data que a revista foi pega");
            DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine()); 
            

            Emprestimo emprestimo = new Emprestimo(amigo, revista);

            return emprestimo;
        }

    }
}
