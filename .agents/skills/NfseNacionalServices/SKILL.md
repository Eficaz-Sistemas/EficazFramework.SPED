---
name: nfse-nacional-services
description: >-
  Orienta a implementação, correção, manutenção e testes dos serviços de comunicação REST
  com o Ambiente de Dados Nacional (ADN) da NFS-e (Sefin Nacional / Receita Federal / Serpro).
  Use esta skill sempre que trabalhar em Service.cs, Classes.cs ou quaisquer classes do namespace
  EficazFramework.SPED.Services.NFSe.Nacional ou endpoints da NFS-e Nacional.
---

# NFS-e Nacional Services (ADN / Sefin Nacional)

Esta skill define as diretrizes, contratos da API REST e padrões de implementação para o cliente de serviços da NFS-e Nacional (Ambiente de Dados Nacional - ADN / Sefin Nacional / Receita Federal / Serpro).

## 1. Referência Oficial da API

A documentação detalhada dos endpoints, payloads e contratos de resposta está documentada em:
- [src/NFsNacionaServices.md](../../../src/NFsNacionaServices.md)

---

## 2. Visão Geral dos Endpoints Suportados

| Método | Rota | Descrição | Requer Certificado (mTLS) |
|---|---|---|:---:|
| `POST` | `/nfse` | Recepciona a DPS síncrona e gera a NFS-e | Sim (ICP-Brasil) |
| `GET` | `/nfse/{chaveAcesso}` | Retorna a NFS-e autorizada pela chave de acesso (50 dígitos) | Sim (ICP-Brasil) |
| `GET` | `/dps/{id}` | Retorna a chave de acesso da NFS-e vinculada ao Id da DPS | Sim (ICP-Brasil) |
| `GET` | `/DFe/{NSU}` | Retorna o Documento Fiscal de Serviço correspondente ao NSU informado | Sim (ICP-Brasil) |
| `GET` | `/danfse/{chaveAcesso}` | Download do PDF do DANFSE gerado pelo ADN | Sim (ICP-Brasil) |
| `POST` | `/nfse/{chaveAcesso}/eventos` | Registra evento (ex.: cancelamento e101101). Corpo: `{ "pedidoRegistroEventoXmlGZipB64" }` | Sim (ICP-Brasil) |
| `GET` | `/nfse/{chaveAcesso}/eventos[/{tipoEvento}[/{numSeqEvento}]]` | Consulta os eventos da NFS-e | Sim (ICP-Brasil) |

Eventos (leiaute `pedRegEvento`/`evento` v1.01, XSDs em `src/Tests/EficazFramework.Tests/Resources/Schemas/NFSe/Nacional`):
- Schemas (`EficazFramework.SPED.Schemas/NFSe/Nacional/eventos.cs`, padrão `IXmlSpedDocument` como `NFSe`/`DPS`): `PedidoRegistroEvento` (raiz `pedRegEvento`, `XmlDocumentType.NFS_e_Nacional_PedidoEvento`) e `EventoNfse` (raiz `evento`, `NFS_e_Nacional_Evento`), com `Serialize`/`Deserialize`/`LoadFromAsync`, reconhecidos por `Operations.OpenAsync` (namespace da NFS-e); grupos `TE*` como subclasses de `DetalheEventoNfse`; enums `TipoEventoNfse`, `MotivoCancelamentoNfse`, `AmbienteGeradorEvento`.
- Serviço (`Services/NFSe/Nacional/Eventos.cs`): `EventosNfseNacional.MontarPedido`/`MontarPedidoCancelamento` (devolvem `PedidoRegistroEvento`), `LerEvento`, leitura tolerante do JSON.
- `Id` do `infPedReg`: `PRE` + chave (50) + código do evento (6) — `TSIdPedRegEvt`; `Id` do `infEvento`: `EVT` + chave + código + nº sequencial (3).
- Assinatura: `Certificado.SignXml(pedido, "pedRegEvento", "infPedReg", signAsSHA256: true)`.
- `Service.Eventos.cs`: `AssinarPedidoEvento`, `CancelarNfseAsync`, `RegistrarEventoAsync`, `ConsultarEventosAsync`. A leitura das respostas é tolerante (`erro`/`erros`, qualquer `*XmlGZipB64`); confirmar os nomes JSON em homologação.

