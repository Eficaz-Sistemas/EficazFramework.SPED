# EFD Contribuições (Sped PIS / COFINS)

O schema da **EFD Contribuições** no *EficazFramework.SPED* permite ler, auditar e gerar arquivos de texto estruturados de acordo com o leiaute definido para a apuração da Contribuição para o PIS/Pasep, da Cofins e da Contribuição Previdenciária sobre a Receita Bruta (CPRB).

---

## 🚀 Leitura de Arquivo EFD Contribuições
A leitura da EFD Contribuições é feita de forma assíncrona consumindo um `Stream`. O framework carrega e classifica cada linha em suas classes correspondentes.

```csharp
using System;
using System.IO;
using System.Text;
using System.Linq;
using EficazFramework.SPED.Schemas.EFD_Contribuicoes;

// 1. Abre o arquivo do SPED Contribuições
using Stream stream = File.OpenRead(@"C:\SPED\EFD_Contribuicoes_2026.txt");

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
Para preencher e gerar um arquivo do zero, alimente as coleções dos blocos correspondentes (`0`, `A`, `C`, `D`, `F`, `I`, `M`, `1`). Os registros de controle de bloco (ex: `RegistroC001`, `RegistroC990`) e os totalizadores (bloco `9` e `Registro9900`) são calculados e gravados **automaticamente** pelo framework.

### Exemplo Prático de Preenchimento:
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.EFD_Contribuicoes;
using EficazFramework.SPED.Schemas.Primitives;

var escrituracao = new Escrituracao()
{
    Versao = "006" // Versão do leiaute correspondente
};

// --- BLOCO 0: Abertura e Identificação ---
var reg0000 = new Registro0000(null, escrituracao.Versao)
{
    Finalidade = Finalidade.Original,
    DataInicial = new DateTime(2026, 8, 1),
    DataFinal = new DateTime(2026, 8, 31),
    RazaoSocial = "EMPRESA CONTRIBUINTE PIS COFINS LTDA",
    CNPJ = "12345678000199",
    UF = "SP",
    MunicipioCodigo = "3550308",
    IndicadorRegimeCumulativo = "1", // Regime Não-Cumulativo
    IndicadorTipoAtividade = "0" // Industrial ou equiparado
};
escrituracao.Blocos["0"].Registros.Add(reg0000);

// Cadastro de Participante (Registro 0150)
var reg0150 = new Registro0150(null, escrituracao.Versao)
{
    Codigo = "PART001",
    Nome = "CLIENTE COMPRADOR S/A",
    CodigoPais = "01058",
    CNPJ = "98765432100099",
    UF = "SP"
};
escrituracao.Blocos["0"].Registros.Add(reg0150);

// Cadastro de Item / Produto (Registro 0200)
var reg0200 = new Registro0200(null, escrituracao.Versao)
{
    Codigo = "PROD001",
    Descricao = "Produto de Venda Comum",
    UnidadeMedida = "UN",
    TipoItem = TipoItem.MercadoriaParaRevenda,
    NCM = "39269090"
};
escrituracao.Blocos["0"].Registros.Add(reg0200);


// --- BLOCO C: Documentos Fiscais de Entrada / Saída (PIS/COFINS) ---
// Documento Fiscal de Saída (Registro C100)
var regC100 = new RegistroC100(null, escrituracao.Versao)
{
    IndicadorOperacao = IndicadorOperacao.Saida,
    IndicadorEmitente = IndicadorEmitente.Proprio,
    CodigoParticipante = "PART001",
    CodigoModelo = "55",
    SituacaoDocumento = SituacaoDocumento.Regular,
    Serie = "1",
    Numero = "52344",
    DataEmissao = new DateTime(2026, 8, 5),
    DataEntradaSaida = new DateTime(2026, 8, 5),
    ValorDocumento = 500.00M,
    ValorMercadorias = 500.00M,
    IndicadorFrete = IndicadorFrete.SemFrete
};

// Item do Documento Fiscal (Registro C170)
var regC170 = new RegistroC170(regC100, escrituracao.Versao)
{
    NumeroItem = 1,
    CodigoItem = "PROD001",
    Quantidade = 5.000M,
    Unidade = "UN",
    ValorTotalItem = 500.00M,
    CST_PIS = "01", // Operação Tributável com Alíquota Básica
    ValorBcPis = 500.00M,
    AliquotaPis = 1.65M,
    ValorPis = 8.25M,
    CST_COFINS = "01",
    ValorBcCofins = 500.00M,
    AliquotaCofins = 7.60M,
    ValorCofins = 38.00M
};
regC100.RegistrosC170.Add(regC170);
escrituracao.Blocos["C"].Registros.Add(regC100);


// --- ESCRITA FINAL DO ARQUIVO ---
using Stream fileStream = File.Create(@"C:\SPED\EFD_Contribuicoes_2026.txt");
await escrituracao.EscreveArquivo(fileStream);
```
