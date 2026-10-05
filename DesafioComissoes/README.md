# Desafio 1 - Comissões

Programa de console que lê as vendas do arquivo `vendas.json`, agrupa por vendedor e calcula as comissões.

## Arquivos

- `Main.cs`: ponto de entrada; inicia o `Caller`.
- `Caller.cs`: controla o fluxo do programa.
- `Models/Seller.cs`: vendedor e lista de vendas.
- `UseCases/Read.cs`: lê e agrupa o JSON.
- `UseCases/Calc.cs`: calcula as comissões.

## Como executar

Com o .NET 8 SDK instalado, abra um terminal nesta pasta e execute:

```powershell
dotnet run
```

## Teste básico

```powershell
dotnet run -- --test
```

O arquivo `vendas.json` é copiado junto ao executável automaticamente pelo SDK.

## Resultado esperado

| Vendedor | Comissão total |
|---|---:|
| Ana Lima | R$ 404,98 |
| Carlos Oliveira | R$ 379,37 |
| João Silva | R$ 495,68 |
| Maria Souza | R$ 465,95 |
