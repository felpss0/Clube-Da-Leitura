using ClubeDaLeitura2.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura2.ConsoleApp.ModuloCaixas
{
    class TelaCaixa
    {
        public RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerenciador de Caixas");
            Console.WriteLine();
            Console.WriteLine("----------------------------");

        }

        public char ApresentarMenu()
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

        public void CadastrarCaixa()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Cadastrando Caixa");
            Console.WriteLine("----------------------------");


            Console.WriteLine();
            Caixa novaCaixa = ObterDadosCaixa();
            novaCaixa.ObterDiasEmprestimo();

            repositorioCaixa.CadastrarCaixa(novaCaixa);
        }

        public void EditarCaixa()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando Caixa");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarCaixa(true);

            Console.WriteLine("Digite o ID da caixa que deseja selecionar");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Caixa caixaEditada = ObterDadosCaixa();

            bool conseguiuEditar = repositorioCaixa.EditarCaixa(idCaixa, caixaEditada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do registro...");
            }
            Console.WriteLine("O registo foi editado com sucesso");

        }
        public void ExcluirCaixa()
        {
            ExibirCabecalho();

            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Editando caixa");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            VisualizarCaixa(true);

            Console.WriteLine("Digite o ID da caixa que deseja selecionar");
            int idCaixa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool conseguiuExcluir = repositorioCaixa.ExcluirCaixa(idCaixa);


            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusao do registro...");
            }
            Console.WriteLine("O registo foi excluido com sucesso");

        }

        public void VisualizarCaixa(bool exibirTitulo)
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

            Caixa[] caixasCadastradas = repositorioCaixa.SelecionarCaixa();

            for (int i = 0; i < caixasCadastradas.Length; i++)
            {
                Caixa c = caixasCadastradas[i];

                if (c == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20} ",
                    c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
                    );


            }
            Console.WriteLine();

            Notificador.ExibirMensagem("Pressione ENTER para continuar", ConsoleColor.DarkYellow);
        }

        public Caixa ObterDadosCaixa()
        {
            Console.WriteLine("Digite o nome Etiqueta da Caixa");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Digite a Cor da Caixa (Vermelho e Roxo para Caixas Raras, qualquer outra cor será definida como Comum)");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite quantos dias de emprestimo a caixa vai ter");
            int diasDeEmprestimo = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

            return caixa;
        }
    }
}
