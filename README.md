# Desafios em C#

Este repositório reúne três aplicações de console desenvolvidas em C# e .NET 8.

## Pré-requisito

Instale o [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

## Projetos

### 1. Comissões

Local: `DesafioComissoes`

Lê vendas de um JSON, agrupa os valores por vendedor e calcula a comissão:

- abaixo de R$ 100,00: sem comissão;
- de R$ 100,00 até abaixo de R$ 500,00: 1%;
- a partir de R$ 500,00: 5%.

```powershell
cd DesafioComissoes
dotnet run
```

### 2. Estoque

Local: `DesafioEstoque`

Lê produtos de um JSON e permite registrar entrada ou saída de estoque. Cada movimentação possui identificador, descrição, tipo, quantidade e estoque final.

```powershell
cd DesafioEstoque
dotnet run
```

### 3. Juros

Local: `DesafioJuros`

Recebe valor e data de vencimento, usa a data atual e calcula juros simples de 2,5% por dia de atraso.

```powershell
cd DesafioJuros
dotnet run
```

## Organização dos projetos

Todos seguem a mesma estrutura simples:

- `Main.cs`: ponto de entrada do programa;
- `Caller.cs`: controla o fluxo e chama as funções principais;
- `Models`: representa os dados usados pela aplicação;
- `UseCases`: contém a leitura e as regras de negócio;
- `Tests.cs`: testes básicos sem bibliotecas externas.

## Executar os testes

Dentro da pasta de qualquer projeto, execute:

```powershell
dotnet run -- --test
```
