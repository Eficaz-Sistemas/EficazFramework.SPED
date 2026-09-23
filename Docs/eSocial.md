# eSocial

O **eSocial** (Sistema de Escrituração Digital das Obrigações Fiscais, Previdenciárias e Trabalhistas) é composto por uma série de eventos individuais transmitidos em formato XML (como admissões, alterações cadastrais, desligamentos, tabelas e fechamentos).

---

## 🚀 Leitura de Eventos XML do eSocial
A leitura de qualquer XML de evento do eSocial é feita utilizando o método estático `Evento.ReadAsync(...)` ou `Evento.Read(...)`. O parser identifica automaticamente o tipo do evento e retorna a instância da classe correspondente.

```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.eSocial;

// 1. Carrega o arquivo XML
using Stream stream = File.OpenRead(@"C:\eSocial\evtS1000.xml");

// 2. Efetua a leitura assíncrona
Evento eventoBase = await Evento.ReadAsync(stream);

// 3. Verifica o tipo do evento e faz o cast para a classe específica
if (eventoBase is S1000 s1000)
{
    var inclusao = s1000.evtInfoEmpregador.infoEmpregador.Item as S1000Inclusao;
    if (inclusao != null)
    {
        Console.WriteLine($"Razão Social: {inclusao.infoCadastro.nmRazao}");
        Console.WriteLine($"Classificação Tributária: {inclusao.infoCadastro.classTrib}");
    }
}
```

---

## ✍️ Escrita e Geração de Eventos XML
Para gerar um XML de evento válido, você deve instanciar a respectiva classe do evento, popular seus campos obrigatórios de acordo com o leiaute e chamar o método `Write()` ou `ToString()`.

### Exemplo Prático: Gerando Evento S-1000 (Informações do Empregador)
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.eSocial;

var evento = new S1000()
{
    Versao = Versao.v_S_01_03_00 // Define a versão do leiaute do eSocial
};

evento.evtInfoEmpregador = new S1000InfoEmpregador()
{
    ideEvento = new IdentificacaoCadastro()
    {
        tpAmb = Ambiente.ProducaoRestrita_DadosReais,
        procEmi = EmissorEvento.AppEmpregador,
        verProc = "1.0"
    },
    ideEmpregador = new IdentificacaoEmpregador()
    {
        tpInsc = PersonalidadeJuridica.CNPJ,
        nrInsc = "12345678" // CNPJ Base (8 dígitos)
    },
    infoEmpregador = new S1000InfoEmpregadorAcao()
    {
        Item = new S1000Inclusao()
        {
            idePeriodo = new IdePeriodo()
            {
                iniValid = "2026-08"
            },
            infoCadastro = new S1000InfoCadastro()
            {
                classTrib = "99",
                indCoop = IndicadorCooperativa.Nao,
                indCoopSpecified = true,
                indConstr = SimNaoByte.Nao,
                indConstrSpecified = true,
                indDesFolha = SimNaoByte.Nao,
                indOptRegEletron = SimNaoByte.Sim
            }
        }
    }
};

// Gera o ID único obrigatório do evento baseado nos dados preenchidos
evento.GeraEventoID();

// Serializa o evento para string XML
string xmlString = evento.Write(); // ou evento.ToString();

// Salva em arquivo
File.WriteAllText(@"C:\eSocial\evtS1000_novo.xml", xmlString);
```

---

## 🔑 Assinatura Digital do XML (ICP-Brasil)
Todos os eventos do eSocial devem ser assinados digitalmente antes do envio. O framework fornece utilitários para assinar o arquivo XML usando um certificado digital A1/A3 de forma simplificada:

```csharp
using System.Xml;
using EficazFramework.SPED.Utilities;
using EficazFramework.SPED.Utilities.XML;

// 1. Carrega o documento XML gerado
XmlDocument doc = new XmlDocument();
doc.LoadXml(xmlString);

// 2. Abre o certificado digital
using var cert = new IcpBrasilX509Certificate2(@"C:\Certificados\certificado.pfx", "sua_senha");

// 3. Aplica a assinatura digital padrão no elemento correto
Sign.SignXml(
    doc, 
    EficazFramework.SPED.Schemas.eSocial.Evento.root, // Elemento root do eSocial
    evento.TagToSign, // Tag a ser assinada definida no próprio evento
    cert, 
    evento.SignAsSHA256, 
    evento.EmptyURI
);

// Salva o XML assinado pronto para transmissão
doc.Save(@"C:\eSocial\evtS1000_assinado.xml");
```

---

## 🏗️ Lista de Eventos Suportados
O framework suporta os principais eventos do eSocial divididos em:
*   **Eventos de Tabela (S-1000 a S-1020):** Informações do Empregador, Estabelecimentos, Rubricas e Lotações Tributárias.
*   **Eventos Não Periódicos (S-2190 a S-2399):** Admissões, cadastros preliminares, alterações de contrato/dados cadastrais, afastamentos, desligamentos e trabalhadores sem vínculo.
*   **Eventos Periódicos (S-1200 a S-1299):** Remunerações, pagamentos, comercialização de produção rural e fechamentos de período.
*   **Eventos Totalizadores de Retorno (S-5001 a S-5013):** Eventos de retorno contendo as bases de cálculo e contribuições calculadas pelo governo (ex: `S-5011` para contribuições das empresas).