DANFSe: `ObterDanfseAsync(chave, ambiente)` faz `GET` na URL de distribuição (ADN) + `CaminhoDanfse` (padrão `danfse/{0}`), com `Accept: application/pdf`, e devolve `RetornoDanfse` (`Pdf` só quando o conteúdo começa com `%PDF`; senão `ConteudoErro`). O caminho é configurável porque a documentação oficial não o detalha — confirmar em produção restrita.

---

## 3. Contratos de Dados (DTOs / Models)

O arquivo [Classes.cs](../../../src/Core/EficazFramework.SPED/Services/NFSe/Nacional/Classes.cs) deve refletir com exatidão os schemas retornados pelo ADN:

### 3.1. Envio de DPS (`POST /nfse`)
- **Request Body:**
  ```json
  {
    "dpsXmlGZipB64": "string"
  }
  ```
- **Response Sucesso (HTTP 201):**
  - `tipoAmbiente`: int (1 = Produção, 2 = Homologação)
  - `versaoAplicativo`: string
  - `dataHoraProcessamento`: DateTimeOffset / DateTime
  - `idDps`: string
  - `chaveAcesso`: string
  - `nfseXmlGZipB64`: string (XML da NFS-e gerada compactado em GZip e codificado em Base64)
  - `alertas`: Lista de mensagens (`codigo`, `descricao`, `complemento`)

- **Response Erro (HTTP 400, 403, 500):**
  - `tipoAmbiente`: int
  - `versaoAplicativo`: string
  - `dataHoraProcessamento`: DateTimeOffset / DateTime
  - `idDPS` / `idDps`: string
  - `erros`: Lista de mensagens (`codigo`, `descricao`, `complemento`)

### 3.2. Consulta por Chave de Acesso (`GET /nfse/{chaveAcesso}`)
- **Response Sucesso (HTTP 200):**
  - `tipoAmbiente`: int
  - `versaoAplicativo`: string
  - `dataHoraProcessamento`: DateTime
  - `chaveAcesso`: string
  - `nfseXmlGZipB64`: string (GZip Base64)

- **Response Erro (HTTP 400, 401, 403, 404):**
  - `tipoAmbiente`: int
  - `versaoAplicativo`: string
  - `dataHoraProcessamento`: DateTime
  - `erro`: Objeto único contendo `codigo`, `descricao`, `complemento` (atenção: difere do array `erros` do POST)

### 3.3. Consulta por ID da DPS (`GET /dps/{id}`)
- **Response Sucesso (HTTP 200):**
  - `tipoAmbiente`: int
  - `versaoAplicativo`: string
  - `dataHoraProcessamento`: DateTime
  - `idDps`: string
  - `chaveAcesso`: string

- **Response Erro (HTTP 400, 404):**
  - `tipoAmbiente`: int
  - `versaoAplicativo`: string
  - `dataHoraProcessamento`: DateTime
  - `erro`: Objeto contendo `codigo`, `descricao`, `complemento`

### 3.4. Consulta de DFe por NSU (`GET /DFe/{NSU}`)
- **Path Parameters:**
  - `NSU`: long (obrigatório)
- **Query Parameters (opcionais):**
  - `cnpjConsulta`: string
  - `lote`: bool
