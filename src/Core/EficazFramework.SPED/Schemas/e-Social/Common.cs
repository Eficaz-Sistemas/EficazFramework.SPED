namespace EficazFramework.SPED.Schemas.eSocial;

public class eSocialTimeStampUtils
{
    public static Dictionary<string, int> TimestampDict { get; private set; } = new Dictionary<string, int>();

    public static string GetTimeStampIDForEvent()
    {
        int ID = 1;
        string timeString = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
        if (TimestampDict.ContainsKey(timeString))
        {
            ID = TimestampDict[timeString] + 1;
            TimestampDict[timeString] = ID;
        }
        else
        {
            TimestampDict.Add(timeString, 1);
        }

        return string.Format("{0}{1:00000}", timeString, ID);
    }
}

public abstract class IeSocialEvt
{
    private XmlSerializer sSerializer; // New System.Xml.Serialization.XmlSerializer(GetType(EnvioLoteEventos))

    public abstract XmlSerializer DefineSerializer();
    public abstract void GeraEventoID();
    public abstract object GetEventoID();
    public abstract string ContribuinteCNPJ();

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            sSerializer = DefineSerializer();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            if (streamReader != null)
            {
                streamReader.Dispose();
            }

            if (memoryStream != null)
            {
                memoryStream.Dispose();
            }
        }
    }

    public virtual async Task SaveToAsync(System.IO.Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new System.IO.StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            await streamWriter.WriteLineAsync(xmlString);
            await streamWriter.FlushAsync();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }
}

/// <summary>
/// Identificação do Empregador, titular do Evento
/// </summary>
public partial class Empregador : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get
        {
            return tpInscField;
        }

        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get
        {
            return nrInscField;
        }

        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    public string NumeroInscricaoTag()
    {
        string inscrFinal = nrInsc;
        if (inscrFinal.Length < 8)
            inscrFinal = Extensions.String.ToFixedLenghtString(inscrFinal, 8, Extensions.Alignment.Left, "0");
        if (tpInsc == PersonalidadeJuridica.CNPJ)
            inscrFinal = inscrFinal.Substring(0, 8);
        return Extensions.String.ToFixedLenghtString(inscrFinal, 14, Extensions.Alignment.Right, "0");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Identificação do Evento, com Ambiente, Processo Emissor e Versão
/// </summary>
public partial class IdentificacaoCadastro : object, INotifyPropertyChanged
{
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public Ambiente tpAmb
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string verProc
    {
        get
        {
            return verProcField;
        }

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Identificação do Evento Períodico
/// </summary>
public partial class IdeEventoPeriodico : object, INotifyPropertyChanged
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorRetificacao indRetif
    {
        get
        {
            return indRetifField;
        }

        set
        {
            indRetifField = value;
            RaisePropertyChanged("indRetif");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecibo
    {
        get
        {
            return nrReciboField;
        }

        set
        {
            nrReciboField = value;
            RaisePropertyChanged("nrRecibo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IndicadorApuracao indApuracao
    {
        get
        {
            return indApuracaoField;
        }

        set
        {
            indApuracaoField = value;
            RaisePropertyChanged("indApuracao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string perApur
    {
        get
        {
            return perApurField;
        }

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public Ambiente tpAmb
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string verProc
    {
        get
        {
            return verProcField;
        }

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Identificação do Evento Não Períodico
/// </summary>
public partial class IdeEventoNaoPeriodico : object, INotifyPropertyChanged
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    /// <remarks/>
    public IndicadorRetificacao indRetif
    {
        get
        {
            return indRetifField;
        }

        set
        {
            indRetifField = value;
            RaisePropertyChanged("indRetif");
        }
    }

    /// <remarks/>
    public string nrRecibo
    {
        get
        {
            return nrReciboField;
        }

        set
        {
            nrReciboField = value;
            RaisePropertyChanged("nrRecibo");
        }
    }

    /// <remarks/>
    public Ambiente tpAmb
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    public string verProc
    {
        get
        {
            return verProcField;
        }

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


/// <summary>
/// Informação do Período (inicial e final, formato AAAA-MM)
/// </summary>
public partial class IdePeriodo : object, INotifyPropertyChanged
{
    private string iniValidField;
    private string fimValidField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string iniValid
    {
        get
        {
            return iniValidField;
        }

        set
        {
            iniValidField = value;
            RaisePropertyChanged("iniValid");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string fimValid
    {
        get
        {
            return fimValidField;
        }

        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Identificação do Transmissor
/// </summary>
public partial class IdeTransmissor : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get
        {
            return tpInscField;
        }

        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get
        {
            return nrInscField;
        }

        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Endereço no Brasil
/// </summary>
public partial class EnderecoBrasileiro : object, INotifyPropertyChanged
{
    private string tpLogradField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string cepField;
    private string codMunicField;
    private UFCadastro ufField;

    /// <remarks/>
    public string tpLograd
    {
        get
        {
            return tpLogradField;
        }

        set
        {
            tpLogradField = value;
            RaisePropertyChanged("tpLograd");
        }
    }

    /// <remarks/>
    public string dscLograd
    {
        get
        {
            return dscLogradField;
        }

        set
        {
            dscLogradField = value;
            RaisePropertyChanged("dscLograd");
        }
    }

    /// <remarks/>
    public string nrLograd
    {
        get
        {
            return nrLogradField;
        }

        set
        {
            nrLogradField = value;
            RaisePropertyChanged("nrLograd");
        }
    }

    /// <remarks/>
    public string complemento
    {
        get
        {
            return complementoField;
        }

        set
        {
            complementoField = value;
            RaisePropertyChanged("complemento");
        }
    }

    /// <remarks/>
    public string bairro
    {
        get
        {
            return bairroField;
        }

        set
        {
            bairroField = value;
            RaisePropertyChanged("bairro");
        }
    }

    /// <remarks/>
    public string cep
    {
        get
        {
            return cepField;
        }

        set
        {
            cepField = value;
            RaisePropertyChanged("cep");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "integer")]
    public string codMunic
    {
        get
        {
            return codMunicField;
        }

        set
        {
            codMunicField = value;
            RaisePropertyChanged("codMunic");
        }
    }

    /// <remarks/>
    public UFCadastro uf
    {
        get
        {
            return ufField;
        }

        set
        {
            ufField = value;
            RaisePropertyChanged("uf");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}