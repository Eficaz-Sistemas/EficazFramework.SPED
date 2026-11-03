# EPROCESSO — Processos digitais (e-Processo)

Serviço da solução **Integra-e-Processo** que consulta todos os processos digitais da Receita Federal em que o contribuinte figura como interessado.

[← Integra Contador](../IntegraContador.md)

---

## 📋 Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--:|:--|:--|
| `CONSPROCPORINTER271` | `/Consultar` | 2.0 | `EProcessoConsultarProcessosAsync` | `List<Processo>` |

O `idSistema` é `EPROCESSO` (ver `Catalogo.EProcesso`).

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço):

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraEProcesso;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

---

## 📂 CONSPROCPORINTER271 — Consultar processos por interessado

O serviço não tem dados de entrada: basta informar o contribuinte.

```csharp
var resposta = await servico.EProcessoConsultarProcessosAsync(contribuinte);

if (resposta.Sucesso)
{
    foreach (var processo in resposta.Retorno ?? [])
    {
        Console.WriteLine($"{processo.NumeroDoProcesso} ({processo.RelacaoDoInteressadoComOProcesso}) - protocolado em {processo.DataDeProtocolo}");
        Console.WriteLine($"  {processo.TipoDoProcesso} / {processo.SubtipoDoProcesso}");
        Console.WriteLine($"  Situação: {processo.Situacao} | Localização: {processo.Localizacao}");
        if (processo.UltimoEncaminhamentoExterno is { } encaminhamento)
            Console.WriteLine($"  Último encaminhamento externo: {encaminhamento}");
    }
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

### Dados enviados
O campo `pedidoDados.dados` é enviado vazio:
```json
""
```

### Retorno (fictício)
```json
[
  {
    "numeroDoProcesso": "10880123456202611",
    "relacaoDoInteressadoComOProcesso": "INTERESSADO",
    "dataDeProtocolo": "12/02/2026",
    "tipoDoProcesso": "RESTITUIÇÃO/RESSARCIMENTO/REEMBOLSO/COMPENSAÇÃO",
    "subtipoDoProcesso": "PEDIDO DE RESTITUIÇÃO",
    "localizacao": "DRF-SÃO PAULO-SP",
    "situacao": "EM ANDAMENTO",
    "ultimoEncaminhamentoExterno": null
  },
  {
    "numeroDoProcesso": "16327720001202599",
    "relacaoDoInteressadoComOProcesso": "INTERESSADO",
    "dataDeProtocolo": "03/09/2025",
    "tipoDoProcesso": "AÇÃO FISCAL",
    "subtipoDoProcesso": "MEMORIAL",
    "localizacao": "CARF",
    "situacao": "CONFIRMADO",
    "ultimoEncaminhamentoExterno": "CARF - 1ª SEÇÃO"
  }
]
```

**Mensagens:** `[Sucesso-EPROCESSO-SC_001]` — Requisição efetuada com sucesso.

---

> [!NOTE]
> - A versão do sistema deste serviço é `"2.0"`.
> - Na documentação do SERPRO o campo `dados` da resposta aparece como **array JSON**, e não como string JSON escapada; o cliente aceita os dois formatos e preenche `Retorno` normalmente (o conteúdo bruto fica em `resposta.Dados`).
> - `DataDeProtocolo` vem no formato `DD/MM/AAAA` (texto); todos os campos do `Processo` são textos e podem vir nulos.
> - Os números de processo e demais dados acima são fictícios.
