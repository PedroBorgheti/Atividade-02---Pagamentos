# Projeto: Pagamentos (Cartão, PIX, Boleto)

**Aluno:** Pedro Gabriel Sepulveda Borgheti  
**Professor:** Everton Coimbra  
**Atividade 02:** Processamento de Pagamentos (Herança e Composição)

## Como executar
```bash
dotnet build
dotnet test
```

## Descrição
Projeto demonstrando herança controlada (Pagamento como base concreta com ganchos virtual)
e composição via delegates para políticas (Antifraude e Câmbio).

O ritual: Validar → Autorizar/Capturar → Confirmar. Delegates: Antifraude: decimal->bool;
Cambio: decimal->decimal.
