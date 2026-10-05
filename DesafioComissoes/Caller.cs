using System.Globalization;
using DesafioComissoes.UseCases;

namespace DesafioComissoes;

// Controla o fluxo do programa de comissões.
public static class Caller
{
    public static void Run()
    {
        var culture = CultureInfo.GetCultureInfo("pt-BR");
        var path = Path.Combine(AppContext.BaseDirectory, "vendas.json");

        List<Models.Seller> sellers;

        try
        {
            // Primeiro lê e agrupa; depois calcula as comissões.
            sellers = new Read().Sales(path);
        }
        catch (InvalidOperationException error)
        {
            Console.WriteLine($"Erro: {error.Message}");
            return;
        }

        var commissions = new Calc().Commission(sellers);

        Console.WriteLine("COMISSÕES POR VENDEDOR");
        Console.WriteLine(new string('-', 62));

        foreach (var seller in sellers)
        {
            var totalSales = seller.Sales.Sum();
            var totalCommission = commissions[seller.Name];

            Console.WriteLine($"Vendedor: {seller.Name}");
            Console.WriteLine($"Vendas: {string.Join(", ", seller.Sales.Select(value => value.ToString("C", culture)))}");
            Console.WriteLine($"Total de vendas: {totalSales.ToString("C", culture)}");
            Console.WriteLine($"Comissão total: {totalCommission.ToString("C", culture)}\n");
        }
    }
}
