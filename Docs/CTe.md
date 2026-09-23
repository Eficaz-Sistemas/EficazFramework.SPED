# Conhecimento de Transporte Eletrônico (CT-e e CT-eOS)

O **CT-e** (Conhecimento de Transporte Eletrônico, Modelo 57) e o **CT-eOS** (Conhecimento de Transporte Eletrônico para Outros Serviços, Modelo 67) são estruturados em XML. No *EficazFramework.SPED*, o documento de transporte completo é representado principalmente pelas classes `ProcessoCTe` (que engloba o conhecimento de transporte e seu respectivo protocolo de autorização) e `CTe` (que representa o conhecimento em si).

---

## 🚀 Leitura de XML de CT-e / CT-eOS (Desserialização)
Semelhante à NF-e, o framework identifica automaticamente o XML de transporte por meio do utilitário `Operations.OpenAsync(...)`:

```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.CTe;
using EficazFramework.SPED.Utilities.XML;

// 1. Abre o arquivo XML do CT-e
using Stream stream = File.OpenRead(@"C:\DFse\cte.xml");

// 2. Abre e identifica automaticamente o tipo do documento fiscal
var documento = await Operations.OpenAsync(stream);

// 3. Faz o cast para a classe ProcessoCTe
if (documento is ProcessoCTe procCTe)
{
    Console.WriteLine($"Chave de Acesso: {procCTe.Chave}");
    Console.WriteLine($"Número do CT-e: {procCTe.CTe.InformacoesCTe.Identificacao.Numero}");
    Console.WriteLine($"Valor total do serviço: {procCTe.CTe.InformacoesCTe.ValoresPrestacaoServico.ValorTotalPrestacao:C}");
    Console.WriteLine($"Remetente CNPJ: {procCTe.CTe.InformacoesCTe.Remetente.CNPJ_CPF}");
}
```

---

## 📡 Integração de Serviços (Sefaz WebServices)

A classe `CTeService` (sob o namespace `EficazFramework.SPED.Services.CTe`) é responsável pela comunicação SOAP com os WebServices autorizadores de transporte.

### 1. Consultando a Situação de um CT-e
Útil para verificar o status de autorização de um documento de transporte a partir de sua chave de acesso:

```csharp
using System;
using System.Threading.Tasks;
using EficazFramework.SPED.Services.CTe;
using EficazFramework.SPED.Schemas.CTe;
using EficazFramework.SPED.Utilities;

// 1. Inicializa o serviço com o certificado ICP-Brasil
var servico = new CTeService()
{
    SelecionaCertificado = () => new IcpBrasilX509Certificate2(@"C:\Certificados\certificado.pfx", "senha")
};

string chaveCTe = "31231120855151000139650040000938509100660678";

try
{
    // 2. Consulta de forma assíncrona
    RetornoConsultaSituacaoCTe consulta = await servico.ConsultaSituacaoAsync(
        chaveCTe,
        EficazFramework.SPED.Schemas.NFe.Ambiente.Homologacao
    );

    Console.WriteLine($"Status Consulta: {consulta.cStat} - {consulta.xMotivo}");
    if (consulta.cStat == "100") // Autorizado
    {
        Console.WriteLine($"Protocolo de Autorização: {consulta.protCTe.infProt.nProt}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Falha na consulta: {ex.Message}");
}
```

---

### 2. Distribuição de Documentos Fiscais Eletrônicos (Interesse do CT-e)
Este serviço permite que atores interessados (como destinatários do serviço de transporte) busquem documentos fiscais vinculados ao seu CNPJ/CPF gerados nos últimos 90 dias:

```csharp
using EficazFramework.SPED.Schemas.NFe;

string cnpjInteressado = "12345678000199";

try
{
    // Efetua a busca pelo NSU (Número Sequencial Único)
    RetornoDistribuicaoDFe retorno = await servico.DistribuicaoDFeAsync(
        OrgaoIBGE.SP, // UF do destinatário
        cnpjInteressado,
        0, // nsu inicial (0 para todos os disponíveis)
        Ambiente.Homologacao
    );

    Console.WriteLine($"Status Busca DFe: {retorno.cStat} - {retorno.xMotivo}");
    if (retorno.cStat == "138") // Documento(s) localizado(s)
    {
        Console.WriteLine($"Maior NSU retornado: {retorno.maxNSU}");
        // Processar lista de documentos retornados na propriedade 'retorno.loteDistDFeInt'...
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro na distribuição de DFe: {ex.Message}");
}
```
