# SICALC — Integra-Sicalc

O **Sicalc** (Sistema de Cálculo de Acréscimos Legais) consolida débitos de receitas federais — calculando multa de mora e juros até a data de pagamento — e emite o **Darf** em PDF ou apenas o seu código de barras (com Pix). O serviço de apoio informa, para cada receita, quais campos são obrigatórios/opcionais na consolidação.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `CONSOLIDARGERARDARF51` | `/Emitir` | 2.9 | `SicalcConsolidarGerarDarfAsync` | `RetornoDarf` |
| `CONSULTAAPOIORECEITAS52` | `/Apoiar` | 2.9 | `SicalcConsultarReceitaAsync` | `RetornoConsultaReceita` |
| `GERARDARFCODBARRA53` | `/Emitir` | 2.9 | `SicalcGerarDarfCodigoBarrasAsync` | `RetornoDarfCodigoBarras` |
| `CONSOLIDAR54` | `/Consultar` | 2.9 | `SicalcConsolidarAsync` | `RetornoConsolidacao` |

Os identificadores estão em `Catalogo.Sicalc` (`ConsolidarGerarDarf`, `ConsultarReceitas`, `GerarDarfCodigoBarras`, `Consolidar`).

---

## 🚀 Preparação

Os exemplos consideram o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço) e o contribuinte abaixo:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSicalc;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

Os serviços 51, 53 e 54 recebem a mesma entrada, `ConsolidarDarf`. O débito usado nos exemplos é um IRRF (receita **1708-01**) de setembro/2025, vencido em 20/10/2025 e consolidado para pagamento em 14/11/2025:

```csharp
var debito = new ConsolidarDarf
{
    Uf = "SP",
    Municipio = "7107",                        // código TOM da RFB (São Paulo), não o código IBGE
    CodigoReceita = "1708",
    CodigoReceitaExtensao = "01",
    TipoPA = "ME",                             // mensal
    DataPA = "09/2025",                        // mm/aaaa (formato conforme o TipoPA)
    Vencimento = new DateTime(2025, 10, 20),
    ValorImposto = 1500.00m,
    DataConsolidacao = new DateTime(2025, 11, 14), // data prevista para o pagamento (padrão: DateTime.Today)
    Observacao = "IRRF s/ serviços - NF 1234",
    CnpjPrestador = "11222333000181"
};
```

---

## 🔎 CONSULTAAPOIORECEITAS52 — Consultar receita

Serviço de apoio (não tarifado) que retorna as extensões da receita e indica quais campos de `ConsolidarDarf` são obrigatórios ou opcionais, e se a receita aceita código de barras. Recomenda-se consultá-lo antes de consolidar uma receita pela primeira vez.

```csharp
var resposta = await servico.SicalcConsultarReceitaAsync(contribuinte, "1708");

if (resposta.Sucesso)
{
    var receita = resposta.Retorno!.Receita!;
    Console.WriteLine($"{receita.CodigoReceita} - {receita.DescricaoReceita}");

    foreach (var extensao in receita.Extensoes ?? [])
    {
        var info = extensao.Informacoes;
        Console.WriteLine($"Extensão {info?.CodigoReceitaExtensao}: {info?.DescricaoReceitaExtensao}");
        Console.WriteLine($"  Período: {info?.TipoPeriodoApuracao} | Código de barras: {info?.CodigoBarras} | Manual: {info?.Manual}");
        Console.WriteLine($"  Vencimento obrigatório: {extensao.Obrigatorios?.Vencimento} | Cota obrigatória: {extensao.Obrigatorios?.Cota}");
        Console.WriteLine($"  Aceita município: {extensao.Opcionais?.Municipio} | Aceita CNPJ do prestador: {extensao.Opcionais?.CnpjPrestador}");
    }
}
```

#### Dados enviados
```json
{
  "codigoReceita": "1708"
}
```

#### Retorno (fictício)
```json
{
  "receita": {
    "codigoReceita": 1708,
    "descricaoReceita": "IRRF - Remuneração de Serviços Prestados por Pessoa Jurídica",
    "extensoes": [
      {
        "obrigatorios": {
          "codigoReceita": true,
          "codigoReceitaExtensao": true,
          "cota": false,
          "dataConsolidacao": true,
          "dataPA": true,
          "referencia": false,
          "tipoPA": true,
          "valorImposto": true,
          "vencimento": true
        },
        "opcionais": {
          "cno": false,
          "cnpjPrestador": true,
          "dataAlienacao": false,
          "ganhoCapital": false,
          "municipio": true,
          "observacao": true,
          "referencia": false,
          "uf": true,
          "valorJuros": false,
          "valorMulta": false
        },
        "informacoes": {
          "calculado": true,
          "codigoBarras": true,
          "codigoReceitaExtensao": 1,
          "criacao": "1997-01-01T00:00:00",
          "descricaoReceitaExtensao": "IRRF - SERVIÇOS PRESTADOS POR PJ",
          "descricaoReferencia": "SEM REFERÊNCIA",
          "exigeMatriz": false,
          "manual": false,
          "pf": false,
          "pj": true,
          "tipoPeriodoApuracao": "ME",
          "vedaValor": true
        }
      }
    ]
  }
}
```
Mensagens: `[Sucesso-SICALC] Requisição efetuada com sucesso.`

