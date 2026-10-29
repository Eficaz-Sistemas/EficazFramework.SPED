# AUTENTICAPROCURADOR — Autenticação de procurador

Quando o **autor do pedido de dados** (ex.: o escritório contábil com procuração dos clientes) não é o contratante, ele assina digitalmente um **Termo de Autorização** permitindo que o contratante faça as requisições em seu nome. O envio do termo devolve um token que passa a acompanhar automaticamente as requisições seguintes.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `ENVIOXMLASSINADO81` | `/Apoiar` | 1.0 | `AutenticarProcuradorAsync` (2 sobrecargas) | `RetornoAutenticaProcurador` |
| — (local) | — | — | `AssinarTermo` | `string` (termo assinado em Base64) |

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço) (contratante `11222333000181`).

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;
using EficazFramework.SPED.Services.IntegraContador;
using EficazFramework.SPED.Utilities;

var contribuinte = Identificacao.Cnpj("00000000000100"); // cliente do escritório
```

---

## 📝 Termo de autorização (`TermoAutorizacao`)

```csharp
var termo = new TermoAutorizacao
{
    CnpjContratante = "11222333000181",          // destinatário da autorização
    NomeContratante = "EMPRESA CONTRATANTE LTDA",
    NumeroAutor = "99888777000166",               // deve ser o NI do certificado que assina
    NomeAutor = "ESCRITORIO CONTABIL LTDA",
    TipoAutor = TipoIdentificacao.CNPJ,           // CPF (e-CPF) ou CNPJ (e-CNPJ)
    DataAssinatura = new DateTime(2026, 10, 28),  // padrão: hoje
    Vigencia = new DateTime(2027, 10, 28)         // padrão: hoje + 1 ano
};
```

`TermoAutorizacao.GerarXml()` produz o XML abaixo — **sem declaração XML e sem indentação** (aqui indentado e com os textos fixos abreviados por legibilidade). Os textos completos estão nas constantes `TermoAutorizacao.TextoTermo`, `TextoAvisoLegal` e `TextoFinalidade`.

```xml
<termoDeAutorizacao>
  <dados>
    <sistema id="API Integra Contador" />
    <termo texto="Autorizo a empresa CONTRATANTE, identificada neste termo de autorização como DESTINATÁRIO, a executar as requisições…" />
    <avisoLegal texto="O acesso a estas informações foi autorizado pelo próprio PROCURADOR ou OUTORGADO DO CONTRIBUINTE…" />
    <finalidade texto="A finalidade única e exclusiva desse TERMO DE AUTORIZAÇÃO, é garantir que o CONTRATANTE apresente…" />
    <dataAssinatura data="20261028" />
    <vigencia data="20271028" />
    <destinatario numero="11222333000181" nome="EMPRESA CONTRATANTE LTDA" tipo="PJ" papel="contratante" />
    <assinadoPor numero="99888777000166" nome="ESCRITORIO CONTABIL LTDA" tipo="PJ" papel="autor pedido de dados" />
  </dados>
</termoDeAutorizacao>
```

`AssinarTermo(termo, certificadoAutor)` assina o XML (XMLDSig RSA-SHA256, enveloped + C14N, `Reference URI=""`), inserindo `<Signature>` como último filho de `termoDeAutorizacao`, e devolve o XML assinado em Base64. Sem `certificadoAutor`, usa o certificado do serviço (`SelecionaCertificado`).

---

## 🔐 ENVIOXMLASSINADO81 — Enviar termo assinado

### Sobrecarga 1: termo + certificado (gera, assina e envia)

```csharp
var certificadoAutor = new IcpBrasilX509Certificate2(@"C:\Certificados\escritorio.pfx", "senha");
var resposta = await servico.AutenticarProcuradorAsync(termo, certificadoAutor);

if (resposta.Retorno?.Token is { } token) // 200 ou 304 (ver abaixo)
    Console.WriteLine($"Token {token} válido até {resposta.Retorno.DataHoraExpiracao:dd/MM/yyyy HH:mm:ss}");
else
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
```

O autor do pedido de dados é `new Identificacao(termo.NumeroAutor, termo.TipoAutor)` e o contribuinte da requisição é o próprio autor.

### Sobrecarga 2: termo já assinado (Base64)

Útil quando a assinatura é feita em outro lugar (ex.: na máquina do escritório, que detém o certificado A3):

```csharp
string termoAssinado = servico.AssinarTermo(termo, certificadoAutor); // ou recebido de outro sistema

