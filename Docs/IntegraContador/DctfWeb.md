# DCTFWEB — Declaração de Débitos e Créditos Tributários Federais Previdenciários e de Outras Entidades e Fundos

Serviços da solução **Integra-DCTFWeb** para emitir guias (DARF) de declarações ativas ou em andamento, consultar recibo, declaração completa e XML, e transmitir a declaração assinada.

[← Integra Contador](../IntegraContador.md)

---

## 📋 Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--:|:--|:--|
| `GERARGUIA31` | `/Emitir` | 1.0 | `DctfWebGerarGuiaAsync` | `RetornoPdfDctfWeb` |
| `CONSRECIBO32` | `/Consultar` | 1.0 | `DctfWebConsultarReciboAsync` | `RetornoPdfDctfWeb` |
| `CONSDECCOMPLETA33` | `/Consultar` | 1.0 | `DctfWebConsultarDeclaracaoCompletaAsync` | `RetornoPdfDctfWeb` |
| `CONSXMLDECLARACAO38` | `/Consultar` | 1.0 | `DctfWebConsultarXmlDeclaracaoAsync` | `RetornoXmlDctfWeb` |
| `TRANSDECLARACAO310` | `/Declarar` | 1.0 | `DctfWebTransmitirDeclaracaoAsync` | `RetornoTransmissaoDctfWeb` |
| `GERARGUIAANDAMENTO313` | `/Emitir` | 1.0 | `DctfWebGerarGuiaEmAndamentoAsync` | `RetornoPdfDctfWeb` |

O `idSistema` de todos é `DCTFWEB` (ver `Catalogo.DctfWeb`).

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço):

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraDCTFWeb;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

Todas as entradas herdam de `DeclaracaoDctfWeb`, que identifica a declaração:

| Propriedade | JSON | Uso |
|:--|:--|:--|
| `Categoria` | `categoria` | `CategoriaDctfWeb` enviada como número (padrão `GeralMensal` = 40). |
| `AnoPA` | `anoPA` | Ano do período de apuração (obrigatório). |
| `MesPA` | `mesPA` | Mês (`"MM"`); não informar nas categorias 41 e 51 (13º salário). |
| `DiaPA` | `diaPA` | Somente na categoria 45 (espetáculo desportivo). |
| `CnoAfericao` | `cnoAfericao` | Somente na categoria 44 (aferição). |
| `NumProcReclamatoria` | `numProcReclamatoria` | Somente na categoria 46 (reclamatória trabalhista). |

---

## 💰 GERARGUIA31 — Gerar guia de declaração ativa

```csharp
var resposta = await servico.DctfWebGerarGuiaAsync(contribuinte, new GerarGuiaDctfWeb
{
    Categoria = CategoriaDctfWeb.GeralMensal,
    AnoPA = "2026",
    MesPA = "09",
    NumeroReciboEntrega = 1234567,               // opcional: sem ele, usa a declaração mais recente
    DataAcolhimentoProposta = 20261030,          // AAAAMMDD, dia útil do mês corrente
    IdsSistemaOrigem = [SistemaOrigemDctfWeb.ESocial, SistemaOrigemDctfWeb.ReinfCp]
});

if (resposta.Sucesso)
{
    var pdf = resposta.Retorno?.ObterPdf();
    if (pdf is not null)
        File.WriteAllBytes(@"C:\DCTFWeb\darf-202609.pdf", pdf);
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

### Dados enviados
```json
{
  "categoria": 40,
  "anoPA": "2026",
  "mesPA": "09",
  "numeroReciboEntrega": 1234567,
  "DataAcolhimentoProposta": 20261030,
  "idsSistemaOrigem": [1, 6]
}
```

### Retorno (fictício)
```json
{
  "PDFByteArrayBase64": "JVBERi0xLjQK..."
}
```

**Mensagens:** `[Sucesso-DCTFWEB]` — Requisição efetuada com sucesso.

---

## 🧾 CONSRECIBO32 — Consultar recibo de transmissão

Exemplo com uma declaração de **aferição** (categoria 44), que exige o `CnoAfericao`:

```csharp
var resposta = await servico.DctfWebConsultarReciboAsync(contribuinte, new ConsultaDctfWeb
{
    Categoria = CategoriaDctfWeb.Afericao,
    AnoPA = "2026",
    MesPA = "08",
    CnoAfericao = 900012345678,
    NumeroReciboEntrega = 1234567                // opcional: sem ele, usa a declaração mais recente
});

