# Livro Caixa Digital do Produtor Rural (LCDPR)

O **LCDPR** (Livro Caixa Digital do Produtor Rural) é uma obrigação acessória para produtores rurais pessoas físicas que atingiram determinado limite de faturamento anual. O formato do arquivo é textual estruturado em blocos e registros delimitados por barra vertical `|`, semelhante ao SPED Fiscal.

---

## 🚀 Leitura de Arquivo LCDPR
A leitura do arquivo é assíncrona. O framework lê o Stream e preenche a árvore de registros dentro do objeto `Escrituracao`.

```csharp
using System;
using System.IO;
using System.Linq;
using EficazFramework.SPED.Schemas.LCDPR;

// 1. Abre o arquivo LCDPR
using Stream stream = File.OpenRead(@"C:\SPED\LCDPR_2026.txt");

// 2. Cria a instância da escrituração do LCDPR
var escrituracao = new Escrituracao();

// 3. Efetua a leitura assíncrona
await escrituracao.LeArquivo(stream);

// 4. Acessando os dados
var reg0000 = escrituracao.Blocos["0"].Registros.FirstOrDefault() as Registro0000;
if (reg0000 != null)
{
    Console.WriteLine($"CPF do Produtor: {reg0000.CPF}");
    Console.WriteLine($"Nome do Produtor: {reg0000.Nome}");
}

// Obtendo o número de lançamentos de caixa realizados no período
int lancamentos = escrituracao.Blocos["Q"].Registros.Count(reg => reg.Codigo == "Q100");
Console.WriteLine($"Total de lançamentos no livro caixa: {lancamentos}");
```

> [!TIP]
> Você pode ler o CPF do contribuinte diretamente do cabeçalho do arquivo sem ler o arquivo inteiro na memória usando o método `LeEmpresaArquivo(stream)`:
> ```csharp
> string cpf = await escrituracao.LeEmpresaArquivo(stream);
> ```

---

## ✍️ Escrita e Geração da Escrituração
Para preencher e gerar um arquivo LCDPR, alimente as coleções dos blocos `0` e `Q`. O bloco totalizador `9` é gerenciado automaticamente pelo framework durante o processo de serialização/escrita.

### Exemplo Prático de Preenchimento:
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.LCDPR;

var escrituracao = new Escrituracao()
{
    Versao = "0013" // Versão do leiaute do LCDPR
};

// --- BLOCO 0: Abertura e Identificação ---
var reg0000 = new Registro0000(null, escrituracao.Versao)
{
    CPF = "12345678900",
    Nome = "JOAO DA SILVA SAZONAL",
    DataInicial = new DateTime(2026, 1, 1),
    DataFinal = new DateTime(2026, 12, 31)
};
escrituracao.Blocos["0"].Registros.Add(reg0000);

var reg0010 = new Registro0010(null, escrituracao.Versao)
{
    FormaApuracao = FormaApuracao.LivroCaixa
};
escrituracao.Blocos["0"].Registros.Add(reg0010);

// Cadastro do Imóvel Rural (Registro 0040)
var reg0040 = new Registro0040(null, escrituracao.Versao)
{
    CodImovel = 1,
    NomeImovel = "FAZENDA SOL NASCENTE",
    UF = "SP",
    CodigoMunicipio = "3550308", // São Paulo
    ExploracaoTipo = ExploracaoTipo.ExploracaoIndividual,
    Participacao = 10000 // 100,00% de participação
};
escrituracao.Blocos["0"].Registros.Add(reg0040);

// Cadastro de Conta Bancária (Registro 0050)
var reg0050 = new Registro0050(null, escrituracao.Versao)
{
    CodigoContaBanco = "CTA01",
    Agencia = "1234",
    NumeroConta = "567890",
    NomeBanco = "BANCO DO BRASIL S/A"
};
escrituracao.Blocos["0"].Registros.Add(reg0050);


// --- BLOCO Q: Livro Caixa do Produtor Rural ---
// Lançamento de Despesa (Registro Q100)
var regQ100_despesa = new RegistroQ100(null, escrituracao.Versao)
{
    DataMov = new DateTime(2026, 8, 10),
    CodImovel = 1,
    CodigoContaBanco = "CTA01",
    NumeroDoc = "NF-5012",
    TipoDocumento = TipoDocumento.NF,
    Historico = "Pagamento referente à aquisição de fertilizantes para lavoura",
    TerceiroID = "98765432000100", // CNPJ/CPF do terceiro
    TipoLancamento = TipoLancamento.Despesa,
    ValorSaida = 1500.00D, // Valor pago
    SaldoFinal = 1500.00D,
    SaldoFinal_Natureza = "N" // Negativo (Saída maior que Entrada)
};
escrituracao.Blocos["Q"].Registros.Add(regQ100_despesa);

// Lançamento de Receita (Registro Q100)
var regQ100_receita = new RegistroQ100(null, escrituracao.Versao)
{
    DataMov = new DateTime(2026, 8, 25),
    CodImovel = 1,
    CodigoContaBanco = "CTA01",
    NumeroDoc = "NF-9080",
    TipoDocumento = TipoDocumento.NF,
    Historico = "Recebimento ref. à venda de safra de milho",
    TerceiroID = "55566677700011",
    TipoLancamento = TipoLancamento.Receita,
    ValorEntrada = 10000.00D, // Valor recebido
    SaldoFinal = 8500.00D, // Saldo acumulado (10000 - 1500)
    SaldoFinal_Natureza = "P" // Positivo
};
escrituracao.Blocos["Q"].Registros.Add(regQ100_receita);

// Resumo Mensal (Registro Q200) - Um para cada mês com movimento
var regQ200 = new RegistroQ200(null, escrituracao.Versao)
{
    MesAno = "082026", // Formato MMAAAA
    ValorTotalEntradas = 10000.00D,
    ValorTotalSaidas = 1500.00D,
    SaldoFinal = 8500.00D,
    SaldoFinal_Natureza = "P"
};
escrituracao.Blocos["Q"].Registros.Add(regQ200);


// --- ESCRITA DO ARQUIVO TEXTO ---
using Stream fileStream = File.Create(@"C:\SPED\LCDPR_2026.txt");
await escrituracao.EscreveArquivo(fileStream);
```
