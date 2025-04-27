using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos;
using System.Collections;

namespace ClubeDaLeitura2.ConsoleApp.ModuloRevistas
{
    public class Revista : EntidadeBase
    {
        public ArrayList Revistas;


        public string Titulo { get; set; }
        public string NumeroEdicao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public Emprestimo StatusEmprestimo;
        public Caixa Caixa;

        public Revista(string titulo, string numeroEdicao, DateTime dataPublicacao)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            DataPublicacao = dataPublicacao;
        }

        public override void AtualizarRegistro(EntidadeBase registroEditado)
        {
            Revista revistaEditada = (Revista)registroEditado;

            Titulo = revistaEditada.Titulo;
            NumeroEdicao = revistaEditada.NumeroEdicao;
            DataPublicacao = revistaEditada.DataPublicacao;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
