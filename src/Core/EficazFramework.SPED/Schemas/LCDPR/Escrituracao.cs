using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Classe principal de configuração, leitura e escrita do Livro Caixa Digital do Produtor Rural
/// </summary>
/// <remarks>
/// Blocos disponíveis: 0, Q <br/>
/// Bloco Totalizador: Não se aplica <br/>
/// Registro Totalizador: Não se aplica <br/>
/// </remarks>
/// <example>
/// #### Leitura
/// ```csharp
/// System.IO.Stream stream = System.IO.File.OpenRead(@"C:\LCDPR\exemplo.txt");
/// var escrituracao = new EficazFramework.SPED.Schemas.LCDPR.Escrituracao();
/// escrituracao.Encoding = System.Text.Encoding.Default; //opcional
/// await escrituracao.LeArquivo(stream);
/// ```
/// #### Escrita
/// ```csharp
/// EficazFramework.SPED.Schemas.LCDPR.Escrituracao escrituracao = new();
/// escrituracao.Encoding = System.Text.Encoding.Default; //opcional
/// escrituracao.Versao = "0013"; //opcional
/// var reg0000 = new Registro0000(null, escrituracao.Versao)
/// {
///     SituacaoEspecial = SituacaoEspecial.Normal,
///     DataInicial = new System.DateTime(2021, 1, 1),
///     DataFinal = new System.DateTime(2021, 12, 31),
///     Nome = "Produtor Rural Exemplo",
///     CPF = "12345678900"
/// };
/// escrituracao.Blocos["0"].Registros.Add(reg0000);
/// // TODO: Adicionar demais registros em seus respectivos blocos...
/// await escrituracao.EscreveArquivo(System.IO.File.Create(@"C:\LCDPR\exemplo.txt"));
/// ```
/// </example>
public class Escrituracao : Primitives.Escrituracao
{
    public Escrituracao() : base("Escrituração Livro Caixa Digital do Produtor Rural")
    {
        ValidaPipeInicial = false;
        Blocos.Add("0", new Bloco0());
        Blocos.Add("Q", new BlocoQ());
        Blocos.Add("9", new Bloco9());
        BlocoTotalizador = null;
        RegistroTotalizadorCodigo = null;
        RegistroTotalizadorStringFormat = null;
    }
    
    /// <exclude/>
    public override void ProcessaLinha(string linha)
    {
        Primitives.Registro reg = null;
        switch (linha.Substring(1, 4) ?? "")
        {
            case "0000":
                {
                    Versao = linha.Substring(6, 3);
                    reg = new Registro0000(linha, Versao);
                    Blocos["0"].Registros.Add(reg);
                    break;
                }

            case "9999":
                {
                    _mustStop = true;
                    break;
                }

            default:
                {
                    string registro = linha.Substring(0, 4);
                    reg = Activator.CreateInstance(Type.GetType($"EficazFramework.SPED.Schemas.LCDPR.Registro{registro}", true), new[] { linha, Versao }) as Primitives.Registro;
                    Blocos[registro.Substring(0,1)].Registros.Add(reg);
                    break;
                }
        }

        if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
        {
            if (reg != null)
                reg.LeParametros(linha.Split("|"));
        }
    }

    /// <summary>
    /// Obtém o valor do campo CPF do <see cref="Registro0000"/> do escrituração fornecida no parâmetro <paramref name="stream"/>
    /// </summary>
    public override async Task<string> LeEmpresaArquivo(System.IO.Stream stream)
    {
        string cnpj = null;
        using (var reader = new System.IO.StreamReader(stream, Encoding))
        {
            while (!reader.EndOfStream)
            {
                string linha = await reader.ReadLineAsync();
                Versao = linha.Substring(6, 3);
                string reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                var reg0000 = new Registro0000(linha, Versao);
                reg0000.LeParametros(linha.Split("|"));
                cnpj = reg0000.CPF;
                break;
            }

            reader.Dispose();
        }

        return cnpj;
    }
}


/// <summary>
/// # Livro Caixa Digital do Produtor Rural (LCDPR)<br/>
/// ## Publico Alvo<br/>
///  - Produtor Rural Pessoa Física<br/>
///  - Faturamento Anual acima de R$ 4,8 milhões de reais<br/>
/// ## Guia<br/>
/// Obrigação Assessória de competência do Produtor Rural, que visa esclarecer para a Receita Federal as suas movimentações (Receitas x Despesas), quando a Renda Bruta do ano-calendário ultrapassar o limite até R$4,8 milhões de reais. <br/>
/// Foi implementada pela Instrução Normativa n° 1848, de 28 de Novembro de 2018.<br/>
/// ## Objetivo<br/>
/// Tornar o cumprimento das obrigações fiscais do produtor rural, obrigatoriamente, pessoa física, mais transparentes e claros, agilizando o processo por meio da digitalização.<br/>
/// ## Links Úteis<br/>
/// - [Manual de Preenchimento, v1.3](https://www.gov.br/receitafederal/pt-br/assuntos/orientacao-tributaria/declaracoes-e-demonstrativos/lcdpr-livro-caixa-digital-do-produtor-rural/manual-de-preenchimento-do-lcdpr-1-3)<br/>
/// - [Perguntas e Respostas](https://www.gov.br/receitafederal/pt-br/centrais-de-conteudo/publicacoes/perguntas-e-respostas/perguntas-e-respostas-lcdpr/Perguntas-Respostas-LCDPR)<br/>
/// ## Implementação<br/>
/// </summary>
internal class NamespaceDoc { }