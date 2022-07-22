
namespace EficazFramework.SPED.Schemas.Primitives;

/// <summary>
/// Classe abstrata que representa um registro do SPED ou qualquer outra obrigação assessória.
/// </summary>
public abstract class Registro
{

    /// <summary>
    /// Inicia uma nova instância de <see cref="Registro"/> à partir de uma linha obtida pela leitura 
    /// da escrituração, executando o método <see cref="LeParametros(string[])"/> e alimentando os campos
    /// do registro, conforme versão de layout especificada no argumento <paramref name="versao"/>.
    /// </summary>
    /// <param name="linha">string obtida pela leitura de linha da <see cref="Escrituracao"/>.</param>
    /// <param name="versao">versão do layout para preenchimento dos campos obtidos de <paramref name="linha"/>.</param>
    public Registro(string linha, string versao)
    {
        if (linha != null)
        {
            _versao = versao;
            if (!string.IsNullOrEmpty(linha) && !string.IsNullOrWhiteSpace(linha))
            {
                var data = linha.Split("|");
                if (data.Length > 1)
                {
                    _codigo = data[1];
                    LeParametros(data);
                }
                else
                    _codigo = GetType().Name.Replace("Registro", string.Empty);
            }
            else
                _codigo = GetType().Name.Replace("Registro", string.Empty);
        }
    }

    /// <summary>
    /// Inicia uma nova instância de <see cref="Registro"/>
    /// </summary>
    /// <param name="codigo">Código do Registro a ser criado. Ex: C100</param>
    public Registro(string codigo) =>
        _codigo = codigo;

    private string _codigo;
    private string _versao = "011";

    /// <summary>
    /// Código do Registro representado pela instância.
    /// </summary>
    /// <example>
    /// "C100"
    /// </example>
    public string Codigo
    {
        get
        {
            return _codigo;
        }
    }

    /// <summary>
    /// Versão do layout para correta leitura (desserialização) / escrita (serialização)
    /// </summary>
    public string Versao
    {
        get
        {
            return _versao;
        }
    }

    /// <summary>
    /// Método utilizado para alteração da versão já inicializada pelo construtor, quando necessário.
    /// </summary>
    internal void OverrideVersao(string novaVersao)
    {
        _versao = novaVersao;
    }

    /// <summary>
    /// Efetua a leitura (desserialização) da linha especificada em <paramref name="data"/>
    /// </summary>
    /// <param name="data">Array de string contendo os valores obtidos da linha obtida no stream.</param>
    public abstract void LeParametros(string[] data);

    /// <summary>
    /// Realiza a escrita (serialização) da instância em uma linha do arquivo.
    /// </summary>
    /// <returns></returns>
    public abstract string EscreveLinha();

    /// <summary>
    /// Retorna o resultado do método <see cref="EscreveLinha"/>
    /// </summary>
    public override string ToString()
    {
        return EscreveLinha();
    }
}
