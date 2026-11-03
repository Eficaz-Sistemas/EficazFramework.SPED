# Integra-Parcelamento — Parcelamentos do Simples Nacional e do MEI

Consulta os pedidos e o detalhamento dos parcelamentos do Simples Nacional e do MEI, as parcelas disponíveis e os pagamentos, e emite o DAS das parcelas. As 8 modalidades (PARCSN, PARCSN-ESP, PERTSN, RELPSN, PARCMEI, PARCMEI-ESP, PERTMEI e RELPMEI) expõem os mesmos 5 serviços, selecionados pelo enum `ModalidadeParcelamento`.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `GERARDAS{p}1` | `/Emitir` | 1.0 | `ParcelamentoGerarDasAsync` | `RetornoGerarDasParcela` |
| `PARCELASPARAGERAR{p}2` | `/Consultar` | 1.0 | `ParcelamentoConsultarParcelasParaGerarAsync` | `ParcelasParaGerar` |
| `PEDIDOSPARC{p}3` | `/Consultar` | 1.0 | `ParcelamentoConsultarPedidosAsync` | `PedidosParcelamento` |
| `OBTERPARC{p}4` | `/Consultar` | 1.0 | `ParcelamentoObterOrdinarioAsync`, `ParcelamentoObterPertSnAsync`, `ParcelamentoObterPertMeiAsync`, `ParcelamentoObterRelpSnAsync`, `ParcelamentoObterRelpMeiAsync`, `ParcelamentoObterAsync<T>` | `ParcelamentoOrdinario`, `ParcelamentoPertSn`, `ParcelamentoPertMei`, `ParcelamentoRelpSn`, `ParcelamentoRelpMei` (ou `T`) |
| `DETPAGTOPARC{p}5` | `/Consultar` | 1.0 | `ParcelamentoConsultarDetalhePagamentoAsync` | `DetalhePagamentoParcela` |

### Modalidades (`Catalogo.Parcelamento.Servicos(modalidade)`)

`{p}` é o prefixo numérico da modalidade. O `idSistema` e os `idServico` vêm de `Catalogo.Parcelamento.Servicos(modalidade)` (record `ServicosParcelamento`: `GerarDas`, `ParcelasParaGerar`, `Pedidos`, `ObterParcelamento`, `DetalhePagamento`).

| `ModalidadeParcelamento` | idSistema | GerarDas | ParcelasParaGerar | Pedidos | ObterParcelamento | DetalhePagamento | Layout do OBTERPARC |
|:--|:--|:--|:--|:--|:--|:--|:--|
| `PARCSN` | `PARCSN` | `GERARDAS161` | `PARCELASPARAGERAR162` | `PEDIDOSPARC163` | `OBTERPARC164` | `DETPAGTOPARC165` | `ParcelamentoOrdinario` |
| `PARCSN_ESP` | `PARCSN-ESP` | `GERARDAS171` | `PARCELASPARAGERAR172` | `PEDIDOSPARC173` | `OBTERPARC174` | `DETPAGTOPARC175` | `ParcelamentoOrdinario` |
| `PERTSN` | `PERTSN` | `GERARDAS181` | `PARCELASPARAGERAR182` | `PEDIDOSPARC183` | `OBTERPARC184` | `DETPAGTOPARC185` | `ParcelamentoPertSn` |
| `RELPSN` | `RELPSN` | `GERARDAS191` | `PARCELASPARAGERAR192` | `PEDIDOSPARC193` | `OBTERPARC194` | `DETPAGTOPARC195` | `ParcelamentoRelpSn` |
| `PARCMEI` | `PARCMEI` | `GERARDAS201` | `PARCELASPARAGERAR202` | `PEDIDOSPARC203` | `OBTERPARC204` | `DETPAGTOPARC205` | `ParcelamentoOrdinario` |
| `PARCMEI_ESP` | `PARCMEI-ESP` | `GERARDAS211` | `PARCELASPARAGERAR212` | `PEDIDOSPARC213` | `OBTERPARC214` | `DETPAGTOPARC215` | `ParcelamentoOrdinario` |
| `PERTMEI` | `PERTMEI` | `GERARDAS221` | `PARCELASPARAGERAR222` | `PEDIDOSPARC223` | `OBTERPARC224` | `DETPAGTOPARC225` | `ParcelamentoPertMei` |
| `RELPMEI` | `RELPMEI` | `GERARDAS231` | `PARCELASPARAGERAR232` | `PEDIDOSPARC233` | `OBTERPARC234` | `DETPAGTOPARC235` | `ParcelamentoRelpMei` |

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço).

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraParcelamento;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

