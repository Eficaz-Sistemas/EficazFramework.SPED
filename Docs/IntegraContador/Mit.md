# MIT — Módulo de Inclusão de Tributos

Serviços da solução **Integra-DCTFWeb** para encerrar apurações do MIT (enviando-as à DCTFWeb), acompanhar o encerramento e consultar ou listar as apurações de um período.

[← Integra Contador](../IntegraContador.md)

---

## 📋 Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--:|:--|:--|
| `ENCAPURACAO314` | `/Declarar` | 1.0 | `MitEncerrarApuracaoAsync` | `RetornoEncerrarApuracaoMit` |
| `SITUACAOENC315` | `/Apoiar` | 1.0 | `MitConsultarSituacaoEncerramentoAsync` | `RetornoSituacaoEncerramentoMit` |
| `CONSAPURACAO316` | `/Consultar` | 1.0 | `MitConsultarApuracaoAsync` | `RetornoConsultaApuracaoMit` |
| `LISTAAPURACOES317` | `/Consultar` | 1.0 | `MitListarApuracoesAsync` | `RetornoListaApuracoesMit` |

O `idSistema` de todos é `MIT` (ver `Catalogo.Mit`).

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço):

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraDCTFWeb;
using EficazFramework.SPED.Schemas.MIT;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

---

## 🔒 ENCAPURACAO314 — Encerrar apuração

A entrada é um `ApuracaoMit`, que herda o leiaute de `Escrituracao` (arquivo de importação do MIT) e acrescenta `TransmissaoImediata`. O encerramento é assíncrono: o retorno traz o protocolo para acompanhar pelo `SITUACAOENC315`.

```csharp
var apuracao = new ApuracaoMit
{
    PeriodoApuracao = new PeriodoApuracao { MesApuracao = 3, AnoApuracao = 2026 },
    DadosIniciais = new DadosIniciais
    {
        SemMovimento = false,
        QualificacaoPj = 2,
        TributacaoLucro = 2,
        VariacoesMonetarias = 1,
        RegimePisCofins = 1,
        ResponsavelApuracao = new ResponsavelApuracao
        {
            CpfResponsavel = "12345678909",
            TelResponsavel = new Telefone { Ddd = "11", NumTelefone = "912345678" },
            EmailResponsavel = "fiscal@exemplo.com.br",
            RegistroCrc = new RegistroCrc { UfRegistro = "SP", NumRegistro = "123456O8" }
        }
    },
    Debitos = new Debitos
    {
        Irpj = new Irpj { ListaDebitos = [new DetalhamentoDebito { IdDebito = 1, CodigoDebito = "208901", ValorDebito = 15000.00m }] },
        Csll = new Csll { ListaDebitos = [new DetalhamentoDebito { IdDebito = 2, CodigoDebito = "237201", ValorDebito = 8100.00m }] },
        PisPasep = new PisPasep { ListaDebitos = [new DetalhamentoDebito { IdDebito = 3, CodigoDebito = "810902", ValorDebito = 3250.00m }] },
        Cofins = new Cofins { ListaDebitos = [new DetalhamentoDebito { IdDebito = 4, CodigoDebito = "217201", ValorDebito = 15000.00m }] }
    },
    ListaSuspensoes =
    [
        new Suspensao
        {
            TipoSuspensao = 2,                   // judicial
            MotivoSuspensao = 1,
            ComDeposito = true,
            NumeroProcesso = "50012345620264036100",
            ProcessoTerceiro = false,
            DataDecisao = 20260115,              // AAAAMMDD
            VaraJudiciaria = 5,
            CodigoMunicipioSj = "3550308",       // IBGE, 7 dígitos
            ListaDebitosSuspensos = [new DebitoSuspenso { IdDebitoSuspenso = 4, ValorSuspenso = 15000.00m }]
        }
    ],
    TransmissaoImediata = false
};

var resposta = await servico.MitEncerrarApuracaoAsync(contribuinte, apuracao);

if (resposta.Sucesso)
{
    Console.WriteLine($"Protocolo: {resposta.Retorno?.ProtocoloEncerramento}");
    Console.WriteLine($"Apuração: {resposta.Retorno?.IdApuracao}");
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

Também é possível partir de uma `Escrituracao` já montada (ex.: a mesma usada para gerar o arquivo de importação):

```csharp
var apuracao = new ApuracaoMit(escrituracao, transmissaoImediata: false);
```

### Dados enviados
```json
{
  "PeriodoApuracao": { "MesApuracao": 3, "AnoApuracao": 2026 },
  "DadosIniciais": {
    "SemMovimento": false,
    "QualificacaoPj": 2,
    "TributacaoLucro": 2,
    "VariacoesMonetarias": 1,
    "RegimePisCofins": 1,
    "ResponsavelApuracao": {
      "CpfResponsavel": "12345678909",
      "TelResponsavel": { "Ddd": "11", "NumTelefone": "912345678" },
      "EmailResponsavel": "fiscal@exemplo.com.br",
      "RegistroCrc": { "UfRegistro": "SP", "NumRegistro": "123456O8" }
    }
  },
  "Debitos": {
    "Irpj": { "ListaDebitos": [ { "IdDebito": 1, "CodigoDebito": "208901", "ValorDebito": 15000.00 } ] },
    "Csll": { "ListaDebitos": [ { "IdDebito": 2, "CodigoDebito": "237201", "ValorDebito": 8100.00 } ] },
    "PisPasep": { "ListaDebitos": [ { "IdDebito": 3, "CodigoDebito": "810902", "ValorDebito": 3250.00 } ] },
    "Cofins": { "ListaDebitos": [ { "IdDebito": 4, "CodigoDebito": "217201", "ValorDebito": 15000.00 } ] }
  },
  "ListaSuspensoes": [
    {
      "TipoSuspensao": 2,
      "MotivoSuspensao": 1,
      "ComDeposito": true,
      "NumeroProcesso": "50012345620264036100",
      "ProcessoTerceiro": false,
      "DataDecisao": 20260115,
      "VaraJudiciaria": 5,
      "CodigoMunicipioSj": "3550308",
      "ListaDebitosSuspensos": [ { "IdDebitoSuspenso": 4, "ValorSuspenso": 15000.00 } ]
    }
  ],
  "TransmissaoImediata": false
}
```

### Retorno (fictício)
```json
{
  "protocoloEncerramento": "Qk3xV8pLm2RtY7nWc1ZsHg==",
  "idApuracao": 12
}
```

**Mensagens:** `[Sucesso-MIT]` — Requisição efetuada com sucesso.

---

## ⏳ SITUACAOENC315 — Consultar situação do encerramento

Serviço não tarifado. Enquanto a situação for `EncerramentoEmCurso` (4), consulte novamente após alguns instantes:

```csharp
var protocolo = "Qk3xV8pLm2RtY7nWc1ZsHg==";
RespostaIntegraContador<RetornoSituacaoEncerramentoMit> resposta;

