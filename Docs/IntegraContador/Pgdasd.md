# PGDASD — Programa Gerador do DAS do Simples Nacional

O sistema **PGDASD** (solução Integra-SN) permite entregar a declaração mensal do Simples Nacional (PGDAS-D), consultar declarações e recibos e gerar o DAS (normal, de cobrança, de processo e avulso). Os bodies ficam no namespace `EficazFramework.SPED.Schemas.IntegraContador.IntegraSN`; o `Das` de retorno é compartilhado com o PGMEI e fica em `EficazFramework.SPED.Schemas.IntegraContador`.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `TRANSDECLARACAO11` | Declarar | 1.0 | `PgdasdTransmitirDeclaracaoAsync` | `DeclaracaoTransmitida` |
| `GERARDAS12` | Emitir | 1.0 | `PgdasdGerarDasAsync` | `List<Das>` |
| `CONSDECLARACAO13` | Consultar | 1.0 | `PgdasdConsultarDeclaracoesAsync` | `DeclaracoesEntregues` |
| `CONSULTIMADECREC14` | Consultar | 1.0 | `PgdasdConsultarUltimaDeclaracaoAsync` | `DeclaracaoRecibo` |
| `CONSDECREC15` | Consultar | 1.0 | `PgdasdConsultarDeclaracaoAsync` | `DeclaracaoRecibo` |
| `CONSEXTRATO16` | Consultar | 1.0 | `PgdasdConsultarExtratoDasAsync` | `ExtratoDas` |
| `GERARDASCOBRANCA17` | Emitir | 1.0 | `PgdasdGerarDasCobrancaAsync` | `Das` |
| `GERARDASPROCESSO18` | Emitir | 1.0 | `PgdasdGerarDasProcessoAsync` | `Das` |
| `GERARDASAVULSO19` | Emitir | 1.0 | `PgdasdGerarDasAvulsoAsync` | `Das` |

Os identificadores também estão em `Catalogo.Pgdasd` (ex.: `Catalogo.Pgdasd.GerarDas`).

---

## 🔑 Pré-requisito