---

## 📋 PEDIDOSPARC{p}3 — Consultar pedidos de parcelamento

Lista todos os pedidos do contribuinte na modalidade (não há dados de entrada).

```csharp
var resposta = await servico.ParcelamentoConsultarPedidosAsync(ModalidadeParcelamento.PARCSN, contribuinte);

if (resposta.Sucesso)
{
    foreach (var pedido in resposta.Retorno?.Parcelamentos ?? [])
        Console.WriteLine($"Nº {pedido.Numero} pedido em {pedido.DataDoPedido}: {pedido.Situacao} desde {pedido.DataDaSituacao}");
}
```

**Dados enviados** (`pedidoDados.dados`): string vazia.

```json
""
```

**Retorno (fictício)**

```json
{
  "parcelamentos": [
    { "numero": 1, "dataDoPedido": 20190312, "situacao": "Encerrado a Pedido do Contribuinte", "dataDaSituacao": 20200115 },
    { "numero": 2, "dataDoPedido": 20250310, "situacao": "Em parcelamento", "dataDaSituacao": 20250310 }
  ]
}
```

Mensagens: `[Sucesso-PARCSN]` — Requisição efetuada com sucesso.

---

## 📅 PARCELASPARAGERAR{p}2 — Consultar parcelas disponíveis para impressão

Lista as parcelas do parcelamento **ativo** da modalidade para as quais o DAS pode ser emitido (não há dados de entrada).

```csharp
var resposta = await servico.ParcelamentoConsultarParcelasParaGerarAsync(ModalidadeParcelamento.PARCSN, contribuinte);

if (resposta.Sucesso)
{
    foreach (var parcela in resposta.Retorno?.ListaParcelas ?? [])
        Console.WriteLine($"Parcela {parcela.Parcela}: R$ {parcela.Valor:N2}");
}
```

**Dados enviados** (`pedidoDados.dados`): string vazia.

```json
""
```

**Retorno (fictício)**

```json
{
  "listaParcelas": [
    { "parcela": 202610, "valor": 412.37 },
    { "parcela": 202611, "valor": 412.37 }
  ]
}
```

Mensagens: `[Sucesso-PARCSN]` — Requisição efetuada com sucesso.

> [!NOTE]
> A tabela da documentação oficial cita `listaParcela`, mas todos os exemplos de retorno trazem `listaParcelas` (nome mapeado em `ParcelasParaGerar.ListaParcelas`). O RELPSN devolve `parcela` como texto (`"202610"`); a leitura aceita número ou texto.

---

## 🧾 GERARDAS{p}1 — Emitir DAS da parcela

```csharp
var resposta = await servico.ParcelamentoGerarDasAsync(
    ModalidadeParcelamento.PARCSN,
    contribuinte,
    new GerarDasParcela { ParcelaParaEmitir = 202610 }); // AAAAMM

if (resposta.Sucesso && resposta.Retorno?.DocArrecadacaoPdfB64 is { } pdf)
    File.WriteAllBytes(@"C:\DAS\parcsn-202610.pdf", Convert.FromBase64String(pdf));
```

**Dados enviados** (`pedidoDados.dados`)

```json
{"parcelaParaEmitir":202610}
```

**Retorno (fictício)**

```json
{
  "docArrecadacaoPdfB64": "JVBERi0xLjQK..."
}
```

Mensagens: `[Sucesso-PARCSN]` — Requisição efetuada com sucesso.

---

## 🔎 OBTERPARC{p}4 — Consultar parcelamento

Detalha um parcelamento (consolidação original, alterações da dívida e demonstrativo de pagamentos). Os campos comuns (`Numero`, `DataDoPedido`, `Situacao`, `DataDaSituacao`, `DemonstrativoPagamentos`) estão na classe base abstrata `ParcelamentoDetalhado`; a consolidação e as alterações têm **layout próprio por família de modalidades**, por isso há um método tipado para cada layout.

A entrada é a mesma em todos os layouts (`ConsultaParcelamento`):

