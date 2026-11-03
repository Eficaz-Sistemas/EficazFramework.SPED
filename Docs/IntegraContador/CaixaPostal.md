# CAIXAPOSTAL — Integra-CaixaPostal

A **Caixa Postal** do e-CAC concentra as mensagens e intimações enviadas pela Receita Federal (e por estados/municípios conveniados) ao contribuinte. O framework lista as mensagens com filtros e paginação, obtém o detalhe (corpo) de uma mensagem e consulta o indicador de mensagens novas.

[← Integra Contador](../IntegraContador.md) · Ver também: [DTE](Dte.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `MSGCONTRIBUINTE61` | `/Consultar` | 1.0 | `CaixaPostalListarMensagensAsync` | `RetornoListaMensagens` |
| `MSGDETALHAMENTO62` | `/Consultar` | 1.0 | `CaixaPostalDetalharMensagemAsync` | `RetornoDetalheMensagem` |
| `INNOVAMSG63` | `/Monitorar` | 1.0 | `CaixaPostalIndicadorNovasMensagensAsync` | `RetornoIndicadorNovasMensagens` |

Os identificadores estão em `Catalogo.CaixaPostal` (`ListarMensagens`, `DetalharMensagem`, `IndicadorNovasMensagens`).

---

## 🚀 Preparação

Os exemplos consideram o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço) e o contribuinte abaixo:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

---

## 🔔 INNOVAMSG63 — Indicador de mensagens novas

Serviço de monitoramento (não tarifado) que indica se há mensagens ainda não lidas por ninguém. Não tem dados de entrada. É o ponto de partida recomendado: só liste as mensagens quando houver novidades.

```csharp
var resposta = await servico.CaixaPostalIndicadorNovasMensagensAsync(contribuinte);

if (resposta.Sucesso)
{
    switch (resposta.Retorno?.IndicadorMensagensNovas)
    {
        case IndicadorMensagensNovas.SemMensagensNovas:
            Console.WriteLine("Nenhuma mensagem nova.");
            break;
        case IndicadorMensagensNovas.UmaMensagemNova:
            Console.WriteLine("Há uma mensagem nova.");
            break;
        case IndicadorMensagensNovas.MensagensNovas:
            Console.WriteLine("Há mensagens novas.");
            break;
    }
}
```

#### Dados enviados
Nenhum — `pedidoDados.dados` é enviado vazio (`""`).

#### Retorno (fictício)
```json
{
  "codigo": "00",
  "conteudo": [
    {
      "indicadorMensagensNovas": "2"
    }
  ]
}
```
Mensagens: `[Sucesso-CAIXAPOSTAL] Requisição efetuada com sucesso.`

---

## 📬 MSGCONTRIBUINTE61 — Listar mensagens

Lista até 50 mensagens por página, das mais recentes para as mais antigas. Sem filtro (`CaixaPostalListarMensagensAsync(contribuinte)`), retorna a página inicial com todas as mensagens.

```csharp
var filtro = new ListarMensagens
{
    CnpjReferencia = "00000000000100",           // somente para contribuinte PJ
    StatusLeitura = StatusLeitura.NaoLida,
    IndicadorFavorito = IndicadorFavorito.NaoFavorita,
    IndicadorPagina = IndicadorPagina.Inicial
};

while (true)
{
    var resposta = await servico.CaixaPostalListarMensagensAsync(contribuinte, filtro);
    if (!resposta.Sucesso)
    {
        foreach (var msg in resposta.Mensagens ?? [])
            Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
        break;
    }

    var pagina = resposta.Retorno?.Conteudo?.FirstOrDefault();
    if (pagina is null)
        break;

    foreach (var mensagem in pagina.ListaMensagens ?? [])
    {
        var lida = mensagem.IndicadorLeitura == "1" ? "lida" : "não lida";
        Console.WriteLine($"[{mensagem.Isn}] {mensagem.DataEnvio} {mensagem.HoraEnvio} - {mensagem.AssuntoFormatado} ({lida})");
        Console.WriteLine($"   Origem: {mensagem.DescricaoOrigem} | Controle: {mensagem.NumeroControle} | Validade: {mensagem.DataValidade}");
    }

    if (pagina.UltimaPagina)
        break;

    // próxima página: informa o ponteiro retornado
    filtro.IndicadorPagina = IndicadorPagina.NaoInicial;
    filtro.PonteiroPagina = pagina.PonteiroProximaPagina;
}
```

