using ClubeDaLeitura2.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos
{
    public class Emprestimo
    {
        public int Id;
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataEmprestimo;
        public DateTime DataDevolucao;
        public string SituacaoEmprestimo;


        public Emprestimo(Amigo amigo, Revista revista)
        {

            Amigo = amigo;
            Revista = revista;
            //DataEmprestimo = DataDevolucao = DataEmprestimo.AddDays();
            //DataDevolucao = DataEmprestimo.AddDays(diasCaixa);
            SituacaoEmprestimo = "Aberto";
        }

        public DateTime ObterDataDevolucao()
        {
            return DataDevolucao;
        }

        public void RegistrarDevolucao()
        {
            if (SituacaoEmprestimo == "Aberto" && DateTime.Now > DataDevolucao)
                SituacaoEmprestimo = "Atrasado";

        }

        public void Registrar()
        {
            int qtdDiasEmprestimo = Revista.Caixa.DiasDeEmprestimo;
            DataDevolucao = DataEmprestimo.AddDays(qtdDiasEmprestimo);
        }



    }
}
