using DesafioEstoque.Models;
using DesafioEstoque.UseCases;

namespace DesafioEstoque;

// Testes simples das funções principais, sem biblioteca externa.
public static class Tests
{
    public static void Run()
    {
        try
        {
            var items = new List<Item> { new(1, "Produto teste", 10) };
            var stock = new Stock();

            var entry = stock.Move(items, 1, 1, "ENTRADA", "Reposição", 5);
            Check(entry.FinalQuantity == 15, "Entrada no estoque");

            var exit = stock.Move(items, 2, 1, "SAÍDA", "Venda", 3);
            Check(exit.FinalQuantity == 12, "Saída no estoque");

            var path = Path.Combine(AppContext.BaseDirectory, "estoque.json");
            Check(new Read().Stock(path).Count == 5, "Leitura do JSON");

            Console.WriteLine("Todos os testes de estoque passaram.");
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
