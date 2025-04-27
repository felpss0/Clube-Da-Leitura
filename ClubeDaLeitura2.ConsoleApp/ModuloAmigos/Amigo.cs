using ClubeDaLeitura2.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura2.ConsoleApp.ModuloAmigos
{
    public class Amigo : EntidadeBase
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }

        public Amigo(string nome, string responsavel, string telefone)
        {
            Nome = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigo amigoAtualizado = (Amigo)registroAtualizado;

            Nome = amigoAtualizado.Nome;
            Responsavel = amigoAtualizado.Responsavel;
            Telefone = amigoAtualizado.Telefone;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (Nome.Length < 3)
                erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

            if (Responsavel.Length < 3)
                erros += "O nome do Responsavel precisa conter no minimo 3 caracteres.\n";

            if (Telefone.Length != 10 && Telefone.Length != 11)
                erros += "Numero informado invalido, Digite um numero de telefone ou celular valido.\n";

            if (Nome == Nome && Telefone == Telefone)
                erros += "Não pode ter Nomes e Telefones iguais.\n";



            return erros;
        }


    }
}
