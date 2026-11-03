# DEFIS — Declaração de Informações Socioeconômicas e Fiscais

O sistema **DEFIS** (solução Integra-SN) permite transmitir a declaração anual de informações socioeconômicas e fiscais das empresas do Simples Nacional e consultar as declarações e recibos já transmitidos. Os bodies ficam no namespace `EficazFramework.SPED.Schemas.IntegraContador.IntegraSN`.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `TRANSDECLARACAO141` | Declarar | 1.0 | `DefisTransmitirDeclaracaoAsync` | `ReciboDefis` |
| `CONSDECLARACAO142` | Consultar | 1.0 | `DefisConsultarDeclaracoesAsync` | `List<DeclaracaoDefis>` |
| `CONSULTIMADECREC143` | Consultar | 1.0 | `DefisConsultarUltimaDeclaracaoAsync` | `ReciboDefis` |
| `CONSDECREC144` | Consultar | 1.0 | `DefisConsultarDeclaracaoAsync` | `ReciboDefis` |

Os identificadores também estão em `Catalogo.Defis` (ex.: `Catalogo.Defis.TransmitirDeclaracao`).

---

## 🔑 Pré-requisito

Os exemplos abaixo assumem o `servico` configurado conforme [Configurando o serviço](../IntegraContador.md#-configurando-o-serviço) e o contribuinte:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

> [!NOTE]
> Os métodos que recebem `dados` lançam `ArgumentNullException` quando ele é `null`. Erros HTTP **não** lançam exceção: verifique `resposta.Sucesso`, `resposta.StatusCode` e `resposta.Mensagens`. Os retornos abaixo mostram o conteúdo de `dados` já decodificado (o Base64 dos PDFs está truncado).

---

## 📤 TRANSDECLARACAO141 — Transmitir declaração

Transmite a DEFIS do ano-calendário. Qualquer declaração pendente de transmissão no mesmo ano-calendário é apagada.

```csharp
var dados = new TransmitirDeclaracaoDefis
{
    Ano = 2024,
    Inatividade = 2, // obrigatório só para ano-calendário anterior a 2025: 2 - total das atividades maior que zero
    Empresa = new EmpresaDefis
    {
        GanhoCapital = 0m,
        QtdEmpregadoInicial = 3,
        QtdEmpregadoFinal = 4,
        LucroContabil = 85000m,
        ReceitaExportacaoDireta = 0m,
        ComerciaisExportadoras = [new ComercialExportadora { CnpjCompleto = "00000000000291", Valor = 15000m }],
        Socios =
        [
            new Socio { Cpf = "00000000000", RendimentosIsentos = 60000m, RendimentosTributaveis = 18000m, ParticipacaoCapitalSocial = 60m, IrRetidoFonte = 0m },
            new Socio { Cpf = "11111111111", RendimentosIsentos = 40000m, RendimentosTributaveis = 18000m, ParticipacaoCapitalSocial = 40m, IrRetidoFonte = 0m }
        ],
        ParticipacaoCotasTesouraria = 0m,
        GanhoRendaVariavel = 0m,
        Estabelecimentos =
        [
            new EstabelecimentoDefis
            {
                CnpjCompleto = "00000000000100",
                EstoqueInicial = 45000m,
                EstoqueFinal = 52300.5m,
                SaldoCaixaInicial = 12000m,
                SaldoCaixaFinal = 18750.25m,
                AquisicoesMercadoInterno = 180000m,
                Importacoes = 0m,
                TotalEntradasPorTransferencia = 0m,
                TotalSaidasPorTransferencia = 0m,
                TotalDevolucoesVendas = 2500m,
                TotalEntradas = 182500m, // aquisições + entradas por transferência + devoluções de vendas
                TotalDevolucoesCompras = 1200m,
                TotalDespesas = 96000m,
                OperacoesInterestaduais = [new OperacaoInterestadual { Uf = "RJ", Valor = 25000m, TipoOperacao = 2 }], // 1 - Entrada; 2 - Saída
                IssRetidosFonte = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 7107, Valor = 1234.56m }]
            }
        ]
    }
};

var resposta = await servico.DefisTransmitirDeclaracaoAsync(contribuinte, dados);

if (resposta.Sucesso)
{
    var recibo = resposta.Retorno!;
    Console.WriteLine($"DEFIS transmitida: {recibo.IdDefis}");
    File.WriteAllBytes($@"C:\DEFIS\declaracao-{recibo.IdDefis}.pdf", Convert.FromBase64String(recibo.DeclaracaoPdf!));
    File.WriteAllBytes($@"C:\DEFIS\recibo-{recibo.IdDefis}.pdf", Convert.FromBase64String(recibo.ReciboPdf!));
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

**Dados enviados**
```json
{
  "ano": 2024,
  "inatividade": 2,
  "empresa": {
    "ganhoCapital": 0,
    "qtdEmpregadoInicial": 3,
    "qtdEmpregadoFinal": 4,
    "lucroContabil": 85000,
    "receitaExportacaoDireta": 0,
    "comerciaisExportadoras": [ { "cnpjCompleto": "00000000000291", "valor": 15000 } ],
    "socios": [
      { "cpf": "00000000000", "rendimentosIsentos": 60000, "rendimentosTributaveis": 18000, "participacaoCapitalSocial": 60, "irRetidoFonte": 0 },
      { "cpf": "11111111111", "rendimentosIsentos": 40000, "rendimentosTributaveis": 18000, "participacaoCapitalSocial": 40, "irRetidoFonte": 0 }
    ],
    "participacaoCotasTesouraria": 0,
    "ganhoRendaVariavel": 0,
    "estabelecimentos": [
      {
        "cnpjCompleto": "00000000000100",
        "estoqueInicial": 45000,
        "estoqueFinal": 52300.5,
        "saldoCaixaInicial": 12000,
        "saldoCaixaFinal": 18750.25,
        "aquisicoesMercadoInterno": 180000,
        "importacoes": 0,
        "totalEntradasPorTransferencia": 0,
        "totalSaidasPorTransferencia": 0,
        "totalDevolucoesVendas": 2500,
        "totalEntradas": 182500,
        "totalDevolucoesCompras": 1200,
        "totalDespesas": 96000,
        "operacoesInterestaduais": [ { "uf": "RJ", "valor": 25000, "tipoOperacao": 2 } ],
        "issRetidosFonte": [ { "uf": "SP", "codigoMunicipio": 7107, "valor": 1234.56 } ]
      }
    ]
  }
}
```

**Retorno (fictício)**
```json
{
  "declaracaoPdf": "JVBERi0xLjQK...",
  "reciboPdf": "JVBERi0xLjQK...",
  "idDefis": "000000002024001"
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-DEFIS]","texto":"Requisição efetuada com sucesso."}]`

### Campos opcionais

Situação especial, não optante, doações eleitorais e os demais blocos do estabelecimento são enviados apenas quando preenchidos (valores `null` são omitidos):

```csharp
var dados = new TransmitirDeclaracaoDefis
{
    Ano = 2024,
    SituacaoEspecial = new SituacaoEspecial { TipoEvento = 3, DataEvento = 20240930 }, // 3 - Extinção
    Inatividade = 2,
    NaoOptante = new NaoOptanteDefis { AdministracaoTributaria = 3, Uf = "SP", CodigoMunicipio = 7107, NumeroProcesso = "00000000000000000" },
    Empresa = new EmpresaDefis
    {
        // ... demais campos como no exemplo anterior
        DoacoesCampanhaEleitoral = [new DoacaoCampanhaEleitoral { CnpjBeneficiario = "00000000000372", TipoBeneficiario = 3, FormaDoacao = 3, Valor = 500m }],
        Estabelecimentos =
        [
            new EstabelecimentoDefis
            {
                CnpjCompleto = "00000000000100",
                // ... demais campos como no exemplo anterior
                PrestacaoServicosComunicacao = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 7107, Valor = 3000m }],
                PrestacoesServicoTransporte = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 6291, Valor = 4500m }],
                MudancasOutroMunicipio =
                [
                    new MudancaOutroMunicipio
                    {
                        UfOrigem = "SP", CodigoMunicipioOrigem = 7107,
                        UfDestino = "SP", CodigoMunicipioDestino = 6291,
                        DataMudanca = 20240701,
                        InformacaoOpcional = new InformacaoOpcional { SaidaTransferenciaMercadoria = 1500m }
                    }
                ],
                InformacaoOpcional = new InformacaoOpcional
                {
                    SaidaTransferenciaMercadoria = 2000m,
                    VendasRevendedorAmbulante = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 6291, Valor = 800m }],
                    PreparosComercializacaoRefeicoes = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 6291, Valor = 650m }],
                    ProducoesRurais = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 6291, Valor = 900m }],
                    AquisicoesProdutoresRurais = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 6291, Valor = 1100m }],
                    AquisicoesDispensadosInscricao = [new ValorMunicipio { Uf = "SP", CodigoMunicipio = 6291, Valor = 300m }],
                    AutoInfracaoPago = 750m,
                    RateiosReceitaRegimeEspecial = [new RateioRegimeEspecial { Uf = "SP", CodigoMunicipio = 6291, Valor = 1000m, NumeroRegime = "000001" }],
                    RateiosDecisaoJudicial = [new RateioDecisaoJudicial { Uf = "SP", CodigoMunicipio = 6291, Valor = 1000m, IdentificacaoDecisao = "PROCESSO 0000000-00.2024.8.26.0000" }],
                    RateiosReceitaOutrosRateios = [new RateioOutrosRateios { Uf = "SP", CodigoMunicipio = 6291, Valor = 1000m, OrigemExigencia = "SEFAZ-SP" }]
                }
            }
        ]
    }
};
```

Trechos correspondentes (raiz e estabelecimento):
```json
{
  "ano": 2024,
  "situacaoEspecial": { "tipoEvento": 3, "dataEvento": 20240930 },
  "inatividade": 2,
  "empresa": {
    "doacoesCampanhaEleitoral": [ { "cnpjBeneficiario": "00000000000372", "tipoBeneficiario": 3, "formaDoacao": 3, "valor": 500 } ],
    "estabelecimentos": [
      {
        "cnpjCompleto": "00000000000100",
        "prestacaoServicosComunicacao": [ { "uf": "SP", "codigoMunicipio": 7107, "valor": 3000 } ],
        "mudancasOutroMunicipio": [
          {
            "ufOrigem": "SP", "codigoMunicipioOrigem": 7107,
            "ufDestino": "SP", "codigoMunicipioDestino": 6291,
            "dataMudanca": 20240701,
            "informacaoOpcional": { "saidaTransferenciaMercadoria": 1500 }
          }
        ],
        "prestacoesServicoTransporte": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 4500 } ],
        "informacaoOpcional": {
          "saidaTransferenciaMercadoria": 2000,
          "vendasRevendedorAmbulante": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 800 } ],
          "preparosComercializacaoRefeicoes": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 650 } ],
          "producoesRurais": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 900 } ],
          "aquisicoesProdutoresRurais": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 1100 } ],
          "aquisicoesDispensadosInscricao": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 300 } ],
          "autoInfracaoPago": 750,
          "rateiosReceitaRegimeEspecial": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 1000, "numeroRegime": "000001" } ],
          "rateiosDecisaoJudicial": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 1000, "identificacaoDecisao": "PROCESSO 0000000-00.2024.8.26.0000" } ],
          "rateiosReceitaOutrosRateios": [ { "uf": "SP", "codigoMunicipio": 6291, "valor": 1000, "origemExigencia": "SEFAZ-SP" } ]
        }
      }
    ]
  },
  "naoOptante": { "administracaoTributaria": 3, "uf": "SP", "codigoMunicipio": 7107, "numeroProcesso": "00000000000000000" }
}
```
(no JSON acima foram omitidos, por brevidade, os campos do exemplo anterior que continuam sendo enviados.)

> [!NOTE]
> Os nomes dos campos seguem o **schema de entrada** da DEFIS, que diverge da tabela de campos da documentação em alguns pontos: `codigoMunicipio` (e não `codMunicipio`), `prestacaoServicosComunicacao` (e não `prestacoesServicoComunicacao`), `mudancasOutroMunicipio` (e não `mudancaOutroMunicipio`) e `naoOptante` na **raiz** do objeto, e não dentro de `empresa`. Os códigos (`TipoEvento`, `Inatividade`, `TipoBeneficiario`, `FormaDoacao`, `AdministracaoTributaria`, `TipoOperacao`) são `int`, com os domínios descritos nos comentários XML de cada propriedade; datas (`DataEvento`, `DataMudanca`) são `int` no formato `AAAAMMDD`. Os municípios usam o código da tabela TOM.

---

## 📋 CONSDECLARACAO142 — Consultar declarações transmitidas

Lista todas as declarações transmitidas no período não decadente. O serviço não tem dados de entrada (`pedidoDados.dados` é enviado vazio).

```csharp
var resposta = await servico.DefisConsultarDeclaracoesAsync(contribuinte);

if (resposta.Sucesso)
{
    foreach (var declaracao in resposta.Retorno ?? [])
    {
        var tipo = declaracao.Tipo switch
        {
            1 => "Original Normal",
            2 => "Retificadora Normal",
            3 => "Original de Situação Especial",
            4 => "Retificadora de Situação Especial",
            _ => "?"
        };
        Console.WriteLine($"{declaracao.AnoCalendario} - {declaracao.IdDefis} - {tipo} - {declaracao.DataHora}");
    }
}
```

**Dados enviados**
```json
""
```

**Retorno (fictício)**
```json
[
  { "anoCalendario": 2024, "idDefis": "000000002024001", "tipo": 1, "dataHora": "20250325101530" },
  { "anoCalendario": 2023, "idDefis": "000000002023002", "tipo": 2, "dataHora": "20240612163045" },
  { "anoCalendario": 2023, "idDefis": "000000002023001", "tipo": 1, "dataHora": "20240328091210" }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-DEFIS]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> `DeclaracaoDefis.DataHora` é `long?` (`AAAAMMDDHHMMSS`); o exemplo da documentação o traz como texto, aceito na leitura.

---

## 📄 CONSULTIMADECREC143 — Consultar a última declaração/recibo

Retorna a última declaração transmitida no ano-calendário (dentro do período não decadente).

```csharp
var resposta = await servico.DefisConsultarUltimaDeclaracaoAsync(contribuinte, new ConsultarUltimaDeclaracaoDefis { Ano = 2024 });

if (resposta.Sucesso)
{
    var recibo = resposta.Retorno!;
    File.WriteAllBytes($@"C:\DEFIS\declaracao-{recibo.IdDefis}.pdf", Convert.FromBase64String(recibo.DeclaracaoPdf!));
    File.WriteAllBytes($@"C:\DEFIS\recibo-{recibo.IdDefis}.pdf", Convert.FromBase64String(recibo.ReciboPdf!));
}
```

**Dados enviados**
```json
{ "ano": 2024 }
```

**Retorno (fictício)**
```json
{
  "declaracaoPdf": "JVBERi0xLjQK...",
  "reciboPdf": "JVBERi0xLjQK...",
  "idDefis": "000000002024001"
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-DEFIS]","texto":"Requisição efetuada com sucesso."}]`

---

## 📄 CONSDECREC144 — Consultar declaração/recibo específica

Retorna a declaração e o recibo de uma DEFIS pelo seu identificador (15 dígitos).

```csharp
var idDefis = "000000002023002";
var resposta = await servico.DefisConsultarDeclaracaoAsync(contribuinte, new ConsultarDeclaracaoDefis { IdDefis = idDefis });

if (resposta.Sucesso)
{
    var recibo = resposta.Retorno!;
    // o CONSDECREC144 não devolve o idDefis: use o identificador consultado
    File.WriteAllBytes($@"C:\DEFIS\declaracao-{idDefis}.pdf", Convert.FromBase64String(recibo.DeclaracaoPdf!));
    File.WriteAllBytes($@"C:\DEFIS\recibo-{idDefis}.pdf", Convert.FromBase64String(recibo.ReciboPdf!));
}
```

**Dados enviados**
```json
{ "idDefis": "000000002023002" }
```

**Retorno (fictício)**
```json
{
  "declaracaoPdf": "JVBERi0xLjQK...",
  "reciboPdf": "JVBERi0xLjQK..."
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-DEFIS]","texto":"Requisição efetuada com sucesso."}]`