> [!NOTE]
> `codigoReceita` e `codigoReceitaExtensao` podem vir como número ou texto; são lidos como `string` (`"1708"`, `"1"`). A documentação também traz exemplos em que cada categoria (`obrigatorios`, `opcionais`, `informacoes`) vem em um item separado do array `extensoes` — ambos os formatos são aceitos.

---

## 🧾 CONSOLIDARGERARDARF51 — Consolidar e emitir Darf (PDF)

Calcula os acréscimos legais e emite o Darf em PDF (Base64), com o número do documento e o código Pix.

```csharp
var resposta = await servico.SicalcConsolidarGerarDarfAsync(contribuinte, debito);

if (resposta.Sucesso)
{
    var retorno = resposta.Retorno!;
    var consolidado = retorno.Consolidado!;
    Console.WriteLine($"Principal: {consolidado.ValorPrincipalMoedaCorrente:N2}");
    Console.WriteLine($"Multa ({consolidado.PercentualMultaMora}%): {consolidado.ValorMultaMora:N2}");
    Console.WriteLine($"Juros ({consolidado.PercentualJuros}%): {consolidado.ValorJuros:N2}");
    Console.WriteLine($"Total: {consolidado.ValorTotalConsolidado:N2} - pagar até {consolidado.DataValidadeCalculo:dd/MM/yyyy}");

    File.WriteAllBytes($@"C:\Darf\{retorno.NumeroDocumento}.pdf", Convert.FromBase64String(retorno.Darf!));

    if (retorno.QrCode is { } pix)
        Console.WriteLine($"Pix copia e cola: {pix}");
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

#### Dados enviados
```json
{
  "uf": "SP",
  "municipio": "7107",
  "codigoReceita": "1708",
  "codigoReceitaExtensao": "01",
  "tipoPA": "ME",
  "dataPA": "09/2025",
  "vencimento": "2025-10-20T00:00:00",
  "valorImposto": "1500.00",
  "dataConsolidacao": "2025-11-14T00:00:00",
  "observacao": "IRRF s/ serviços - NF 1234",
  "cnpjPrestador": "11222333000181"
}
```

#### Retorno (fictício)
```json
{
  "consolidado": {
    "valorPrincipalMoedaCorrente": 1500.00,
    "valorTotalConsolidado": 1638.75,
    "valorMultaMora": 123.75,
    "percentualMultaMora": 8.25,
    "valorJuros": 15.00,
    "percentualJuros": 1.00,
    "termoInicialJuros": "2025-11-01T00:00:00",
    "dataArrecadacaoConsolidacao": "2025-11-14T00:00:00",
    "dataValidadeCalculo": "2025-11-28T00:00:00"
  },
  "darf": "JVBERi0xLjQK...",
  "numeroDocumento": "07012531800123456",
  "qrCode": "00020101021226900014br.gov.bcb.pix..."
}
```
Mensagens: `[Sucesso-SICALC] Requisição efetuada com sucesso.`

---

## 🔢 GERARDARFCODBARRA53 — Consolidar e gerar código de barras

Mesma consolidação do serviço 51, mas retorna o código de barras (44 posições) e os campos da linha digitável em vez do PDF. A receita/extensão deve permitir código de barras (`InformacoesReceita.CodigoBarras` no serviço 52).

```csharp
var resposta = await servico.SicalcGerarDarfCodigoBarrasAsync(contribuinte, debito);

if (resposta.Sucesso)
{
    var retorno = resposta.Retorno!;
    var codigo = retorno.CodigoDeBarras!;
    Console.WriteLine($"Documento: {retorno.NumeroDocumento}");
    Console.WriteLine($"Total: {retorno.Consolidado?.ValorTotalConsolidado:N2}");
    Console.WriteLine($"Código de barras: {codigo.Codigo44}");
    Console.WriteLine($"Linha digitável: {codigo.Campo1ComDV} {codigo.Campo2ComDV} {codigo.Campo3ComDV} {codigo.Campo4ComDV}");
    Console.WriteLine($"Pix: {retorno.QrCode ?? "(não retornado)"}");
}
```

#### Dados enviados
Idênticos aos do serviço 51:
```json
{
  "uf": "SP",
  "municipio": "7107",
  "codigoReceita": "1708",
  "codigoReceitaExtensao": "01",
  "tipoPA": "ME",
  "dataPA": "09/2025",
  "vencimento": "2025-10-20T00:00:00",
  "valorImposto": "1500.00",
  "dataConsolidacao": "2025-11-14T00:00:00",
  "observacao": "IRRF s/ serviços - NF 1234",
  "cnpjPrestador": "11222333000181"
}
```

#### Retorno (fictício)
```json
{
  "consolidado": {
    "valorPrincipalMoedaCorrente": 1500.00,
    "valorTotalConsolidado": 1638.75,
    "valorMultaMora": 123.75,
    "percentualMultaMora": 8.25,
    "valorJuros": 15.00,
    "percentualJuros": 1.00,
    "termoInicialJuros": "2025-11-01T00:00:00",
    "dataArrecadacaoConsolidacao": "2025-11-14T00:00:00",
    "dataValidadeCalculo": "2025-11-28T00:00:00"
  },
  "codigoDeBarras": {
    "codigo44": "85800000016387503852025111407012531800123456",
    "campo1ComDV": "858000000164",
    "campo2ComDV": "387503852021",
    "campo3ComDV": "511140701257",
    "campo4ComDV": "318001234562"
  },
  "numeroDocumento": "07012531800123456",
  "qrCode": "00020101021226900014br.gov.bcb.pix..."
}
```
Mensagens: `[Sucesso-SICALC] Requisição efetuada com sucesso.`

---

## 🧮 CONSOLIDAR54 — Consolidar sem emitir Darf

Apenas calcula os acréscimos legais (útil para simular o valor a pagar em uma data), sem emitir documento.

```csharp
var resposta = await servico.SicalcConsolidarAsync(contribuinte, debito);

