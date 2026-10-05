using DesafioJuros.UseCases;

namespace DesafioJuros;

// Testes simples das funções principais, sem biblioteca externa.
public static class Tests
{
    public static void Run()
    {
        try
        {
            var interest = new Interest();
            var today = DateOnly.FromDateTime(DateTime.Today);

            var late = interest.Calc(100m, today.AddDays(-2));
            Check(late.OverdueDays == 2 && late.InterestAmount == 5m && late.FinalAmount == 105m,
                "Juros de dois dias");

            var future = interest.Calc(100m, today.AddDays(2));
            Check(future.OverdueDays == 0 && future.InterestAmount == 0m, "Vencimento futuro");

            Console.WriteLine("Todos os testes de juros passaram.");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Teste falhou: {error.Message}");
        }
    }

    private static void Check(bool condition, string name)
    {
        if (!condition)
            throw new InvalidOperationException($"Falha no teste: {name}.");
    }
}