```json
{"numeroParcelamento":2}
```

### Ordinário — PARCSN, PARCSN-ESP, PARCMEI e PARCMEI-ESP (`ParcelamentoObterOrdinarioAsync`)

```csharp
var resposta = await servico.ParcelamentoObterOrdinarioAsync(
    ModalidadeParcelamento.PARCSN,
    contribuinte,
    new ConsultaParcelamento { NumeroParcelamento = 2 });

if (resposta.Sucesso && resposta.Retorno is { } parc)
{
    var consolidacao = parc.ConsolidacaoOriginal!;
    Console.WriteLine($"Nº {parc.Numero} ({parc.Situacao}): R$ {consolidacao.ValorTotalConsolidado:N2} em {consolidacao.QuantidadeParcelas}x de R$ {consolidacao.ParcelaBasica:N2}");

    foreach (var debito in consolidacao.DetalhesConsolidacao ?? [])
        Console.WriteLine($"  PA {debito.PeriodoApuracao}: original {debito.SaldoDevedorOriginal:N2}, atualizado {debito.ValorAtualizado:N2}");

    foreach (var alteracao in parc.AlteracoesDivida ?? [])
    {
        // PARCSN/PARCSN-ESP: DetalhesConsolidacao; PARCMEI/PARCMEI-ESP: DetalhesAlteracaoDivida
        var debitos = alteracao.DetalhesConsolidacao ?? alteracao.DetalhesAlteracaoDivida ?? [];
        Console.WriteLine($"  Alteração {alteracao.DataAlteracaoDivida}: {alteracao.ParcelasRemanescentes} parcelas de R$ {alteracao.ParcelaBasica:N2} ({debitos.Count} débitos)");
    }

    foreach (var pagamento in parc.DemonstrativoPagamentos ?? [])
        Console.WriteLine($"  Parcela {pagamento.MesDaParcela} paga em {pagamento.DataDeArrecadacao}: R$ {pagamento.ValorPago:N2}");
}
```

**Retorno (fictício)**

```json
{
  "numero": 2,
  "dataDoPedido": 20250310,
  "situacao": "Em parcelamento",
  "dataDaSituacao": 20250310,
  "consolidacaoOriginal": {
    "valorTotalConsolidado": 24742.20,
    "quantidadeParcelas": 60,
    "primeiraParcela": 412.37,
    "parcelaBasica": 412.37,
    "dataConsolidacao": 20250310143512,
    "detalhesConsolidacao": [
      { "periodoApuracao": 202401, "vencimento": 20240220, "numeroProcesso": "", "saldoDevedorOriginal": 9850.00, "valorAtualizado": 11203.45 },
      { "periodoApuracao": 202402, "vencimento": 20240320, "numeroProcesso": "", "saldoDevedorOriginal": 11980.10, "valorAtualizado": 13538.75 }
    ]
  },
  "alteracoesDivida": [
    {
      "valorTotalConsolidado": 18970.02,
      "parcelasRemanescentes": 46,
      "parcelaBasica": 412.39,
      "dataAlteracaoDivida": 20260115,
      "detalhesConsolidacao": [
        { "periodoApuracao": 202402, "vencimento": 20240320, "numeroProcesso": "", "saldoDevedorOriginal": 11980.10, "valorAtualizado": 13538.75 }
      ]
    }
  ],
  "demonstrativoPagamentos": [
    { "mesDaParcela": 202504, "vencimentoDoDas": 20250430, "dataDeArrecadacao": 20250428, "valorPago": 412.37 },
    { "mesDaParcela": 202505, "vencimentoDoDas": 20250530, "dataDeArrecadacao": 20250529, "valorPago": 412.37 }
  ]
}
```

Mensagens: `[Sucesso-PARCSN]` — Requisição efetuada com sucesso.

> [!NOTE]
> `ParcelamentoObterOrdinarioAsync` lança `ArgumentOutOfRangeException` (sem enviar a requisição) se a modalidade for PERTSN, PERTMEI, RELPSN ou RELPMEI. Nas alterações da dívida, a documentação do PARCSN/PARCSN-ESP nomeia os débitos `detalhesConsolidacao` e a do PARCMEI/PARCMEI-ESP `detalhesAlteracaoDivida`; `AlteracaoDividaOrdinaria` mapeia os dois.

### PERTSN (`ParcelamentoObterPertSnAsync`)

