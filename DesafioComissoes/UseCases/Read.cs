using System.Text.Json;
using DesafioComissoes.Models;

namespace DesafioComissoes.UseCases;

// Lê o JSON e separa as vendas pelo nome de cada vendedor.
public sealed class Read
{
    public List<Seller> Sales(string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<FileData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? throw new InvalidOperationException("O arquivo está vazio.");

            return data.Sales
                // Ignora vendas sem vendedor ou com valor negativo.
                .Where(sale => !string.IsNullOrWhiteSpace(sale.Seller) && sale.Amount >= 0)
                .GroupBy(sale => sale.Seller)
                .Select(group => new Seller(group.Key, group.Select(sale => sale.Amount).ToList()))
                .ToList();
        }
        catch (IOException error)
        {
            throw new InvalidOperationException("Não foi possível abrir o arquivo de vendas.", error);
        }
        catch (JsonException error)
        {
            throw new InvalidOperationException("O JSON de vendas é inválido.", error);
        }
    }

    // Classes internas usadas apenas para ler o formato do JSON.
    private sealed class FileData
    {
        public List<SaleData> Sales { get; init; } = [];
    }

    private sealed class SaleData
    {
        public string Seller { get; init; } = string.Empty;
        public decimal Amount { get; init; }
    }
}