Os exemplos abaixo assumem o `servico` configurado conforme [Configurando o serviço](../IntegraContador.md#-configurando-o-serviço) e o contribuinte:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

> [!NOTE]
> Todos os métodos lançam `ArgumentNullException` quando `dados` é `null`. Erros HTTP **não** lançam exceção: verifique `resposta.Sucesso`, `resposta.StatusCode` e `resposta.Mensagens`. Os exemplos de "Dados enviados" mostram o conteúdo de `pedidoDados.dados` (o framework o envia como texto JSON); os de "Retorno" mostram o conteúdo de `dados` já decodificado (o Base64 dos PDFs está truncado).

---

## 📤 TRANSDECLARACAO11 — Entregar declaração mensal

Transmite a declaração original ou retificadora do período de apuração. Com `IndicadorTransmissao = false`, o serviço apenas calcula e devolve os valores devidos, sem transmitir.

```csharp
var dados = new TransmitirDeclaracao
{
    CnpjCompleto = "00000000000100",
    Pa = 202501,
    IndicadorTransmissao = true,
    IndicadorComparacao = true, // compara ValoresParaComparacao com o valor apurado (diferença de 0,01 impede a transmissão)
    Declaracao = new DeclaracaoPgdasd
    {
        TipoDeclaracao = 1, // 1 - Original; 2 - Retificadora
        ReceitaPaCompetenciaInterno = 12345.67m,
        ReceitaPaCompetenciaExterno = 0m,
        ReceitasBrutasAnteriores =
        [
            // informe todos os períodos anteriores exigidos pelo cálculo (RBT12); dois meses apenas para ilustrar
            new ReceitaBrutaAnterior { Pa = 202411, ValorInterno = 10500m, ValorExterno = 0m },
            new ReceitaBrutaAnterior { Pa = 202412, ValorInterno = 11800.5m, ValorExterno = 0m }
        ],
        FolhasSalario =
        [
            new FolhaSalario { Pa = 202411, Valor = 3500m },
            new FolhaSalario { Pa = 202412, Valor = 3500m }
        ],
        Estabelecimentos =
        [
            new Estabelecimento
            {
                CnpjCompleto = "00000000000100",
                Atividades =
                [
                    new Atividade
                    {
                        IdAtividade = 1,
                        ValorAtividade = 12345.67m,
                        ReceitasAtividade = [new ReceitaAtividade { Valor = 12345.67m }]
                    }
                ]
            }
        ]
    },
    ValoresParaComparacao =
    [
        new ValorDevido { CodigoTributo = 1001, Valor = 27.16m },
        new ValorDevido { CodigoTributo = 1002, Valor = 17.28m },
        new ValorDevido { CodigoTributo = 1004, Valor = 62.91m },
        new ValorDevido { CodigoTributo = 1005, Valor = 13.63m },
        new ValorDevido { CodigoTributo = 1006, Valor = 204.94m },
        new ValorDevido { CodigoTributo = 1007, Valor = 167.9m }
    ]
};

var resposta = await servico.PgdasdTransmitirDeclaracaoAsync(contribuinte, dados);

if (resposta.Sucesso)
{
    var retorno = resposta.Retorno!;
    Console.WriteLine($"Declaração {retorno.IdDeclaracao} transmitida em {retorno.DataHoraTransmissao}");

    foreach (var valor in retorno.ValoresDevidos ?? [])
        Console.WriteLine($"Tributo {valor.CodigoTributo}: {valor.Valor:N2}");

    File.WriteAllBytes(@"C:\PGDASD\declaracao-202501.pdf", Convert.FromBase64String(retorno.Declaracao!));
    File.WriteAllBytes(@"C:\PGDASD\recibo-202501.pdf", Convert.FromBase64String(retorno.Recibo!));

    // MAED: somente quando a declaração original é entregue fora do prazo
    if (retorno.Darf is not null)
    {
        File.WriteAllBytes(@"C:\PGDASD\maed-notificacao-202501.pdf", Convert.FromBase64String(retorno.NotificacaoMaed!));
        File.WriteAllBytes(@"C:\PGDASD\maed-darf-202501.pdf", Convert.FromBase64String(retorno.Darf));
        Console.WriteLine($"DARF MAED: {retorno.DetalhamentoDarfMaed?.Valores?.Total:N2} vence em {retorno.DetalhamentoDarfMaed?.DataVencimento}");
    }
}
```

**Dados enviados**
```json
{
  "cnpjCompleto": "00000000000100",
  "pa": 202501,
  "indicadorTransmissao": true,
  "indicadorComparacao": true,
  "declaracao": {
    "tipoDeclaracao": 1,
    "receitaPaCompetenciaInterno": 12345.67,
    "receitaPaCompetenciaExterno": 0,
    "receitasBrutasAnteriores": [
      { "pa": 202411, "valorInterno": 10500, "valorExterno": 0 },
      { "pa": 202412, "valorInterno": 11800.5, "valorExterno": 0 }
    ],
    "folhasSalario": [
      { "pa": 202411, "valor": 3500 },
      { "pa": 202412, "valor": 3500 }
    ],
    "estabelecimentos": [
      {
        "cnpjCompleto": "00000000000100",
        "atividades": [
          {
            "idAtividade": 1,
            "valorAtividade": 12345.67,
            "receitasAtividade": [ { "valor": 12345.67 } ]
          }
        ]
      }
    ]
  },
  "valoresParaComparacao": [
    { "codigoTributo": 1001, "valor": 27.16 },
    { "codigoTributo": 1002, "valor": 17.28 },
    { "codigoTributo": 1004, "valor": 62.91 },
    { "codigoTributo": 1005, "valor": 13.63 },
    { "codigoTributo": 1006, "valor": 204.94 },
    { "codigoTributo": 1007, "valor": 167.9 }
  ]
}
```

**Retorno (fictício)**
```json
{
  "idDeclaracao": "00000000202501001",
  "dataHoraTransmissao": "20250218103015",
  "valoresDevidos": [
    { "codigoTributo": 1001, "valor": 27.16 },
    { "codigoTributo": 1002, "valor": 17.28 },
    { "codigoTributo": 1004, "valor": 62.91 },
    { "codigoTributo": 1005, "valor": 13.63 },
    { "codigoTributo": 1006, "valor": 204.94 },
    { "codigoTributo": 1007, "valor": 167.90 }
  ],
  "declaracao": "JVBERi0xLjQK...",
  "recibo": "JVBERi0xLjQK...",
  "notificacaoMaed": null,
  "darf": null,
  "detalhamentoDarfMaed": null
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

### Campos opcionais da declaração

Os demais membros de `DeclaracaoPgdasd` e `ReceitaAtividade` são enviados apenas quando preenchidos (valores `null` são omitidos):

```csharp
var declaracao = new DeclaracaoPgdasd
{
    TipoDeclaracao = 2, // retificadora
    ReceitaPaCompetenciaInterno = 12345.67m,
    ReceitaPaCompetenciaExterno = 0m,
    ReceitaPaCaixaInterno = 11000m,   // optantes pelo regime de caixa
    ReceitaPaCaixaExterno = 0m,
    ValorFixoIcms = 150m,
    ValorFixoIss = 80m,
    NaoOptante = new NaoOptante { EsferaAdm = "1", Uf = "SP", CodMunicipio = "7107", NomeMunicipio = "SAO PAULO", Processo = "00000000000000000" },
    Estabelecimentos =
    [
        new Estabelecimento
        {
            CnpjCompleto = "00000000000100",
            Atividades =
            [
                new Atividade
                {
                    IdAtividade = 14,
                    ValorAtividade = 12345.67m,
                    ReceitasAtividade =
                    [
                        new ReceitaAtividade
                        {
                            Valor = 12345.67m,
                            CodigoOutroMunicipio = 7107, // código TOM, quando a atividade ocorre em outro município
                            OutraUf = "SP",
                            Isencoes = [new Isencao { CodTributo = 1010, Valor = 1000m, Identificador = 1 }],
                            Reducoes = [new Reducao { CodTributo = 1007, Valor = 2000m, PercentualReducao = 50m, Identificador = 1 }],
                            QualificacoesTributarias = [new QualificacaoTributaria { CodigoTributo = 1001, Id = 1 }],
                            ExigibilidadesSuspensas =
                            [
                                new ExigibilidadeSuspensa
                                {
                                    CodTributo = 1005,
                                    NumeroProcesso = "00000000000000000",
                                    CodMunicipio = "7107",
                                    Uf = "SP",
                                    Vara = "1",
                                    ExisteDeposito = true,
                                    Motivo = 1
                                }
                            ]
                        }
                    ]
                }
            ]
        }
    ]
};
```

Trecho correspondente em `declaracao`:
```json
{
  "tipoDeclaracao": 2,
  "receitaPaCompetenciaInterno": 12345.67,
  "receitaPaCompetenciaExterno": 0,
  "receitaPaCaixaInterno": 11000,
  "receitaPaCaixaExterno": 0,
  "valorFixoIcms": 150,
  "valorFixoIss": 80,
  "naoOptante": { "esferaAdm": "1", "uf": "SP", "codMunicipio": "7107", "nomeMunicipio": "SAO PAULO", "processo": "00000000000000000" },
  "estabelecimentos": [
    {
      "cnpjCompleto": "00000000000100",
      "atividades": [
        {
          "idAtividade": 14,
          "valorAtividade": 12345.67,
          "receitasAtividade": [
            {
              "valor": 12345.67,
              "codigoOutroMunicipio": 7107,
              "outraUf": "SP",
              "isencoes": [ { "codTributo": 1010, "valor": 1000, "identificador": 1 } ],
              "reducoes": [ { "codTributo": 1007, "valor": 2000, "percentualReducao": 50, "identificador": 1 } ],
              "qualificacoesTributarias": [ { "codigoTributo": 1001, "id": 1 } ],
              "exigibilidadesSuspensas": [
                { "codTributo": 1005, "numeroProcesso": "00000000000000000", "codMunicipio": "7107", "uf": "SP", "vara": "1", "existeDeposito": true, "motivo": 1 }
              ]
            }
          ]
        }
      ]
    }
  ]
}
```

> [!NOTE]
> `ReceitaAtividade.CodigoOutroMunicipio` é `int?`: a tabela de campos da documentação o descreve como texto, mas o exemplo e o schema de entrada usam número. Já `NaoOptante.EsferaAdm`/`CodMunicipio` e `ExigibilidadeSuspensa.NumeroProcesso`/`CodMunicipio` são texto. `Estabelecimento.Atividades` não deve ser enviado quando não houve atividade no estabelecimento. Os valores `decimal` são serializados com a escala informada no C# (`167.9m` → `167.9`, `167.90m` → `167.90`).

---

## 🧾 GERARDAS12 — Gerar DAS

Gera o DAS de uma declaração já transmitida, opcionalmente para uma data de consolidação futura (`AAAAMMDD`).

```csharp
var resposta = await servico.PgdasdGerarDasAsync(contribuinte, new GerarDas
{
    PeriodoApuracao = "202501",
    DataConsolidacao = "20250220"
});

if (resposta.Sucesso)
{
    foreach (var das in resposta.Retorno ?? [])
    {
        File.WriteAllBytes($@"C:\PGDASD\das-{das.CnpjCompleto}-202501.pdf", Convert.FromBase64String(das.Pdf!));

        foreach (var detalhe in das.Detalhamento ?? [])
        {
            Console.WriteLine($"DAS {detalhe.NumeroDocumento} - PA {detalhe.PeriodoApuracao} - vencimento {detalhe.DataVencimento} - total {detalhe.Valores?.Total:N2}");
            foreach (var tributo in detalhe.Composicao ?? [])
                Console.WriteLine($"  {tributo.Codigo} {tributo.Denominacao}: {tributo.Valores?.Principal:N2}");
        }
    }
}
```

**Dados enviados**
```json
{ "periodoApuracao": "202501", "dataConsolidacao": "20250220" }
```

**Retorno (fictício)**
```json
[
  {
    "pdf": "JVBERi0xLjQK...",
    "cnpjCompleto": "00000000000100",
    "detalhamentoDas": {
      "periodoApuracao": "202501",
      "numeroDocumento": "07202505012345678",
      "dataVencimento": "20250220",
      "dataLimiteAcolhimento": "20250220",
      "valores": { "principal": 493.82, "multa": 0.00, "juros": 0.00, "total": 493.82 },
      "observacao1": null,
      "observacao2": null,
      "observacao3": null,
      "composicao": [
        { "periodoApuracao": "202501", "codigo": "1001", "denominacao": "01/2025", "valores": { "principal": 27.16, "multa": 0.00, "juros": 0.00, "total": 27.16 } },
        { "periodoApuracao": "202501", "codigo": "1002", "denominacao": "01/2025", "valores": { "principal": 17.28, "multa": 0.00, "juros": 0.00, "total": 17.28 } },
        { "periodoApuracao": "202501", "codigo": "1004", "denominacao": "01/2025", "valores": { "principal": 62.91, "multa": 0.00, "juros": 0.00, "total": 62.91 } },
        { "periodoApuracao": "202501", "codigo": "1005", "denominacao": "01/2025", "valores": { "principal": 13.63, "multa": 0.00, "juros": 0.00, "total": 13.63 } },
        { "periodoApuracao": "202501", "codigo": "1006", "denominacao": "01/2025", "valores": { "principal": 204.94, "multa": 0.00, "juros": 0.00, "total": 204.94 } },
        { "periodoApuracao": "202501", "codigo": "1007", "denominacao": "SP - 01/2025", "valores": { "principal": 167.90, "multa": 0.00, "juros": 0.00, "total": 167.90 } }
      ]
    }
  }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> A documentação do SERPRO diverge quanto ao detalhamento do DAS: os exemplos do PGDAS-D usam a chave `detalhamentoDas` com um **objeto**, enquanto as tabelas de campos (e o PGMEI) usam `detalhamento`, às vezes como **lista**. O `Das` aceita todas as formas na leitura e sempre expõe `Das.Detalhamento` como `List<DetalhamentoDas>`. Os campos `PeriodoApuracao`, `NumeroDocumento`, `DataVencimento`, `DataLimiteAcolhimento` e `ComposicaoDas.Codigo` são `string` e aceitam texto ou número no JSON; em DAS de mais de um período, `PeriodoApuracao` vem como `"Diversos"`.

---

## 🔎 CONSDECLARACAO13 — Consultar declarações transmitidas

Retorna o índice das operações (declarações e DAS gerados) por **ano-calendário** ou por **período de apuração** — informe apenas um dos dois.

```csharp
var resposta = await servico.PgdasdConsultarDeclaracoesAsync(contribuinte, new ConsultarDeclaracoes { AnoCalendario = "2025" });
// ou, por período: new ConsultarDeclaracoes { PeriodoApuracao = "202501" } -> resultado em resposta.Retorno.Periodo

if (resposta.Sucesso)
{
    var retorno = resposta.Retorno!;
    foreach (var periodo in retorno.Periodos ?? [])
    {
        foreach (var operacao in periodo.Operacoes ?? [])
        {
            if (operacao.IndiceDeclaracao is { } declaracao)
                Console.WriteLine($"{periodo.PeriodoApuracao} {operacao.TipoOperacao}: {declaracao.NumeroDeclaracao} em {declaracao.DataHoraTransmissao} (malha: {declaracao.Malha})");
            else if (operacao.IndiceDas is { } das)
                Console.WriteLine($"{periodo.PeriodoApuracao} {operacao.TipoOperacao}: DAS {das.NumeroDas} em {das.DataHoraEmissaoDas} - pago: {das.DasPago}");
        }
    }
}
```

**Dados enviados**
```json
{ "anoCalendario": "2025" }
```

**Retorno (fictício)**
```json
{
  "anoCalendario": 2025,
  "periodos": [
    {
      "periodoApuracao": 202501,
      "operacoes": [
        {
          "tipoOperacao": "Original",
          "indiceDeclaracao": { "numeroDeclaracao": "00000000202501001", "dataHoraTransmissao": "20250218103015", "malha": "" },
          "indiceDas": null
        },
        {
          "tipoOperacao": "Geração de DAS",
          "indiceDeclaracao": null,
          "indiceDas": { "numeroDas": "07202505012345678", "datahoraEmissaoDas": "20250218103512", "dasPago": true }
        }
      ]
    },
    {
      "periodoApuracao": 202502,
      "operacoes": [
        {
          "tipoOperacao": "Retificadora",
          "indiceDeclaracao": { "numeroDeclaracao": "00000000202502002", "dataHoraTransmissao": "20250319141022", "malha": "" },
          "indiceDas": null
        }
      ]
    }
  ]
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

Na consulta por período de apuração, o retorno traz o objeto `periodo` (em `DeclaracoesEntregues.Periodo`) no lugar da lista `periodos`.

> [!NOTE]
> `IndiceDeclaracao.DataHoraTransmissao` e `IndiceDas.DataHoraEmissaoDas` são `long?` no formato `yyyyMMddHHmmss`: o exemplo da documentação os traz como texto e a tabela de campos como número, e ambos são aceitos na leitura. Observe a chave `datahoraEmissaoDas` (com "h" minúsculo), conforme a documentação. `Malha` é vazia ou nula quando a declaração não está em malha.

---

## 📄 CONSULTIMADECREC14 — Consultar a última declaração/recibo

Retorna a última declaração transmitida no período de apuração, com o recibo e, se houver, a MAED.

```csharp
var resposta = await servico.PgdasdConsultarUltimaDeclaracaoAsync(contribuinte, new ConsultarUltimaDeclaracao { PeriodoApuracao = "202501" });

if (resposta.Sucesso)
{
    var retorno = resposta.Retorno!;
    Console.WriteLine($"Declaração {retorno.NumeroDeclaracao}");

    if (retorno.Declaracao is { } declaracao)
        File.WriteAllBytes(Path.Combine(@"C:\PGDASD", declaracao.NomeArquivo!), Convert.FromBase64String(declaracao.Pdf!));
    if (retorno.Recibo is { } recibo)
        File.WriteAllBytes(Path.Combine(@"C:\PGDASD", recibo.NomeArquivo!), Convert.FromBase64String(recibo.Pdf!));
}
```

**Dados enviados**
```json
{ "periodoApuracao": "202501" }
```

**Retorno (fictício)**
```json
{
  "numeroDeclaracao": "00000000202501001",
  "recibo": { "nomeArquivo": "PGDASD-RECIBO-00000000202501001.pdf", "pdf": "JVBERi0xLjQK..." },
  "declaracao": { "nomeArquivo": "PGDASD-DECLARACAO-00000000202501001.pdf", "pdf": "JVBERi0xLjQK..." },
  "maed": null
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

---

## 📄 CONSDECREC15 — Consultar declaração/recibo específica

Retorna uma declaração pelo número, com o recibo e, se houver, a notificação e o DARF da MAED (declaração original entregue fora do prazo).

```csharp
var resposta = await servico.PgdasdConsultarDeclaracaoAsync(contribuinte, new ConsultarDeclaracao { NumeroDeclaracao = "00000000202412001" });

if (resposta.Sucesso)
{
    var retorno = resposta.Retorno!;
    var pasta = @"C:\PGDASD";

    File.WriteAllBytes(Path.Combine(pasta, retorno.Declaracao!.NomeArquivo!), Convert.FromBase64String(retorno.Declaracao.Pdf!));
    File.WriteAllBytes(Path.Combine(pasta, retorno.Recibo!.NomeArquivo!), Convert.FromBase64String(retorno.Recibo.Pdf!));

    if (retorno.Maed is { } maed)
    {
        File.WriteAllBytes(Path.Combine(pasta, maed.NomeArquivoNotificacao!), Convert.FromBase64String(maed.PdfNotificacao!));
        File.WriteAllBytes(Path.Combine(pasta, maed.NomeArquivoDarf!), Convert.FromBase64String(maed.PdfDarf!));
    }
}
```

**Dados enviados**
```json
{ "numeroDeclaracao": "00000000202412001" }
```

**Retorno (fictício)**
```json
{
  "numeroDeclaracao": "00000000202412001",
  "recibo": { "nomeArquivo": "PGDASD-RECIBO-00000000202412001.pdf", "pdf": "JVBERi0xLjQK..." },
  "declaracao": { "nomeArquivo": "PGDASD-DECLARACAO-00000000202412001.pdf", "pdf": "JVBERi0xLjQK..." },
  "maed": {
    "nomeArquivoNotificacao": "PGDASD-NOTIFICACAO-MAED-00000000202412001.pdf",
    "pdfNotificacao": "JVBERi0xLjQK...",
    "nomeArquivoDarf": "PGDASD-DARF-MAED-00000000202412001.pdf",
    "pdfDarf": "JVBERi0xLjQK..."
  }
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

---

## 📑 CONSEXTRATO16 — Consultar extrato do DAS

Retorna o extrato detalhado (PDF) de um DAS gerado.

```csharp
var resposta = await servico.PgdasdConsultarExtratoDasAsync(contribuinte, new ConsultarExtratoDas { NumeroDas = "07202505012345678" });

if (resposta.Sucesso && resposta.Retorno!.Extrato is { } extrato)
{
    File.WriteAllBytes(Path.Combine(@"C:\PGDASD", extrato.NomeArquivo!), Convert.FromBase64String(extrato.Pdf!));
    Console.WriteLine($"Extrato do DAS {resposta.Retorno.NumeroDas} salvo.");
}
```

**Dados enviados**
```json
{ "numeroDas": "07202505012345678" }
```

**Retorno (fictício)**
```json
{
  "numeroDas": "07202505012345678",
  "extrato": { "nomeArquivo": "PGDASD-EXTRATO-07202505012345678.pdf", "pdf": "JVBERi0xLjQK..." }
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

---

## 💰 GERARDASCOBRANCA17 — Gerar DAS de cobrança

Gera o DAS com os débitos do período de apuração que estão em sistema de cobrança. Retorna **um único** `Das` (não uma lista).

```csharp
var resposta = await servico.PgdasdGerarDasCobrancaAsync(contribuinte, new GerarDasCobranca { PeriodoApuracao = "202410" });

if (resposta.Sucesso)
{
    var das = resposta.Retorno!;
    File.WriteAllBytes(@"C:\PGDASD\das-cobranca-202410.pdf", Convert.FromBase64String(das.Pdf!));

    var detalhe = das.Detalhamento![0];
    Console.WriteLine($"DAS {detalhe.NumeroDocumento}: principal {detalhe.Valores?.Principal:N2}, multa {detalhe.Valores?.Multa:N2}, juros {detalhe.Valores?.Juros:N2}, total {detalhe.Valores?.Total:N2}");
    Console.WriteLine($"Pagável até {detalhe.DataLimiteAcolhimento}");
}
```

**Dados enviados**
```json
{ "periodoApuracao": "202410" }
```

**Retorno (fictício)**
```json
{
  "pdf": "JVBERi0xLjQK...",
  "cnpjCompleto": "00000000000100",
  "detalhamentoDas": {
    "periodoApuracao": "202410",
    "numeroDocumento": "07202508823456789",
    "dataVencimento": "20241120",
    "dataLimiteAcolhimento": "20250331",
    "valores": { "principal": 1234.56, "multa": 246.91, "juros": 61.73, "total": 1543.20 },
    "observacao1": null,
    "observacao2": null,
    "observacao3": null,
    "composicao": [
      { "periodoApuracao": "202410", "codigo": "1006", "denominacao": "10/2024", "valores": { "principal": 512.34, "multa": 102.47, "juros": 25.62, "total": 640.43 } },
      { "periodoApuracao": "202410", "codigo": "1007", "denominacao": "SP - 10/2024", "valores": { "principal": 722.22, "multa": 144.44, "juros": 36.11, "total": 902.77 } }
    ]
  }
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> `GerarDasCobranca.PeriodoApuracao` é `string`: o exemplo da documentação o envia como texto, embora a tabela de campos indique número.

---

## ⚖️ GERARDASPROCESSO18 — Gerar DAS de processo

Gera o DAS com os débitos de um processo em sistema de cobrança (número do processo com 17 dígitos, sem formatação). Retorna **um único** `Das`.

```csharp
var resposta = await servico.PgdasdGerarDasProcessoAsync(contribuinte, new GerarDasProcesso { NumeroProcesso = "00000000000000001" });

if (resposta.Sucesso)
{
    var das = resposta.Retorno!;
    File.WriteAllBytes(@"C:\PGDASD\das-processo.pdf", Convert.FromBase64String(das.Pdf!));

    foreach (var detalhe in das.Detalhamento ?? [])
    {
        Console.WriteLine($"{detalhe.Observacao1} - total {detalhe.Valores?.Total:N2}");
        foreach (var tributo in detalhe.Composicao ?? [])
            Console.WriteLine($"  {tributo.Codigo} ({tributo.PeriodoApuracao}): {tributo.Valores?.Total:N2}");
    }
}
```

**Dados enviados**
```json
{ "numeroProcesso": "00000000000000001" }
```

**Retorno (fictício)**
```json
{
  "pdf": "JVBERi0xLjQK...",
  "cnpjCompleto": "00000000000100",
  "detalhamentoDas": {
    "periodoApuracao": "202403",
    "numeroDocumento": "07202509934567890",
    "dataVencimento": "20240422",
    "dataLimiteAcolhimento": "20250331",
    "valores": { "principal": 456.78, "multa": 91.36, "juros": 36.54, "total": 584.68 },
    "observacao1": "Nrº Processo: 00000.000.000/0000-01",
    "observacao2": null,
    "observacao3": null,
    "composicao": [
      { "periodoApuracao": "202403", "codigo": "1004", "denominacao": "03/2024", "valores": { "principal": 375.00, "multa": 75.00, "juros": 30.00, "total": 480.00 } },
      { "periodoApuracao": "202403", "codigo": "1005", "denominacao": "03/2024", "valores": { "principal": 81.78, "multa": 16.36, "juros": 6.54, "total": 104.68 } }
    ]
  }
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

---

## 🧮 GERARDASAVULSO19 — Gerar DAS avulso

Gera um DAS avulso com os tributos informados. O ISS exige `CodMunicipio` (código TOM) e o ICMS exige `Uf`. Não informe `DataConsolidacao` quando a emissão for no próprio dia.

```csharp
var resposta = await servico.PgdasdGerarDasAvulsoAsync(contribuinte, new GerarDasAvulso
{
    PeriodoApuracao = 202501,
    ListaTributos =
    [
        new TributoDasAvulso { Codigo = 1010, Valor = 123.45m, CodMunicipio = 7107, Uf = "SP" }, // ISS
        new TributoDasAvulso { Codigo = 1007, Valor = 234.56m, Uf = "SP" }                       // ICMS
    ],
    DataConsolidacao = 20250228
    // ProrrogacaoEspecial: somente para os períodos prorrogados de 03/2020 a 05/2020 ou 03/2021 a 05/2021
});

if (resposta.Sucesso)
{
    var das = resposta.Retorno!;
    var detalhe = das.Detalhamento![0];
    File.WriteAllBytes($@"C:\PGDASD\das-avulso-{detalhe.NumeroDocumento}.pdf", Convert.FromBase64String(das.Pdf!));
    Console.WriteLine($"DAS avulso {detalhe.NumeroDocumento}: total {detalhe.Valores?.Total:N2}");
}
```

**Dados enviados**
```json
{
  "periodoApuracao": 202501,
  "listaTributos": [
    { "codigo": 1010, "valor": 123.45, "codMunicipio": 7107, "uf": "SP" },
    { "codigo": 1007, "valor": 234.56, "uf": "SP" }
  ],
  "dataConsolidacao": 20250228
}
```

**Retorno (fictício)**
```json
{
  "pdf": "JVBERi0xLjQK...",
  "cnpjCompleto": "00000000000100",
  "detalhamentoDas": {
    "periodoApuracao": "202501",
    "numeroDocumento": "07202505998765432",
    "dataVencimento": "20250220",
    "dataLimiteAcolhimento": "20250228",
    "valores": { "principal": 358.01, "multa": 9.45, "juros": 3.58, "total": 371.04 },
    "observacao1": null,
    "observacao2": "",
    "observacao3": null,
    "composicao": [
      { "periodoApuracao": "202501", "codigo": "1010", "denominacao": "SAO PAULO (SP) - 01/2025", "valores": { "principal": 123.45, "multa": 3.26, "juros": 1.23, "total": 127.94 } },
      { "periodoApuracao": "202501", "codigo": "1007", "denominacao": "SP - 01/2025", "valores": { "principal": 234.56, "multa": 6.19, "juros": 2.35, "total": 243.10 } }
    ]
  }
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGDASD]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> No DAS avulso, `PeriodoApuracao` e `DataConsolidacao` são **numéricos** (`int`/`int?`), ao contrário do `GerarDas` (GERARDAS12), em que são texto — conforme os exemplos da documentação.
