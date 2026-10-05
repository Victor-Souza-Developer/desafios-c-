using DesafioJuros.Models;

namespace DesafioJuros.UseCases;

// Calcula juros simples de 2,5% para cada dia de atraso.
public sealed class Interest
{
    private const decimal DailyRate = 0.025m;

    public Result Calc(decimal amount, DateOnly dueDate)
    {
        if (amount <= 0)
            throw new InvalidOperationException("O valor deve ser maior que zero.");

        var today = DateOnly.FromDateTime(DateTime.Today);

        // Se o vencimento for hoje ou futuro, o atraso fica em zero.
        var days = Math.Max(0, today.DayNumber - dueDate.DayNumber);
        var interest = amount * DailyRate * days;
        var finalAmount = amount + interest;

        return new Result(amount, dueDate, days, interest, finalAmount);
    }
}