do
{
    await Task.Delay(TimeSpan.FromSeconds(10));
    resposta = await servico.MitConsultarSituacaoEncerramentoAsync(contribuinte, protocolo);
}
while (resposta.Sucesso && resposta.Retorno?.SituacaoApuracao == SituacaoApuracaoMit.EncerramentoEmCurso);

if (resposta.Sucesso && resposta.Retorno is { } situacao)
{
    Console.WriteLine($"Apuração {situacao.IdApuracao}: {situacao.TextoSituacao} em {situacao.DataEncerramento}");
    foreach (var aviso in situacao.AvisosDctf ?? [])
        Console.WriteLine($"DCTFWeb: {aviso}");
}
```

### Dados enviados
```json
{
  "protocoloEncerramento": "Qk3xV8pLm2RtY7nWc1ZsHg=="
}
```

### Retorno (fictício)
```json
{
  "idApuracao": 12,
  "situacaoApuracao": 3,
  "textoSituacao": "ENCERRADA",
  "avisosDctf": [
    "Débitos do MIT incluídos na DCTFWeb do período 03/2026."
  ],
  "dataEncerramento": "20260415"
}
```

**Mensagens:** `[Sucesso-MIT]` — Requisição efetuada com sucesso.

---

## 🔎 CONSAPURACAO316 — Consultar apuração

```csharp
var resposta = await servico.MitConsultarApuracaoAsync(contribuinte, idApuracao: 12);

