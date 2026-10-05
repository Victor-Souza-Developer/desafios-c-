namespace DesafioComissoes.Models;

// Guarda o nome do vendedor e todas as vendas dele.
public sealed class Seller
{
    public string Name { get; }
    public List<decimal> Sales { get; }

    public Seller(string name, List<decimal> sales)
    {
        Name = name;
        Sales = sales;
    }
}
