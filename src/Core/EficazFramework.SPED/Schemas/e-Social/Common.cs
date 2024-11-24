namespace EficazFramework.SPED.Schemas.eSocial;

public class eSocialTimeStampUtils
{
    public static Dictionary<string, int> TimestampDict { get; private set; } = new Dictionary<string, int>();

    public static string GetTimeStampIDForEvent()
    {
        int ID = 1;
        string timeString = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
        if (TimestampDict.TryGetValue(timeString, out int value))
        {
            ID = value + 1;
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
            streamReader?.Dispose();

            memoryStream?.Dispose();
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
            streamWriter?.Dispose();
        }
    }
}

/// <summary>
/// Identificação do Empregador, titular do Evento
/// </summary>
public partial class Empregador : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
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
}

/// <summary>
/// Identificação do Evento, com Ambiente, Processo Emissor e Versão
/// </summary>
public partial class IdentificacaoCadastro : ESocialBindableObject
{
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    [XmlElement(Order = 0)]
    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    [XmlElement(Order = 1)]
    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    [XmlElement(Order = 2)]
    public string verProc
    {
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}

/// <summary>
/// Identificação do Evento Períodico
/// </summary>
public partial class IdeEventoPeriodico : ESocialBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
    private string perApurField;
    private IndicadorGuia indGuiaField = IndicadorGuia.DAE;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    public IndicadorRetificacao indRetif
    {
        get => indRetifField;
        set
        {
            indRetifField = value;
            RaisePropertyChanged(nameof(indRetif));
        }
    }

    public string nrRecibo
    {
        get => nrReciboField;
        set
        {
            nrReciboField = value;
            RaisePropertyChanged(nameof(nrRecibo));
        }
    }

    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }

    public IndicadorGuia indGuia
    {
        get =>indGuiaField;
        set 
        { 
            indGuiaField = value;
            RaisePropertyChanged(nameof(indGuia));
        }
    }

    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    public string verProc
    {
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}

/// <summary>
/// Identificação do Evento Não Períodico
/// </summary>
public partial class IdeEventoNaoPeriodico : ESocialBindableObject
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
    private string verProcField;

    public IndicadorRetificacao indRetif
    {
        get => indRetifField;
        set
        {
            indRetifField = value;
            RaisePropertyChanged(nameof(indRetif));
        }
    }

    public string nrRecibo
    {
        get => nrReciboField;
        set
        {
            nrReciboField = value;
            RaisePropertyChanged(nameof(nrRecibo));
        }
    }

    public Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            tpAmbField = value;
            RaisePropertyChanged(nameof(tpAmb));
        }
    }

    public EmissorEvento procEmi
    {
        get => procEmiField;
        set
        {
            procEmiField = value;
            RaisePropertyChanged(nameof(procEmi));
        }
    }

    public string verProc
    {
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged(nameof(verProc));
        }
    }
}


/// <summary>
/// Informação do Período (inicial e final, formato AAAA-MM)
/// </summary>
public partial class IdePeriodo : ESocialBindableObject
{
    private string iniValidField;
    private string fimValidField;

    [XmlElement(Order = 0)]
    public string iniValid
    {
        get => iniValidField;
        set
        {
            iniValidField = value;
            RaisePropertyChanged(nameof(iniValid));
        }
    }

    [XmlElement(Order = 1)]
    public string fimValid
    {
        get => fimValidField;
        set
        {
            fimValidField = value;
            RaisePropertyChanged(nameof(fimValid));
        }
    }
}

/// <summary>
/// Identificação do Transmissor
/// </summary>
public partial class IdeTransmissor : ESocialBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;

    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged(nameof(tpInsc));
        }
    }

    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged(nameof(nrInsc));
        }
    }
}

/// <summary>
/// Endereço no Brasil
/// </summary>
public partial class EnderecoBrasileiro : ESocialBindableObject
{
    private string tpLogradField;
    private string dscLogradField;
    private string nrLogradField;
    private string complementoField;
    private string bairroField;
    private string cepField;
    private string codMunicField;
    private UFCadastro ufField;

    public string tpLograd
    {
        get => tpLogradField;
        set
        {
            tpLogradField = value;
            RaisePropertyChanged(nameof(tpLograd));
        }
    }

    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged(nameof(dscLograd));
        }
    }

    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged(nameof(nrLograd));
        }
    }

    public string complemento
    {
        get => complementoField;
        set
        {
            complementoField = value;
            RaisePropertyChanged(nameof(complemento));
        }
    }

    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged(nameof(bairro));
        }
    }

    public string cep
    {
        get => cepField;
        set
        {
            cepField = value;
            RaisePropertyChanged(nameof(cep));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codMunic
    {
        get => codMunicField;
        set
        {
            codMunicField = value;
            RaisePropertyChanged(nameof(codMunic));
        }
    }

    public UFCadastro uf
    {
        get => ufField;
        set
        {
            ufField = value;
            RaisePropertyChanged(nameof(uf));
        }
    }
}


public partial class ProcessoAdmOuJud : ESocialBindableObject
{
    private sbyte tpProcField = -1;
    private string nrProcField;
    private string codSuspField;

    public sbyte tpProc
    {
        get => tpProcField;
        set
        {
            tpProcField = value;
            RaisePropertyChanged(nameof(tpProc));
        }
    }

    public bool ShouldSerializetpProc()
        => tpProc >= 0;

    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged(nameof(nrProc));
        }
    }

    [XmlElement(DataType = "integer")]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(codSusp));
        }
    }
}
