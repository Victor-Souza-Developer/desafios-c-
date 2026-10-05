using DesafioComissoes.Models;

namespace DesafioComissoes.UseCases;

// Calcula a comissão total de cada vendedor.
public sealed class Calc
{
    public Dictionary<string, decimal> Commission(List<Seller> sellers)
    {
        var result = new Dictionary<string, decimal>();

        foreach (var seller in sellers)
        {
            decimal total = 0m;

            foreach (var sale in seller.Sales)
            {
                // Vendas abaixo de R$ 100,00 não entram no cálculo.
                if (sale < 100m)
                    continue;

                // Até R$ 499,99 rende 1%; a partir de R$ 500,00 rende 5%.
                total += sale < 500m ? sale * 0.01m : sale * 0.05m;
            }

            result.Add(seller.Name, total);
        }

        return result;
    }
}
