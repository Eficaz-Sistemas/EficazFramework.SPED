﻿global using System.Threading;

namespace EficazFramework.SPED.Schemas.Primitives;

/// <summary>
/// Classe abstrata que representa uma escrituração do SPED ou de qualquer outra obrigação assessória.
/// Contém a instrumentação básica para leitura (desserialização) e escrita (serialização) da escrituração. 
/// </summary>
public abstract class Escrituracao : INotifyPropertyChanged
{

    /// <summary>
    /// Cria uma nova instância de Escrituração Digital
    /// </summary>
    /// <param name="name">Nome da Escrituração a ser implementada</param>
    /// <remarks></remarks>
    public Escrituracao(string? name)
    {
        _RegistroTotalizadorStringFormat = "|" + RegistroTotalizadorCodigo + "|{0}|{1}|";
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        Name = name;
    }

    private readonly string Name = string.Empty;
    private bool _isWorking = false;
    //internal bool _mustStop = false;
    private string _blocoTotalizador = "9";
    private string _codigoRegTotalizador = "9900";
    private string _RegistroTotalizadorStringFormat;
    private System.Text.Encoding _encoding = System.Text.Encoding.UTF8;

    /// <summary>
    /// Dicionário contendo o par de Chave / Valor de Todos os Blocos da Escrituração Implementada. <br/>
    /// Permite o acesso aos registros desejados durante etapas de leitura (desserialização) e escrita (serialização).
    /// </summary>
    /// <example>
    /// ```csharp
    /// escrituracao.Blocos["0"].Registros
    /// escrituracao.Blocos["C"].Registros
    /// ```
    /// </example>
    public Dictionary<string, Bloco> Blocos { get; } = [];

    /// <summary>
    /// Versão para leitura (desserialização) / escrita (serialização) da escrituração.
    /// </summary>
    public string Versao { get; set; } = "001";

    /// <summary>
    /// Progresso em percentual da leitura (desserialização).
    /// </summary>
    public int Progresso { get; private set; } = 0;

    /// <summary>
    /// Listagem de regitros que devem ser desconsiderados durante a leitura (desserialização) da escrituração
    /// </summary>
    public List<string> RegistrosIgnorados { get; } = [];

