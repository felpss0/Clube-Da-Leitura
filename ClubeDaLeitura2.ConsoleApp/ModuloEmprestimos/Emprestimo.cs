using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura2.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;
using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeitura2.ConsoleApp.ModuloEmprestimos
{
    public class Emprestimo : EntidadeBase
    {
        
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataEmprestimo;
        public DateTime DataDevolucao; 
        public string SituacaoEmprestimo;
        


        public Emprestimo(Amigo amigo, Revista revista)
        {

            Amigo = amigo;
            Revista = revista;
            SituacaoEmprestimo = "Aberto";
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(3);
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

        public override void AtualizarRegistro(EntidadeBase registroEditado)
        {
            Emprestimo emprestimoEditado = (Emprestimo)registroEditado;

            Amigo = emprestimoEditado.Amigo;
            Revista = emprestimoEditado.Revista;
            
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
