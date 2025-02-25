using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.CTe;

public partial class CTeRodoviario : INotifyPropertyChanged
{
    private string rNTRCField;
    private DateTime? dPrevField;
    private rodoLota lotaField;
    private string cIOTField;
    private ObservableCollection<rodoOcc> occField;
    private ObservableCollection<rodoValePed> valePedField;
    private ObservableCollection<rodoVeic> veicField;
    private ObservableCollection<rodoLacRodo> lacRodoField;
    private ObservableCollection<rodoMoto> motoField;


    public CTeRodoviario() : base()
    {
        motoField = new ObservableCollection<rodoMoto>();
        lacRodoField = new ObservableCollection<rodoLacRodo>();
        veicField = new ObservableCollection<rodoVeic>();
        valePedField = new ObservableCollection<rodoValePed>();
        occField = new ObservableCollection<rodoOcc>();
    }

    public string RNTRC
    {
        get => rNTRCField;
        set
        {
            if (rNTRCField is null || rNTRCField.Equals(value) != true)
            {
                rNTRCField = value;
                OnPropertyChanged(nameof(RNTRC));
            }
        }
    }

    [XmlIgnore()]
    public DateTime? DataPrevistaEntrega
    {
        get => dPrevField;
        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged(nameof(DataPrevistaEntrega));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'DataPrevistaEntrega' (Date?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dPrev")]
    public string DataPrevistaEntregaXML
    {
        get
        {
            if (DataPrevistaEntrega.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataPrevistaEntrega);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dPrevField = new DateTime(int.Parse(dt[0]), int.Parse(dt[1]), int.Parse(dt[2].Substring(0, 2)));
                }
                else
                {
                    dPrevField = default;
                }

                OnPropertyChanged(nameof(DataPrevistaEntrega));
            }
        }
    }

    public bool ShouldSerializeDataPrevistaEntregaXML() => dPrevField.HasValue;

    public rodoLota lota
    {
        get => lotaField;
        set
        {
            if (lotaField.Equals(value) != true)
            {
                lotaField = value;
                OnPropertyChanged(nameof(lota));
            }
        }
    }

    public string CIOT
    {
        get => cIOTField;
        set
        {
            if (cIOTField is null || cIOTField.Equals(value) != true)
            {
                cIOTField = value;
                OnPropertyChanged(nameof(CIOT));
            }
        }
    }

    [XmlElement("occ")]
    public ObservableCollection<rodoOcc> occ
    {
        get => occField;
        set
        {
            if (occField is null || occField.Equals(value) != true)
            {
                occField = value;
                OnPropertyChanged(nameof(occ));
            }
        }
    }

    [XmlElement("valePed")]
    public ObservableCollection<rodoValePed> valePed
    {
        get => valePedField;
        set
        {
            if (valePedField is null || valePedField.Equals(value) != true)
            {
                valePedField = value;
                OnPropertyChanged(nameof(valePed));
            }
        }
    }

    [XmlElement("veic")]
    public ObservableCollection<rodoVeic> veic
    {
        get => veicField;
        set
        {
            if (veicField is null || veicField.Equals(value) != true)
            {
                veicField = value;
                OnPropertyChanged(nameof(veic));
            }
        }
    }

    [XmlElement("lacRodo")]
    public ObservableCollection<rodoLacRodo> lacRodo
    {
        get => lacRodoField;
        set
        {
            if (lacRodoField is null || lacRodoField.Equals(value) != true)
            {
                lacRodoField = value;
                OnPropertyChanged(nameof(lacRodo));
            }
        }
    }

    [XmlElement("moto")]
    public ObservableCollection<rodoMoto> moto
    {
        get => motoField;
        set
        {
            if (motoField is null || motoField.Equals(value) != true)
            {
                motoField = value;
                OnPropertyChanged(nameof(moto));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class rodoOcc : INotifyPropertyChanged
{
    private string serieField;
    private string nOccField;
    private string dEmiField;
    private rodoOccEmiOcc emiOccField;


    public rodoOcc() : base()
    {
        emiOccField = new rodoOccEmiOcc();
    }

    public string serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(serie));
            }
        }
    }

