# Nota Fiscal Eletrônica (NF-e e NFC-e)

A **NF-e** (Nota Fiscal Eletrônica, Modelo 55) e a **NFC-e** (Nota Fiscal de Consumidor Eletrônica, Modelo 65) são estruturadas em arquivos XML. No *EficazFramework.SPED*, o documento completo é representado principalmente pelas classes `ProcessoNFe` (que engloba a nota fiscal e seu protocolo de autorização) e `NFe` (que representa a nota fiscal em si).

---

## 🚀 Leitura de XML de NF-e / NFC-e (Desserialização)
O framework fornece um utilitário centralizado na classe `Operations` para abrir e identificar automaticamente qualquer documento fiscal eletrônico (NF-e, CT-e, etc.) a partir de um Stream.

```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Utilities.XML;

// 1. Abre o arquivo XML da nota fiscal
using Stream stream = File.OpenRead(@"C:\DFse\nfe.xml");

// 2. Utiliza o método de abertura automática do framework
var documento = await Operations.OpenAsync(stream);

// 3. Faz o cast para a classe ProcessoNFe
if (documento is ProcessoNFe procNFe)
{
    Console.WriteLine($"Chave de Acesso: {procNFe.Chave}");
    Console.WriteLine($"Número da Nota: {procNFe.NFe.InformacoesNFe.IdentificacaoOperacao.Numero}");
    Console.WriteLine($"Emitente CNPJ: {procNFe.NFe.InformacoesNFe.Emitente.CNPJ_CPF}");
    
    // Iterando sobre os itens da nota
    foreach (var item in procNFe.NFe.InformacoesNFe.Items)
    {
        Console.WriteLine($"- Item: {item.Dados.Descricao} | Valor: {item.Dados.ValorTotalItem:C}");
    }
}
```

---

## ✍️ Escrita e Geração de XML
Para gerar uma NF-e/NFC-e do zero, você instancia o documento, popula os dados de identificação, emitente, destinatário, itens/tributos e depois gera a string XML correspondente chamando o método `Serialize()`.

### Exemplo de Preenchimento Básico:
```csharp
using System;
using System.IO;
using System.Collections.Generic;
using EficazFramework.SPED.Schemas.NFe;

// 1. Instancia o processo da NF-e
var processo = new ProcessoNFe();
var nfe = processo.NFe;
var infNFe = nfe.InformacoesNFe;

infNFe.Versao = "4.00";

// --- IDENTIFICAÇÃO DA OPERAÇÃO ---
infNFe.IdentificacaoOperacao = new IdentificacaoOperacao()
{
    UF = OrgaoIBGE.SP,
    NaturezaOperacao = "VENDA DE MERCADORIA",
    Modelo = ModeloDocumento.NFe, // Modelo 55 ou NFCe (65)
    Serie = 1,
    Numero = 1500,
    DataHoraEmissao = DateTime.Now,
    TipoOperacao = OperacaoNFe.Saida,
    DestinoOperacao = DestinoOperacao.Interna,
    CodigoMunicipio = "3550308", // São Paulo
    TipoImpressao = TipoImpressao.DanfeRetrato,
    FormaEmissao = FormaEmissao.Normal,
    Ambiente = Ambiente.Homologacao,
    Finalidade = FinalidadeEmissao.Normal,
    ConsumidorFinal = IndicadorConsumidorFinal.Sim,
    ProcessoDeEmissao = ProcessoEmissao.AplicativoContribuinte,
    VersaoProcessoEmissao = "1.0.0"
};

// --- EMITENTE ---
infNFe.Emitente = new Emitente()
{
    CNPJ_CPF = "12345678000199",
    RazaoSocial = "EMPRESA VENDEDORA LTDA",
    RegimeTributario = RegimeTributario.RegimeNormal,
    Endereco = new EnderecoEmitente()
    {
        Logradouro = "AVENIDA PAULISTA",
        Numero = "1000",
        Bairro = "BELA VISTA",
        MunicipioCodigo = "3550308",
        MunicipioNome = "SAO PAULO",
        UF = Estado.SP,
        CEP = "01310100",
        PaisCodigo = "1058",
        PaisNome = "BRASIL"
    }
};

// --- DESTINATÁRIO ---
infNFe.Destinatario = new Destinatario()
{
    CNPJ_CPF = "98765432100099",
    RazaoSocial = "CLIENTE COMPRADOR S/A",
    IndicadorIE = IndicadorIE.Contribuinte,
    InscricaoEstadual = "999888777666",
    Endereco = new EnderecoDestinatario()
    {
        Logradouro = "RUA DA CONSOLACAO",
        Numero = "500",
        Bairro = "CONSOLACAO",
        MunicipioCodigo = "3550308",
        MunicipioNome = "SAO PAULO",
        UF = Estado.SP,
        CEP = "01302000",
        PaisCodigo = "1058",
        PaisNome = "BRASIL"
    }
};

// --- ITENS E TRIBUTOS ---
var item = new DetalheItem()
{
    NumeroSequencial = "1",
    Dados = new DadosProduto()
    {
        Codigo = "COD001",
        GTIN = "SEM GTIN",
        Descricao = "PRODUTO EXCELENCIA A",
        NCM = "39269090",
        CFOP = "5101",
        UnidadeComercial = "UN",
        QuantidadeComercial = 2.00,
        ValorUnitarioComercial = 50.00,
        ValorTotalItem = 100.00,
        IndicadorComposicaoTotal = IndicadorTotal.CompoeTotal
    },
    Imposto = new Impostos()
    {
        ICMS = new ICMS()
        {
            Tributacao = new ICMS00() // CST 00
            {
                Origem = OrigemMercadoria.Nacional,
                CST = CST_ICMS.CST_00,
                ModalidadeBC = ModalidadeDeterminacaoBC.ValorOperacao,
                vBC = 100.00M,
                pICMS = 18.00M,
                vICMS = 18.00M
            }
        }
    }
};
infNFe.Items.Add(item);

// --- TOTAIS DA NOTA ---
infNFe.Totais = new Totais()
{
    ICMS = new TotalICMS()
    {
        vBC = 100.00M,
        vICMS = 18.00M,
        vProd = 100.00M,
        vNF = 100.00M
    }
};

// --- GERA O XML FINAL ---
string xmlNFe = processo.Serialize(); // Método que converte a árvore de objetos em XML formatado
File.WriteAllText(@"C:\DFse\nfe_gerada.xml", xmlNFe);
```

