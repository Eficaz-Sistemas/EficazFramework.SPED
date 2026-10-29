# CCMEI — Certificado da Condição de Microempreendedor Individual

O sistema **CCMEI** (solução Integra-MEI) permite emitir o Certificado da Condição de Microempreendedor Individual em PDF, consultar os dados atualizados do certificado e consultar a situação cadastral dos CNPJs (que tenham sido MEI) vinculados a um CPF. Os bodies ficam no namespace `EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI`.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `EMITIRCCMEI121` | Emitir | 1.0 | `CcmeiEmitirAsync` | `List<RetornoEmitirCcmei>` |
| `DADOSCCMEI122` | Consultar | 1.0 | `CcmeiConsultarDadosAsync` | `DadosCcmei` |
| `CCMEISITCADASTRAL123` | Consultar | 1.0 | `CcmeiConsultarSituacaoCadastralAsync` | `List<SituacaoCadastralCcmei>` |

Os identificadores também estão em `Catalogo.Ccmei` (ex.: `Catalogo.Ccmei.Emitir`).

---

## 🔑 Pré-requisito

Os exemplos abaixo assumem o `servico` configurado conforme [Configurando o serviço](../IntegraContador.md#-configurando-o-serviço) e o contribuinte (CNPJ do MEI):

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

> [!NOTE]
> Nenhum serviço do CCMEI tem dados de entrada: o contribuinte é a única informação enviada e `pedidoDados.dados` vai vazio (`""`). Erros HTTP **não** lançam exceção: verifique `resposta.Sucesso`, `resposta.StatusCode` e `resposta.Mensagens`. Os retornos abaixo mostram o conteúdo de `dados` já decodificado (o Base64 dos PDFs está truncado).

---

## 📜 EMITIRCCMEI121 — Emitir CCMEI

Emite o Certificado da Condição de Microempreendedor Individual em PDF (Base64).

```csharp
var resposta = await servico.CcmeiEmitirAsync(contribuinte);

if (resposta.Sucesso)
{
    foreach (var certificado in resposta.Retorno ?? [])
        File.WriteAllBytes($@"C:\CCMEI\ccmei-{certificado.Cnpj}.pdf", Convert.FromBase64String(certificado.Pdf!));
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

**Dados enviados**
```json
""
```

**Retorno (fictício)**
```json
[
  { "cnpj": "00000000000100", "pdf": "JVBERi0xLjQK..." }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-CCMEI]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> O retorno é tipado como **lista** porque o exemplo da documentação traz um array com um único item.

---

## 🔎 DADOSCCMEI122 — Consultar dados do CCMEI

Retorna os dados atualizados do certificado: empresário, endereço comercial, enquadramento, atividades e termo de ciência e responsabilidade com efeito de dispensa de alvará.

```csharp
var resposta = await servico.CcmeiConsultarDadosAsync(contribuinte);

if (resposta.Sucesso)
{
    var ccmei = resposta.Retorno!;
    Console.WriteLine($"{ccmei.Cnpj} - {ccmei.NomeEmpresarial} ({ccmei.SituacaoCadastralVigente} desde {ccmei.DataInicioSituacaoCadastral})");
    Console.WriteLine($"Empresário: {ccmei.Empresario?.NomeCivil} - CPF {ccmei.Empresario?.Cpf}");
    Console.WriteLine($"Início das atividades: {ccmei.DataInicioAtividades} - capital social {ccmei.CapitalSocial:N2}");

    if (ccmei.EnderecoComercial is { } end)
        Console.WriteLine($"{end.Logradouro}, {end.Numero} {end.Complemento} - {end.Bairro} - {end.Municipio}/{end.Uf} - CEP {end.Cep}");

    if (ccmei.Enquadramento is { } enq)
    {
        Console.WriteLine($"{enq.Situacao} (optante: {enq.OptanteMei})");
        foreach (var periodo in enq.PeriodosMei ?? [])
            Console.WriteLine($"  período {periodo.Indice}: {periodo.DataInicio} a {periodo.DataFim ?? "atual"}");
    }

    if (ccmei.Atividade is { } atividade)
    {
        Console.WriteLine($"Formas de atuação: {string.Join(", ", atividade.FormasAtuacao ?? [])}");
        Console.WriteLine($"Principal: {atividade.OcupacaoPrincipal?.CodigoCnae} - {atividade.OcupacaoPrincipal?.DescricaoOcupacao}");
        foreach (var secundaria in atividade.OcupacoesSecundarias ?? [])
            Console.WriteLine($"Secundária: {secundaria.CodigoCnae} - {secundaria.DescricaoOcupacao}");
    }

    Console.WriteLine(ccmei.TermoCienciaDispensa?.Titulo);
}
```

**Dados enviados**
```json
""
```

**Retorno (fictício)**
```json
{
  "cnpj": "00000000000100",
  "empresario": { "nomeCivil": "FULANO DE TAL", "nomeSocial": null, "cpf": "00000000000" },
  "dataInicioAtividades": "2021-03-15",
  "nomeEmpresarial": "FULANO DE TAL 00000000000",
  "capitalSocial": 5000.00,
  "situacaoCadastralVigente": "ATIVA",
  "dataInicioSituacaoCadastral": "2021-03-15",
  "enderecoComercial": {
    "cep": "01000000",
    "logradouro": "RUA EXEMPLO",
    "numero": "123",
    "complemento": "SALA 1",
    "bairro": "CENTRO",
    "municipio": "SAO PAULO",
    "uf": "SP"
  },
  "enquadramento": {
    "periodosMei": [ { "indice": 1, "dataInicio": "2021-03-15T00:00:00", "dataFim": null } ],
    "situacao": "Enquadrado na condição de MEI",
    "optanteMei": true
  },
  "atividade": {
    "formasAtuacao": [ "Estabelecimento fixo", "Internet" ],
    "ocupacaoPrincipal": {
      "descricaoOcupacao": "CABELEIREIRO(A) INDEPENDENTE",
      "codigoCNAE": "9602-5/01",
      "descricaoCNAE": "Cabeleireiros, manicure e pedicure"
    },
    "ocupacoesSecundarias": [
      {
        "descricaoOcupacao": "MANICURE/PEDICURE INDEPENDENTE",
        "codigoCNAE": "9602-5/01",
        "descricaoCNAE": "Cabeleireiros, manicure e pedicure"
      }
    ]
  },
  "termoCienciaDispensa": {
    "titulo": "Termo de Ciência e Responsabilidade com Efeito de Dispensa de Alvará e Licença de Funcionamento",
    "texto": "Declaro, sob as penas da Lei, ..."
  },
  "qrCode": null
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-CCMEI]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> As datas são texto: `DataInicioAtividades` e `DataInicioSituacaoCadastral` no formato `AAAA-MM-DD`, e `PeriodoMei.DataInicio`/`DataFim` com hora (`AAAA-MM-DDTHH:mm:ss`; `DataFim` nulo enquanto o período estiver vigente). As chaves `codigoCNAE`/`descricaoCNAE` são mapeadas para `OcupacaoCcmei.CodigoCnae`/`DescricaoCnae`. `AtividadeCcmei.OptanteMei` consta na tabela da documentação, mas não no exemplo de retorno — o indicador confiável é `EnquadramentoCcmei.OptanteMei`.

---

## 🪪 CCMEISITCADASTRAL123 — Consultar situação cadastral por CPF

Lista a situação cadastral dos CNPJs (que tenham sido MEI) vinculados ao CPF informado. Neste serviço o **contribuinte é o CPF**.

```csharp
var cpf = Identificacao.Cpf("00000000000");
var resposta = await servico.CcmeiConsultarSituacaoCadastralAsync(cpf);

if (resposta.Sucesso)
{
    foreach (var cnpj in resposta.Retorno ?? [])
        Console.WriteLine($"{cnpj.Cnpj}: {cnpj.Situacao} - enquadrado como MEI: {cnpj.EnquadradoMei}");
}
```

**Dados enviados**
```json
""
```

**Retorno (fictício)**
```json
[
  { "cnpj": "00000000000100", "situacao": "ATIVA", "enquadradoMei": true },
  { "cnpj": "00000000000291", "situacao": "BAIXADA", "enquadradoMei": false }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-CCMEI]","texto":"Requisição efetuada com sucesso."}]`