- **Response (HTTP 200, 400, 404):**
  - `StatusProcessamento`: enum/string (`REJEICAO`, `NENHUM_DOCUMENTO_LOCALIZADO`, `DOCUMENTOS_LOCALIZADOS`)
  - `LoteDFe`: Lista de itens (`NSU`, `ChaveAcesso`, `TipoDocumento`, `TipoEvento`, `ArquivoXml`, `DataHoraGeracao`, helper `XmlDocumento` descompactado)
  - `Alertas`: Lista de mensagens (`Mensagem`, `Parametros`, `Codigo`, `Descricao`, `Complemento`)
  - `Erros`: Lista de mensagens (`Mensagem`, `Parametros`, `Codigo`, `Descricao`, `Complemento`)
  - `TipoAmbiente`: enum/string (`PRODUCAO`, `HOMOLOGACAO`)
  - `VersaoAplicativo`: string
  - `DataHoraProcessamento`: DateTime

---

## 4. Diretrizes de Implementação no `Service.cs`

1. **Herança e Certificado:**
   - A classe `NfseNacionalService` herda de `RestServiceBase` (todo serviço REST usa certificado no mTLS).
   - O `RestServiceBase` cria um único `HttpClient` por instância, na primeira requisição, com `Certificado.PrivateInstance` em `SocketsHttpHandler.SslOptions.ClientCertificates`.
   - Nunca usar `BaseAddress` nem `DefaultRequestHeaders`: montar a URL completa com `Endereco(ambiente, caminho, distribuicao)` e enviar por `EnviarAsync` (cabeçalhos por requisição).
   - O serviço é `IDisposable`: uma instância por certificado, descartada ao final.

2. **Endpoints Base:**
   - Produção: `https://sefin.nfse.gov.br/` (ou caminho base aplicável)
   - Homologação: `https://sefin.producaorestrita.nfse.gov.br/SefinNacional/`

3. **Serialização e Naming Policy:**
   - JSON com `camelCase` (`JsonNamingPolicy.CamelCase`).
   - Propriedades com case alternativo (ex: `idDPS` vs `idDps`) devem ter atributos ou desserializadores tolerantes.
   - `tipoAmbiente` na API do ADN é serializado como **inteiro** (`1` ou `2`), e não como string pura de enum.

4. **Tratamento de Erros e Polimorfismo de Resposta:**
   - Se o status code for de erro (400, 401, 403, 404, 500), desserializar a estrutura de erro correspondente (`erros: []` ou `erro: {}`).
   - Tratar respostas que não sejam JSON válido (HTML de gateway, proxy 502/504) encapsulando em um objeto de resposta de erro padronizado do framework.

5. **Descompressão Automática:**
   - Ao receber `nfseXmlGZipB64`, disponibilizar helper ou propriedade para obter o XML da NFS-e descompactado em texto puro UTF-8.

---

## 5. Checklist para Modificações

Ao corrigir ou evoluir o [Service.cs](../../../src/Core/EficazFramework.SPED/Services/NFSe/Nacional/Service.cs) e [Classes.cs](../../../src/Core/EficazFramework.SPED/Services/NFSe/Nacional/Classes.cs):

- [ ] Verificar se os DTOs em `Classes.cs` contemplam:
  - `RetornoEnvioDps` (com `nfseXmlGZipB64`, `alertas`, `erros`, etc.)
  - `RetornoConsultaNfse` (com `nfseXmlGZipB64`, `erro`)
  - `RetornoConsultaDps` (com `idDps`, `chaveAcesso`, `erro`)
  - `MensagemProcessamento` com mapeamento de `codigo`, `descricao`, `complemento`
- [ ] Implementar em `Service.cs` o método `ConsultarNfsePorDpsAsync(string idDps, ...)`.
- [ ] Ajustar `ConsultarNfsePorChaveAsync` para desserializar a resposta específica de consulta (objeto `erro` vs lista `erros`).
- [ ] Garantir deserialização de `tipoAmbiente` compatível com inteiro (`1` e `2`).
- [ ] Assegurar descompressão transparente de `nfseXmlGZipB64`.
- [ ] Validar a compilação do projeto com `dotnet build`.
