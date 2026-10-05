using System.Text.Json;
using System.Text.Json.Serialization;
using DesafioEstoque.Models;

namespace DesafioEstoque.UseCases;

// Lê o estoque inicial do arquivo JSON.
public sealed class Read
{
    public List<Item> Stock(string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<FileData>(json)
                ?? throw new InvalidOperationException("O arquivo está vazio.");

            return data.Items
                // Ignora produtos incompletos ou com estoque negativo.
                .Where(item => item.Code > 0 && !string.IsNullOrWhiteSpace(item.Name) && item.Quantity >= 0)
                .Select(item => new Item(item.Code, item.Name, item.Quantity))
                .ToList();
        }
        catch (IOException error)
        {
            throw new InvalidOperationException("Não foi possível abrir o arquivo de estoque.", error);
        }
        catch (JsonException error)
        {
            throw new InvalidOperationException("O JSON de estoque é inválido.", error);
        }
    }

    // Classes internas que representam o JSON de entrada.
    private sealed class FileData
    {
        [JsonPropertyName("estoque")]
        public List<ItemData> Items { get; init; } = [];
    }

    private sealed class ItemData
    {
        [JsonPropertyName("codigoProduto")]
        public int Code { get; init; }

        [JsonPropertyName("descricaoProduto")]
        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("estoque")]
        public int Quantity { get; init; }
    }
}
