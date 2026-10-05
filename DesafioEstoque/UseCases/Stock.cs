using DesafioEstoque.Models;

namespace DesafioEstoque.UseCases;

// Registra uma movimentação e atualiza a quantidade do produto.
public sealed class Stock
{
    public Move Move(
        List<Item> items,
        int id,
        int code,
        string type,
        string description,
        int quantity)
    {
        var item = items.FirstOrDefault(item => item.Code == code)
            ?? throw new InvalidOperationException("Produto não encontrado.");

        if (quantity <= 0)
            throw new InvalidOperationException("A quantidade deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("A descrição é obrigatória.");

        var moveType = type.Trim().ToUpperInvariant();

        if (moveType == "ENTRADA")
        {
            // Entrada aumenta a quantidade atual.
            item.Add(quantity);
        }
        else if (moveType == "SAIDA" || moveType == "SAÍDA")
        {
            // Saída só acontece quando há saldo no estoque.
            if (!item.Remove(quantity))
                throw new InvalidOperationException("Saída maior que o estoque disponível.");

            moveType = "SAÍDA";
        }
        else
        {
            throw new InvalidOperationException("Digite ENTRADA ou SAÍDA.");
        }

        return new Move(id, item.Code, moveType, description, quantity, item.Quantity);
    }
}