if (resposta.Sucesso && resposta.Retorno?.ObterPdf() is { } pdf)
    File.WriteAllBytes(@"C:\DCTFWeb\recibo-afericao-202608.pdf", pdf);
```

### Dados enviados
```json
{
  "categoria": 44,
  "anoPA": "2026",
  "mesPA": "08",
  "cnoAfericao": 900012345678,
  "numeroReciboEntrega": 1234567
}
```

### Retorno (fictício)
```json
{
  "PDFByteArrayBase64": "JVBERi0xLjQK..."
}
```

**Mensagens:** `[Sucesso-DCTFWEB]` — Requisição efetuada com sucesso.

---

## 📄 CONSDECCOMPLETA33 — Consultar declaração completa

Exemplo com a declaração do **13º salário** (categoria 41, sem `MesPA`):

```csharp
var resposta = await servico.DctfWebConsultarDeclaracaoCompletaAsync(contribuinte, new ConsultaDctfWeb
{
    Categoria = CategoriaDctfWeb.Geral13Salario,
    AnoPA = "2025",
    NumeroReciboEntrega = 1198877
});

if (resposta.Sucesso && resposta.Retorno?.ObterPdf() is { } pdf)
    File.WriteAllBytes(@"C:\DCTFWeb\declaracao-13-2025.pdf", pdf);
```

### Dados enviados
```json
{
  "categoria": 41,
  "anoPA": "2025",
  "numeroReciboEntrega": 1198877
}
```

### Retorno (fictício)
```json
{
  "PDFByteArrayBase64": "JVBERi0xLjQK..."
}
```

**Mensagens:** `[Sucesso-DCTFWEB]` — Requisição efetuada com sucesso.

---

## 🗎 CONSXMLDECLARACAO38 — Consultar XML da declaração

Retorna o XML de uma declaração transmitida (já assinado) ou gera o XML de uma declaração **em andamento**, para assinatura e transmissão pelo `TRANSDECLARACAO310`.

```csharp
var resposta = await servico.DctfWebConsultarXmlDeclaracaoAsync(contribuinte, new ConsultaDctfWeb
{
    Categoria = CategoriaDctfWeb.GeralMensal,
    AnoPA = "2026",
    MesPA = "09"
    // NumeroReciboEntrega: informe para obter o XML de uma declaração transmitida específica
});

if (resposta.Sucesso && resposta.Retorno?.ObterXml() is { } xml)
    File.WriteAllBytes(@"C:\DCTFWeb\declaracao-202609.xml", xml); // não altere o conteúdo antes de assinar
```

### Dados enviados
```json
{
  "categoria": 40,
  "anoPA": "2026",
  "mesPA": "09"
}
```

### Retorno (fictício)
```json
{
  "XMLStringBase64": "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4K..."
}
```

**Mensagens:** `[Sucesso-DCTFWEB]` — Requisição efetuada com sucesso.

---

## 📤 TRANSDECLARACAO310 — Transmitir declaração

A declaração **em andamento** é transmitida a partir do XML do `CONSXMLDECLARACAO38`, assinado na tag `ConteudoDeclaracao` com o certificado do **autor do pedido de dados**.

### Com o XML assinado (`XmlDocument`)
O overload que recebe um `XmlDocument` codifica o XML (UTF-8) em Base64 e preenche `XmlAssinadoBase64`:

```csharp
using System.Xml;
using EficazFramework.SPED.Utilities;

// 1. obtém o XML da declaração em andamento
var consulta = await servico.DctfWebConsultarXmlDeclaracaoAsync(contribuinte, new ConsultaDctfWeb
{
    Categoria = CategoriaDctfWeb.GeralMensal,
    AnoPA = "2026",
    MesPA = "09"
});

// 2. carrega preservando espaços e quebras de linha (o XML deve permanecer idêntico)
var xml = new XmlDocument { PreserveWhitespace = true };
using (var stream = new MemoryStream(consulta.Retorno!.ObterXml()!))
    xml.Load(stream);

// 3. assina a tag ConteudoDeclaracao (RSA-SHA256) com o certificado do autor do pedido de dados:
//    a <Signature> é inserida em ProcDctf (irmã de ConteudoDeclaracao) com Reference URI="#<id de ConteudoDeclaracao>"
var certificadoAutor = new IcpBrasilX509Certificate2(@"C:\Certificados\escritorio.pfx", "senha");
certificadoAutor.SignXml(xml, "ProcDctf", "ConteudoDeclaracao", signAsSHA256: true);

