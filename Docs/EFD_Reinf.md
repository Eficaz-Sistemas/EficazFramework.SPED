# EFD-Reinf

A **EFD-Reinf** (Escrituração Fiscal Digital de Retenções e Outras Informações Fiscais) é estruturada em eventos baseados em arquivos XML. Ao contrário de escriturações em formato texto (como a EFD ICMS/IPI), cada evento é transmitido individualmente ou em lotes para os servidores do governo.

---

## 🚀 Leitura de Eventos XML
Para ler um evento existente, você pode instanciar a classe correspondente ao evento e chamar o método `Read(stream)`.

```csharp
using System.IO;
using EficazFramework.SPED.Schemas.EFD_Reinf;

// 1. Abre o arquivo XML correspondente ao evento (ex: R-1000)
using Stream stream = File.OpenRead(@"C:\SPED\SPED-EFD-REINF-EVT-R1000.xml");

// 2. Cria a instância do evento especificando a versão do leiaute
var evento = new R1000()
{
    Versao = Versao.v2_01_02
};

// 3. Efetua a leitura/desserialização dos dados
evento.Read(stream);

// 4. Acessando os dados lidos
Console.WriteLine($"CNPJ Contribuinte: {evento.evtInfoContri.ideContri.nrInsc}");
Console.WriteLine($"Nome Contato: {evento.evtInfoContri.infoContri.Item.infoCadastro.contato.nmCtt}");
```

---

## ✍️ Escrita e Serialização de Eventos XML
Para gerar um XML de evento válido, você instancia o evento, popula suas subpropriedades e então gera a string XML ou salva diretamente em um arquivo/stream.

### Exemplo de Preenchimento do Evento R-1000 (Informações do Contribuinte):
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.EFD_Reinf;

// 1. Cria a estrutura do evento e define as informações básicas
var evento = new R1000()
{
    Versao = Versao.v2_01_02,
    evtInfoContri = new R1000_EventoInfoContribuinte()
    {
        ideEvento = new IdentificacaoEvento()
        {
            tpAmb = Ambiente.ProducaoRestrita_DadosReais,
            procEmi = EmissorEvento.AppContribuinte,
            verProc = "2.2"
        },
        ideContri = new IdentificacaoContribuinte()
        {
            tpInsc = PersonalidadeJuridica.CNPJ,
            nrInsc = "12345678" // CNPJ raiz (8 dígitos)
        },
        infoContri = new R1000EventoInfoContribuinte()
        {
            Item = new R1000Inclusao() // Utilize Inclusao, Alteracao ou Exclusao
            {
                idePeriodo = new IdentificacaoPeriodo()
                {
                    iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                },
                infoCadastro = new R1000InfoCadastro()
                {
                    classTrib = "99", // Classificação tributária (consultar tabela oficial)
                    indEscrituracao = ObrigatoriedadeECD.EntregaECD,
                    indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
                    indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
                    indSitPJ = SituacaoPessoaJuridica.Normal,
                    indSitPJSpecified = true,
                    contato = new R1000InfoCadastroContato()
                    {
                        nmCtt = "Contato Técnico",
                        cpfCtt = "12345678901",
                        foneFixo = "1133334444",
                        email = "suporte@empresa.com.br"
                    }
                }
            }
        }
    }
};

// 2. Serializando o evento para XML string
string xmlString = evento.ToString();

// 3. Salvando a string XML estruturada em um arquivo
using Stream stream = File.Create(@"C:\SPED\SPED-EFD-REINF-EVT-R1000.xml");
System.Xml.XmlDocument doc = new();
doc.LoadXml(xmlString);
doc.Save(stream);
```

---

## 🔒 Assinatura Digital Manual do XML (ICP-Brasil)
Se você estiver gerando os XMLs para transmitir por um serviço externo ou próprio de mensageria (fora do `EfdReinfServices`), você deve aplicar a assinatura digital baseada no certificado ICP-Brasil (A1 ou A3) antes de enviá-los ao governo:

```csharp
using System.Xml;
using EficazFramework.SPED.Utilities;

// 1. Carrega o documento XML gerado
XmlDocument docXml = new XmlDocument();
docXml.LoadXml(xmlString);

// 2. Abre o certificado digital
using var cert = new IcpBrasilX509Certificate2(@"C:\Certificados\certificado.pfx", "sua_senha");

// 3. Aplica a assinatura digital utilizando os parâmetros do evento
cert.SignXml(
    docXml,
    evento.TagToSign, // Tag a ser assinada (definida no próprio evento)
    evento.TagId,     // Atributo ID do elemento principal
    true              // Assinar com SHA-256 (Obrigatório para Reinf)
);