## 📡 Integração de Serviços (Sefaz WebServices)

O framework fornece a classe `NFeService` (sob o namespace `EficazFramework.SPED.Services.NFe`) para realizar a comunicação direta com os WebServices da Sefaz. Ela herda de `SoapServiceBase` e gerencia a criptografia SOAP, conexão TLS/SSL e a assinatura digital automatizada das notas.

---

### 1. Transmitindo uma NF-e para Autorização (Síncrono)
Durante a chamada de autorização, o próprio serviço realiza a assinatura digital do XML contido no objeto `NFe` usando o certificado fornecido:

```csharp
using System;
using System.Threading.Tasks;
using EficazFramework.SPED.Services.NFe;
using EficazFramework.SPED.Schemas.NFe;
using EficazFramework.SPED.Utilities;

// 1. Inicializa o serviço e fornece o certificado digital ICP-Brasil
var servico = new NFeService()
{
    SelecionaCertificado = () => new IcpBrasilX509Certificate2(@"C:\Certificados\certificado.pfx", "senha")
};

// 2. Cria ou carrega a instância populada da NFe (objeto 'processo.NFe')
// NFe nfe = ... (definido no exemplo anterior de escrita)

try
{
    // 3. Executa a transmissão assíncrona (Método Síncrono da Sefaz)
    RetornoAutorizacaoNFe retorno = await servico.Autoriza4Async(
        nfe, 
        "000000000000001", // Identificador do Lote
        Ambiente.Homologacao // Altere para Producao quando necessário
    );

    // 4. Analisa o resultado
    Console.WriteLine($"Status do Envio: {retorno.cStat} - {retorno.xMotivo}");
    if (retorno.cStat == "104") // Lote Processado
    {
        var protocolo = retorno.protNFe;
        Console.WriteLine($"Status do Protocolo: {protocolo.infProt.cStat} - {protocolo.infProt.xMotivo}");
        if (protocolo.infProt.cStat == "100") // Autorizado o uso da NF-e
        {
            Console.WriteLine($"Número do Recibo: {protocolo.infProt.nProt}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Falha no processamento: {ex.Message}");
}
```

---

### 2. Consultando o Protocolo/Situação de uma NF-e
Útil para recuperar o recibo ou verificar a situação de uma nota fiscal a partir de sua chave de acesso de 44 caracteres:

```csharp
string chaveNFe = "31231120855151000139650040000938509100660678";

try
{
    RetornoConsultaSituacaoNFe retornoConsulta = await servico.ConsultaProtocolo4Async(
        chaveNFe, 
        Ambiente.Homologacao
    );

    Console.WriteLine($"Código Status Sefaz: {retornoConsulta.cStat}");
    Console.WriteLine($"Motivo da resposta: {retornoConsulta.xMotivo}");
    if (retornoConsulta.cStat == "100") // Autorizado o uso
    {
        Console.WriteLine($"Chave Autorizada em: {retornoConsulta.protNFe.infProt.dhRecb}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao consultar: {ex.Message}");
}
```

---

### 3. Consultando o Status de Funcionamento dos Serviços Sefaz
Permite verificar a integridade da Sefaz autorizadora (se está online ou em contingência) antes de tentar enviar notas:

```csharp
try
{
    RetornoConsultaStatusServicoNFe status = await servico.ConsultaStatusServicoAsync(
        OrgaoIBGE.SP, // UF de envio
        ModeloDocumento.NFe, // Modelo 55 (NFe) ou 65 (NFCe)
        Ambiente.Homologacao
    );

    Console.WriteLine($"Status do WebService: {status.cStat} - {status.xMotivo}");
    if (status.cStat == "107")
    {
        Console.WriteLine("O serviço da Sefaz está operando normalmente.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"WebService indisponível: {ex.Message}");
}
```
