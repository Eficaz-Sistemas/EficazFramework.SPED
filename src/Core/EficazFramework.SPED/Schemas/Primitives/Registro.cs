
namespace EficazFramework.SPED.Schemas.Primitives;

public abstract class Registro
{

    public Registro(string linha, string versao)
    {
        if (linha != null)
        {
            _versao = versao;
            if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
            {
                var data = linha.Split("|");
                if (data.Length > 1)
                {
                    _codigo = data[1];
                }
                else
                {
                    _codigo = GetType().Name.Replace("Registro", string.Empty);
                }
            }
        }
    }

    public Registro(string codigo)
    {
        _codigo = codigo;
    }

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