    public string nOcc
    {
        get => nOccField;
        set
        {
            if (nOccField is null || nOccField.Equals(value) != true)
            {
                nOccField = value;
                OnPropertyChanged(nameof(nOcc));
            }
        }
    }

    public string dEmi
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(dEmi));
            }
        }
    }

    public rodoOccEmiOcc emiOcc
    {
        get => emiOccField;
        set
        {
            if (emiOccField is null || emiOccField.Equals(value) != true)
            {
                emiOccField = value;
                OnPropertyChanged(nameof(emiOcc));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class rodoOccEmiOcc : INotifyPropertyChanged
{
    private string cNPJField;
    private string cIntField;
    private string ieField;
    private NFe.Estado ufField;
    private string foneField;


    public string CNPJ
    {
        get => cNPJField;
        set
        {
            if (cNPJField is null || cNPJField.Equals(value) != true)
            {
                cNPJField = value;
                OnPropertyChanged(nameof(CNPJ));
            }
        }
    }

    public string cInt
    {
        get => cIntField;
        set
        {
            if (cIntField is null || cIntField.Equals(value) != true)
            {
                cIntField = value;
                OnPropertyChanged(nameof(cInt));
            }
        }
    }

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public NFe.Estado UF
    {
        get => ufField;
        set
        {
            if (ufField.Equals(value) != true)
            {
                ufField = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) 
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class rodoValePed : INotifyPropertyChanged
{
    private string cNPJFornField;
    private string nCompraField;
    private string cNPJPgField;
    private string vValePedField;

    public string CNPJForn
    {
        get => cNPJFornField;
        set
        {
            if (cNPJFornField is null || cNPJFornField.Equals(value) != true)
            {
                cNPJFornField = value;
                OnPropertyChanged(nameof(CNPJForn));
            }
        }
    }

    public string nCompra
    {
        get => nCompraField;
        set
        {
            if (nCompraField is null || nCompraField.Equals(value) != true)
            {
                nCompraField = value;
                OnPropertyChanged(nameof(nCompra));
            }
        }
    }

    public string CNPJPg
    {
        get => cNPJPgField;
        set
        {
            if (cNPJPgField is null || cNPJPgField.Equals(value) != true)
            {
                cNPJPgField = value;
                OnPropertyChanged(nameof(CNPJPg));
            }
        }
    }

    public string vValePed
    {
        get => vValePedField;
        set
        {
            if (vValePedField is null || vValePedField.Equals(value) != true)
            {
                vValePedField = value;
                OnPropertyChanged(nameof(vValePed));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class rodoVeic : INotifyPropertyChanged
{
    private string cIntField;
    private string rENAVAMField;
    private string placaField;
    private string taraField;
    private string capKGField;
    private string capM3Field;
    private rodoVeicTpProp tpPropField;
    private rodoVeicTpVeic tpVeicField;
    private rodoVeicTpRod tpRodField;
    private rodoVeicTpCar tpCarField;
    private NFe.Estado ufField;
    private rodoVeicProp propField;


    public rodoVeic() : base()
    {
        propField = new rodoVeicProp();
    }

    public string cInt
    {
        get => cIntField;
        set
        {
            if (cIntField is null || cIntField.Equals(value) != true)
            {
                cIntField = value;
                OnPropertyChanged(nameof(cInt));
            }
        }
    }

    public string RENAVAM
    {
        get => rENAVAMField;
        set
        {
            if (rENAVAMField is null || rENAVAMField.Equals(value) != true)
            {
                rENAVAMField = value;
                OnPropertyChanged(nameof(RENAVAM));
            }
        }
    }

    public string placa
    {
        get => placaField;
        set
        {
            if (placaField is null || placaField.Equals(value) != true)
            {
                placaField = value;
                OnPropertyChanged(nameof(placa));
            }
        }
    }

    public string tara
    {
        get => taraField;
        set
        {
            if (taraField is null || taraField.Equals(value) != true)
            {
                taraField = value;
                OnPropertyChanged(nameof(tara));
            }
        }
    }

    public string capKG
    {
        get => capKGField;
        set
        {
            if (capKGField is null || capKGField.Equals(value) != true)
            {
                capKGField = value;
                OnPropertyChanged(nameof(capKG));
            }
        }
    }

    public string capM3
    {
        get => capM3Field;
        set
        {
            if (capM3Field is null || capM3Field.Equals(value) != true)
            {
                capM3Field = value;
                OnPropertyChanged(nameof(capM3));
            }
        }
    }

    public rodoVeicTpProp tpProp
    {
        get => tpPropField;
        set
        {
            if (tpPropField.Equals(value) != true)
            {
                tpPropField = value;
                OnPropertyChanged(nameof(tpProp));
            }
        }
    }

    public rodoVeicTpVeic tpVeic
    {
        get => tpVeicField;
        set
        {
            if (tpVeicField.Equals(value) != true)
            {
                tpVeicField = value;
                OnPropertyChanged(nameof(tpVeic));
            }
        }
    }

    public rodoVeicTpRod tpRod
    {
        get => tpRodField;
        set
        {
            if (tpRodField.Equals(value) != true)
            {
                tpRodField = value;
                OnPropertyChanged(nameof(tpRod));
            }
        }
    }

    public rodoVeicTpCar tpCar
    {
        get => tpCarField;
        set
        {
            if (tpCarField.Equals(value) != true)
            {
                tpCarField = value;
                OnPropertyChanged(nameof(tpCar));
            }
        }
    }

    public NFe.Estado UF
    {
        get => ufField;
        set
        {
            if (ufField.Equals(value) != true)
            {
                ufField = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }

    public rodoVeicProp prop
    {
        get => propField;
        set
        {
            if (propField is null || propField.Equals(value) != true)
            {
                propField = value;
                OnPropertyChanged(nameof(prop));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum rodoVeicTpVeic
{

    /// <remarks/>
    [XmlEnum("0")]
    Item0,

    /// <remarks/>
    [XmlEnum("1")]
    Item1
}

public enum rodoVeicTpRod
{

    /// <remarks/>
    [XmlEnum("00")]
    Item00,

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("02")]
    Item02,

    /// <remarks/>
    [XmlEnum("03")]
    Item03,

    /// <remarks/>
    [XmlEnum("04")]
    Item04,

    /// <remarks/>
    [XmlEnum("05")]
    Item05,

    /// <remarks/>
    [XmlEnum("06")]
    Item06
}

public enum rodoVeicTpCar
{

    /// <remarks/>
    [XmlEnum("00")]
    Item00,

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("02")]
    Item02,

    /// <remarks/>
    [XmlEnum("03")]
    Item03,

    /// <remarks/>
    [XmlEnum("04")]
    Item04,

    /// <remarks/>
    [XmlEnum("05")]
    Item05
}

public partial class rodoVeicProp : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string rNTRCField;
    private string xNomeField;
    private string ieField;
    private NFe.Estado ufField;
    private rodoVeicPropTpProp tpPropField;


    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(ItemElementName));
            }
        }
    }

    public string RNTRC
    {
        get => rNTRCField;
        set
        {
            if (rNTRCField is null || rNTRCField.Equals(value) != true)
            {
                rNTRCField = value;
                OnPropertyChanged(nameof(RNTRC));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public NFe.Estado UF
    {
        get => ufField;
        set
        {
            if (ufField.Equals(value) != true)
            {
                ufField = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }

    public rodoVeicPropTpProp tpProp
    {
        get => tpPropField;
        set
        {
            if (tpPropField.Equals(value) != true)
            {
                tpPropField = value;
                OnPropertyChanged(nameof(tpProp));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum rodoVeicPropTpProp
{

    /// <remarks/>
    [XmlEnum("0")]
    Item0,

    /// <remarks/>
    [XmlEnum("1")]
    Item1,

    /// <remarks/>
    [XmlEnum("2")]
    Item2
}

public partial class rodoLacRodo : INotifyPropertyChanged
{
    private string nLacreField;


    public string nLacre
    {
        get => nLacreField;
        set
        {
            if (nLacreField is null || nLacreField.Equals(value) != true)
            {
                nLacreField = value;
                OnPropertyChanged(nameof(nLacre));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class rodoMoto : INotifyPropertyChanged
{
    private string xNomeField;
    private string cPFField;


    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string CPF
    {
        get => cPFField;
        set
        {
            if (cPFField is null || cPFField.Equals(value) != true)
            {
                cPFField = value;
                OnPropertyChanged(nameof(CPF));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}