```csharp
var resposta = await servico.ParcelamentoObterPertSnAsync(contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9102 });

if (resposta.Sucesso && resposta.Retorno is { } parc)
{
    var entrada = parc.ConsolidacaoOriginal!;
    Console.WriteLine($"Entrada: {entrada.QuantidadeParcelasDeEntrada}x de R$ {entrada.ParcelaDeEntrada:N2} (total R$ {entrada.ValorTotalConsolidadoDaEntrada:N2}); dívida R$ {entrada.ValorConsolidadoDaDivida:N2}");

    foreach (var alteracao in parc.AlteracoesDivida ?? [])
        Console.WriteLine($"Alteração {alteracao.DataAlteracaoDivida}: R$ {alteracao.TotalConsolidado:N2} (principal {alteracao.ValorConsolidadoPrincipal:N2}) em {alteracao.ParcelasRemanescentes}x de R$ {alteracao.ParcelaBasica:N2}");
}
```

**Dados enviados**: `{"numeroParcelamento":9102}`

**Retorno (fictício)**

```json
{
  "numero": 9102,
  "dataDoPedido": 20180619,
  "situacao": "Em parcelamento",
  "dataDaSituacao": 20230831,
  "consolidacaoOriginal": {
    "valorTotalConsolidadoDaEntrada": 2687.15,
    "quantidadeParcelasDeEntrada": 5,
    "parcelaDeEntrada": 537.43,
    "dataConsolidacao": 20180619155825,
    "valorConsolidadoDaDivida": 53742.98,
    "detalhesConsolidacao": [
      { "periodoApuracao": 201511, "vencimento": 20151221, "numeroProcesso": "", "saldoDevedorOriginal": 3156.80, "valorAtualizado": 4619.91 }
    ]
  },
  "alteracoesDivida": [
    {
      "totalConsolidado": 45089.05,
      "parcelasRemanescentes": 145,
      "parcelaBasica": 310.96,
      "dataAlteracaoDivida": 202308311053,
      "valorConsolidadoPrincipal": 40435.41,
      "detalhesAlteracaoDivida": [
        { "periodoApuracao": 201511, "vencimento": 20151221, "numeroProcesso": "12376094286201915", "saldoDevedorOriginal": 1679.07, "valorAtualizado": 1935.42 }
      ]
    }
  ],
  "demonstrativoPagamentos": [
    { "mesDaParcela": 201806, "vencimentoDoDas": 20180629, "dataDeArrecadacao": 20180628, "valorPago": 537.43 }
  ]
}
```

Mensagens: `[Sucesso-PERTSN]` — Requisição efetuada com sucesso.

> [!NOTE]
> `ConsolidacaoPertSn` segue o exemplo de retorno da documentação: a tabela oficial cita `parcelasRemanescentes` e `parcelaBasicaDaEntrada`, ausentes do exemplo. Em `AlteracaoDividaPertSn`, `DataAlteracaoDivida` vem no formato AAAAMMDDHHMM.

### PERTMEI (`ParcelamentoObterPertMeiAsync`)

```csharp
var resposta = await servico.ParcelamentoObterPertMeiAsync(contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9101 });

if (resposta.Sucesso && resposta.Retorno is { } parc)
{
    var entrada = parc.ConsolidacaoOriginal!;
    Console.WriteLine($"Entrada: {entrada.QuantidadeParcelasDaEntrada}x de R$ {entrada.ParcelaBasicaDaEntrada:N2}; dívida R$ {entrada.ValorTotalConsolidadoDaDivida:N2}");

    foreach (var restante in parc.ConsolidacoesRestanteDivida ?? [])
        Console.WriteLine($"Restante confirmado em {restante.DataConfirmacaoConsolidacao}: R$ {restante.ValorTotalConsolidadoDivida:N2} em {restante.ParcelasRemanescentes}x de R$ {restante.ParcelaBasica:N2}");
}
```

**Dados enviados**: `{"numeroParcelamento":9101}`

**Retorno (fictício)**

