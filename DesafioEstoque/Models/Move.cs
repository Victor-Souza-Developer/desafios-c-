namespace DesafioEstoque.Models;

// Guarda os dados de uma entrada ou saída realizada.
public sealed record Move(
    int Id,
    int ProductCode,
    string Type,
    string Description,
    int Quantity,
    int FinalQuantity);