// 4. transmite
var resposta = await servico.DctfWebTransmitirDeclaracaoAsync(contribuinte, new TransmitirDeclaracaoDctfWeb
{
    Categoria = CategoriaDctfWeb.GeralMensal,
    AnoPA = "2026",
    MesPA = "09"
}, xml);

if (resposta.Sucesso)
    Console.WriteLine($"Declaração transmitida. Recibo: {resposta.Retorno?.NumeroRecibo}");
```

### Com o Base64 já pronto
```csharp
// XML assinado por outro processo, lido sem nenhuma alteração
var xmlAssinadoBase64 = Convert.ToBase64String(File.ReadAllBytes(@"C:\DCTFWeb\espetaculo-20260920-assinado.xml"));

var resposta = await servico.DctfWebTransmitirDeclaracaoAsync(contribuinte, new TransmitirDeclaracaoDctfWeb
{
    Categoria = CategoriaDctfWeb.EspetaculoDesportivo,
    AnoPA = "2026",
    MesPA = "09",
    DiaPA = "20",
    XmlAssinadoBase64 = xmlAssinadoBase64       // XML assinado, codificado em Base64
});
```

### Dados enviados
(primeiro exemplo, categoria 40)
```json
{
  "categoria": 40,
  "anoPA": "2026",
  "mesPA": "09",
  "xmlAssinadoBase64": "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4K..."
}
```

### Retorno (fictício)
```json
{
  "NumeroRecibo": 1234568
}
```

**Mensagens:** `[Sucesso-DCTFWEB]` — Requisição efetuada com sucesso.

---

## 🧮 GERARGUIAANDAMENTO313 — Gerar guia de declaração em andamento

Para as apurações do **MIT**, use a categoria `GeralMensal` (40) e o sistema de origem `Mit`.

```csharp
var resposta = await servico.DctfWebGerarGuiaEmAndamentoAsync(contribuinte, new GerarGuiaAndamentoDctfWeb
{
    Categoria = CategoriaDctfWeb.GeralMensal,
    AnoPA = "2026",
    MesPA = "09",
    IdsSistemaOrigem = [SistemaOrigemDctfWeb.Mit]
});

if (resposta.Sucesso && resposta.Retorno?.ObterPdf() is { } pdf)
    File.WriteAllBytes(@"C:\DCTFWeb\darf-mit-202609.pdf", pdf);
```

### Dados enviados
```json
{
  "categoria": 40,
  "anoPA": "2026",
  "mesPA": "09",
  "idsSistemaOrigem": [8]
}
```

### Retorno (fictício)
```json
{
  "PDFByteArrayBase64": "JVBERi0xLjQK..."
}
```

**Mensagens:** `[Sucesso-DCTFWEB]` — Requisição efetuada com sucesso.

---

> [!NOTE]
> - Os métodos lançam `ArgumentNullException` se os dados ou o `AnoPA` não forem informados; o `TRANSDECLARACAO310` também exige o XML assinado.
> - Os campos de identificação da declaração (`categoria`, `anoPA`, `mesPA`, `diaPA`, `cnoAfericao`, `numProcReclamatoria`) são serializados antes dos campos específicos de cada serviço; campos nulos são omitidos.
> - `DataAcolhimentoProposta` é enviado com a chave em PascalCase (`"DataAcolhimentoProposta"`), como na documentação do SERPRO, e deve ser um dia útil do mês corrente, igual ou posterior a hoje.
> - Sistemas de origem (`SistemaOrigemDctfWeb`): 1 - eSocial, 5 - Sero, 6 - EFD-Reinf (CP), 7 - EFD-Reinf (RET), 8 - MIT. Quando informados, a guia contém apenas as receitas desses sistemas.
> - Na transmissão, a assinatura deve ser XMLDSig *enveloped*, RSA-SHA256, C14N, somente com o certificado final, na tag `ConteudoDeclaracao`. Fora a assinatura, o XML deve ser idêntico, caractere a caractere, ao recebido no `CONSXMLDECLARACAO38` — por isso carregue-o com `PreserveWhitespace = true`. Conforme o exemplo oficial, o elemento `<Signature>` fica dentro de `ProcDctf`, após `ConteudoDeclaracao`, e referencia o atributo `id` dela (`<Reference URI="#id_16436">`).
> - Os códigos de mensagem acima são ilustrativos.
