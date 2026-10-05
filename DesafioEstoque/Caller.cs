using DesafioEstoque.Models;
using DesafioEstoque.UseCases;

namespace DesafioEstoque;

// Controla o fluxo do programa de estoque.
public static class Caller
{
    public static void Run()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "estoque.json");
        List<Item> items;

        try
        {
            items = new Read().Stock(path);
        }
        catch (InvalidOperationException error)
        {
            Console.WriteLine($"Erro: {error.Message}");
            return;
        }

        var stock = new Stock();
        var moves = new List<Move>();
        var nextId = 1;

        Console.WriteLine("CONTROLE DE ESTOQUE");

        while (true)
        {
            Show(items);

            Console.Write("Código do produto (ou 0 para encerrar): ");
            if (!int.TryParse(Console.ReadLine(), out var code))
            {
                Console.WriteLine("Digite um código numérico.\n");
                continue;
            }

            if (code == 0)
                break;

            Console.Write("Tipo (ENTRADA ou SAÍDA): ");
            var type = Console.ReadLine() ?? string.Empty;

            Console.Write("Descrição: ");
            var description = Console.ReadLine() ?? string.Empty;

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Digite uma quantidade numérica.\n");
                continue;
            }

            try
            {
                // O ID só aumenta depois de uma movimentação válida.
                var move = stock.Move(items, nextId, code, type, description, quantity);
                moves.Add(move);
                nextId++;

                Console.WriteLine($"\nMovimentação #{move.Id} registrada.");
                Console.WriteLine($"Estoque final: {move.FinalQuantity}\n");
            }
            catch (InvalidOperationException error)
            {
                Console.WriteLine($"Erro: {error.Message}\n");
            }
        }

        Console.WriteLine("\nMovimentações realizadas:");
        foreach (var move in moves)
        {
            Console.WriteLine($"#{move.Id} | Produto {move.ProductCode} | {move.Type} | " +
                              $"{move.Description} | Quantidade: {move.Quantity} | " +
                              $"Estoque final: {move.FinalQuantity}");
        }
    }

    // Mostra o estoque atual antes de uma nova movimentação.
    private static void Show(List<Item> items)
    {
        Console.WriteLine("\nProdutos em estoque:");
        foreach (var item in items)
            Console.WriteLine($"{item.Code} - {item.Name}: {item.Quantity} unidade(s)");

        Console.WriteLine();
    }
}
