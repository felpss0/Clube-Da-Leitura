using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura2.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas[0] = new Caixa("abc-123", "Vermelho", 3);

            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos[0] = new Amigo("Pedrinho", "Roberto", "99 9929-2107");

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.revistas[0] = new Revista("As aventuras do batman", "1", new DateTime(2020, 10, 10));

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista, telaAmigo, telaRevista);


            MenuPrincipal telaPrincipal = new MenuPrincipal();

            while (true)
            {
                Console.Clear();

                char opcaoPrincipal = telaPrincipal.ApresentarMenu();

                if (opcaoPrincipal == '1')
                {
                    char opcaoEscolhida = telaAmigo.ApresentarMenu();

                    switch (opcaoEscolhida)
                    {
                        case '1': telaAmigo.CadastrarAmigo(); break;

                        case '2': telaAmigo.EditarAmigo(); break;

                        case '3': telaAmigo.ExcluirAmigo(); break;

                        case '4': telaAmigo.VisualizarAmigo(true); break;

                    }
                }

                if (opcaoPrincipal == '2')
                {
                    char opcaoEscolhida = telaCaixa.ApresentarMenu();

                    switch (opcaoEscolhida)
                    {
                        case '1': telaCaixa.CadastrarCaixa(); break;

                        case '2': telaCaixa.EditarCaixa(); break;

                        case '3': telaCaixa.ExcluirCaixa(); break;

                        case '4': telaCaixa.VisualizarCaixa(true); ; break;

                    }
                }

                if (opcaoPrincipal == '3')
                {
                    char opcaoEscolhida = telaRevista.ApresentarMenu();

                    switch (opcaoEscolhida)
                    {
                        case '1': telaRevista.CadastrarCaixa(); break;

                        case '2': telaRevista.EditarRevista(); break;

                        case '3': telaRevista.ExcluirRevista(); break;

                        case '4': telaRevista.VisualizarRevista(true); break;

                    }
                }

                if (opcaoPrincipal == '4')
                {
                    char opcaoEscolhida = telaEmprestimo.ApresentarMenu();

                    switch (opcaoEscolhida)
                    {
                        case '1': telaEmprestimo.CadastrarEmprestimo(); break;

                        case '2': telaEmprestimo.EditarEmprestimo(); break;

                        case '3': telaEmprestimo.ExcluirEmprestimo(); break;

                        case '4': telaEmprestimo.VisualizarEmprestimo(true); break;

                    }
                }
            }
        }
    }
}
