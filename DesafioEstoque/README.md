# Desafio 2 - Estoque

Programa de console para registrar entradas e saídas de produtos.

## Arquivos

- `Main.cs`: ponto de entrada; inicia o `Caller`.
- `Caller.cs`: controla o fluxo no console.
- `Models/Item.cs`: produto e quantidade atual.
- `Models/Move.cs`: dados de uma movimentação.
- `UseCases/Read.cs`: lê o arquivo `estoque.json`.
- `UseCases/Stock.cs`: aplica entrada ou saída.

## Regras aplicadas

- Toda movimentação recebe um identificador sequencial único durante a execução.
- Cada movimentação possui tipo, descrição e quantidade.
- Saídas não podem deixar o estoque negativo.
- A quantidade final é mostrada após cada movimentação.

## Como executar

Com o .NET 8 SDK instalado, abra um terminal nesta pasta e execute:

```powershell
dotnet run
```

## Teste básico

```powershell
dotnet run -- --test
```
