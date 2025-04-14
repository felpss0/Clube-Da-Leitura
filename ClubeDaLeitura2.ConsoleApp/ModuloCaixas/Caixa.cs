using ClubeDaLeitura2.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura2.ConsoleApp.ModuloCaixas
{
    public class Caixa
    {
        public Revista[] revistas;

        public int Id;
        public string Etiqueta;
        public string Cor;
        public int DiasDeEmprestimo;

        public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasDeEmprestimo = diasDeEmprestimo;
        }

        

    }
}
