# ECF (Escrituração Contábil Fiscal)

O schema da **ECF** (Escrituração Contábil Fiscal - Sped ECF) permite ler, auditar e gerar arquivos de texto estruturados de acordo com o leiaute definido pela Receita Federal, integrando os dados contábeis e fiscais do Imposto de Renda (IRPJ) e da Contribuição Social (CSLL).

---

## 🚀 Leitura de Arquivo ECF
A leitura da ECF é feita de forma assíncrona, preenchendo todos os registros nos blocos correspondentes (`0`, `K`, `L`, `M`, `N`, `P`, `U`, `X`, `Y`, `9`).

```csharp
using System;
using System.IO;
using System.Text;
using System.Linq;
using EficazFramework.SPED.Schemas.ECF;

// 1. Abre o arquivo do SPED ECF
using Stream stream = File.OpenRead(@"C:\SPED\ECF_2026.txt");

// 2. Inicializa a escrituração
var escrituracao = new Escrituracao();
escrituracao.Encoding = Encoding.Default;

// 3. Efetua a leitura assíncrona
await escrituracao.LeArquivo(stream);

// 4. Acessando os dados
var reg0000 = escrituracao.Blocos["0"].Registros.FirstOrDefault() as Registro0000;
if (reg0000 != null)
{
    Console.WriteLine($"Razão Social: {reg0000.RazaoSocial}");
    Console.WriteLine($"CNPJ: {reg0000.CNPJ}");
}
```

---

## ✍️ Escrita e Geração da Escrituração
Durante a serialização e gravação do arquivo texto, os registros de controle e encerramento (ex: bloco `9`, `Registro9900` e totalizadores de bloco) são calculados e gravados **automaticamente** pelo framework.

### Exemplo Prático de Preenchimento:
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.ECF;
using EficazFramework.SPED.Schemas.Primitives;

var escrituracao = new Escrituracao()
{
    Versao = "0012" // Versão do leiaute correspondente
};

// --- BLOCO 0: Abertura e Identificação ---
var reg0000 = new Registro0000(null, escrituracao.Versao)
{
    Finalidade = Finalidade.Original,
    DataInicial = new DateTime(2026, 1, 1),
    DataFinal = new DateTime(2026, 12, 31),
    RazaoSocial = "EMPRESA CONTRIBUINTE S/A",
    CNPJ = "12345678000199",
    UF = "SP"
};
escrituracao.Blocos["0"].Registros.Add(reg0000);

// Parâmetros de Tributação (Registro 0010)
var reg0010 = new Registro0010(null, escrituracao.Versao)
{
    QualificacaoPJ = "01", // PJ em Geral
    FormaTributacao = "1", // Lucro Real
    FormaApuracao = "A" // Anual
};
escrituracao.Blocos["0"].Registros.Add(reg0010);

// Parâmetros Complementares (Registro 0020)
var reg0020 = new Registro0020(null, escrituracao.Versao)
{
    IndicadorAlteraQuadroSocios = "N",
    IndicadorInovacaoTecnologica = "N"
};
escrituracao.Blocos["0"].Registros.Add(reg0020);

// Signatários da Escrituração (Registro 0930)
var reg0930 = new Registro0930(null, escrituracao.Versao)
{
    NomeSignatario = "Nome do Contador",
    CPF = "12345678901",
    QualificacaoSignatario = "900", // Contador
    CRC = "SP123456/O-7",
    Email = "contador@empresa.com.br"
};
escrituracao.Blocos["0"].Registros.Add(reg0930);


// --- ESCRITA FINAL DO ARQUIVO ---
using Stream fileStream = File.Create(@"C:\SPED\ECF_2026.txt");
await escrituracao.EscreveArquivo(fileStream);
```
