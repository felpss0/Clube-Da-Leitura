using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;
using ClubeDaLeitura2.ConsoleApp.Util;
using System.Collections;

namespace ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo : TelaBase
    {
        RepositorioEmprestimo repositorioEmprestimo;
        RepositorioAmigo repositorioAmigo;
        RepositorioRevista repositorioRevista;
        TelaAmigo telaAmigo;
        TelaRevista telaRevista;
        

        public TelaEmprestimo(
            RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista,
            TelaAmigo telaAmigo, TelaRevista telaRevista
            ) : base("Emprestimo", repositorioEmprestimo) 
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
            this.telaAmigo = telaAmigo;
            this.telaRevista = telaRevista;
        }

        

        public override char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Emprestimos");
            Console.WriteLine("2 - Editar Emprestimos");
            Console.WriteLine("3 - Excluir Emprestimos");
            Console.WriteLine("4 - Visualizar Emprestimos");
            Console.WriteLine("5 - Registrar Devolução");


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
            Console.WriteLine("Cadastrando Emprestimo");
            Console.WriteLine("----------------------------");


            Console.WriteLine();
            Emprestimo novoEmprestimo = (Emprestimo)ObterDados();

            repositorioEmprestimo.CadastrarRegistro(novoEmprestimo);
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Emprestimo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID do Emprestimo que deseja selecionar");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Emprestimo emprestimoEditado = (Emprestimo)ObterDados();

            bool conseguiuEditar = repositorioEmprestimo.EditarRegistro(idEmprestimo, emprestimoEditado);

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
            Console.WriteLine("Editando Emprestimo");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID do emprestimo que deseja Excluir");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool conseguiuExcluir = repositorioEmprestimo.ExcluirRegistro(idEmprestimo);


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

            Console.WriteLine("Visualizando Emprestimo");
            Console.WriteLine("----------------------");

            Console.WriteLine();


            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -10} ",
            "Id", "Amigo", "Revista", "Data da Devolução"
                );

            ArrayList emprestimoCadastrado = repositorioEmprestimo.SelecionarRegistros();
            ArrayList amigoCadastrado = repositorioAmigo.SelecionarRegistros();
            ArrayList revistaCadastrada = repositorioRevista.SelecionarRegistros();

            for (int i = 0; i < emprestimoCadastrado.Count; i++)
            {
                Emprestimo e = (Emprestimo)emprestimoCadastrado[i]!;

                Amigo a = (Amigo)amigoCadastrado[i]!;

                Revista r = (Revista)revistaCadastrada[i]!;

                if (e == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -25} | {2, -25} | {3, -20} ",
                    e.Id, a.Nome, r.Titulo, e.ObterDataDevolucao()
                    );
            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar", ConsoleColor.DarkYellow);
        }

        public override EntidadeBase ObterDados()
        {
            telaAmigo.VisualizarRegistros(false);

            Console.Write("Digite o id do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idAmigo);

            Console.Clear();
            telaRevista.VisualizarRegistros(false);

            Console.WriteLine("Digite o Id da revista que será Emprestada");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revista = (Revista)repositorioRevista.SelecionarRegistroPorId(idRevista);


            Console.Clear();

            Console.WriteLine("Digite a Data que a revista foi pega");
            DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());


            Emprestimo emprestimo = new Emprestimo(amigo, revista);

            return emprestimo;
        }

        public void RegistrarDevolucao()
        {
            
        }
    }
}
