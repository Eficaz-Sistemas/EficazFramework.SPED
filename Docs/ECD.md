# ECD (Escrituração Contábil Digital)

O schema da **ECD** (Escrituração Contábil Digital - Sped Contábil) permite ler, auditar e gerar arquivos de texto estruturados de acordo com o leiaute definido pela Receita Federal para a contabilidade digital de empresas.

---

## 🚀 Leitura de Arquivo ECD
A leitura da ECD consome um `Stream` de dados e lê de forma assíncrona, preenchendo todos os registros nos blocos correspondentes (`0`, `I`, `J`, `K`, `9`).

```csharp
using System;
using System.IO;
using System.Text;
using System.Linq;
using EficazFramework.SPED.Schemas.ECD;

// 1. Abre o arquivo do SPED Contábil
using Stream stream = File.OpenRead(@"C:\SPED\ECD_2026.txt");

// 2. Inicializa a escrituração
var escrituracao = new Escrituracao();
escrituracao.Encoding = Encoding.Default; // Geralmente Windows-1252

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
Para gerar a ECD do zero, alimente as coleções dos blocos `0`, `I`, `J` e `K`. Os registros de controle de bloco (ex: `RegistroI001`, `RegistroI990`) e encerramento/totalização (como o bloco `9` e o `Registro9900`) são gerados **automaticamente** pelo framework.

### Exemplo Prático de Preenchimento:
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.ECD;
using EficazFramework.SPED.Schemas.Primitives;

var escrituracao = new Escrituracao()
{
    Versao = "9.00" // Versão do leiaute correspondente
};

// --- BLOCO 0: Abertura e Identificação ---
var reg0000 = new Registro0000(null, escrituracao.Versao)
{
    Finalidade = Finalidade.Original,
    DataInicial = new DateTime(2026, 1, 1),
    DataFinal = new DateTime(2026, 12, 31),
    RazaoSocial = "EMPRESA CONTABILIDADE EXEMPLO S/A",
    CNPJ = "12345678000199",
    UF = "SP",
    InscricaoEstadual = "111222333444",
    MunicipioCodigo = "3550308",
    QualificacaoInstituicao = "01" // PJ em Geral
};
escrituracao.Blocos["0"].Registros.Add(reg0000);


// --- BLOCO I: Lançamentos Contábeis e Diário ---
// Identificação da Escrituração (Registro I010)
var regI010 = new RegistroI010(null, escrituracao.Versao)
{
    IndicadorFormaEscrituracao = "G", // Livro Diário Geral
    VersaoLeiaute = "9.00"
};
escrituracao.Blocos["I"].Registros.Add(regI010);

// Termo de Abertura (Registro I030)
var regI030 = new RegistroI030(null, escrituracao.Versao)
{
    NumeroOrdemLivro = 10,
    NaturezaLivro = "DIARIO",
    RazaoSocial = "EMPRESA CONTABILIDADE EXEMPLO S/A",
    CNPJ = "12345678000199",
    DataTermoAbertura = new DateTime(2026, 1, 1)
};
escrituracao.Blocos["I"].Registros.Add(regI030);

// Plano de Contas (Registro I050)
var regI050_caixa = new RegistroI050(null, escrituracao.Versao)
{
    DataInclusao = new DateTime(2026, 1, 1),
    NaturezaConta = "01", // Ativo
    IndicadorTipoConta = "A", // Analítica
    NivelConta = 4,
    CodigoConta = "1.01.01.001",
    NomeConta = "CAIXA GERAL"
};
escrituracao.Blocos["I"].Registros.Add(regI050_caixa);

// Lançamento Contábil (Registro I200)
var regI200 = new RegistroI200(null, escrituracao.Versao)
{
    NumeroLancamento = "LANC-001",
    DataLancamento = new DateTime(2026, 8, 15),
    ValorLancamento = 500.00M,
    IndicadorTipoLancamento = "N" // Lançamento Normal
};

// Partida do Lançamento (Registro I250 - Débito)
var regI250_debito = new RegistroI250(regI200, escrituracao.Versao)
{
    CodigoConta = "1.01.01.001", // Conta Débito (Caixa)
    ValorPartida = 500.00M,
    IndicadorDebitoCredito = "D", // Débito
    HistoricoPadrao = "Histórico de Depósito em Dinheiro"
};
regI200.RegistrosI250.Add(regI250_debito);

// Partida do Lançamento (Registro I250 - Crédito)
var regI250_credito = new RegistroI250(regI200, escrituracao.Versao)
{
    CodigoConta = "2.01.01.001", // Conta Crédito (Fornecedores)
    ValorPartida = 500.00M,
    IndicadorDebitoCredito = "C", // Crédito
    HistoricoPadrao = "Histórico de Depósito em Dinheiro"
};
regI200.RegistrosI250.Add(regI250_credito);

escrituracao.Blocos["I"].Registros.Add(regI200);


// --- ESCRITA FINAL DO ARQUIVO ---
using Stream fileStream = File.Create(@"C:\SPED\ECD_2026.txt");
await escrituracao.EscreveArquivo(fileStream);
```