var resposta = await servico.AutenticarProcuradorAsync(
    termoAssinado,
    autorPedidoDados: Identificacao.Cnpj("99888777000166"),
    contribuinte: null,              // padrão: o próprio autor
    ambiente: Ambiente.Producao);    // padrão: servico.Ambiente
```

**Dados enviados** (`pedidoDados.dados`) — `EnvioXmlAssinado`:

```json
{"xml":"PHRlcm1vRGVBdXRvcml6YWNhbz48ZGFkb3M+..."}
```

Envelope da requisição (trecho):

```json
{
  "contratante": { "numero": "11222333000181", "tipo": 2 },
  "autorPedidoDados": { "numero": "99888777000166", "tipo": 2 },
  "contribuinte": { "numero": "99888777000166", "tipo": 2 },
  "pedidoDados": {
    "idSistema": "AUTENTICAPROCURADOR",
    "idServico": "ENVIOXMLASSINADO81",
    "versaoSistema": "1.0",
    "dados": "{\"xml\":\"PHRlcm1vRGVBdXRvcml6YWNhbz48ZGFkb3M+...\"}"
  }
}
```

**Retorno (fictício)** — HTTP 200:

```json
{
  "autenticar_procurador_token": "b06feea3-1ca8-49f4-bdb4-211ab006cb92",
  "data_hora_expiracao": "2026-10-30T00:00:01"
}
```

Mensagens: `[Sucesso-AUTENTICAPROCURADOR]` — Requisição efetuada com sucesso.

### HTTP 304 — termo ainda válido no cache do SERPRO

Se o mesmo termo ainda estiver válido, o SERPRO responde **304 sem corpo**. O método extrai o token (UUID) do cabeçalho `ETag` e a expiração do cabeçalho `Expires`, preenchendo `Retorno` normalmente:

```http
HTTP/1.1 304 Not Modified
ETag: "autenticar_procurador_token:b06feea3-1ca8-49f4-bdb4-211ab006cb92"
Expires: Fri, 30 Oct 2026 03:00:01 GMT
```

```csharp
// resposta.StatusCode == 304
// resposta.Retorno!.Token == "b06feea3-1ca8-49f4-bdb4-211ab006cb92"
// resposta.Retorno.DataHoraExpiracao == resposta.Expires?.LocalDateTime (30/10/2026 00:00:01 em Brasília)
```

> [!IMPORTANT]
> `Sucesso` considera apenas 2xx, portanto é `false` no 304. Verifique `resposta.Retorno?.Token` (como no exemplo acima) em vez de `resposta.Sucesso`.

---

## 🔄 Uso automático do token

Sempre que a resposta (200 ou 304) traz um token, o serviço passa a usá-lo como padrão:

- `servico.TokenProcurador` recebe o token, enviado no cabeçalho `autenticar_procurador_token` de todas as requisições seguintes (exceto no endpoint `/Apoiar`, que não o aceita);
- `servico.AutorPedidoDados` recebe o autor que assinou o termo, enviado em `autorPedidoDados` (em vez do contratante).

```csharp
await servico.AutenticarProcuradorAsync(termo, certificadoAutor);

// já vai com autorPedidoDados = 99888777000166 e o cabeçalho autenticar_procurador_token
var pedidos = await servico.ParcelamentoConsultarPedidosAsync(ModalidadeParcelamento.PARCSN, contribuinte);

// sobrescrevendo por requisição (ex.: outro procurador)
var outro = new OpcoesRequisicao(
    AutorPedidoDados: Identificacao.Cpf("00000000191"),
    TokenProcurador: "5f0c8e2a-7d41-4b6e-9a3c-2e1d4f6a8b90");
var dte = await servico.ExecutarAsync(Catalogo.Dte.ConsultarSituacao, contribuinte, dadosJson: null, outro);

// reaproveitando um token guardado (ex.: em outra instância do serviço)
servico.TokenProcurador = "b06feea3-1ca8-49f4-bdb4-211ab006cb92";
servico.AutorPedidoDados = Identificacao.Cnpj("99888777000166");
```

> [!NOTE]
> O token vale até o fim do dia seguinte (`DataHoraExpiracao`, horário de Brasília). Guarde-o e reenvie o termo apenas após a expiração. `NumeroAutor` deve coincidir com o NI do certificado que assina; `destinatario` é sempre `tipo="PJ"` / `papel="contratante"` e `assinadoPor` usa `PF` quando `TipoAutor` é `CPF` e `PJ` nos demais casos. `AssinarTermo` lança `ArgumentNullException` sem termo ou sem certificado disponível; `AutenticarProcuradorAsync` lança `ArgumentNullException` sem termo assinado ou sem autor.
