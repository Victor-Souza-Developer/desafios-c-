using DesafioComissoes.Models;
using DesafioComissoes.UseCases;

namespace DesafioComissoes;

// Testes simples das funções principais, sem biblioteca externa.
public static class Tests
{
    public static void Run()
    {
        try
        {
            var sellers = new List<Seller>
            {
                new("Teste", [50m, 100m, 500m])
            };

            // R$ 50 não conta; R$ 100 gera R$ 1; R$ 500 gera R$ 25.
            var result = new Calc().Commission(sellers);
            Check(result["Teste"] == 26m, "Cálculo de comissão");

            var path = Path.Combine(AppContext.BaseDirectory, "vendas.json");
            Check(new Read().Sales(path).Count == 4, "Leitura e agrupamento do JSON");

            Console.WriteLine("Todos os testes de comissões passaram.");
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