if (resposta.Sucesso && resposta.Retorno is { } consulta)
{
    Console.WriteLine($"Situação: {consulta.SituacaoApuracao} ({consulta.TextoSituacao})");

    var dados = consulta.DadosApuracaoMit;
    Console.WriteLine($"Período: {dados?.PeriodoApuracao?.MesApuracao:00}/{dados?.PeriodoApuracao?.AnoApuracao}");
    foreach (var debito in dados?.Debitos?.Cofins?.ListaDebitos ?? [])
        Console.WriteLine($"COFINS {debito.CodigoDebito}: {debito.ValorDebito:N2}");
}
```

### Dados enviados
```json
{
  "idApuracao": 12
}
```

### Retorno (fictício)
```json
{
  "situacaoApuracao": 3,
  "textoSituacao": "ENCERRADA",
  "dadosApuracaoMit": {
    "PeriodoApuracao": { "MesApuracao": 3, "AnoApuracao": 2026 },
    "DadosIniciais": {
      "SemMovimento": false,
      "QualificacaoPj": 2,
      "TributacaoLucro": 2,
      "VariacoesMonetarias": 1,
      "RegimePisCofins": 1,
      "ResponsavelApuracao": {
        "CpfResponsavel": "12345678909",
        "TelResponsavel": { "Ddd": "11", "NumTelefone": "912345678" },
        "EmailResponsavel": "fiscal@exemplo.com.br",
        "RegistroCrc": { "UfRegistro": "SP", "NumRegistro": "123456O8" }
      }
    },
    "Debitos": {
      "Irpj": { "ListaDebitos": [ { "IdDebito": 1, "CodigoDebito": "208901", "ValorDebito": 15000.00 } ] },
      "Csll": { "ListaDebitos": [ { "IdDebito": 2, "CodigoDebito": "237201", "ValorDebito": 8100.00 } ] },
      "PisPasep": { "ListaDebitos": [ { "IdDebito": 3, "CodigoDebito": "810902", "ValorDebito": 3250.00 } ] },
      "Cofins": { "ListaDebitos": [ { "IdDebito": 4, "CodigoDebito": "217201", "ValorDebito": 15000.00 } ] }
    },
    "ListaSuspensoes": [
      {
        "TipoSuspensao": 2,
        "MotivoSuspensao": 1,
        "ComDeposito": true,
        "NumeroProcesso": "50012345620264036100",
        "ProcessoTerceiro": false,
        "DataDecisao": 20260115,
        "VaraJudiciaria": 5,
        "CodigoMunicipioSj": "3550308",
        "ListaDebitosSuspensos": [ { "IdDebitoSuspenso": 4, "ValorSuspenso": 15000.00 } ]
      }
    ],
    "TransmissaoImediata": false
  }
}
```

**Mensagens:** `[Sucesso-MIT]` — Requisição efetuada com sucesso.

---

## 📑 LISTAAPURACOES317 — Listar apurações

`mesApuracao` e `situacaoApuracao` são opcionais; sem eles, são listadas todas as apurações do ano.

```csharp
var resposta = await servico.MitListarApuracoesAsync(contribuinte,
    anoApuracao: 2026,
    mesApuracao: 3,
    situacaoApuracao: SituacaoApuracaoMit.Encerrada);

if (resposta.Sucesso)
{
    foreach (var item in resposta.Retorno?.Apuracoes ?? [])
        Console.WriteLine($"{item.PeriodoApuracao} | id {item.IdApuracao} | {item.Situacao} | {item.DataEncerramento} | evento especial: {item.EventoEspecial} | {item.ValorTotalApurado:N2}");
}
```

### Dados enviados
```json
{
  "anoApuracao": 2026,
  "mesApuracao": 3,
  "situacaoApuracao": 3
}
```

### Retorno (fictício)
```json
{
  "Apuracoes": [
    {
      "periodoApuracao": 202603,
      "idApuracao": 9,
      "situacao": 3,
      "dataEncerramento": "20260410",
      "eventoEspecial": false,
      "valorTotalApurado": 38900.00
    },
    {
      "periodoApuracao": 202603,
      "idApuracao": 12,
      "situacao": 3,
      "dataEncerramento": "20260415",
      "eventoEspecial": false,
      "valorTotalApurado": 41350.00
    }
  ]
}
```

**Mensagens:** `[Sucesso-MIT]` — Requisição efetuada com sucesso.

---

> [!NOTE]
> - O `ENCAPURACAO314` é serializado por `ApuracaoMit.SerializarDados` (opções `ApuracaoMit.OpcoesJson`), no leiaute do MIT: chaves em **PascalCase**, nulos omitidos e **inteiros zerados omitidos** (nenhum código ou identificador do leiaute aceita 0). `ComDeposito` e `ProcessoTerceiro` só são enviados em suspensões judiciais (`TipoSuspensao = 2`), e `ComDeposito` não é enviado quando `MotivoSuspensao = 2`. Booleanos não anuláveis (ex.: `SemMovimento`) e `ValorDebito` são sempre enviados.
> - `TransmissaoImediata` é sempre o último campo e é **obrigatório** quando `DadosIniciais.SemMovimento` for verdadeiro; quando verdadeiro, a DCTFWeb é transmitida logo após o encerramento.
> - `TributoDebito.AddDebito` numera o `IdDebito` dentro de cada tributo; como o identificador deve ser único na apuração (é ele que `IdDebitoSuspenso` referencia), informe-o diretamente, como no exemplo, ou ajuste a numeração após usar `AddDebito`.
> - `MitEncerrarApuracaoAsync` lança `ArgumentNullException` se a apuração ou o `PeriodoApuracao` não forem informados; `MitConsultarSituacaoEncerramentoAsync`, se o protocolo estiver vazio.
> - O `SITUACAOENC315` usa o endpoint `/Apoiar`, no qual o token do procurador (`autenticar_procurador_token`) **não** é enviado.
> - Situações (`SituacaoApuracaoMit`): 1 - em edição com pendências (exclusiva da interface Web), 2 - em edição, 3 - encerrada, 4 - encerramento em curso.
> - Para emitir o DARF de uma apuração encerrada ainda em andamento na DCTFWeb, use o [`GERARGUIAANDAMENTO313`](DctfWeb.md#-gerarguiaandamento313--gerar-guia-de-declaração-em-andamento) com a categoria `GeralMensal` e o sistema de origem `Mit`.
> - Os códigos de receita, de qualificação e de tributação acima são apenas ilustrativos; consulte as tabelas do leiaute do MIT. Os códigos de mensagem também são ilustrativos.
