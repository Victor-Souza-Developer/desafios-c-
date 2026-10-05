namespace DesafioJuros.Models;

// Guarda os valores calculados para mostrar no final.
public sealed record Result(
    decimal OriginalAmount,
    DateOnly DueDate,
    int OverdueDays,
    decimal InterestAmount,
    decimal FinalAmount);
