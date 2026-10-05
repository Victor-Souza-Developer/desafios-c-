# Desafio 3 - Juros

Programa de console que calcula juros por atraso a partir de um valor e de uma data de vencimento.

## Regra aplicada

- Multa diária: 2,5%.
- Os juros são simples: `valor original × 2,5% × dias em atraso`.
- Se a data de vencimento for hoje ou futura, não há juros.

## Arquivos

- `Main.cs`: ponto de entrada; inicia o `Caller`.
- `Caller.cs`: recebe os dados e mostra o resultado.
- `Models/Result.cs`: guarda os dados calculados.
- `UseCases/Interest.cs`: calcula os dias, os juros e o valor final.

## Exemplo

Para R$ 100,00 vencidos há 2 dias:

```text
Juros = 100,00 × 0,025 × 2 = R$ 5,00
Valor final = R$ 105,00
```

## Como executar

Com o .NET 8 SDK instalado, abra um terminal nesta pasta e execute:

```powershell
dotnet run
```

## Teste básico

```powershell
dotnet run -- --test
```
