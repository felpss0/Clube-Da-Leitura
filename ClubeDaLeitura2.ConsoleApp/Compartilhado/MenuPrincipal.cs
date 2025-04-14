namespace ClubeDaLeitura2.ConsoleApp.Compartilhado
{
    public class MenuPrincipal
    {
        public char ApresentarMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|        Clube da Leitura         |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("-----------------------------------");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("1 - Gerenciar Amigos");
            Console.WriteLine("2 - Gerenciar Caixas");
            Console.WriteLine("3 - Gerenciar Revistas");
            Console.WriteLine("4 - Gerenciar Emprestimos");


            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            Console.ResetColor();
            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;


        }

    }
}