    /// <summary>
    /// Obtém ou define se a instância está em estado de trabalho de leitura (desserialização) / escrita (serialização).
    /// </summary>
    public bool IsLoading
    {
        get => _isWorking;
        set
        {
            _isWorking = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoading)));
        }
    }

    /// <summary>
    /// Obtém o registro que está em análise no momento da leitura (desserialização).
    /// </summary>
    public string? RegistroAtual { get; private set; } = null;

    /// <summary>
    /// Obtém ou define se a leitura da linha do arquivo deve iniciar com carectere pipe ("|")
    /// </summary>
    public bool ValidaPipeInicial { get; set; } = true;

    public HeaderPosition HeaderPosition { get; } = new HeaderPosition();

    /// <summary>
    /// Obtém ou define o código do Bloco Totalizador da Escrituração implementada, para cálculo automatizado dos registros de totalização.
    /// </summary>
    /// <example>
    /// ```csharp
    /// escrituracao.BlocoTotalizador = "9";
    /// ```
    /// </example>
    public string BlocoTotalizador
    {
        get => _blocoTotalizador;
        set
        {
            _blocoTotalizador = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BlocoTotalizador)));
        }
    }

    /// <summary>
    /// Obtém ou define o código do Registro Totalizador da Escrituração implementada, para cálculo automatizado de totalização.
    /// </summary>
    /// <example>
    /// ```csharp
    /// escrituracao.RegistroTotalizadorCodigo = "9990";
    /// ```
    /// </example>
    public string RegistroTotalizadorCodigo
    {
        get => _codigoRegTotalizador;
        set
        {
            _codigoRegTotalizador = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RegistroTotalizadorCodigo)));
        }
    }

    /// <summary>
    /// Obtém ou define o formato do registro totalizador da escrituração.
    /// </summary>
    /// <example>
    /// ```csharp
    /// escrituracao.RegistroTotalizadorStringFormat = $"|{this.RegistroTotalizadorCodigo}|{0}|{1}|";
    /// ```
    /// </example>
    public string RegistroTotalizadorStringFormat
    {
        get => _RegistroTotalizadorStringFormat;
        set
        {
            _RegistroTotalizadorStringFormat = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RegistroTotalizadorStringFormat)));
        }
    }

    /// <summary>
    /// Obtém ou define a codificação utilizada na escrituração. Por padrão, é UTF8.
    /// </summary>
    public System.Text.Encoding Encoding
    {
        get => _encoding;

        set
        {
            _encoding = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Encoding)));
        }
    }

    /// <summary>
    /// Método principal para leitura (desserialização) da escrituração.
    /// </summary>
    /// <param name="stream">Origem para leitura dos dados.</param>
    public async Task LeArquivo(
        System.IO.Stream stream,
        CancellationToken cancelationToken = default)
    {
        // Try
        IsLoading = true;
        using (var reader = new System.IO.StreamReader(stream, Encoding))
        {
            while (!reader.EndOfStream)
            {
                if (cancelationToken.IsCancellationRequested == true)
                    break;

                string? linha = await reader.ReadLineAsync();

                if (linha == null)
                    continue;

                if (linha.Length < HeaderPosition.Index + HeaderPosition.Lenght)
                    continue; // 02/04/2018: anti blank-line exception

                if (ValidaPipeInicial && (!linha.StartsWith("|")))
                    continue;

                string? reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                if ((reg ?? "") != (RegistroAtual ?? ""))
                {
                    SetCurrent(reg);
                }

                if (reg == null)
                    continue;

                if (!RegistrosIgnorados.Contains(reg))
                {
                    await Task.Run(() => ProcessaLinha(linha));
                }

                if (reader.BaseStream.Length > 0L)
                {
                    int per = (int)(reader.BaseStream.Position / (double)reader.BaseStream.Length * 100d);
                    SetPercent(per);
                }
            }

            reader.Dispose();
        }
        // Catch ex As Exception

        // End Try
        IsLoading = false;
        SetCurrent(null);
    }

    private void SetPercent(int percent)
    {
        Progresso = percent;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progresso)));
    }

    private void SetCurrent(string? reg)
    {
        RegistroAtual = reg;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RegistroAtual)));
    }

    /// <summary>
    /// Método principal para escrita (serialização) da escrituração.
    /// </summary>
    /// <param name="stream">Stream destino para gravação dos dados.</param>
    /// <exception cref="ArgumentException">Uma <see cref="ArgumentException"/> pode ser disparada quando a propriedade 
    /// <see cref="BlocoTotalizador"/> se referir a algum bloco não mapeado na escrituração.</exception>
    public async Task EscreveArquivo(System.IO.Stream stream,
        CancellationToken cancelationToken = default) // As String
    {
        SetPercent(0);
        int i = 0;
        using (var writer = new System.IO.StreamWriter(stream, Encoding))
        {
            // ## Geração Automática dos Registros Totalizadores
            if (BlocoTotalizador != null)
            {
                if (!Blocos.ContainsKey(BlocoTotalizador))
                    throw new ArgumentException(string.Format("O Bloco {0} não foi adicionado à escrituração.", BlocoTotalizador));
                foreach (var preReg in PrefixoBlocoEncerramento())
                    Blocos[BlocoTotalizador].Registros.Add(preReg);

                if (cancelationToken.IsCancellationRequested == true)
                {
                    SetCurrent(null);
                    SetPercent(0);
                    await writer.DisposeAsync();
                    return;
                }

                foreach (var bl in Blocos)
                {
                    if ((bl.Key ?? "") == (BlocoTotalizador ?? ""))
                        continue;
                    var results = bl.Value.GeraRegistrosTotalizadores(RegistroTotalizadorCodigo, RegistroTotalizadorStringFormat);
                    foreach (var tot in results)
                        Blocos[BlocoTotalizador ?? ""].Registros.Add(tot);

                    if (cancelationToken.IsCancellationRequested == true)
                    {
                        SetCurrent(null);
                        SetPercent(0);
                        await writer.DisposeAsync();
                        return;
                    }
                }

                foreach (var postReg in SufixoBlocoEncerramento())
                    Blocos[BlocoTotalizador ?? ""].Registros.Add(postReg);
            };

            if (cancelationToken.IsCancellationRequested == true)
            {
                SetCurrent(null);
                SetPercent(0);
                await writer.DisposeAsync();
                return;
            }

            // ## Obtenção do total de registros para progress bar:
            long total_registros = Blocos.Values.Select(v => v.Registros.Count).Sum();
            ContagemRegistroConcluida?.Invoke(this, new ContagemRegistroEventArgs(total_registros));

            // ## Escrita dos Registros
            foreach (var bl in Blocos.Values)
            {
                foreach (var o in bl.Registros)
                {
                    if (cancelationToken.IsCancellationRequested == true)
                    {
                        SetCurrent(null);
                        SetPercent(0);
                        await writer.DisposeAsync();
                        return;
                    }

                    i += 1;
                    o.OverrideVersao(Versao);
                    await writer.WriteLineAsync(o.EscreveLinha());
                    SetPercent((int)((double)i / (double)total_registros * 100d));
                }
            }

            // '## Escrita personalizada final
            if (cancelationToken.IsCancellationRequested == true)
            {
                SetCurrent(null);
                SetPercent(0);
                await writer.DisposeAsync();
                return;
            }
            await EncerraArquivo(writer);

            // ## Liberação de recursos
            await writer.FlushAsync();
            writer.Dispose();
        }
    }

    /// <summary>
    /// Quando implementado, executa custom actions para geração de registros totalizadores no cabeçalho do bloco de encerramento do arquivo.
    /// </summary>
    public virtual Registro[] PrefixoBlocoEncerramento()
    {
        return null;
    }

    /// <summary>
    /// Quando implementado, executa custom actions para geração de registros totalizadores no rodapé do bloco de encerramento do arquivo.
    /// </summary>
    /// <returns><see cref="IEnumerable{Registro}"/></returns>
    public virtual Registro[] SufixoBlocoEncerramento() 
    {
        return null;
    }

    /// <summary>
    /// Quando implementado, é chamado pelo método <see cref="EscreveArquivo"/> para escrita personalizada do final do arquivo.
    /// </summary>
    /// <returns><see cref="IEnumerable{Registro}"/></returns>
    public virtual async Task EncerraArquivo(System.IO.StreamWriter writer)
    {
        await Task.Delay(1);
    }

    /// <summary>
    /// Método executado durante a leitura (desserialização) do arquivo digital. 
    /// É executado a cada linha e permite a criação de instâncias de Registros, 
    /// e monstagem da estrutura
    /// hierárquica de Blocos e Registros.
    /// </summary>
    /// <param name="linha">Conteúdo da linha atualmente lida.</param>
    public abstract void ProcessaLinha(
        string linha,
        CancellationToken cancelationToken = default);

    /// <summary>
    /// Retorna o CNPJ do informante do arquivo.
    /// </summary>
    /// <param name="stream">Origem para leitura dos dados.</param>
    public abstract Task<string> LeEmpresaArquivo(
        System.IO.Stream stream,
        CancellationToken cancelationToken = default);

    /// <summary>
    /// Por padrão, este override do método .ToString() irá retornar a representação escrita (serializada) 
    /// do conteúdo da escrituração por completo.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var writer = new System.Text.StringBuilder();
        foreach (var bl in Blocos.Values)
            writer.Append(bl.EscreveLinha());
        return writer.ToString();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public event ContagemRegistroEventHandler? ContagemRegistroConcluida;
}

public class HeaderPosition
{
    public int Index { get; set; } = 1;
    public int Lenght { get; set; } = 4;
}

public class ContagemRegistroEventArgs
{
    public ContagemRegistroEventArgs(long contagem)
    {
        TotalRegistro = contagem;
    }

    public long TotalRegistro { get; private set; }
}

public delegate void ContagemRegistroEventHandler(object sender, ContagemRegistroEventArgs e);
