# PROCURACOES — Procurações eletrônicas

Serviço da solução **Integra-Procurações** que obtém as procurações eletrônicas (e-CAC) outorgadas por um contribuinte a um procurador, com a data de expiração e os sistemas autorizados em cada uma.

[← Integra Contador](../IntegraContador.md)

---

## 📋 Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--:|:--|:--|
| `OBTERPROCURACAO41` | `/Consultar` | 1 | `ProcuracoesObterAsync` | `List<Procuracao>` |

O `idSistema` é `PROCURACOES` (ver `Catalogo.Procuracoes`).

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço):

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraProcuracoes;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

---

## 🧾 OBTERPROCURACAO41 — Obter procurações

O outorgante é o titular (aqui, o próprio contribuinte) e o outorgado é o procurador (ex.: o escritório de contabilidade). `ObterProcuracao.Criar` monta a entrada a partir das identificações, preenchendo os tipos (`"1"` - CPF, `"2"` - CNPJ):

```csharp
var dados = ObterProcuracao.Criar(
    outorgante: contribuinte,
    outorgado: Identificacao.Cnpj("99888777000166"));

// equivalente a:
// new ObterProcuracao { Outorgante = "00000000000100", TipoOutorgante = "2", Outorgado = "99888777000166", TipoOutorgado = "2" }

var resposta = await servico.ProcuracoesObterAsync(contribuinte, dados);

if (resposta.Sucesso)
{
    foreach (var procuracao in resposta.Retorno ?? [])
    {
        var expiracao = DateTime.ParseExact(procuracao.DtExpiracao!, "yyyyMMdd", null);
        Console.WriteLine($"Expira em {expiracao:dd/MM/yyyy} - {procuracao.NrSistemas} sistema(s):");
        foreach (var sistema in procuracao.Sistemas ?? [])
            Console.WriteLine($"  - {sistema}");
    }
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
  "outorgante": "00000000000100",
  "tipoOutorgante": "2",
  "outorgado": "99888777000166",
  "tipoOutorgado": "2"
}
```

### Retorno (fictício)
```json
[
  {
    "dtexpiracao": "20271231",
    "nrsistemas": 3,
    "sistemas": [
      "Caixa Postal - Mensagens",
      "Caixa Postal - Termo de Opção pelo Domicílio Tributário Eletrônico",
      "DCTFWeb"
    ]
  },
  {
    "dtexpiracao": "20270630",
    "nrsistemas": 2,
    "sistemas": [
      "Simples Nacional - PGDAS-D",
      "Certidões e Situação Fiscal"
    ]
  }
]
```

**Mensagens:** `[Sucesso-PROCURACOES]` — Requisição efetuada com sucesso.

---

> [!NOTE]
> - A versão do sistema deste serviço é `"1"` (e não `"1.0"`), conforme o `Catalogo.Procuracoes.ObterProcuracao`.
> - Os tipos de outorgante e outorgado são enviados como **texto** (`"1"` - CPF, `"2"` - CNPJ), e os números somente com dígitos (CPF com 11, CNPJ com 14).
> - `DtExpiracao` vem no formato `AAAAMMDD` (texto) e `NrSistemas` é a quantidade de itens de `Sistemas`.
> - `ProcuracoesObterAsync` lança `ArgumentNullException` se os dados não forem informados.
> - Os nomes de sistemas e os códigos de mensagem acima são ilustrativos.
