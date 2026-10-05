using System.Globalization;
using DesafioJuros.UseCases;

namespace DesafioJuros;

// Controla o fluxo do programa de juros.
public static class Caller
{
    public static void Run()
    {
        var culture = CultureInfo.GetCultureInfo("pt-BR");

        Console.WriteLine("CÁLCULO DE JUROS POR ATRASO");
        Console.Write("Valor original (exemplo: 150,00): R$ ");

        if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, culture, out var amount))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.Write("Data de vencimento (dd/MM/aaaa): ");
        if (!DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", culture, DateTimeStyles.None, out var dueDate))
        {
            Console.WriteLine("Data inválida. Use o formato dd/MM/aaaa.");
            return;
        }

        try
        {
            // Envia o valor e o vencimento para a classe que faz o cálculo.
            var result = new Interest().Calc(amount, dueDate);

            Console.WriteLine("\nRESULTADO");
            Console.WriteLine($"Valor original: {result.OriginalAmount.ToString("C", culture)}");
            Console.WriteLine($"Vencimento: {result.DueDate:dd/MM/yyyy}");
            Console.WriteLine($"Dias em atraso: {result.OverdueDays}");
            Console.WriteLine($"Juros: {result.InterestAmount.ToString("C", culture)}");
            Console.WriteLine($"Valor final: {result.FinalAmount.ToString("C", culture)}");
        }
        catch (InvalidOperationException error)
        {
            Console.WriteLine($"Erro: {error.Message}");
        }
    }
}
