namespace DesafioEstoque.Models;

// Representa um produto e a quantidade disponível no estoque.
public sealed class Item
{
    public int Code { get; }
    public string Name { get; }
    public int Quantity { get; private set; }

    public Item(int code, string name, int quantity)
    {
        Code = code;
        Name = name;
        Quantity = quantity;
    }

    // Soma uma quantidade ao estoque.
    public void Add(int quantity) => Quantity += quantity;

    // Retira uma quantidade e informa se havia saldo suficiente.
    public bool Remove(int quantity)
    {
        if (quantity > Quantity)
            return false;

        Quantity -= quantity;
        return true;
    }
}