```json
{
  "numero": 9101,
  "dataDoPedido": 20180623,
  "situacao": "Em parcelamento",
  "dataDaSituacao": 20181119,
  "consolidacaoOriginal": {
    "valorTotalConsolidadoDaEntrada": 211.48,
    "quantidadeParcelasDaEntrada": 4,
    "parcelaBasicaDaEntrada": 52.87,
    "dataConsolidacao": 20180623121350,
    "valorTotalConsolidadoDaDivida": 4229.59,
    "detalhesConsolidacao": [
      { "periodoApuracao": 201208, "vencimento": 20120920, "numeroProcesso": "", "saldoDevedorOriginal": 31.10, "valorAtualizado": 55.64 }
    ]
  },
  "consolidacoesRestanteDivida": [
    {
      "valorTotalConsolidadoDivida": 3145.56,
      "parcelasRemanescentes": 62,
      "parcelaBasica": 50.73,
      "dataConfirmacaoConsolidacao": 20181119,
      "detalhesConsolidacao": [
        { "periodoApuracao": 201211, "vencimento": 20121220, "numeroProcesso": "", "saldoDevedorOriginal": 31.10, "valorAtualizado": 30.17 }
      ]
    }
  ],
  "demonstrativoPagamentos": []
}
```

Mensagens: `[Sucesso-PERTMEI]` — Requisição efetuada com sucesso.

### RELPSN (`ParcelamentoObterRelpSnAsync`)

```csharp
var resposta = await servico.ParcelamentoObterRelpSnAsync(contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9131 });

if (resposta.Sucesso && resposta.Retorno is { } parc)
{
    var entrada = parc.ConsolidacaoOriginal!;
    Console.WriteLine($"Entrada: {entrada.QuantidadeParcelasDeEntrada}x de R$ {entrada.ParcelaDeEntrada:N2}; dívida R$ {entrada.ValorConsolidadoDivida:N2}");

    foreach (var alteracao in parc.AlteracoesDivida ?? [])
    {
        // 1 = consolidação do restante da dívida; 2 = reconsolidação por alteração de débitos
        Console.WriteLine($"Alteração {alteracao.DataAlteracaoDivida} (tipo {alteracao.IdentificadorConsolidacao}): R$ {alteracao.ValorRemanescenteComReducoes:N2} com reduções");
        foreach (var faixa in alteracao.ParcelasAlteracao ?? [])
            Console.WriteLine($"  {faixa.FaixaParcelas} a partir de {faixa.ParcelaInicial} (venc. {faixa.VencimentoInicial}): R$ {faixa.ParcelaBasica:N2}");
    }
}
```

**Dados enviados**: `{"numeroParcelamento":9131}`

**Retorno (fictício)**

```json
{
  "numero": 9131,
  "dataDoPedido": 20220520,
  "situacao": "Em parcelamento",
  "dataDaSituacao": 20230120,
  "consolidacaoOriginal": {
    "valorTotalConsolidadoDeEntrada": 2801.50,
    "quantidadeParcelasDeEntrada": 8,
    "parcelaDeEntrada": 350.18,
    "dataConsolidacao": 20220520164440,
    "valorConsolidadoDivida": 22412.05,
    "detalhesConsolidacao": [
      { "periodoApuracao": 201812, "vencimento": 20190121, "numeroProcesso": "", "saldoDevedorOriginal": 8310.35, "valorAtualizado": 12054.06 }
    ]
  },
  "alteracoesDivida": [
    {
      "dataAlteracaoDivida": 202301201620,
      "identificadorConsolidacao": 1,
      "saldoDevedorOriginalSemReducoes": 14457.75,
      "valorRemanescenteComReducoes": 20810.71,
      "partePrevidenciaria": 9037.79,
      "demaisDebitos": 11778.92,
      "detalhesConsolidacao": [
        { "periodoApuracao": 201812, "vencimento": 20190121, "numeroProcesso": "", "saldoDevedorOriginal": 8310.35, "valorAtualizado": 12054.06 }
      ],
      "parcelasAlteracao": [
        { "faixaParcelas": "1ª a 12ª", "parcelaInicial": 202301, "vencimentoInicial": 20230131, "parcelaBasica": 300.00 }
      ]
    }
  ],
  "demonstrativoPagamentos": []
}
```

Mensagens: `[Sucesso-RELPSN]` — Requisição efetuada com sucesso.

### RELPMEI (`ParcelamentoObterRelpMeiAsync`)