#### Dados enviados
Primeira página:
```json
{
  "cnpjReferencia": "00000000000100",
  "statusLeitura": "2",
  "indicadorFavorito": "0",
  "indicadorPagina": "0"
}
```

Página seguinte:
```json
{
  "cnpjReferencia": "00000000000100",
  "statusLeitura": "2",
  "indicadorFavorito": "0",
  "indicadorPagina": "1",
  "ponteiroPagina": "202510010815300000000000"
}
```

Sem filtro, o corpo enviado é `{"statusLeitura":"0","indicadorPagina":"0"}`.

#### Retorno (fictício)
```json
{
  "codigo": "00",
  "conteudo": [
    {
      "quantidadeMensagens": "2",
      "indicadorUltimaPagina": "N",
      "ponteiroPaginaRetornada": "202510280930120000000000",
      "ponteiroProximaPagina": "202510010815300000000000",
      "cnpjMatriz": "00000000000100",
      "listaMensagens": [
        {
          "codigoSistemaRemetente": "00019",
          "codigoModelo": "00007",
          "dataEnvio": "20251028",
          "horaEnvio": "093012",
          "numeroControle": "2025/000000000045678",
          "indicadorLeitura": "0",
          "dataLeitura": "",
          "horaLeitura": "",
          "dataExclusao": "",
          "horaExclusao": "",
          "dataCiencia": "",
          "assuntoModelo": "Termo de Intimação - Processo nº ++VARIAVEL++",
          "dataValidade": "20260128",
          "origemModelo": "1",
          "valorParametroAssunto": "10880.720001/2025-11",
          "relevancia": "2",
          "isn": "0001626772",
          "tipoOrigem": "1",
          "descricaoOrigem": "RECEITA FEDERAL DO BRASIL",
          "indicadorFavorito": "0"
        },
        {
          "codigoSistemaRemetente": "00014",
          "codigoModelo": "00009",
          "dataEnvio": "20251015",
          "horaEnvio": "141505",
          "numeroControle": "2025/000000000044321",
          "indicadorLeitura": "0",
          "dataLeitura": "",
          "horaLeitura": "",
          "dataExclusao": "",
          "horaExclusao": "",
          "dataCiencia": "",
          "assuntoModelo": "[e-Processo] Dossiê: ++VARIAVEL++ - Abertura do Dossiê",
          "dataValidade": "20260115",
          "origemModelo": "1",
          "valorParametroAssunto": "10010.123456/1025-01",
          "relevancia": "1",
          "isn": "0001621450",
          "tipoOrigem": "1",
          "descricaoOrigem": "RECEITA FEDERAL DO BRASIL",
          "indicadorFavorito": "0"
        }
      ]
    }
  ]
}
```
Mensagens: `[Sucesso-CAIXAPOSTAL] Requisição efetuada com sucesso.`

Com esse retorno, `AssuntoFormatado` da primeira mensagem é `Termo de Intimação - Processo nº 10880.720001/2025-11` e `UltimaPagina` é `false`.

---

## ✉️ MSGDETALHAMENTO62 — Detalhar mensagem

Obtém o corpo (HTML) e as variáveis de uma mensagem, identificada pelo `Isn` da lista.

> [!WARNING]
> Assim como no portal e-CAC, a execução deste serviço **caracteriza ciência da intimação** (art. 23, § 2º, inciso III, do Decreto nº 70.235/1972). Detalhe a mensagem apenas quando o contribuinte (ou o escritório) realmente for tomar ciência.