// Salva o XML assinado pronto para transmissão
docXml.Save(@"C:\SPED\SPED-EFD-REINF-EVT-R1000-ASSINADO.xml");
```

---

## 🏗️ Estrutura de Classes de Eventos Disponíveis

A EFD-Reinf possui diferentes grupos de eventos suportados pelo framework:

*   **Série R-1000 / R-1070:** Eventos de Cadastro (Informações do Contribuinte e Processos).
*   **Série R-2000:** Eventos Periódicos de Contribuições Previdenciárias (Serviços tomados/prestados, comercialização de produção rural, CPRB).
*   **Série R-3000:** Receita de espetáculo desportivo.
*   **Série R-4000:** Eventos de Retenções na Fonte (IR, CSLL, PIS, COFINS pagos a beneficiários PF ou PJ).
*   **Série R-9000:** Eventos de Retorno e Fechamento/Reabertura de movimento (ex: `R4099` para fechamento da série R-4000).

> [!TIP]
> Os utilitários contidos na classe `ReinfTimeStampUtils` podem ser utilizados para gerar identificadores únicos de eventos (`Id`), necessários para a transmissão correta para os servidores da Receita Federal.

---

## 📡 Transmissão e Consulta via `EfdReinfServices`

O framework possui a classe `EfdReinfServices` (sob o namespace `EficazFramework.SPED.Services.EFD_Reinf`) para se comunicar diretamente com as APIs REST do governo, realizando a validação, assinatura digital e transmissão de lotes de eventos.

> [!NOTE]
> Ao utilizar o `EfdReinfServices`, o framework se encarrega de gerar o ID do evento (`GeraEventoID`) e aplicar a assinatura digital em cada XML automaticamente usando o certificado fornecido.

### 1. Transmitindo um Lote de Eventos (Assíncrono)
Respeitando o limite oficial de **50 eventos por lote**:

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EficazFramework.SPED.Services.EFD_Reinf;
using EficazFramework.SPED.Schemas.EFD_Reinf;
using EficazFramework.SPED.Utilities;

// 1. Inicializa o serviço e configura o certificado digital
var servico = new EfdReinfServices()
{
    // Define a função/delegate que retorna o certificado digital ICP-Brasil válido
    SelecionaCertificado = () => new IcpBrasilX509Certificate2(@"C:\Certificados\certificado.pfx", "senha")
};

// 2. Define o Contribuinte responsável
var contribuinte = new IdentificacaoContribuinte()
{
    tpInsc = PersonalidadeJuridica.CNPJ,
    nrInsc = "12345678" // CNPJ Raiz (8 dígitos)
};

// 3. Monta a lista (lote) com os eventos populados
var loteEventos = new List<Evento>() { eventoR1000 };

try
{
    // 4. Executa a transmissão assíncrona
    Response resposta = await servico.EnviaEventosAsync(
        loteEventos, 
        contribuinte, 
        Ambiente.ProducaoRestrita_DadosReais // Altere para Producao no ambiente real
    );

    // 5. Trata o retorno de processamento
    string codigoResposta = resposta.retornoLoteEventosAssincrono.status.cdResposta;
    if (codigoResposta == "1") // Lote recebido com sucesso
    {
        string protocolo = resposta.retornoLoteEventosAssincrono.dadosRecepcaoLote.protocoloEnvio;
        Console.WriteLine($"Lote recebido. Protocolo de Envio: {protocolo}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro na transmissão: {ex.Message}");
}
```

### 2. Consultando o Processamento do Lote
Após o envio do lote, é necessário consultar o protocolo para obter os recibos de entrega dos eventos individuais:

```csharp
string protocolo = "NÚMERO_DO_PROTOCOLO_RECEBIDO";

// Executa a consulta assíncrona
Response respostaConsulta = await servico.ConsultaLoteAsync(
    protocolo, 
    Ambiente.ProducaoRestrita_DadosReais
);

var statusLote = respostaConsulta.retornoLoteEventosAssincrono.status;
if (statusLote.cdResposta == "2") // Lote Processado
{
    // Varre os eventos do lote para obter os recibos de entrega
    foreach (var eventoRetorno in respostaConsulta.retornoLoteEventosAssincrono.retornoEventos.evento)
    {
        var totalizador = eventoRetorno.retornoEventoInfo.evtTotal;
        Console.WriteLine($"Evento: {eventoRetorno.Id} | Status: {totalizador.ideRecRetorno.ideStatus.cdRetorno}");
        Console.WriteLine($"Número do Recibo: {totalizador.ideRecRetorno.noRecibo}");
    }
}
else
{
    Console.WriteLine($"Lote em processamento ou erro. Código de resposta: {statusLote.cdResposta}");
}
```

