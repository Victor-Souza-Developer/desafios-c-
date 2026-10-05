namespace DesafioEstoque;

// Ponto de entrada: inicia o Caller, que controla o fluxo do programa.
public static class App
{
    public static void Main(string[] args)
    {
        // Permite executar os testes sem iniciar o fluxo normal.
        if (args.Contains("--test"))
            Tests.Run();
        else
            Caller.Run();
    }
}
