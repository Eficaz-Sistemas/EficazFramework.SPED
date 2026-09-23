# EFD ICMS / IPI (Sped Fiscal)

O schema da **EFD ICMS / IPI** no *EficazFramework.SPED* permite ler, auditar e gerar arquivos de texto estruturados de acordo com o leiaute definido pelo Guia Prático do SPED Fiscal.

---

## 🚀 Leitura de Arquivo EFD ICMS / IPI
A leitura é assíncrona e consome um `Stream` de dados. O framework se encarrega de ler e parsear todas as linhas em suas respectivas classes de registros, organizando-as dentro de blocos de navegação.

```csharp
using System.IO;
using System.Text;
using EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

// 1. Abre o arquivo do SPED Fiscal
using Stream stream = File.OpenRead(@"C:\SPED\SPED-EFD-ICMS-IPI.txt");

// 2. Inicializa a classe principal da escrituração
var escrituracao = new Escrituracao();
escrituracao.Encoding = Encoding.Default; // Garante o encoding correto (geralmente Windows-1252)

// 3. Efetua a leitura assíncrona
await escrituracao.LeArquivo(stream);

// 4. Acessando os dados lidos
var reg0000 = escrituracao.Blocos["0"].Registros.FirstOrDefault() as Registro0000;
if (reg0000 != null)
{
    Console.WriteLine($"Razão Social: {reg0000.RazaoSocial}");
    Console.WriteLine($"CNPJ/CPF: {reg0000.CNPJ ?? reg0000.CPF}");
}
```

---

## ✍️ Escrita e Geração da Escrituração
Para gerar um arquivo do zero, você instancia a classe `Escrituracao` e preenche as coleções de registros dentro de seus respectivos blocos (`0`, `B`, `C`, `D`, `E`, `G`, `H`, `K`, `1`, `9`).

> [!NOTE]
> Os registros de controle de bloco (ex: `RegistroC001`, `RegistroC990`) e os registros de encerramento/totalização (como o bloco `9` e o `Registro9900`) são gerados **automaticamente** pelo framework durante a escrita. Não é necessário adicioná-los manualmente à coleção.

### Exemplo Prático de Preenchimento:
```csharp
using System;
using System.IO;
using EficazFramework.SPED.Schemas.EFD_ICMS_IPI;
using EficazFramework.SPED.Schemas.Primitives;

var escrituracao = new Escrituracao()
{
    Versao = "017" // Informe a versão do leiaute correspondente
};

// --- BLOCO 0: Abertura e Identificação ---
var reg0000 = new Registro0000(null, escrituracao.Versao)
{
    Finalidade = Finalidade.Original,
    DataInicial = new DateTime(2026, 8, 1),
    DataFinal = new DateTime(2026, 8, 31),
    RazaoSocial = "EMPRESA EXEMPLO LTDA",
    CNPJ = "12345678000199",
    UF = "SP",
    InscricaoEstadual = "111222333444",
    MunicipioCodigo = "3550308", // São Paulo (IBGE)
    Perfil = Perfil.A,
    Atividade = TipoAtividade.Outros
};
escrituracao.Blocos["0"].Registros.Add(reg0000);

// Cadastro de Participante (Registro 0150)
var reg0150 = new Registro0150(null, escrituracao.Versao)
{
    Codigo = "PART001",
    Nome = "FORNECEDOR DE MATERIA-PRIMA S/A",
    CodigoPais = "01058", // Brasil
    CNPJ = "98765432100099",
    UF = "MG"
};
escrituracao.Blocos["0"].Registros.Add(reg0150);

// Cadastro de Item / Produto (Registro 0200)
var reg0200 = new Registro0200(null, escrituracao.Versao)
{
    Codigo = "PROD001",
    Descricao = "Materia-prima de Teste",
    CodigoBarra = "7891234567890",
    UnidadeMedida = "UN",
    TipoItem = TipoItem.MateriaPrima,
    NCM = "39269090"
};
escrituracao.Blocos["0"].Registros.Add(reg0200);


// --- BLOCO C: Documentos Fiscais de Entrada / Saída ---
// Documento Fiscal de Entrada (Registro C100)
var regC100 = new RegistroC100(null, escrituracao.Versao)
{
    IndicadorOperacao = IndicadorOperacao.Entrada,
    IndicadorEmitente = IndicadorEmitente.Terceiros,
    CodigoParticipante = "PART001",
    CodigoModelo = "55", // NF-e
    SituacaoDocumento = SituacaoDocumento.Regular,
    Serie = "1",
    Numero = "10052",
    DataEmissao = new DateTime(2026, 8, 5),
    DataEntradaSaida = new DateTime(2026, 8, 6),
    ValorDocumento = 150.00M,
    IndicadorPagamento = IndicadorPagamento.Vista,
    ValorDesconto = 0.00M,
    ValorMercadorias = 150.00M,
    IndicadorFrete = IndicadorFrete.SemFrete,
    ValorIcms = 27.00M
};

// Item do Documento Fiscal (Registro C170)
var regC170 = new RegistroC170(regC100, escrituracao.Versao) // Note a referência ao C100 pai
{
    NumeroItem = 1,
    CodigoItem = "PROD001",
    Quantidade = 10.000M,
    Unidade = "UN",
    ValorTotalItem = 150.00M,
    CST_ICMS = "000", // Tributada integralmente
    CFOP = "1101", // Compra para industrialização
    AliquotaIcms = 18.00M,
    ValorIcms = 27.00M
};
regC100.RegistrosC170.Add(regC170); // Adiciona na sub-coleção do C100
escrituracao.Blocos["C"].Registros.Add(regC100);


// --- BLOCO H: Inventário (Opcional por período) ---
var regH005 = new RegistroH005(null, escrituracao.Versao)
{
    DataInventario = new DateTime(2026, 8, 31),
    ValorTotalEstoque = 1500.00M,
    MotivoInventario = MotivoInventario.FinalPeriodo
};

var regH010 = new RegistroH010(regH005, escrituracao.Versao)
{
    CodigoItem = "PROD001",
    Unidade = "UN",
    Quantidade = 100.00M,
    ValorUnitario = 15.00M,
    ValorTotalItem = 1500.00M,
    IndicadorPropriedade = IndicadorPropriedade.ContribuintePosse
};
regH005.RegistrosH010.Add(regH010);
escrituracao.Blocos["H"].Registros.Add(regH005);


// --- ESCRITA FINAL DO ARQUIVO ---
using Stream fileStream = File.Create(@"C:\SPED\SPED-EFD-ICMS-IPI.txt");
await escrituracao.EscreveArquivo(fileStream);
```

---

## 🔑 Pontos Importantes para a Implementação
1. **Datas:** Sempre use objetos do tipo `DateTime`. A formatação correta de strings (como `AAAAMMDD` ou `DDMMAAAA` exigida pelo leiaute físico) é resolvida internamente pelo framework durante a serialização.
2. **Escrita em Stream:** O método `EscreveArquivo` assíncrono é a melhor prática para ambientes de alta concorrência (como serviços web ou jobs em segundo plano).