```csharp
var resposta = await servico.ParcelamentoObterRelpMeiAsync(contribuinte, new ConsultaParcelamento { NumeroParcelamento = 9001 });

if (resposta.Sucesso && resposta.Retorno is { } parc)
{
    var entrada = parc.ConsolidacaoOriginal!; // ValorConsolidadoDivida é sempre nulo no RELPMEI
    Console.WriteLine($"Entrada: {entrada.QuantidadeParcelasDeEntrada}x de R$ {entrada.ParcelaDeEntrada:N2}");

    foreach (var alteracao in parc.AlteracoesDividas ?? []) // plural no RELPMEI
        Console.WriteLine($"Alteração {alteracao.DataAlteracaoDivida}: previdenciário R$ {alteracao.PartePrevidenciaria:N2}, demais R$ {alteracao.DemaisDebitos:N2}");
}
```

**Dados enviados**: `{"numeroParcelamento":9001}`

**Retorno (fictício)**

```json
{
  "numero": 9001,
  "dataDoPedido": 20220519,
  "situacao": "Em parcelamento",
  "dataDaSituacao": 20230406,
  "consolidacaoOriginal": {
    "valorTotalConsolidadoDeEntrada": 453.85,
    "quantidadeParcelasDeEntrada": 8,
    "parcelaDeEntrada": 56.73,
    "dataConsolidacao": 20220519143508,
    "detalhesConsolidacao": []
  },
  "alteracoesDividas": [
    {
      "dataAlteracaoDivida": 202304061015,
      "identificadorConsolidacao": 2,
      "saldoDevedorOriginalSemReducoes": 4120.40,
      "valorRemanescenteComReducoes": 3210.88,
      "partePrevidenciaria": 2450.12,
      "demaisDebitos": 760.76,
      "detalhesConsolidacao": [
        { "periodoApuracao": 202001, "vencimento": 20200220, "numeroProcesso": "", "saldoDevedorOriginal": 57.25, "valorAtualizado": 78.90 }
      ],
      "parcelasAlteracao": [
        { "faixaParcelas": "1ª a 12ª", "parcelaInicial": 202305, "vencimentoInicial": 20230531, "parcelaBasica": 32.11 },
        { "faixaParcelas": "13ª a 180ª", "parcelaInicial": 202405, "vencimentoInicial": 20240531, "parcelaBasica": 17.04 }
      ]
    }
  ],
  "demonstrativoPagamentos": [
    { "mesDaParcela": 202305, "vencimentoDoDas": 20230531, "dataDeArrecadacao": 20230530, "valorPago": 32.11 }
  ]
}
```

Mensagens: `[Sucesso-RELPMEI]` — Requisição efetuada com sucesso.

> [!NOTE]
> O RELPMEI difere do RELPSN pelo nome da lista (`alteracoesDividas`, no plural → `ParcelamentoRelpMei.AlteracoesDividas`) e pela ausência de `valorConsolidadoDivida`. Em ambos, `ConsolidacaoRelp` usa `valorTotalConsolidadoDeEntrada` (como nos exemplos de retorno; a tabela do RELPSN cita `valorTotalConsolidadoDaEntrada`).

### Genérico — `ParcelamentoObterAsync<T>` + `TipoParcelamentoDetalhado`

`ParcelamentoObterAsync<T>` aceita qualquer modalidade e desserializa no layout `T` (derivado de `ParcelamentoDetalhado`). O método estático `IntegraContadorService.TipoParcelamentoDetalhado(modalidade)` informa o layout de cada modalidade, útil para percorrer todas elas:

```csharp
// layout esperado de cada modalidade
foreach (var modalidade in Enum.GetValues<ModalidadeParcelamento>())
    Console.WriteLine($"{modalidade}: {IntegraContadorService.TipoParcelamentoDetalhado(modalidade).Name}");

// chamada genérica (equivale a ParcelamentoObterOrdinarioAsync, mas sem a validação da modalidade)
var parcmei = await servico.ParcelamentoObterAsync<ParcelamentoOrdinario>(
    ModalidadeParcelamento.PARCMEI, contribuinte, new ConsultaParcelamento { NumeroParcelamento = 3 });

// percorrendo todas as modalidades: pedidos + detalhamento no layout correto
async Task<ParcelamentoDetalhado?> ObterAsync(ModalidadeParcelamento modalidade, int numero)
{
    var consulta = new ConsultaParcelamento { NumeroParcelamento = numero };
    return modalidade switch
    {
        ModalidadeParcelamento.PERTSN => (await servico.ParcelamentoObterPertSnAsync(contribuinte, consulta)).Retorno,
        ModalidadeParcelamento.PERTMEI => (await servico.ParcelamentoObterPertMeiAsync(contribuinte, consulta)).Retorno,
        ModalidadeParcelamento.RELPSN => (await servico.ParcelamentoObterRelpSnAsync(contribuinte, consulta)).Retorno,
        ModalidadeParcelamento.RELPMEI => (await servico.ParcelamentoObterRelpMeiAsync(contribuinte, consulta)).Retorno,
        _ => (await servico.ParcelamentoObterOrdinarioAsync(modalidade, contribuinte, consulta)).Retorno
    };
}

foreach (var modalidade in Enum.GetValues<ModalidadeParcelamento>())
{
    var pedidos = await servico.ParcelamentoConsultarPedidosAsync(modalidade, contribuinte);
    foreach (var pedido in pedidos.Retorno?.Parcelamentos?.Where(p => p.Situacao == "Em parcelamento") ?? [])
    {
        var parc = await ObterAsync(modalidade, pedido.Numero!.Value);
        Console.WriteLine($"{modalidade} nº {parc?.Numero}: {parc?.DemonstrativoPagamentos?.Count ?? 0} parcelas pagas");
    }
}
```

> [!NOTE]
> Se `T` não corresponder ao layout da modalidade, os campos específicos (consolidação/alterações) ficam nulos — apenas os campos de `ParcelamentoDetalhado` são garantidos. Prefira os métodos tipados.

---

## 💳 DETPAGTOPARC{p}5 — Consultar detalhes de pagamento de parcela

```csharp
var resposta = await servico.ParcelamentoConsultarDetalhePagamentoAsync(
    ModalidadeParcelamento.PARCSN,
    contribuinte,
    new ConsultaDetalhePagamento
    {
        NumeroParcelamento = 2,
        AnoMesParcela = 202609 // AAAAMM da parcela paga
    });

if (resposta.Sucesso && resposta.Retorno is { } pagto)
{
    Console.WriteLine($"DAS {pagto.NumeroDas} (parcela {pagto.NumeroParcela}) pago em {pagto.DataPagamento}: R$ {pagto.ValorPagoArrecadacao:N2}");

    foreach (var debito in pagto.PagamentoDebitos ?? [])
        foreach (var tributo in debito.DiscriminacoesDebito ?? [])
            Console.WriteLine($"  PA {debito.PaDebito} {tributo.Tributo} ({tributo.EnteFederadoDestino}): {tributo.Principal:N2} + {tributo.Multa:N2} + {tributo.Juros:N2} = {tributo.Total:N2}");
}
```

**Dados enviados** (`pedidoDados.dados`)

```json
{"numeroParcelamento":2,"anoMesParcela":202609}
```

**Retorno (fictício)**

```json
{
  "numeroDas": "07202609123456789",
  "dataVencimento": 20260930,
  "paDasGerado": 202609,
  "geradoEm": "20260915101530",
  "numeroParcelamento": "2",
  "numeroParcela": "19",
  "dataLimiteAcolhimento": 20260930,
  "pagamentoDebitos": [
    {
      "paDebito": 202401,
      "processo": "",
      "discriminacoesDebito": [
        { "tributo": "IRPJ", "principal": 120.00, "multa": 24.00, "juros": 15.60, "total": 159.60, "enteFederadoDestino": "União" },
        { "tributo": "ISS", "principal": 190.00, "multa": 38.00, "juros": 24.77, "total": 252.77, "enteFederadoDestino": "SAO PAULO" }
      ]
    }
  ],
  "dataPagamento": 20260929,
  "bancoAgencia": "1/3456",
  "valorPagoArrecadacao": 412.37
}
```

Mensagens: `[Sucesso-PARCSN]` — Requisição efetuada com sucesso.

> [!NOTE]
> A documentação de algumas modalidades tipa `numeroDas`, `geradoEm`, `numeroParcelamento`, `numeroParcela`, `bancoAgencia` e `processo` ora como texto, ora como número; esses campos são `string` e aceitam os dois formatos. Datas são inteiros AAAAMMDD (ou AAAAMM / AAAAMMDDHHMMSS, conforme o campo).
