# DTE — Domicílio Tributário Eletrônico

O **DTE** (Domicílio Tributário Eletrônico) é a adesão do contribuinte à comunicação eletrônica com a Receita Federal (Caixa Postal do e-CAC e do Simples Nacional). O serviço consulta a situação do contribuinte quanto a essa adesão.

[← Integra Contador](../IntegraContador.md) · Ver também: [Caixa Postal](CaixaPostal.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `CONSULTASITUACAODTE111` | `/Consultar` | 1.0 | `DteConsultarSituacaoAsync` | `RetornoSituacaoDte` |

O identificador está em `Catalogo.Dte.ConsultarSituacao`.

---

## 🚀 Preparação

Os exemplos consideram o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço) e o contribuinte abaixo:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

> [!TIP]
> Os tipos do DTE ficam no mesmo namespace da Caixa Postal (`EficazFramework.SPED.Schemas.IntegraContador.IntegraCaixaPostal`), pois ambos pertencem à solução Integra-CaixaPostal.

---

## 📮 CONSULTASITUACAODTE111 — Consultar situação do DTE

Não tem dados de entrada: a consulta se refere ao contribuinte da requisição.

```csharp
var resposta = await servico.DteConsultarSituacaoAsync(contribuinte);

if (resposta.Sucesso)
{
    var situacao = resposta.Retorno!;
    Console.WriteLine($"{situacao.IndicadorEnquadramento}: {situacao.StatusEnquadramento}");

    var aderiuDte = situacao.IndicadorEnquadramento is IndicadorEnquadramentoDte.OptanteDte
                                                     or IndicadorEnquadramentoDte.OptanteDteESimples;
    if (!aderiuDte)
        Console.WriteLine("Contribuinte sem adesão ao DTE: orientar a opção no e-CAC.");
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

#### Dados enviados
Nenhum — `pedidoDados.dados` é enviado vazio (`""`).

#### Retorno (fictício)
```json
{
  "indicadorEnquadramento": 0,
  "statusEnquadramento": "CNPJ Optante DTE"
}
```
Mensagens: `[Sucesso-DTE] Requisição efetuada com sucesso.`

Valores de `IndicadorEnquadramentoDte`:

| Código | Membro | Significado |
|:--|:--|:--|
| -2 | `NiInvalido` | NI inválido |
| -1 | `NaoOptante` | NI não optante |
| 0 | `OptanteDte` | NI optante DTE |
| 1 | `OptanteSimples` | NI optante Simples |
| 2 | `OptanteDteESimples` | NI optante DTE e Simples |

> [!NOTE]
> O `indicadorEnquadramento` é aceito tanto como número (`0`, `-2`) quanto como texto (`"-1"`); texto vazio resulta em `null`.
