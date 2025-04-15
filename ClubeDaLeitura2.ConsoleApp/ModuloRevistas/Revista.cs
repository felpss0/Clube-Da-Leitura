using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos;

namespace ClubeDaLeitura2.ConsoleApp.ModuloRevistas
{
    public class Revista
    {
        public int Id;
        public string Titulo;
        public string NumeroEdicao;
        public DateTime DataPublicacao;
        public Emprestimo StatusEmprestimo;
        public Caixa Caixa;

        public Revista(string titulo, string numeroEdicao, DateTime dataPublicacao)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            DataPublicacao = dataPublicacao;
        }

        


    }
}
