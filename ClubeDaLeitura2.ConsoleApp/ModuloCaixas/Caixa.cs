using ClubeDaLeitura2.ConsoleApp.Compartilhado;
using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;
using System.Collections;

namespace ClubeDaLeitura2.ConsoleApp.ModuloCaixas
{
    public class Caixa : EntidadeBase
    {
        public ArrayList revistas;

        
        public string Etiqueta;
        public string Cor;
        public int DiasDeEmprestimo;



        public Caixa(string etiqueta, string cor )
        {
            Etiqueta = etiqueta;
            Cor = cor;
            
        }

        public override void AtualizarRegistro(EntidadeBase registroEditado)
        {
            Caixa caixaEditada = (Caixa)registroEditado;

            Etiqueta = caixaEditada.Etiqueta;
            Cor = caixaEditada.Cor;
            
        }

        public int ObterDiasEmprestimo() 
        {
            if (Cor == "Vermelha" && Cor == "Roxo")
                return DiasDeEmprestimo = 3;
            
            return DiasDeEmprestimo = 7;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
