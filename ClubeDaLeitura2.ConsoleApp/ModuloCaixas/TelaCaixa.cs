using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;
using ClubeDaLeitura2.ConsoleApp.Util;
using System.Collections;

namespace ClubeDaLeitura2.ConsoleApp.ModuloCaixas
{
    class TelaCaixa : TelaBase
    {
        public RepositorioCaixa repositorioCaixa;
        public RepositorioRevista repositorioRevista;

        public TelaCaixa(RepositorioCaixa repositorioCaixa, RepositorioRevista repositorioRevista) : base("Caixa", repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioRevista = repositorioRevista;
        }

        

        public override char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Caixa");
            Console.WriteLine("2 - Editar Caixa");
            Console.WriteLine("3 - Excluir Caixa");
            Console.WriteLine("4 - Visualizar Caixas");


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
            Caixa novaCaixa = (Caixa)ObterDados();
            novaCaixa.ObterDiasEmprestimo();

            repositorioCaixa.CadastrarRegistro(novaCaixa);
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Caixa");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID da caixa que deseja selecionar");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Caixa caixaEditada = (Caixa)ObterDados();

            bool conseguiuEditar = repositorioCaixa.EditarRegistro(idCaixa, caixaEditada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do registro...");
            }
            Console.WriteLine("O registo foi editado com sucesso");

        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
                ExibirCabecalho();

            Console.WriteLine("Visualizando Caixas");
            Console.WriteLine("----------------------");

            Console.WriteLine();


            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -10} ",
                "Id", "Etiqueta", "Cor", "Dias de Emprestimo"
                );

            ArrayList registros = repositorioCaixa.SelecionarRegistros();


            foreach (Caixa c in registros)
            {
                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                    c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
                    );
            }


            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar", ConsoleColor.DarkYellow);
        }
        public override void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando caixa");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarRegistros(true);

            Console.WriteLine("Digite o ID da caixa que deseja selecionar");
            int idCaixa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool conseguiuExcluir = repositorioCaixa.ExcluirRegistro(idCaixa);


            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusao do registro...");
            }
            Console.WriteLine("O registo foi excluido com sucesso");

        }

        public override EntidadeBase ObterDados()
        {
            Console.WriteLine("Digite o nome Etiqueta da Caixa");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Digite a Cor da Caixa (Vermelha ou Roxo para Raridade Alta)");
            string cor = Console.ReadLine();


            Caixa caixa = new Caixa(etiqueta, cor);

            return caixa;
        }
    }
}