```csharp
var resposta = await servico.CaixaPostalDetalharMensagemAsync(contribuinte, "0001626772");

if (resposta.Sucesso && resposta.Retorno?.Conteudo?.FirstOrDefault() is { } detalhe)
{
    Console.WriteLine(detalhe.AssuntoFormatado);
    Console.WriteLine($"Enviada em {detalhe.DataEnvio} - expira em {detalhe.DataExpiracao}");

    // corpo com ++1++, ++2++... substituídos pelas variáveis
    File.WriteAllText($@"C:\CaixaPostal\{detalhe.Isn}.html", detalhe.CorpoFormatado);
}
```

#### Dados enviados
```json
{
  "isn": "0001626772"
}
```

#### Retorno (fictício)
```json
{
  "codigo": "00",
  "conteudo": [
    {
      "codigoSistemaRemetente": "00019",
      "codigoModelo": "00007",
      "assuntoModelo": "Termo de Intimação - Processo nº ++VARIAVEL++",
      "origemModelo": "1",
      "dataEnvio": "20251028",
      "horaEnvio": "093012",
      "valorParametroAssunto": "10880.720001/2025-11",
      "dataLeitura": "20251028",
      "horaLeitura": "101544",
      "dataExpiracao": "20260128",
      "numeroControle": "2025/000000000045678",
      "dataCiencia": "20251028",
      "indFavorito": "0",
      "relevancia": "2",
      "isn": "0001626772",
      "enquadramento": "0",
      "dataAcessoExterno": "20251028",
      "horaAcessoExterno": "101544",
      "tipoAutenticacaoUsuario": "2",
      "codigoAcesso": "",
      "numeroSerieCertificadoDigital": "1A2B3C4D5E6F7A8B",
      "emissorCertificadoDigital": "AC FICTICIA RFB v5",
      "tipoUsuario": "2",
      "niUsuario": "11222333000181",
      "papelUsuario": "3",
      "codigoAplicacao": "00000",
      "tipoOrigem": "1",
      "descricaoOrigem": "RECEITA FEDERAL DO BRASIL",
      "corpoModelo": "<p>Fica o contribuinte intimado a apresentar, no prazo de ++1++ dias, os documentos relativos ao período de ++2++.</p><p>Auditor responsável: ++3++</p>",
      "variaveis": ["20", "01/2024 a 12/2024", "FULANO DE TAL"]
    }
  ]
}
```
Mensagens: `[Sucesso-CAIXAPOSTAL] Requisição efetuada com sucesso.`

Com esse retorno, `CorpoFormatado` é:
```html
<p>Fica o contribuinte intimado a apresentar, no prazo de 20 dias, os documentos relativos ao período de 01/2024 a 12/2024.</p><p>Auditor responsável: FULANO DE TAL</p>
```

> [!NOTE]
> - Os enums da entrada (`StatusLeitura`, `IndicadorFavorito`, `IndicadorPagina`) são enviados **como texto** (`"2"`, `"0"`), conforme o exemplo da documentação; `IndicadorFavorito` nulo não é enviado.
> - Datas e horas das mensagens vêm como texto `AAAAMMDD` / `HHMMSS` (vazio quando não há valor). Códigos que a API às vezes devolve como número (`codigo`, `isn`, `quantidadeMensagens`, ponteiros etc.) são lidos como texto, preservando zeros à esquerda.
> - No detalhe, o indicador de favorita vem no campo `indFavorito` (na lista, `indicadorFavorito`); ambos são expostos como `IndicadorFavorito`.
> - `AssuntoFormatado` substitui `++VARIAVEL++` por `ValorParametroAssunto`; `CorpoFormatado` substitui `++n++` pelo n-ésimo item de `Variaveis` — marcadores sem variável correspondente são mantidos.