if (resposta.Sucesso && resposta.Retorno?.Consolidado is { } consolidado)
{
    Console.WriteLine($"Juros a partir de {consolidado.TermoInicialJuros:dd/MM/yyyy}");
    Console.WriteLine($"Total em {consolidado.DataArrecadacaoConsolidacao:dd/MM/yyyy}: {consolidado.ValorTotalConsolidado:N2}");
}
```

#### Dados enviados
Idênticos aos do serviço 51 (mesmo `debito`).

#### Retorno (fictício)
```json
{
  "consolidado": {
    "valorPrincipalMoedaCorrente": "1500.00",
    "valorTotalConsolidado": "1638.75",
    "valorMultaMora": "123.75",
    "percentualMultaMora": "8.25",
    "valorJuros": "15.00",
    "percentualJuros": "1.00",
    "termoInicialJuros": "2025-11-01T00:00:00",
    "dataArrecadacaoConsolidacao": "2025-11-14T00:00:00",
    "dataValidadeCalculo": "2025-11-28T00:00:00"
  }
}
```
Mensagens: `[Sucesso-SICALC] Requisição efetuada com sucesso.`

> [!NOTE]
> Os valores consolidados podem vir como número ou como texto (como neste exemplo); ambos são lidos como `decimal`. O catálogo oficial não publica página de detalhamento do CONSOLIDAR54 — a versão `2.9` e o endpoint `/Consultar` são presumidos.

---

## ✍️ Outras combinações de entrada

Débito com **cota** (sem `Vencimento`) e **ganho de capital** (receita 4600-02, de pessoa física):

```csharp
var pessoaFisica = Identificacao.Cpf("00000000191");

var ganhoCapital = new ConsolidarDarf
{
    CodigoReceita = "4600",
    CodigoReceitaExtensao = "02",
    TipoPA = "ME",
    DataPA = "08/2025",
    Cota = 1,                                   // excludente com Vencimento
    ValorImposto = 3750.00m,
    GanhoCapital = true,                        // obrigatório para 4600-02
    DataAlienacao = new DateTime(2025, 8, 15),  // obrigatório para 4600-02
    DataConsolidacao = new DateTime(2025, 11, 14)
};

var resposta = await servico.SicalcConsolidarGerarDarfAsync(pessoaFisica, ganhoCapital);
```

```json
{
  "codigoReceita": "4600",
  "codigoReceitaExtensao": "02",
  "tipoPA": "ME",
  "dataPA": "08/2025",
  "cota": "1",
  "valorImposto": "3750.00",
  "ganhoCapital": true,
  "dataAlienacao": "2025-08-15T00:00:00",
  "dataConsolidacao": "2025-11-14T00:00:00"
}
```

> [!NOTE]
> - Os campos numéricos de `ConsolidarDarf` (`ValorImposto`, `ValorMulta`, `ValorJuros`, `Cota`) são enviados **como texto** (`"1500.00"`, `"1"`), como nos exemplos da documentação; o `decimal` mantém as casas informadas (`1500.00m` → `"1500.00"`, `12.5m` → `"12.5"`). Datas são enviadas como `yyyy-MM-ddTHH:mm:ss`, sem fuso.
> - `Cota` e `Vencimento` são mutuamente excludentes. `ValorMulta` e `ValorJuros` só devem ser preenchidos em Darf **manual** (`InformacoesReceita.Manual`). `NumeroReferencia`, `Cno` e `CnpjPrestador` dependem da receita — consulte o serviço 52.
> - `Municipio` usa a Tabela de Órgãos e Municípios (TOM) da RFB, sem dígito verificador (ex.: `9701` = Brasília); códigos IBGE não são aceitos. Sem `Uf`/`Municipio`, podem ser usados os dados cadastrais do contribuinte.
> - `DataConsolidacao` tem valor padrão `DateTime.Today`.
> - `QrCode` (Pix) pode vir ausente quando a instituição financeira não o retorna (Aviso-SICALC-001).
> - Os JSONs acima são mostrados sem escapes; na requisição real, caracteres não ASCII (ex.: `ç`) são enviados escapados (`\u00E7`), o que é equivalente.
