using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura2.ConsoleApp.Util
{
    public class MenuPrincipal
    {
        

        private char opcaoPrincipal;
        private RepositorioAmigo repositorioAmigo;
        private RepositorioCaixa repositorioCaixa;
        private RepositorioRevista repositorioRevista;
        private RepositorioEmprestimo repositorioEmprestimo;
        private TelaAmigo telaAmigo;
        private TelaRevista telaRevista;

        public MenuPrincipal()
        {
            this.repositorioAmigo = new RepositorioAmigo();
            this.repositorioCaixa = new RepositorioCaixa();
            this.repositorioRevista = new RepositorioRevista();
            this.repositorioEmprestimo = new RepositorioEmprestimo();
            
        }


        public void ApresentarMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|        Clube da Leitura         |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("-----------------------------------");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("1 - Gerenciar Amigos");
            Console.WriteLine("2 - Gerenciar Caixas");
            Console.WriteLine("3 - Gerenciar Revistas");
            Console.WriteLine("4 - Gerenciar Emprestimos");
            Console.WriteLine("S - Sair");


            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            Console.ResetColor();
            opcaoPrincipal = Console.ReadLine()[0];

            

        }

        public TelaBase ObterTela()
        {
            if (opcaoPrincipal == '1')
                return new TelaAmigo(repositorioAmigo);

            else if (opcaoPrincipal == '2')
                return new TelaCaixa(repositorioCaixa, repositorioRevista);

            else if (opcaoPrincipal == '3')
                return new TelaRevista(repositorioRevista, repositorioCaixa);
            else if (opcaoPrincipal == '4')
                return new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista, telaAmigo, telaRevista);

            return null;
        }

    }
}
