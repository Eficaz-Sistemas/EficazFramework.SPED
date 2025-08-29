using EficazFramework.SPED.Extensions;
using System.Reflection;

namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Grupo de detalhamento de Produtos e Serviços da NF-e
/// </summary>
public partial class Item : INotifyPropertyChanged
{
    public Item() : base()
    {
        // Me.impostoField = New Tributacao()
        // Me.prodField = New Produto()
    }

    private Produto prodField;
    private Tributacao impostoField;
    private TributacaoDevolucao impostoDevolvidoField;
    private string infAdProdField;
    private string nItemField;

    [XmlElement("prod")]
    public Produto Dados
    {
        get => prodField;
        set
        {
            if (prodField is null || prodField.Equals(value) != true)
            {
                prodField = value;
                OnPropertyChanged(nameof(Dados));
            }
        }
    }

    [XmlElement("imposto")]
    public Tributacao Imposto
    {
        get => impostoField;
        set
        {
            if (impostoField is null || impostoField.Equals(value) != true)
            {
                impostoField = value;
                OnPropertyChanged(nameof(Imposto));
            }
        }
    }

    [XmlElement("impostoDevol")]
    public TributacaoDevolucao ImpostoDevolvido
    {
        get => impostoDevolvidoField;
        set
        {
            if (impostoDevolvidoField is null || impostoDevolvidoField.Equals(value) != true)
            {
                impostoDevolvidoField = value;
                OnPropertyChanged(nameof(ImpostoDevolvido));
            }
        }
    }

    [XmlElement("infAdProd")]
    public string InformacoesAdicionais
    {
        get => infAdProdField;
        set
        {
            if (infAdProdField is null || infAdProdField.Equals(value) != true)
            {
                infAdProdField = value;
                OnPropertyChanged(nameof(InformacoesAdicionais));
            }
        }
    }

    public bool PossuiInformacoesAdicionais
    {
        get
        {
            if (!string.IsNullOrEmpty(InformacoesAdicionais) & string.IsNullOrWhiteSpace(InformacoesAdicionais))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [XmlAttribute("nItem")]
    public string NumeroSequencial
    {
        get => nItemField;
        set
        {
            if (nItemField is null || nItemField.Equals(value) != true)
            {
                nItemField = value;
                OnPropertyChanged(nameof(NumeroSequencial));
            }
        }
    }

    public double vCustoST
    {
        get
        {
            double ST = 0d;
            try
            {
                var icms = Imposto.EstaduaisMunicipais[0];
                var trib = icms.GetType().GetRuntimeProperty("Tributacao").GetValue(icms, null);
                ST = Convert.ToDouble(trib.GetType().GetRuntimeProperty("vICMSST").GetValue(trib));
            }
            catch (Exception)
            {
            }

            double bruto = 0d;
            if (Dados.ValorTotalBruto.HasValue == true)
                bruto = (double)Dados.ValorTotalBruto;
            return Math.Round(ST / bruto * 100d, 2);
        }
    }

    public double vCustoTotal
    {
        get
        {
            double v = 0d;
            if (Dados.ValorTotalBruto.HasValue == true)
                v = (double)Dados.ValorTotalBruto;
            try
            {
                if (Imposto.ICMS != null)
                {
                    if (Imposto.ICMS.Tributacao != null)
                    {
                        if (Imposto.ICMS.Tributacao.vICMSST.HasValue == true)
                            v = (double)(v + Imposto.ICMS.Tributacao.vICMSST); // Me.Imposto.DemaisImpostos(0).Tributacao.vICMSST()
                    }
                }
            }
            catch (Exception)
            {
            }

            try
            {
                if (Imposto.IPI != null)
                {
                    if (Imposto.IPI.Tributacao != null)
                    {
                        if (Imposto.IPI.Tributacao.ValorIPI.HasValue == true)
                            v = (double)(v + Imposto.IPI.Tributacao.ValorIPI); // Me.Imposto.DemaisImpostos(1).Tributacao.ValorIPI()
                    }
                }
            }
            catch (Exception)
            {
            }

            return Math.Round(v, 2);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Produto : INotifyPropertyChanged
{
    public Produto() : base()
    {
        itemsField = new List<object>();
        diField = new List<DeclaracaoImportacao>();
    }

    private string cProdField;
    private string cEANField;
    private string xProdField;
    private string nCMField;
    private string eXTIPIField;
    private string cFOPField;
    private string uComField;
    private double? qComField;
    private double? vUnComField;
    private double? vProdField;
    private string cEANTribField;
    private string uTribField;
    private double? qTribField;
    private double? vUnTribField;
    private double? vFreteField;
    private double? vSegField;
    private double? vDescField;
    private double? vOutroField;
    private IndicadorTotal indTotField;
    private string _nFCIField;
    private List<DeclaracaoImportacao> diField = new List<DeclaracaoImportacao>();
    private string xPedField;
    private int? nItemPedField;
    private List<object> itemsField;
    private string _cest;

    [XmlElement("cProd")]
    public string Codigo
    {
        get => cProdField;
        set
        {
            if (cProdField is null || cProdField.Equals(value) != true)
            {
                cProdField = value;
                OnPropertyChanged(nameof(Codigo));
            }
        }
    }

    /// <summary>
    /// Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.
    /// Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14. Não informar conteúdo da TAG em caso do produto não possuir este código.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("cEAN")]
    public string GTIN
    {
        get => cEANField;
        set
        {
            if (cEANField is null || cEANField.Equals(value) != true)
            {
                cEANField = value;
                OnPropertyChanged(nameof(GTIN));
            }
        }
    }

    [XmlElement("xProd")]
    public string Descricao
    {
        get => xProdField;
        set
        {
            if (xProdField is null || xProdField.Equals(value) != true)
            {
                xProdField = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }
    }

    public string NCM
    {
        get => nCMField;
        set
        {
            if (nCMField is null || nCMField.Equals(value) != true)
            {
                nCMField = value;
                OnPropertyChanged(nameof(NCM));
            }
        }
    }

    public string CEST
    {
        get => _cest;
        set
        {
            if (_cest is null || _cest.Equals(value) != true)
            {
                _cest = value;
                OnPropertyChanged(nameof(CEST));
            }
        }
    }

    public string EXTIPI
    {
        get => eXTIPIField;
        set
        {
            if (eXTIPIField is null || eXTIPIField.Equals(value) != true)
            {
                eXTIPIField = value;
                OnPropertyChanged(nameof(EXTIPI));
            }
        }
    }

    public string CFOP
    {
        get => cFOPField;
        set
        {
            if (cFOPField is null || cFOPField.Equals(value) != true)
            {
                cFOPField = value;
                OnPropertyChanged(nameof(CFOP));
            }
        }
    }

    [XmlElement("uCom")]
    public string UnidadeComercial
    {
        get => uComField;
        set
        {
            if (uComField is null || uComField.Equals(value) != true)
            {
                uComField = value;
                OnPropertyChanged(nameof(UnidadeComercial));
            }
        }
    }

    [XmlElement("qCom")]
    public double? QuantidadeComercial
    {
        get => qComField;
        set
        {
            if (qComField is null || qComField.Equals(value) != true)
            {
                qComField = value;
                OnPropertyChanged("qCom");
            }
        }
    }

    public bool ShouldSerializeQuantidadeComercial() => qComField.HasValue;

    [XmlElement("vUnCom")]
    public double? ValorUnitarioComercial
    {
        get => vUnComField;
        set
        {
            if (vUnComField is null || vUnComField.Equals(value) != true)
            {
                vUnComField = value;
                OnPropertyChanged(nameof(ValorUnitarioComercial));
            }
        }
    }

    public bool ShouldSerializeValorUnitarioComercial() => vUnComField.HasValue;

    [XmlIgnore()]
    public double? ValorTotalBruto
    {
        get => vProdField;
        set
        {
            if (vProdField is null || vProdField.Equals(value) != true)
            {
                vProdField = value;
                OnPropertyChanged(nameof(ValorTotalBruto));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'ValorTotalBruto' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vProd")]
    public string ValorTotalBruto_XML
    {
        get
        {
            if (ValorTotalBruto.HasValue == true)
            {
                return string.Format("{0:0.00}", ValorTotalBruto).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vProdField is null || vProdField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vProdField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vProdField = default;
                    }
                }
                else
                {
                    vProdField = default;
                }

                OnPropertyChanged(nameof(ValorTotalBruto));
            }
        }
    }

    public bool ShouldSerializeValorTotalBruto_XML() => vProdField.HasValue;

    /// <summary>
    /// Global Trade Item Number: Código do Produto, antigo código EAN ou código de barras.
    /// Preencher com código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 da unidade tributável do produto.
    /// Não informar conteúdo da TAG em caso do produto não possuir este código.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("cEANTrib")]
    public string GTIN_Tributavel
    {
        get => cEANTribField;
        set
        {
            if (cEANTribField is null || cEANTribField.Equals(value) != true)
            {
                cEANTribField = value;
                OnPropertyChanged(nameof(GTIN_Tributavel));
            }
        }
    }

    [XmlElement("uTrib")]
    public string UnidadeTributavel
    {
        get => uTribField;
        set
        {
            if (uTribField is null || uTribField.Equals(value) != true)
            {
                uTribField = value;
                OnPropertyChanged(nameof(UnidadeTributavel));
            }
        }
    }

    [XmlElement("qTrib")]
    public double? QuantidadeTributavel
    {
        get => qTribField;
        set
        {
            if (qTribField is null || qTribField.Equals(value) != true)
            {
                qTribField = value;
                OnPropertyChanged(nameof(QuantidadeTributavel));
            }
        }
    }

    public bool ShouldSerializeQuantidadeTributavel() => qTribField.HasValue;

    [XmlElement("vUnTrib")]
    public double? ValorUnitarioTributavel
    {
        get => vUnTribField;
        set
        {
            if (vUnTribField is null || vUnTribField.Equals(value) != true)
            {
                vUnTribField = value;
                OnPropertyChanged(nameof(ValorUnitarioTributavel));
            }
        }
    }

    public bool ShouldSerializeValorUnitarioTributavel() => vUnTribField.HasValue;

    [XmlElement("vFrete")]
    public double? ValorFrete
    {
        get => vFreteField;
        set
        {
            if (vFreteField is null || vFreteField.Equals(value) != true)
            {
                vFreteField = value;
                OnPropertyChanged(nameof(ValorFrete));
            }
        }
    }

    public bool ShouldSerializeValorFrete() => vFreteField.HasValue;

    [XmlElement("vSeg")]
    public double? ValorSeguro
    {
        get => vSegField;
        set
        {
            if (vSegField is null || vSegField.Equals(value) != true)
            {
                vSegField = value;
                OnPropertyChanged(nameof(ValorSeguro));
            }
        }
    }

    public bool ShouldSerializeValorSeguro() => vSegField.HasValue;

    [XmlElement("vDesc")]
    public double? ValorDesconto
    {
        get => vDescField;
        set
        {
            if (vDescField is null || vDescField.Equals(value) != true)
            {
                vDescField = value;
                OnPropertyChanged(nameof(ValorDesconto));
            }
        }
    }

    public bool ShouldSerializeValorDesconto() => vDescField.HasValue;

    [XmlElement("vOutro")]
    public double? ValorOutrasDespesas
    {
        get => vOutroField;
        set
        {
            if (vOutroField is null || vOutroField.Equals(value) != true)
            {
                vOutroField = value;
                OnPropertyChanged(nameof(ValorOutrasDespesas));
            }
        }
    }

    public bool ShouldSerializeValorOutrasDespesas() => vOutroField.HasValue;

    [XmlElement("indTot")]
    public IndicadorTotal IndicadorComposicaoTotal
    {
        get => indTotField;
        set
        {
            if (indTotField.Equals(value) != true)
            {
                indTotField = value;
                OnPropertyChanged(nameof(IndicadorComposicaoTotal));
            }
        }
    }

    [XmlElement("nFCI")]
    public string NumeroFCI
    {
        get => _nFCIField;
        set
        {
            if (cProdField is null || cProdField.Equals(value) != true)
            {
                _nFCIField = value;
                OnPropertyChanged(nameof(NumeroFCI));
            }
        }
    }

    public bool PossuiFCI
    {
        get
        {
            return !(string.IsNullOrEmpty(NumeroFCI) | string.IsNullOrWhiteSpace(NumeroFCI));
        }
    }

    [XmlElement("DI")]
    public List<DeclaracaoImportacao> Importacoes
    {
        get => diField;
        set
        {
            if (diField is null || diField.Equals(value) != true)
            {
                diField = value;
                OnPropertyChanged(nameof(Importacoes));
            }
        }
    }

    [XmlElement("xPed")]
    public string PedidoCompraNumero
    {
        get => xPedField;
        set
        {
            if (xPedField is null || xPedField.Equals(value) != true)
            {
                xPedField = value;
                OnPropertyChanged(nameof(PedidoCompraNumero));
            }
        }
    }

    [XmlElement("nItemPed")]
    public int? PedidoCompraItem
    {
        get => nItemPedField;
        set
        {
            if (nItemPedField is null || nItemPedField.Equals(value) != true)
            {
                nItemPedField = value;
                OnPropertyChanged("nItemPed");
            }
        }
    }

    public bool ShouldSerializePedidoCompraItem() => nItemPedField.HasValue;

    [XmlElement("arma", typeof(DetalhamentoItemArma))]
    [XmlElement("comb", typeof(DetalhamentoItemCombustivel))]
    [XmlElement("med", typeof(DetalhamentoItemMedicamento))]
    [XmlElement("rastro", typeof(DetalhamentoItemMedicamento_Rastro))]
    [XmlElement("veicProd", typeof(DetalhamentoItemVeiculo))]
    public List<object> Detalhamentos
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged(nameof(Detalhamentos));
            }
        }
    }

    [XmlIgnore()]
    public List<DetalhamentoItemArma> DetalhamentoArmamento
    {
        get
        {
            if (Detalhamentos != null)
            {
                return (from arma in Detalhamentos
                        where ReferenceEquals(arma.GetType(), typeof(DetalhamentoItemArma))
                        select (DetalhamentoItemArma)arma).ToList();
            }
            else
            {
                return null;
            }
        }
    }

    [XmlIgnore()]
    public List<DetalhamentoItemMedicamento> DetalhamentoMedicamento
    {
        get
        {
            if (Detalhamentos != null)
            {
                return (from rastro in Detalhamentos
                        where ReferenceEquals(rastro.GetType(), typeof(DetalhamentoItemMedicamento))
                        select (DetalhamentoItemMedicamento)rastro).ToList();
            }
            else
            {
                return null;
            }
        }
    }

    [XmlIgnore()]
    public List<DetalhamentoItemMedicamento_Rastro> DetalhamentoMedicamento_Rastro
    {
        get
        {
            if (Detalhamentos != null)
            {
                return (from rastro in Detalhamentos
                        where ReferenceEquals(rastro.GetType(), typeof(DetalhamentoItemMedicamento_Rastro))
                        select (DetalhamentoItemMedicamento_Rastro)rastro).ToList();
            }
            else
            {
                return null;
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoItemCombustivel DetalhamentoCombustivel
    {
        get
        {
            if (Detalhamentos != null)
            {
                foreach (var obj in Detalhamentos)
                {
                    if (ReferenceEquals(obj.GetType(), typeof(DetalhamentoItemCombustivel)))
                    {
                        return (DetalhamentoItemCombustivel)obj;
                    }
                }

                return null;
            }
            else
            {
                return null;
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoItemVeiculo DetalhamentoVeiculo
    {
        get
        {
            if (Detalhamentos != null)
            {
                foreach (var obj in Detalhamentos)
                {
                    if (ReferenceEquals(obj.GetType(), typeof(DetalhamentoItemVeiculo)))
                    {
                        return (DetalhamentoItemVeiculo)obj;
                    }
                }

                return null;
            }
            else
            {
                return null;
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class Tributacao : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Tributacao() : base()
    {
        // Me.cOFINSSTField = New DetalhamentoCOFINSST()
        // Me.cOFINSField = New DetalhamentoCOFINS()
        // Me.pISSTField = New DetalhamentoPISST()
        // Me.pISField = New DetalhamentoPIS()
        itemsField = new List<object>();
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private double? vTotTribField;
    private List<object> itemsField;
    private DetalhamentoPIS pISField;
    private DetalhamentoPISST pISSTField;
    private DetalhamentoCOFINS cOFINSField;
    private DetalhamentoCOFINSST cOFINSSTField;
    private DFeBase.TIS isField;
    private DFeBase.TTribNFe ibsCbsField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("vTotTrib")]
    public double? ValorTotalTributos
    {
        get => vTotTribField;
        set
        {
            if (vTotTribField is null || vTotTribField.Equals(value) != true)
            {
                vTotTribField = value;
                OnPropertyChanged(nameof(ValorTotalTributos));
            }
        }
    }

    public bool ShouldSerializeValorTotalTributos() => vTotTribField.HasValue;

    [XmlElement("ICMS", typeof(DetalhamentoICMS))]
    [XmlElement("ICMSUFDest", typeof(DetalhamentoICMS_UF_Destinataria))]
    [XmlElement("II", typeof(DetalhamentoII))]
    [XmlElement("IPI", typeof(DetalhamentoIPI))]
    [XmlElement("ISSQN", typeof(DetalhamentoISSQN))]
    public List<object> EstaduaisMunicipais
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged("Impostos");
            }
        }
    }

    public DetalhamentoPIS PIS
    {
        get => pISField;
        set
        {
            if (pISField is null || pISField.Equals(value) != true)
            {
                pISField = value;
                OnPropertyChanged(nameof(PIS));
            }
        }
    }

    public DetalhamentoPISST PISST
    {
        get => pISSTField;
        set
        {
            if (pISSTField is null || pISSTField.Equals(value) != true)
            {
                pISSTField = value;
                OnPropertyChanged(nameof(PISST));
            }
        }
    }

    public DetalhamentoCOFINS COFINS
    {
        get => cOFINSField;
        set
        {
            if (cOFINSField is null || cOFINSField.Equals(value) != true)
            {
                cOFINSField = value;
                OnPropertyChanged(nameof(COFINS));
            }
        }
    }

    public DetalhamentoCOFINSST COFINSST
    {
        get => cOFINSSTField;
        set
        {
            if (cOFINSSTField is null || cOFINSSTField.Equals(value) != true)
            {
                cOFINSSTField = value;
                OnPropertyChanged(nameof(COFINSST));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS ICMS
    {
        get
        {
            // Return _icms
            for (int i = 0, loopTo = EstaduaisMunicipais.Count - 1; i <= loopTo; i++)
            {
                if (EstaduaisMunicipais[i] is DetalhamentoICMS)
                {
                    return (DetalhamentoICMS)EstaduaisMunicipais[i];
                }
            }

            return null;
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_UF_Destinataria ICMSUFDestino
    {
        get
        {
            // Return _icms
            for (int i = 0, loopTo = EstaduaisMunicipais.Count - 1; i <= loopTo; i++)
            {
                if (EstaduaisMunicipais[i] is DetalhamentoICMS_UF_Destinataria)
                {
                    return (DetalhamentoICMS_UF_Destinataria)EstaduaisMunicipais[i];
                }
            }

            return null;
        }
    }

    [XmlIgnore()]
    public DetalhamentoIPI IPI
    {
        get
        {
            // Return _icms
            for (int i = 0, loopTo = EstaduaisMunicipais.Count - 1; i <= loopTo; i++)
            {
                if (EstaduaisMunicipais[i] is DetalhamentoIPI)
                {
                    return (DetalhamentoIPI)EstaduaisMunicipais[i];
                }
            }

            return null;
        }
    }

    [XmlIgnore()]
    public DetalhamentoISSQN ISSQN
    {
        get
        {
            // Return _icms
            for (int i = 0, loopTo = EstaduaisMunicipais.Count - 1; i <= loopTo; i++)
            {
                if (EstaduaisMunicipais[i] is DetalhamentoISSQN)
                {
                    return (DetalhamentoISSQN)EstaduaisMunicipais[i];
                }
            }

            return null;
        }
    }

    /// <summary>
    /// Imposto de Importação
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    public DetalhamentoII II
    {
        get
        {
            // Return _icms
            for (int i = 0, loopTo = EstaduaisMunicipais.Count - 1; i <= loopTo; i++)
            {
                if (EstaduaisMunicipais[i] is DetalhamentoII)
                {
                    return (DetalhamentoII)EstaduaisMunicipais[i];
                }
            }

            return null;
        }
    }

    /// <summary>
    /// Grupo de informações do Imposto Seletivo
    /// </summary>
    public DFeBase.TIS IS
    {
        get => isField;
        set
        {
            if (isField is null || isField.Equals(value) != true)
            {
                isField = value;
                OnPropertyChanged(nameof(IS));
            }
        }
    }

    /// <summary>
    /// Grupo de informações dos tributos IBS, CBS e Imposto Seletivo
    /// </summary>
    public DFeBase.TTribNFe IBSCBS
    {
        get => ibsCbsField;
        set
        {
            if (ibsCbsField is null || ibsCbsField.Equals(value) != true)
            {
                ibsCbsField = value;
                OnPropertyChanged(nameof(IBSCBS));
            }
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TributacaoDevolucao : System.ComponentModel.INotifyPropertyChanged
{

    #region Constructor

    public TributacaoDevolucao() : base()
    {
    }

    #endregion

    #region Fields

    private double? pDevolField;
    private DetalhamentoIPI ipiField;

    #endregion

    #region Properties

    [XmlElement("pDevol")]
    public double? pDevol
    {
        get => pDevolField; set
        {
            if (pDevolField is null || pDevolField.Equals(value) != true)
            {
                pDevolField = value;
                OnPropertyChanged(nameof(pDevol));
            }
        }
    }

    public bool ShouldSerializepDevol() => pDevolField.HasValue;

    public DetalhamentoIPI IPI
    {
        get => ipiField; set
        {
            if (ipiField is null || ipiField.Equals(value) != true)
            {
                ipiField = value;
                OnPropertyChanged(nameof(IPI));
            }
        }
    }

    #endregion

    #region Events

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Handlers

    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler is not null)
        {
            handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion

}

public partial class DetalhamentoICMS : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private DetalhamentoICMS_Tributacao itemField;
    private Tributacao_ICMS_Identifier itemElementNameField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */

    [XmlElement("ICMS00", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS02", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS10", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS15", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS20", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS30", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS40", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS51", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS53", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS60", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS61", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS70", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMS90", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSSN101", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSSN102", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSSN201", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSSN202", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSSN500", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSSN900", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSPart", typeof(DetalhamentoICMS_Tributacao))]
    [XmlElement("ICMSST", typeof(DetalhamentoICMS_Tributacao))]
    [XmlChoiceIdentifier("TributacaoIndentifier")]
    public DetalhamentoICMS_Tributacao Tributacao
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Tributacao));
            }
        }
    }

    [XmlIgnore()]
    public Tributacao_ICMS_Identifier TributacaoIndentifier
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TributacaoIndentifier));
            }
        }
    }

    [XmlIgnore()]
    public bool isST
    {
        get
        {
            if (Tributacao is null)
            {
                return false;
            }

            if ((int)TributacaoIndentifier <= 8)
            {
                if (Tributacao.CST == CST_ICMS.CST_10 | (int)Tributacao.CST == 30 | Tributacao.CST == CST_ICMS.CST_70)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((int)TributacaoIndentifier >= 10 & (int)TributacaoIndentifier <= 15)
            {
                if (Tributacao.CSOSN == CSOSN_ICMS.CST201 | Tributacao.CSOSN == CSOSN_ICMS.CST202 | Tributacao.CSOSN == CSOSN_ICMS.CST203)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (TributacaoIndentifier == Tributacao_ICMS_Identifier.ICMSST)
            {
                return true;
            }
            else
            {
                return false;
            }
            // Select Case Tributacao.GetType()
            // Case GetType(ICMS_CST_10), GetType(ICMS_CST_70)
            // Return True

            // Case Else
            // Return False
            // End Select
        }
    }

    public string CST_Formatado
    {
        get
        {
            if (Tributacao != null)
            {
                try
                {
                    if ((int)TributacaoIndentifier <= 12)
                    {
                        return (int)Tributacao.Origem + string.Format("{0:#00}", Tributacao.CSTFinal);
                    }
                    else if ((int)TributacaoIndentifier >= 14 & (int)TributacaoIndentifier <= 19)
                    {
                        return (int)Tributacao.Origem + string.Format("{0:#000}", Tributacao.CSTFinal);
                    }
                    else if (TributacaoIndentifier == Tributacao_ICMS_Identifier.ICMSST)
                    {
                        return (int)Tributacao.Origem + string.Format("{0:#00}", Tributacao.CSTFinal);
                    }
                    else
                    {
                        try
                        {
                            return (int)Tributacao.Origem + string.Format("{0:#00}", Tributacao.CSTFinal);
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// <summary>
/// Clase genérica para tratamento das tributações de ICMS.
/// </summary>
public partial class DetalhamentoICMS_Tributacao : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private OrigemMercadoria origField;
    private CST_ICMS cSTField = CST_ICMS.CST_NA;
    private CSOSN_ICMS cSOSNField = CSOSN_ICMS.CSTNA;
    private double? vBCField;
    private double? pICMSField;
    private double? vICMSField;


    private DetalhamentoICMS_CST00_ModBC modBCField00;
    private DetalhamentoICMS_CST10_ModBC modBCField10;
    private DetalhamentoICMS_CST10_ModBCST modBCSTField10;
    private DetalhamentoICMS_CST20_ModBC modBCField20;
    private DetalhamentoICMS_CST30_ModBCST modBCSTField30;
    private DetalhamentoICMS_CST51_ModBC? modBCField51;
    private double? vBCSTRetField;
    private double? pSTField;
    private double? vICMSSTRetField;
    private DetalhamentoICMS_CST70_ModBC modBCField70;
    private DetalhamentoICMS_CST70_ModBCST modBCSTField70;
    private DetalhamentoICMS_CST90_ModBC modBCField90;
    private DetalhamentoICMS_CST90_ModBCST modBCSTField90;
    private double? pMVASTField;
    private double? pRedBCSTField;
    private double? vBCSTField;
    private double? pICMSSTField;
    private double? vICMSSTField;
    // ##FCP
    private double? vBCFCPSTField;
    private double? pFCPSTField;
    private double? vFCPSTField;

    private double? pRedBCField;
    private DetalhamentoICMS_CST40_MotivoDesoneracao motDesICMSField;
    private double? pvICMSDeson;
    private double? pCredSNField;
    private double? vCredICMSSNField;
    private DetalhamentoICMSSN_CSOSN201_ModBCST modBCSTField201;
    private DetalhamentoICMSSN_CSOSN202_ModBCST modBCSTField202;
    private DetalhamentoICMSSN_CSOSN900_ModBC modBCField900;
    private DetalhamentoICMSSN_CSOSN900_ModBCST modBCSTField900;
    private DetalhamentoICMS_Part_ModBC modBCFieldPart;
    private DetalhamentoICMS_Part_ModBCST modBCSTFieldPart;
    private Estado uFSTField;
    private double? pBCOpField;
    private double? vBCSTDestField;
    private double? vICMSSTDestField;
    private double? vBCEfetField;
    private double? pICMSEfetField;
    private double? vICMSEfetField;
    private int? modBCField;
    private int? modBCSTField;

    // NT 2023.001 ICMS Monofásico para Combustíveis
    private double? qBCMonoRet_OpcField;
    private double? adRemICMSRetField;
    private double? vICMSMonoRetField;


    [XmlElement("orig")]
    public OrigemMercadoria Origem
    {
        get => origField;
        set
        {
            if (origField.Equals(value) != true)
            {
                origField = value;
                OnPropertyChanged(nameof(Origem));
            }
        }
    }

    public CST_ICMS CST
    {
        get => cSTField;
        set
        {
            if (cSTField.Equals(value) != true)
            {
                cSTField = value;
                OnPropertyChanged("CSTNormal");
            }
        }
    }

    public bool ShouldSerializeCST() => CST != CST_ICMS.CST_NA;

    public CSOSN_ICMS CSOSN
    {
        get => cSOSNField;
        set
        {
            if (cSOSNField.Equals(value) != true)
            {
                cSOSNField = value;
                OnPropertyChanged(nameof(CSOSN));
            }
        }
    }

    public bool ShouldSerializeCSOSN() => CSOSN != CSOSN_ICMS.CSTNA;

    public int CSTFinal
    {
        get
        {
            if (CST != CST_ICMS.CST_NA)
            {
                return (int)CST;
            }
            else if (CSOSN != CSOSN_ICMS.CSTNA)
            {
                return (int)CSOSN;
            }
            else
            {
                return 0;
            }
        }
    }

    [XmlIgnore()]
    public double? vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vBC' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vBC")]
    public string vBC_XML
    {
        get
        {
            if (vBC.HasValue == true)
            {
                return string.Format("{0:0.00}", vBC).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vBCField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vBCField = default;
                    }
                }
                else
                {
                    vBCField = default;
                }

                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public bool ShouldSerializevBC_XML() => vBCField.HasValue & CST != CST_ICMS.CST_30 & CST != CST_ICMS.CST_40 & CST != CST_ICMS.CST_41 & CST != CST_ICMS.CST_50 & CST != CST_ICMS.CST_60 & (CSOSN == CSOSN_ICMS.CSTNA | CSOSN == CSOSN_ICMS.CST900);

    public double? pICMS
    {
        get => pICMSField;
        set
        {
            if (pICMSField is null || pICMSField.Equals(value) != true)
            {
                pICMSField = value;
                OnPropertyChanged(nameof(pICMS));
            }
        }
    }

    public bool ShouldSerializepICMS() => pICMSField.HasValue & CST != CST_ICMS.CST_30 & CST != CST_ICMS.CST_40 & CST != CST_ICMS.CST_41 & CST != CST_ICMS.CST_50 & CST != CST_ICMS.CST_60 & (CSOSN == CSOSN_ICMS.CSTNA | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public double? vICMS
    {
        get => vICMSField;
        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                vICMSField = value;
                OnPropertyChanged(nameof(vICMS));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vICMS' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vICMS")]
    public string vICMS_XML
    {
        get
        {
            if (vICMS.HasValue == true)
            {
                return string.Format("{0:0.00}", vICMS).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vICMSField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vICMSField = default;
                    }
                }
                else
                {
                    vICMSField = default;
                }

                OnPropertyChanged(nameof(vICMS));
            }
        }
    }

    public bool ShouldSerializevICMS_XML() => vICMSField.HasValue & CST != CST_ICMS.CST_30 & CST != CST_ICMS.CST_60 & (CSOSN == CSOSN_ICMS.CSTNA | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public DetalhamentoICMS_CST00_ModBC modBC00
    {
        get => modBCField00;
        set
        {
            if (modBCField00.Equals(value) != true)
            {
                modBCField00 = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBC00));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST10_ModBC modBC10
    {
        get => modBCField10;
        set
        {
            if (modBCField10.Equals(value) != true)
            {
                modBCField10 = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBC10));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST10_ModBCST modBCST10
    {
        get => modBCSTField10;
        set
        {
            if (modBCSTField10.Equals(value) != true)
            {
                modBCSTField10 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST10));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST20_ModBC modBC20
    {
        get => modBCField20;
        set
        {
            if (modBCField20.Equals(value) != true)
            {
                modBCField20 = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBC20));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST30_ModBCST modBCST30
    {
        get => modBCSTField30;
        set
        {
            if (modBCSTField30.Equals(value) != true)
            {
                modBCSTField30 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST30));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST51_ModBC modBC51
    {
        get
        {
            if (modBCField51.HasValue)
            {
                return modBCField51.Value;
            }
            else
            {
                return DetalhamentoICMS_CST51_ModBC.ValorOperacao;
            }
        }
        set
        {
            if (modBCField51.Equals(value) != true)
            {
                modBCField51 = value;
                OnPropertyChanged(nameof(modBC51));
            }
        }
    }

    [XmlIgnore()]
    public double? vBCSTRet
    {
        get => vBCSTRetField;
        set
        {
            if (vBCSTRetField is null || vBCSTRetField.Equals(value) != true)
            {
                vBCSTRetField = value;
                OnPropertyChanged(nameof(vBCSTRet));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vBCSTRet' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vBCSTRet")]
    public string vBCSTRet_XML
    {
        get
        {
            if (vBCSTRet.HasValue == true)
            {
                return string.Format("{0:0.00}", vBCSTRet).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vBCSTRetField is null || vBCSTRetField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vBCSTRetField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vBCSTRetField = default;
                    }
                }
                else
                {
                    vBCSTRetField = default;
                }

                OnPropertyChanged(nameof(vBCSTRet));
            }
        }
    }

    public bool ShouldSerializevBCSTRet_XML() => vBCSTRet.HasValue & (CST == CST_ICMS.CST_60 | CSOSN == CSOSN_ICMS.CST500);


    [XmlIgnore()]
    public double? pST
    {
        get => pSTField;
        set
        {
            if (pSTField is null || pSTField.Equals(value) != true)
            {
                pSTField = value;
                OnPropertyChanged(nameof(pST));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'pST' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("pST")]
    public string pST_XML
    {
        get
        {
            if (pST.HasValue == true)
            {
                return string.Format("{0:0.00}", pST).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (pSTField is null || pSTField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        pSTField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        pSTField = default;
                    }
                }
                else
                {
                    pSTField = default;
                }

                OnPropertyChanged(nameof(pST));
            }
        }
    }

    public bool ShouldSerializepST_XML() => pST.HasValue & (CST == CST_ICMS.CST_60 | CSOSN == CSOSN_ICMS.CST500);



    [XmlIgnore()]
    public double? vICMSSTRet
    {
        get => vICMSSTRetField;
        set
        {
            if (vICMSSTRetField is null || vICMSSTRetField.Equals(value) != true)
            {
                vICMSSTRetField = value;
                OnPropertyChanged(nameof(vICMSSTRet));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vICMSSTRet' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vICMSSTRet")]
    public string vICMSSTRet_XML
    {
        get
        {
            if (vICMSSTRet.HasValue == true)
            {
                return string.Format("{0:0.00}", vICMSSTRet).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vICMSSTRetField is null || vICMSSTRetField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vICMSSTRetField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vICMSSTRetField = default;
                    }
                }
                else
                {
                    vICMSSTRetField = default;
                }

                OnPropertyChanged(nameof(vICMSSTRet));
            }
        }
    }

    public bool ShouldSerializevICMSSTRet_XML() => vICMSSTRet.HasValue & (CST == CST_ICMS.CST_60 | CSOSN == CSOSN_ICMS.CST500);

    [XmlIgnore()]
    public DetalhamentoICMS_CST70_ModBC modBC70
    {
        get => modBCField70;
        set
        {
            if (modBCField70.Equals(value) != true)
            {
                modBCField70 = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBC70));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST70_ModBCST modBCST70
    {
        get => modBCSTField70;
        set
        {
            if (modBCSTField70.Equals(value) != true)
            {
                modBCSTField70 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST70));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST90_ModBC modBC90
    {
        get => modBCField90;
        set
        {
            if (modBCField90.Equals(value) != true)
            {
                modBCField90 = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBC90));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_CST90_ModBCST modBCST90
    {
        get => modBCSTField90;
        set
        {
            if (modBCSTField90.Equals(value) != true)
            {
                modBCSTField90 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST90));
            }
        }
    }

    public double? pMVAST
    {
        get => pMVASTField;
        set
        {
            if (pMVASTField is null || pMVASTField.Equals(value) != true)
            {
                pMVASTField = value;
                OnPropertyChanged(nameof(pMVAST));
            }
        }
    }

    public bool ShouldSerializepMVAST() => pMVAST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    public double? pRedBCST
    {
        get => pRedBCSTField;
        set
        {
            if (pRedBCSTField is null || pRedBCSTField.Equals(value) != true)
            {
                pRedBCSTField = value;
                OnPropertyChanged(nameof(pRedBCST));
            }
        }
    }

    public bool ShouldSerializepRedBCST() => pRedBCST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public double? vBCST
    {
        get => vBCSTField;
        set
        {
            if (vBCSTField is null || vBCSTField.Equals(value) != true)
            {
                vBCSTField = value;
                OnPropertyChanged(nameof(vBCST));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vBCST' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vBCST")]
    public string vBCST_XML
    {
        get
        {
            if (vBCST.HasValue == true)
            {
                return string.Format("{0:0.00}", vBCST).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vBCSTField is null || vBCSTField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vBCSTField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vBCSTField = default;
                    }
                }
                else
                {
                    vBCSTField = default;
                }

                OnPropertyChanged(nameof(vBCST));
            }
        }
    }

    public bool ShouldSerializevBCST_XML() => vBCST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    public double? pICMSST
    {
        get => pICMSSTField;
        set
        {
            if (pICMSSTField is null || pICMSSTField.Equals(value) != true)
            {
                pICMSSTField = value;
                OnPropertyChanged(nameof(pICMSST));
            }
        }
    }

    public bool ShouldSerializepICMSST() => pICMSST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public double? vICMSST
    {
        get => vICMSSTField;
        set
        {
            if (vICMSSTField is null || vICMSSTField.Equals(value) != true)
            {
                vICMSSTField = value;
                OnPropertyChanged(nameof(vICMSST));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vICMSST")]
    public string vICMSST_XML
    {
        get
        {
            if (vICMSST.HasValue == true)
            {
                return string.Format("{0:0.00}", vICMSST).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vICMSSTField is null || vICMSSTField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vICMSSTField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vICMSSTField = default;
                    }
                }
                else
                {
                    vICMSSTField = default;
                }

                OnPropertyChanged(nameof(vICMSST));
            }
        }
    }

    public bool ShouldSerializevICMSST_XML() => vICMSST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    // ## FCP da ST

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vBCFCPST' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vBCFCPST")]
    public string vBCFCPST_XML
    {
        get
        {
            if (vBCFCPST.HasValue == true)
            {
                return string.Format("{0:0.00}", vBCFCPST).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vBCFCPSTField is null || vBCFCPSTField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vBCFCPSTField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vBCFCPSTField = default;
                    }
                }
                else
                {
                    vBCFCPSTField = default;
                }

                OnPropertyChanged(nameof(vBCFCPST));
            }
        }
    }

    public bool ShouldSerializevBCFCPST_XML() => vBCFCPST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public double? vBCFCPST
    {
        get => vBCFCPSTField;
        set
        {
            if (vBCFCPSTField is null || vBCFCPSTField.Equals(value) != true)
            {
                vBCFCPSTField = value;
                OnPropertyChanged(nameof(vBCFCPST));
            }
        }
    }

    public double? pFCPST
    {
        get => pFCPSTField;
        set
        {
            if (pFCPSTField is null || pFCPSTField.Equals(value) != true)
            {
                pFCPSTField = value;
                OnPropertyChanged(nameof(pFCPST));
            }
        }
    }

    public bool ShouldSerializepFCPST() => pICMSST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public double? vFCPST
    {
        get => vFCPSTField;
        set
        {
            if (vFCPSTField is null || vFCPSTField.Equals(value) != true)
            {
                vFCPSTField = value;
                OnPropertyChanged(nameof(vFCPST));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vFCPST' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vFCPST")]
    public string vFCPST_XML
    {
        get
        {
            if (vFCPST.HasValue == true)
            {
                return string.Format("{0:0.00}", vFCPST).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vFCPSTField is null || vFCPSTField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vFCPSTField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vFCPSTField = default;
                    }
                }
                else
                {
                    vFCPSTField = default;
                }

                OnPropertyChanged(nameof(vFCPST));
            }
        }
    }

    public bool ShouldSerializevFCPST_XML() => vFCPST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);

    public double? pRedBC
    {
        get => pRedBCField;
        set
        {
            if (pRedBCField is null || pRedBCField.Equals(value) != true)
            {
                pRedBCField = value;
                OnPropertyChanged(nameof(pRedBC));
            }
        }
    }

    public bool ShouldSerializepRedBC() => pRedBC.HasValue == true & (CST == CST_ICMS.CST_20 | CST == CST_ICMS.CST_51 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST900);

    public DetalhamentoICMS_CST40_MotivoDesoneracao motDesICMS
    {
        get => motDesICMSField;
        set
        {
            if (motDesICMSField.Equals(value) != true)
            {
                motDesICMSField = value;
                OnPropertyChanged(nameof(motDesICMS));
            }
        }
    }

    public bool ShouldSerializemotDesICMS() => CST == CST_ICMS.CST_40 | CST == CST_ICMS.CST_41 | CST == CST_ICMS.CST_50;

    public double? vICMSDeson
    {
        get => pvICMSDeson;
        set
        {
            if (pvICMSDeson is null || pvICMSDeson.Equals(value) != true)
            {
                pvICMSDeson = value;
                OnPropertyChanged(nameof(vICMSDeson));
            }
        }
    }

    public bool ShouldSerializevICMSDeson() => pvICMSDeson.HasValue & (CST == CST_ICMS.CST_40 | CST == CST_ICMS.CST_41 | CST == CST_ICMS.CST_50);

    public double? pCredSN
    {
        get => pCredSNField;
        set
        {
            if (pCredSNField is null || pCredSNField.Equals(value) != true)
            {
                pCredSNField = value;
                OnPropertyChanged(nameof(pCredSN));
            }
        }
    }

    public bool ShouldSerializepCredSN() => pCredSN.HasValue && (CSOSN == CSOSN_ICMS.CST101 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST900);

    public double? vCredICMSSN
    {
        get => vCredICMSSNField;
        set
        {
            if (vCredICMSSNField is null || vCredICMSSNField.Equals(value) != true)
            {
                vCredICMSSNField = value;
                OnPropertyChanged(nameof(vCredICMSSN));
            }
        }
    }

    public bool ShouldSerializevCredICMSSN() => vCredICMSSN.HasValue && (CSOSN == CSOSN_ICMS.CST101 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST900);

    [XmlAttribute("vCredICMSSN")]
    public string vCredICMSSN_XML
    {
        get
        {
            if (vCredICMSSN.HasValue == true)
            {
                return string.Format("{0:0.00}", vCredICMSSN).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vCredICMSSNField is null || vCredICMSSNField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vCredICMSSNField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vCredICMSSNField = default;
                    }
                }
                else
                {
                    vCredICMSSNField = default;
                }

                OnPropertyChanged(nameof(vCredICMSSN));
            }
        }
    }

    public bool ShouldSerializevCredICMSSN_XML() => vCredICMSSN.HasValue && (CSOSN == CSOSN_ICMS.CST101 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST900);

    [XmlIgnore()]
    public DetalhamentoICMSSN_CSOSN201_ModBCST modBCST201
    {
        get => modBCSTField201;
        set
        {
            if (modBCSTField201.Equals(value) != true)
            {
                modBCSTField201 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST201));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMSSN_CSOSN202_ModBCST modBCST202
    {
        get => modBCSTField202;
        set
        {
            if (modBCSTField202.Equals(value) != true)
            {
                modBCSTField202 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST202));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMSSN_CSOSN900_ModBC modBC900
    {
        get => modBCField900;
        set
        {
            if (modBCField900.Equals(value) != true)
            {
                modBCField900 = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBC900));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMSSN_CSOSN900_ModBCST modBCST900
    {
        get => modBCSTField900;
        set
        {
            if (modBCSTField900.Equals(value) != true)
            {
                modBCSTField900 = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST900));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_Part_ModBC modBCPart
    {
        get => (DetalhamentoICMS_Part_ModBC)modBCField;
        set
        {
            if (modBCField.Equals(value) != true)
            {
                modBCFieldPart = value;
                modBCField = (int?)value;
                OnPropertyChanged(nameof(modBCPart));
            }
        }
    }

    [XmlIgnore()]
    public DetalhamentoICMS_Part_ModBCST modBCSTPart
    {
        get => (DetalhamentoICMS_Part_ModBCST)modBCSTField;
        set
        {
            if (modBCSTField.Equals(value) != true)
            {
                modBCSTFieldPart = value;
                modBCSTField = (int?)value;
                OnPropertyChanged(nameof(modBCST));
            }
        }
    }

    public Estado UFST
    {
        get => uFSTField;
        set
        {
            if (uFSTField.Equals(value) != true)
            {
                uFSTField = value;
                OnPropertyChanged(nameof(UFST));
            }
        }
    }

    public bool ShouldSerializeUFST() => pBCOpField.HasValue == true;

    public double? pBCOp
    {
        get => pBCOpField;
        set
        {
            if (pBCOpField is null || pBCOpField.Equals(value) != true)
            {
                pBCOpField = value;
                OnPropertyChanged(nameof(pBCOp));
            }
        }
    }

    public bool ShouldSerializepBCOp() => pBCOpField.HasValue == true;

    [XmlIgnore()]
    public double? vBCSTDest
    {
        get => vBCSTDestField;
        set
        {
            if (vBCSTDestField is null || vBCSTDestField.Equals(value) != true)
            {
                vBCSTDestField = value;
                OnPropertyChanged(nameof(vBCSTDest));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vBCSTDest' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vBCSTDest")]
    public string vBCSTDest_XML
    {
        get
        {
            if (vBCSTDestField.HasValue == true)
            {
                return string.Format("{0:0.00}", vBCSTDestField).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vBCSTDestField is null || vBCSTDestField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vBCSTDestField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vBCSTDestField = default;
                    }
                }
                else
                {
                    vBCSTDestField = default;
                }

                OnPropertyChanged(nameof(vBCSTDest));
            }
        }
    }

    public bool ShouldSerializevBCSTDest_XML() => vBCSTDest.HasValue == true;

    [XmlIgnore()]
    public double? vICMSSTDest
    {
        get => vICMSSTDestField;
        set
        {
            if (vICMSSTDestField is null || vICMSSTDestField.Equals(value) != true)
            {
                vICMSSTDestField = value;
                OnPropertyChanged(nameof(vICMSSTDest));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'vICMSST' (Double?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vICMSSTDest")]
    public string vICMSSTDest_XML
    {
        get
        {
            if (vICMSSTDest.HasValue == true)
            {
                return string.Format("{0:0.00}", vICMSSTDest).Replace(",", ".");
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (vICMSSTDestField is null || vICMSSTDestField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains(".") & !value.Contains(","))
                            value = value + "00"; // fix for 0 decimal values
                        vICMSSTDestField = Convert.ToDouble(value) / 100d;
                    }
                    else
                    {
                        vICMSSTDestField = default;
                    }
                }
                else
                {
                    vICMSSTDestField = default;
                }

                OnPropertyChanged(nameof(vICMSSTDest));
            }
        }
    }

    public bool ShouldSerializevICMSSTDest_XML() => vICMSSTDest.HasValue == true;

    [XmlElement("vBCEfet")]
    public double? vBCEfet
    {
        get => vBCEfetField;
        set
        {
            if (vBCEfetField is null || vBCEfetField.Equals(value) != true)
            {
                vBCEfetField = value;
                OnPropertyChanged(nameof(vBCEfet));
            }
        }
    }

    public bool ShouldSerializevBCEfet() => vBCEfetField.HasValue;

    public double? pICMSEfet
    {
        get => pICMSEfetField;
        set
        {
            if (pICMSEfetField is null || pICMSEfetField.Equals(value) != true)
            {
                pICMSEfetField = value;
                OnPropertyChanged(nameof(pICMSEfet));
            }
        }
    }

    public bool ShouldSerializepICMSEfet() => pICMSEfetField.HasValue;

    public double? vICMSEfet
    {
        get => vICMSEfetField;
        set
        {
            if (vICMSEfetField is null || vICMSEfetField.Equals(value) != true)
            {
                vICMSEfetField = value;
                OnPropertyChanged("vIvICMSEfetCMS");
            }
        }
    }

    public bool ShouldSerializevICMSEfet() => vICMSEfetField.HasValue;


    /// <summary>
    /// Propriedade genérica apenas para compatibilidade com Parser XML.
    /// Para correto funcionamento, utilizar as propriedades modBCXXXX.
    /// A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public int? modBC
    {
        get => modBCField;
        set
        {
            if (modBCField.Equals(value) != true)
            {
                modBCField = value;
                OnPropertyChanged(nameof(modBC));
            }
        }
    }

    [XmlIgnore()]
    public bool modBCSpecified
    {
        get => modBCField.HasValue;
        set
        {
            if (value == false)
            {
                modBCField = default;
            }
        }
    }

    public bool ShouldSerializemodBC() => modBCField.HasValue;

    /// <summary>
    /// Propriedade genérica apenas para compatibilidade com Parser XML.
    /// Para correto funcionamento, utilizar as propriedades modBCXXXX.
    /// A sincronização das demais para com esta, no ato da escrita do arquivo XML deve ser feita manualmente.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public int? modBCST
    {
        get => modBCSTField;
        set
        {
            if (modBCSTField.Equals(value) != true)
            {
                modBCSTField = value;
                OnPropertyChanged(nameof(modBCST));
            }
        }
    }

    [XmlIgnore()]
    public bool modBCSTSpecified
    {
        get => modBCSTField.HasValue;
        set
        {
            if (value == false)
            {
                modBCSTField = default;
            }
        }
    }

    public bool ShouldSerializemodBCST() => modBCSTField.HasValue;


    // NT 2023.001 ICMS Monofásico para Combustíveis
    public double? qBCMonoRet
    {
        get => qBCMonoRet_OpcField;
        set
        {
            if (qBCMonoRet_OpcField is null || qBCMonoRet_OpcField.Equals(value) != true)
            {
                qBCMonoRet_OpcField = value;
                OnPropertyChanged("qBCMonoRet_Opc");
            }
        }
    }
    public bool ShouldSerializeqBCMonoRet() => qBCMonoRet_OpcField.HasValue;


    public double? adRemICMSRet
    {
        get => adRemICMSRetField;
        set
        {
            if (adRemICMSRetField is null || adRemICMSRetField.Equals(value) != true)
            {
                adRemICMSRetField = value;
                OnPropertyChanged("adRemICMSRet");
            }
        }
    }
    public bool ShouldSerializeadRemICMSRet() => adRemICMSRetField.HasValue;


    public double? vICMSMonoRet
    {
        get => vICMSMonoRetField;
        set
        {
            if (vICMSMonoRetField is null || vICMSMonoRetField.Equals(value) != true)
            {
                vICMSMonoRetField = value;
                OnPropertyChanged("vICMSMonoRet");
            }
        }
    }
    public bool ShouldSerializevICMSMonoRet() => vICMSMonoRetField.HasValue;



    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

}

/// <summary>
/// Campos referente EC 87/2015
/// </summary>
public partial class DetalhamentoICMS_UF_Destinataria : INotifyPropertyChanged
{
    private double? vBCUFDestField;
    private double? pFCPUFDestField;
    private double? pICMSUFDestField;
    private double? pICMSInterField;
    private double? pICMSInterPartField;
    private double? vFCPUFDestField;
    private double? vICMSUFDestField;
    private double? vICMSUFRemField;


    [XmlElement("vBCUFDest")]
    public double? BaseCalculoUFDestino
    {
        get => vBCUFDestField;
        set
        {
            if (vBCUFDestField is null || vBCUFDestField.Equals(value) != true)
            {
                vBCUFDestField = value;
                OnPropertyChanged(nameof(BaseCalculoUFDestino));
            }
        }
    }

    [XmlElement("pFCPUFDest")]
    public double? PercentualICMS_FCP
    {
        get => pFCPUFDestField;
        set
        {
            if (pFCPUFDestField is null || pFCPUFDestField.Equals(value) != true)
            {
                pFCPUFDestField = value;
                OnPropertyChanged(nameof(PercentualICMS_FCP));
            }
        }
    }

    [XmlElement("pICMSUFDest")]
    public double? PercentualICMS_UFDestino
    {
        get => pICMSUFDestField;
        set
        {
            if (pICMSUFDestField is null || pICMSUFDestField.Equals(value) != true)
            {
                pICMSUFDestField = value;
                OnPropertyChanged(nameof(PercentualICMS_UFDestino));
            }
        }
    }

    [XmlElement("pICMSInter")]
    public double? PercentualICMS_Interno
    {
        get => pICMSInterField;
        set
        {
            if (pICMSInterField is null || pICMSInterField.Equals(value) != true)
            {
                pICMSInterField = value;
                OnPropertyChanged(nameof(PercentualICMS_Interno));
            }
        }
    }

    [XmlElement("pICMSInterPart")]
    public double? PercentualICMS_InternoPartilha
    {
        get => pICMSInterPartField;
        set
        {
            if (pICMSInterPartField is null || pICMSInterPartField.Equals(value) != true)
            {
                pICMSInterPartField = value;
                OnPropertyChanged(nameof(PercentualICMS_InternoPartilha));
            }
        }
    }

    [XmlElement("vFCPUFDest")]
    public double? ValorICMS_FCP
    {
        get => vFCPUFDestField;
        set
        {
            if (vFCPUFDestField is null || vFCPUFDestField.Equals(value) != true)
            {
                vFCPUFDestField = value;
                OnPropertyChanged(nameof(ValorICMS_FCP));
            }
        }
    }

    [XmlElement("vICMSUFDest")]
    public double? ValorICMS_UFDestinataria
    {
        get => vICMSUFDestField;
        set
        {
            if (vICMSUFDestField is null || vICMSUFDestField.Equals(value) != true)
            {
                vICMSUFDestField = value;
                OnPropertyChanged(nameof(ValorICMS_UFDestinataria));
            }
        }
    }

    [XmlElement("vICMSUFRemet")]
    public double? ValorICMS_UFRemetente
    {
        get => vICMSUFRemField;
        set
        {
            if (vICMSUFRemField is null || vICMSUFRemField.Equals(value) != true)
            {
                vICMSUFRemField = value;
                OnPropertyChanged(nameof(ValorICMS_UFRemetente));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}


public partial class DetalhamentoIPI : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private string clEnqField;
    private string cNPJProdField;
    private string cSeloField;
    private int? qSeloField;
    private string cEnqField;
    private DetalhamentoIPI_Tributacao itemField;
    private Tributacao_IPI_Identifier itemElementNameField;
    private double? vIPIDevolField;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("clEnq")]
    public string Classe
    {
        get => clEnqField;
        set
        {
            if (clEnqField is null || clEnqField.Equals(value) != true)
            {
                clEnqField = value;
                OnPropertyChanged(nameof(Classe));
            }
        }
    }

    /// <summary>
    /// CNPJ do produtor da mercadoria, quando diferente do emitente.
    /// Somente para os casos de exportação direta ou indireta.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("CNPJProd")]
    public string CNPJProdutor
    {
        get => cNPJProdField;
        set
        {
            if (cNPJProdField is null || cNPJProdField.Equals(value) != true)
            {
                cNPJProdField = value;
                OnPropertyChanged(nameof(CNPJProdutor));
            }
        }
    }

    [XmlElement("cSelo")]
    public string SeloControle
    {
        get => cSeloField;
        set
        {
            if (cSeloField is null || cSeloField.Equals(value) != true)
            {
                cSeloField = value;
                OnPropertyChanged(nameof(SeloControle));
            }
        }
    }

    [XmlElement("qSelo")]
    public int? SeloQuantidade
    {
        get => qSeloField;
        set
        {
            if (qSeloField is null || qSeloField.Equals(value) != true)
            {
                qSeloField = value;
                OnPropertyChanged("qSelo");
            }
        }
    }

    public bool ShouldSerializeSeloQuantidade() => qSeloField.HasValue;

    [XmlElement("cEnq")]
    public string CodigoEnquadramento
    {
        get => cEnqField;
        set
        {
            if (cEnqField is null || cEnqField.Equals(value) != true)
            {
                cEnqField = value;
                OnPropertyChanged(nameof(CodigoEnquadramento));
            }
        }
    }

    [XmlElement("IPINT", typeof(DetalhamentoIPI_Tributacao))]
    [XmlElement("IPITrib", typeof(DetalhamentoIPI_Tributacao))]
    [XmlChoiceIdentifier("TributacaoIndentifier")]
    public DetalhamentoIPI_Tributacao Tributacao
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlIgnore()]
    public Tributacao_IPI_Identifier TributacaoIndentifier
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TributacaoIndentifier));
            }
        }
    }

    [XmlElement("vIPIDevol")]
    public double? vIPIDevol
    {
        get => vIPIDevolField;
        set
        {
            if (vIPIDevolField is null || vIPIDevolField.Equals(value) != true)
            {
                vIPIDevolField = value;
                OnPropertyChanged(nameof(vIPIDevol));
            }
        }
    }

    public bool ShouldSerializevIPIDevol() => vIPIDevolField.HasValue;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoIPI_Tributacao : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public DetalhamentoIPI_Tributacao() : base()
    {
        // Me.itemsElementNameField = New List(Of DetalhamentoIPI_Tributado_ModoCalculo)()
        // Me.itemsField = New List(Of Double)()
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private CST_IPI cSTField;
    // Private itemsField As List(Of Double)
    // Private itemsElementNameField As List(Of DetalhamentoIPI_Tributado_ModoCalculo)
    private double? vIPIField;
    private double? _pIPI;
    private double? _qUnid;
    private double? _vBC;
    private double? _vUnid;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Valores válidos: 00, 49, 50 e 99
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public CST_IPI CST
    {
        get => cSTField;
        set
        {
            if (cSTField.Equals(value) != true)
            {
                cSTField = value;
                OnPropertyChanged(nameof(CST));
            }
        }
    }

    // // AUTO GENERATED AND NOT WORKED... Will be mapped manually:

    // <System.Xml.Serialization.XmlElementAttribute("pIPI", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("qUnid", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("vBC", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("vUnid", GetType(Double)), _
    // System.Xml.Serialization.XmlChoiceIdentifierAttribute("CamposIPI_PorAliquota")> _
    // Public Property CamposPorAliquota() As List(Of Double)
    // Get
    // Return Me.itemsField
    // End Get
    // Set(value As List(Of Double))
    // If ((Me.itemsField Is Nothing) _
    // OrElse (itemsField.Equals(value) <> True)) Then
    // Me.itemsField = value
    // Me.OnPropertyChanged("CamposPorAliquota")
    // End If
    // End Set
    // End Property

    // <System.Xml.Serialization.XmlIgnoreAttribute()>
    // Public Property CamposIPI_PorAliquota() As DetalhamentoIPI_Tributado_ModoCalculo() 'List(Of DetalhamentoIPITributadoModoCalculo)
    // Get
    // Return Me.itemsElementNameField.ToArray
    // End Get
    // Set(value As DetalhamentoIPI_Tributado_ModoCalculo())
    // Me.itemsElementNameField = value.ToList
    // Me.OnPropertyChanged("CamposIPI_PorAliquota")
    // End Set
    // End Property

    // // Fixed Values:

    /// <summary>
    /// Informar apenas para IPI calculado por alíquota.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("pIPI")]
    public double? Aliquota
    {
        get => _pIPI;
        set
        {
            if (_pIPI is null || _pIPI.Equals(value) != true)
            {
                _pIPI = value;
                OnPropertyChanged(nameof(Aliquota));
            }
        }
    }

    public bool ShouldSerializeAliquota() => Aliquota.HasValue;

    /// <summary>
    /// Informar apenas para IPI calculado por unidade.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("qUnid")]
    public double? Quantidade
    {
        get => _qUnid;
        set
        {
            if (_qUnid is null || _qUnid.Equals(value) != true)
            {
                _qUnid = value;
                OnPropertyChanged(nameof(Quantidade));
            }
        }
    }

    public bool ShouldSerializeQuantidade() => Quantidade.HasValue;

    /// <summary>
    /// Informar apenas para IPI calculado por alíquota.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vBC")]
    public double? BaseDeCalculo
    {
        get => _vBC;
        set
        {
            if (_vBC is null || _vBC.Equals(value) != true)
            {
                _vBC = value;
                OnPropertyChanged(nameof(BaseDeCalculo));
            }
        }
    }

    public bool ShouldSerializeBaseDeCalculo() => BaseDeCalculo.HasValue;

    /// <summary>
    /// Informar apenas para IPI calculado por unidade.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vUnid")]
    public double? ValorPorUnidade
    {
        get => _vUnid;
        set
        {
            if (_vUnid is null || _vUnid.Equals(value) != true)
            {
                _vUnid = value;
                OnPropertyChanged(nameof(ValorPorUnidade));
            }
        }
    }

    public bool ShouldSerializeValorPorUnidade() => ValorPorUnidade.HasValue;

    [XmlElement("vIPI")]
    public double? ValorIPI
    {
        get => vIPIField;
        set
        {
            if (vIPIField is null || vIPIField.Equals(value) != true)
            {
                vIPIField = value;
                OnPropertyChanged(nameof(ValorIPI));
            }
        }
    }

    public bool ShouldSerializeValorIPI() => ValorIPI.HasValue;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoII : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private double? vBCField;
    private double? vDespAduField;
    private double? vIIField;
    private double? vIOFField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public double? vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public bool ShouldSerializevBC() => vBC.HasValue;

    public double? vDespAdu
    {
        get => vDespAduField;
        set
        {
            if (vDespAduField is null || vDespAduField.Equals(value) != true)
            {
                vDespAduField = value;
                OnPropertyChanged(nameof(vDespAdu));
            }
        }
    }

    public bool ShouldSerializevDespAdu() => vDespAdu.HasValue;

    public double? vII
    {
        get => vIIField;
        set
        {
            if (vIIField is null || vIIField.Equals(value) != true)
            {
                vIIField = value;
                OnPropertyChanged(nameof(vII));
            }
        }
    }

    public bool ShouldSerializevII() => vII.HasValue;

    public double? vIOF
    {
        get => vIOFField;
        set
        {
            if (vIOFField is null || vIOFField.Equals(value) != true)
            {
                vIOFField = value;
                OnPropertyChanged(nameof(vIOF));
            }
        }
    }

    public bool ShouldSerializevIOF() => vIOF.HasValue;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoISSQN : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private double? vBCField;
    private double? vAliqField;
    private double? vISSQNField;
    private string cMunFGField;
    private string cListServField;
    private CST_ISSQN cSitTribField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public double? vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public double? vAliq
    {
        get => vAliqField;
        set
        {
            if (vAliqField is null || vAliqField.Equals(value) != true)
            {
                vAliqField = value;
                OnPropertyChanged(nameof(vAliq));
            }
        }
    }

    public double? vISSQN
    {
        get => vISSQNField;
        set
        {
            if (vISSQNField is null || vISSQNField.Equals(value) != true)
            {
                vISSQNField = value;
                OnPropertyChanged(nameof(vISSQN));
            }
        }
    }

    public string cMunFG
    {
        get => cMunFGField;
        set
        {
            if (cMunFGField is null || cMunFGField.Equals(value) != true)
            {
                cMunFGField = value;
                OnPropertyChanged(nameof(cMunFG));
            }
        }
    }

    public string cListServ
    {
        get => cListServField;
        set
        {
            if (cListServField is null || cListServField.Equals(value) != true)
            {
                cListServField = value;
                OnPropertyChanged(nameof(cListServ));
            }
        }
    }

    public CST_ISSQN cSitTrib
    {
        get => cSitTribField;
        set
        {
            if (cSitTribField.Equals(value) != true)
            {
                cSitTribField = value;
                OnPropertyChanged(nameof(cSitTrib));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoPIS : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private DetalhamentoPIS_Tributacao itemField;
    private Tributacao_PIS_Identifier itemElementNameField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("PISAliq", typeof(DetalhamentoPIS_Tributacao))]
    [XmlElement("PISNT", typeof(DetalhamentoPIS_Tributacao))]
    [XmlElement("PISOutr", typeof(DetalhamentoPIS_Tributacao))]
    [XmlElement("PISQtde", typeof(DetalhamentoPIS_Tributacao))]
    [XmlChoiceIdentifier("TributacaoIndentifier")]
    public DetalhamentoPIS_Tributacao Tributacao
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Tributacao));
            }
        }
    }

    [XmlIgnore()]
    public Tributacao_PIS_Identifier TributacaoIndentifier
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TributacaoIndentifier));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// <summary>
/// Clase genérica para tratamento das tributações de PIS (sem ST).
/// </summary>
public partial class DetalhamentoPIS_Tributacao : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private CST_PIS cSTField;
    private double? vBCField;
    private double? pPISField;
    private double? vPISField;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    private double? qBCProdField;
    private double? vAliqProdField;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public CST_PIS CST
    {
        get => cSTField;
        set
        {
            if (cSTField.Equals(value) != true)
            {
                cSTField = value;
                OnPropertyChanged(nameof(CST));
            }
        }
    }

    public double? vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public bool ShouldSerializevBC() => vBC.HasValue;

    public double? pPIS
    {
        get => pPISField;
        set
        {
            if (pPISField is null || pPISField.Equals(value) != true)
            {
                pPISField = value;
                OnPropertyChanged(nameof(pPIS));
            }
        }
    }

    public bool ShouldSerializepPIS() => pPIS.HasValue;

    public double? vPIS
    {
        get => vPISField;
        set
        {
            if (vPISField is null || vPISField.Equals(value) != true)
            {
                vPISField = value;
                OnPropertyChanged(nameof(vPIS));
            }
        }
    }

    public bool ShouldSerializevPIS() => vPIS.HasValue;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public double? qBCProd
    {
        get => qBCProdField;
        set
        {
            if (qBCProdField is null || qBCProdField.Equals(value) != true)
            {
                qBCProdField = value;
                OnPropertyChanged(nameof(qBCProd));
            }
        }
    }

    public bool ShouldSerializeqBCProd() => qBCProd.HasValue;

    public double? vAliqProd
    {
        get => vAliqProdField;
        set
        {
            if (vAliqProdField is null || vAliqProdField.Equals(value) != true)
            {
                vAliqProdField = value;
                OnPropertyChanged(nameof(vAliqProd));
            }
        }
    }

    public bool ShouldSerializevAliqProd() => vAliqProd.HasValue;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoPISST : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public DetalhamentoPISST() : base()
    {
        itemsElementNameField = new List<DetalhamentoPISST_ModoCalculo>();
        itemsField = new List<double>();
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private List<double> itemsField;
    private List<DetalhamentoPISST_ModoCalculo> itemsElementNameField;
    private double? vPISField;
    private double? _pPIS;
    private double? _qBCProd;
    private double? _vAliqProd;
    private double? _vBC;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    // // AUTO GENERATED AND NOT WORKED... Will be mapped manually:

    // <System.Xml.Serialization.XmlElementAttribute("pPIS", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("qBCProd", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("vAliqProd", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("vBC", GetType(Double)), _
    // System.Xml.Serialization.XmlChoiceIdentifierAttribute("CamposPISST_PorAliquota")> _
    // Public Property CamposPorAliquota() As List(Of Double)
    // Get
    // Return Me.itemsField
    // End Get
    // Set(value As List(Of Double))
    // If ((Me.itemsField Is Nothing) _
    // OrElse (itemsField.Equals(value) <> True)) Then
    // Me.itemsField = value
    // Me.OnPropertyChanged("CamposPorAliquota")
    // End If
    // End Set
    // End Property

    // <System.Xml.Serialization.XmlElementAttribute("CamposPISST_PorAliquota"), _
    // System.Xml.Serialization.XmlIgnoreAttribute()> _
    // Public Property CamposPISST_PorAliquota() As DetalhamentoPISST_ModoCalculo() 'List (Of ItemsChoiceType2)
    // Get
    // Return Me.itemsElementNameField.ToArray
    // End Get
    // Set(value As DetalhamentoPISST_ModoCalculo())
    // If ((Me.itemsElementNameField Is Nothing) _
    // OrElse (itemsElementNameField.Equals(value) <> True)) Then
    // Me.itemsElementNameField = value.ToList
    // Me.OnPropertyChanged("CamposPISST_PorAliquota")
    // End If
    // End Set
    // End Property

    // // Fixed Values:

    /// <summary>
    /// Alíquota do PIS, em percentual (%).
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("pPIS")]
    public double? Aliquota
    {
        get => _pPIS;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _pPIS = value;
                OnPropertyChanged(nameof(Aliquota));
            }
        }
    }

    [XmlElement("qBCProd")]
    public double? QuantidadeVendida
    {
        get => _qBCProd;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _qBCProd = value;
                OnPropertyChanged(nameof(QuantidadeVendida));
            }
        }
    }

    /// <summary>
    /// Alíquota do PIS, em moeda (R$).
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vAliqProd")]
    public double? AliquotaMoeda
    {
        get => _vAliqProd;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _vAliqProd = value;
                OnPropertyChanged(nameof(AliquotaMoeda));
            }
        }
    }

    [XmlElement("vBC")]
    public double? BaseDeCalculo
    {
        get => _vBC;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _vBC = value;
                OnPropertyChanged(nameof(BaseDeCalculo));
            }
        }
    }

    [XmlElement("vPIS")]
    public double? ValorPISST
    {
        get => vPISField;
        set
        {
            if (vPISField is null || vPISField.Equals(value) != true)
            {
                vPISField = value;
                OnPropertyChanged(nameof(ValorPISST));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoCOFINS : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private DetalhamentoCOFINS_Tributacao itemField;
    private Tributacao_COFINS_Identifier itemElementNameField;


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("COFINSAliq", typeof(DetalhamentoCOFINS_Tributacao))]
    [XmlElement("COFINSNT", typeof(DetalhamentoCOFINS_Tributacao))]
    [XmlElement("COFINSOutr", typeof(DetalhamentoCOFINS_Tributacao))]
    [XmlElement("COFINSQtde", typeof(DetalhamentoCOFINS_Tributacao))]
    [XmlChoiceIdentifier("TributacaoIndentifier")]
    public DetalhamentoCOFINS_Tributacao Tributacao
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Tributacao));
            }
        }
    }

    [XmlIgnore()]
    public Tributacao_COFINS_Identifier TributacaoIndentifier
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TributacaoIndentifier));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// <summary>
/// Clase genérica para tratamento das tributações de COFINS (sem ST).
/// </summary>
/// <remarks></remarks>
public partial class DetalhamentoCOFINS_Tributacao : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private CST_COFINS cSTField;
    private double? vBCField;
    private double? pCOFINSField;
    private double? vCOFINSField;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
    private double? qBCProdField;
    private double? vAliqProdField;
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public CST_COFINS CST
    {
        get => cSTField;
        set
        {
            if (cSTField.Equals(value) != true)
            {
                cSTField = value;
                OnPropertyChanged(nameof(CST));
            }
        }
    }

    public double? vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public bool ShouldSerializevBC() => vBC.HasValue;

    public double? pCOFINS
    {
        get => pCOFINSField;
        set
        {
            if (pCOFINSField is null || pCOFINSField.Equals(value) != true)
            {
                pCOFINSField = value;
                OnPropertyChanged(nameof(pCOFINS));
            }
        }
    }

    public bool ShouldSerializepCOFINS() => pCOFINS.HasValue;

    public double? vCOFINS
    {
        get => vCOFINSField;
        set
        {
            if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
            {
                vCOFINSField = value;
                OnPropertyChanged(nameof(vCOFINS));
            }
        }
    }

    public bool ShouldSerializevCOFINS() => vCOFINS.HasValue;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public double? qBCProd
    {
        get => qBCProdField;
        set
        {
            if (qBCProdField is null || qBCProdField.Equals(value) != true)
            {
                qBCProdField = value;
                OnPropertyChanged(nameof(qBCProd));
            }
        }
    }

    public bool ShouldSerializeqBCProd() => qBCProd.HasValue;

    public double? vAliqProd
    {
        get => vAliqProdField;
        set
        {
            if (vAliqProdField is null || vAliqProdField.Equals(value) != true)
            {
                vAliqProdField = value;
                OnPropertyChanged(nameof(vAliqProd));
            }
        }
    }

    public bool ShouldSerializevAliqProd() => vAliqProd.HasValue;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoCOFINSST : INotifyPropertyChanged
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public DetalhamentoCOFINSST() : base()
    {
        itemsElementNameField = new List<DetalhamentoCOFINSST_ModoCalculo>();
        itemsField = new List<double>();
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private List<double> itemsField;
    private List<DetalhamentoCOFINSST_ModoCalculo> itemsElementNameField;
    private double? vCOFINSField;
    private double? _pCOFINS;
    private double? _qBCProd;
    private double? _vAliqProd;
    private double? _vBC;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    // // AUTO GENERATED AND NOT WORKED... Will be mapped manually:

    // <System.Xml.Serialization.XmlElementAttribute("pCOFINS", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("qBCProd", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("vAliqProd", GetType(Double)), _
    // System.Xml.Serialization.XmlElementAttribute("vBC", GetType(Double)), _
    // System.Xml.Serialization.XmlChoiceIdentifierAttribute("CamposCOFINSST_PorAliquota")> _
    // Public Property CamposPorAliquota() As List(Of Double)
    // Get
    // Return Me.itemsField
    // End Get
    // Set(value As List(Of Double))
    // If ((Me.itemsField Is Nothing) _
    // OrElse (itemsField.Equals(value) <> True)) Then
    // Me.itemsField = value
    // Me.OnPropertyChanged("CamposPorAliquota")
    // End If
    // End Set
    // End Property

    // <System.Xml.Serialization.XmlElementAttribute("CamposCOFINSST_PorAliquota"), _
    // System.Xml.Serialization.XmlIgnoreAttribute()> _
    // Public Property CamposCOFINSST_PorAliquota() As DetalhamentoCOFINSST_ModoCalculo() 'List(Of DetalhamentoCOFINSST_ModoCalculo)
    // Get
    // Return Me.itemsElementNameField.ToArray
    // End Get
    // Set(value As DetalhamentoCOFINSST_ModoCalculo())
    // If ((Me.itemsElementNameField Is Nothing) _
    // OrElse (itemsElementNameField.Equals(value) <> True)) Then
    // Me.itemsElementNameField = value.ToList
    // Me.OnPropertyChanged("CamposCOFINSST_PorAliquota")
    // End If
    // End Set
    // End Property

    // // Fixed Values:

    /// <summary>
    /// Alíquota do COFINS, em percentual (%).
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("pCOFINS")]
    public double? Aliquota
    {
        get => _pCOFINS;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _pCOFINS = value;
                OnPropertyChanged(nameof(Aliquota));
            }
        }
    }

    [XmlElement("qBCProd")]
    public double? QuantidadeVendida
    {
        get => _qBCProd;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _qBCProd = value;
                OnPropertyChanged(nameof(QuantidadeVendida));
            }
        }
    }

    /// <summary>
    /// Alíquota do COFINS, em moeda (R$).
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vAliqProd")]
    public double? AliquotaMoeda
    {
        get => _vAliqProd;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _vAliqProd = value;
                OnPropertyChanged(nameof(AliquotaMoeda));
            }
        }
    }

    [XmlElement("vBC")]
    public double? BaseDeCalculo
    {
        get => _vBC;
        set
        {
            if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
            {
                _vBC = value;
                OnPropertyChanged(nameof(BaseDeCalculo));
            }
        }
    }

    [XmlElement("vCOFINS")]
    public double? ValorCOFINS
    {
        get => vCOFINSField;
        set
        {
            if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
            {
                vCOFINSField = value;
                OnPropertyChanged(nameof(ValorCOFINS));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class DetalhamentoItemArma : INotifyPropertyChanged
{
    private TipoArma tpArmaField;
    private string nSerieField;
    private string nCanoField;
    private string descrField;

    public TipoArma tpArma
    {
        get => tpArmaField;
        set
        {
            if (tpArmaField.Equals(value) != true)
            {
                tpArmaField = value;
                OnPropertyChanged(nameof(tpArma));
            }
        }
    }

    public string nSerie
    {
        get => nSerieField;
        set
        {
            if (nSerieField is null || nSerieField.Equals(value) != true)
            {
                nSerieField = value;
                OnPropertyChanged(nameof(nSerie));
            }
        }
    }

    public string nCano
    {
        get => nCanoField;
        set
        {
            if (nCanoField is null || nCanoField.Equals(value) != true)
            {
                nCanoField = value;
                OnPropertyChanged(nameof(nCano));
            }
        }
    }

    public string descr
    {
        get => descrField;
        set
        {
            if (descrField is null || descrField.Equals(value) != true)
            {
                descrField = value;
                OnPropertyChanged(nameof(descr));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoItemCombustivel : INotifyPropertyChanged
{
    private string cProdANPField;
    private string descANPField;
    private string cODIFField;
    private string qTempField;
    private Estado uFConsField;
    private DetalhamentoItemCombustivelCIDE cIDEField;
    private DetalhamentoItemCombustivelEncerrante encerranteField;

    public DetalhamentoItemCombustivel() : base()
    {
        // Me.cIDEField = New TNFeInfNFeDetProdCombCIDE()
    }

    [XmlElement("cProdANP")]
    public string cProdANP
    {
        get => cProdANPField;
        set
        {
            if (cProdANPField is null || cProdANPField.Equals(value) != true)
            {
                cProdANPField = value;
                OnPropertyChanged(nameof(cProdANP));
            }
        }
    }

    [XmlElement("descANP")]
    public string descANP
    {
        get => descANPField;
        set
        {
            if (descANPField is null || descANPField.Equals(value) != true)
            {
                descANPField = value;
                OnPropertyChanged(nameof(descANP));
            }
        }
    }

    [XmlElement("CODIF")]
    public string CODIF
    {
        get => cODIFField;
        set
        {
            if (cODIFField is null || cODIFField.Equals(value) != true)
            {
                cODIFField = value;
                OnPropertyChanged(nameof(CODIF));
            }
        }
    }

    [XmlElement("qTemp")]
    public string qTemp
    {
        get => qTempField;
        set
        {
            if (qTempField is null || qTempField.Equals(value) != true)
            {
                qTempField = value;
                OnPropertyChanged(nameof(qTemp));
            }
        }
    }

    [XmlElement("UFCons")]
    public Estado UFCons
    {
        get => uFConsField;
        set
        {
            if (uFConsField.Equals(value) != true)
            {
                uFConsField = value;
                OnPropertyChanged(nameof(UFCons));
            }
        }
    }

    [XmlElement("CIDE")]
    public DetalhamentoItemCombustivelCIDE CIDE
    {
        get => cIDEField;
        set
        {
            if (cIDEField is null || cIDEField.Equals(value) != true)
            {
                cIDEField = value;
                OnPropertyChanged(nameof(CIDE));
            }
        }
    }

    [XmlElement("encerrante")]
    public DetalhamentoItemCombustivelEncerrante encerrante
    {
        get => encerranteField;
        set
        {
            if (encerranteField is null || encerranteField.Equals(value) != true)
            {
                encerranteField = value;
                OnPropertyChanged(nameof(encerrante));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoItemCombustivelCIDE : INotifyPropertyChanged
{
    private double? qBCProdField;
    private double? vAliqProdField;
    private double? vCIDEField;

    public string qBCProd
    {
        get => Convert.ToString(qBCProdField);
        set
        {
            if (qBCProdField is null || qBCProdField.Equals(value) != true)
            {
                qBCProdField = Convert.ToDouble(value);
                OnPropertyChanged(nameof(qBCProd));
            }
        }
    }

    public double? vAliqProd
    {
        get => vAliqProdField;
        set
        {
            if (vAliqProdField is null || vAliqProdField.Equals(value) != true)
            {
                vAliqProdField = value;
                OnPropertyChanged(nameof(vAliqProd));
            }
        }
    }

    public double? vCIDE
    {
        get => vCIDEField;
        set
        {
            if (vCIDEField is null || vCIDEField.Equals(value) != true)
            {
                vCIDEField = value;
                OnPropertyChanged(nameof(vCIDE));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoItemCombustivelEncerrante : INotifyPropertyChanged
{
    private string nBicoField;
    private string nBombaField;
    private string nTanqueField;
    private double? vEncIniField;
    private double? vEncFinField;

    public string nBico
    {
        get => nBicoField;
        set
        {
            if (nBicoField is null || nBicoField.Equals(value) != true)
            {
                nBicoField = value;
                OnPropertyChanged(nameof(nBico));
            }
        }
    }

    public string nBomba
    {
        get => nBombaField;
        set
        {
            if (nBombaField is null || nBombaField.Equals(value) != true)
            {
                nBombaField = value;
                OnPropertyChanged(nameof(nBomba));
            }
        }
    }

    public string nTanque
    {
        get => nTanqueField;
        set
        {
            if (nTanqueField is null || nTanqueField.Equals(value) != true)
            {
                nTanqueField = value;
                OnPropertyChanged(nameof(nTanque));
            }
        }
    }

    public double? vEncIni
    {
        get => vEncIniField;
        set
        {
            if (vEncIniField is null || vEncIniField.Equals(value) != true)
            {
                vEncIniField = value;
                OnPropertyChanged(nameof(vEncIni));
            }
        }
    }

    public double? vEncFin
    {
        get => vEncFinField;
        set
        {
            if (vEncFinField is null || vEncFinField.Equals(value) != true)
            {
                vEncFinField = value;
                OnPropertyChanged(nameof(vEncFin));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoItemMedicamento_Rastro : INotifyPropertyChanged
{
    private string nLoteField;
    private string qLoteField;
    private DateTime? dFabField;
    private string dValField;
    private string cProdAnvisaField;
    private double? vPMCField;

    public string nLote
    {
        get => nLoteField;
        set
        {
            if (nLoteField is null || nLoteField.Equals(value) != true)
            {
                nLoteField = value;
                OnPropertyChanged(nameof(nLote));
            }
        }
    }

    public string qLote
    {
        get => qLoteField;
        set
        {
            if (qLoteField is null || qLoteField.Equals(value) != true)
            {
                qLoteField = value;
                OnPropertyChanged(nameof(qLote));
            }
        }
    }

    [XmlIgnore()]
    public DateTime? DataFabricacao
    {
        get => dFabField;
        set
        {
            if (dFabField is null || dFabField.Equals(value) != true)
            {
                dFabField = value;
                OnPropertyChanged(nameof(DataFabricacao));
            }
        }
    }

    /// <summary>
    /// Formato AAAA-MM-DD
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string dFab
    {
        get
        {
            if (DataFabricacao.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataFabricacao);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dFabField is null || dFabField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dFabField = new DateTime(Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[2].Substring(0, 2)));
                }
                else
                {
                    dFabField = default;
                }

                OnPropertyChanged(nameof(DataFabricacao));
            }
        }
    }

    [XmlIgnore()]
    public DateTime? DataValidade
    {
        get => dValField.ToDate(DateFormat.XML_AAAAMMDD);
        set
        {
            if (dValField is null || dValField.Equals(value) != true)
            {
                dValField = Convert.ToString(value);
                OnPropertyChanged(nameof(DataValidade));
            }
        }
    }


    /// <summary>
    /// Formato AAAA-MM-DD
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string dVal
    {
        get
        {
            if (DataValidade.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataValidade);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dValField is null || dValField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dValField = Convert.ToString(new DateTime(Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[2].Substring(0, 2))));
                }
                else
                {
                    dValField = null;
                }

                OnPropertyChanged(nameof(DataValidade));
            }
        }
    }

    public string cProdANVISA
    {
        get => cProdAnvisaField;
        set
        {
            if (cProdAnvisaField is null || cProdAnvisaField.Equals(value) != true)
            {
                cProdAnvisaField = value;
                OnPropertyChanged(nameof(cProdANVISA));
            }
        }
    }

    public double? vPMC
    {
        get => vPMCField;
        set
        {
            if (vPMCField is null || vPMCField.Equals(value) != true)
            {
                vPMCField = value;
                OnPropertyChanged(nameof(vPMC));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoItemMedicamento : INotifyPropertyChanged
{
    private string nLoteField;
    private string qLoteField;
    private DateTime? dFabField;
    private string dValField;
    private string cProdAnvisaField;
    private double? vPMCField;

    public string nLote
    {
        get => nLoteField;
        set
        {
            if (nLoteField is null || nLoteField.Equals(value) != true)
            {
                nLoteField = value;
                OnPropertyChanged(nameof(nLote));
            }
        }
    }

    public string qLote
    {
        get => qLoteField;
        set
        {
            if (qLoteField is null || qLoteField.Equals(value) != true)
            {
                qLoteField = value;
                OnPropertyChanged(nameof(qLote));
            }
        }
    }

    [XmlIgnore()]
    public DateTime? DataFabricacao
    {
        get => dFabField;
        set
        {
            if (dFabField is null || dFabField.Equals(value) != true)
            {
                dFabField = value;
                OnPropertyChanged(nameof(DataFabricacao));
            }
        }
    }

    /// <summary>
    /// Formato AAAA-MM-DD
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string dFab
    {
        get
        {
            if (DataFabricacao.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataFabricacao);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dFabField is null || dFabField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dFabField = new DateTime(Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[2].Substring(0, 2)));
                }
                else
                {
                    dFabField = default;
                }

                OnPropertyChanged(nameof(DataFabricacao));
            }
        }
    }

    [XmlIgnore()]
    public DateTime? DataValidade
    {
        get => dValField.ToDate(DateFormat.XML_AAAAMMDD);
        set
        {
            if (dValField is null || dValField.Equals(value) != true)
            {
                dValField = Convert.ToString(value);
                OnPropertyChanged(nameof(DataValidade));
            }
        }
    }


    /// <summary>
    /// Formato AAAA-MM-DD
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public string dVal
    {
        get
        {
            if (DataValidade.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataValidade);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dValField is null || dValField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dValField = Convert.ToString(new DateTime(Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[2].Substring(0, 2))));
                }
                else
                {
                    dValField = null;
                }

                OnPropertyChanged(nameof(DataValidade));
            }
        }
    }

    public string cProdANVISA
    {
        get => cProdAnvisaField;
        set
        {
            if (cProdAnvisaField is null || cProdAnvisaField.Equals(value) != true)
            {
                cProdAnvisaField = value;
                OnPropertyChanged(nameof(cProdANVISA));
            }
        }
    }

    public double? vPMC
    {
        get => vPMCField;
        set
        {
            if (vPMCField is null || vPMCField.Equals(value) != true)
            {
                vPMCField = value;
                OnPropertyChanged(nameof(vPMC));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoItemVeiculo : INotifyPropertyChanged
{
    private VeiculoTipoOperacao tpOpField;
    private string chassiField;
    private string cCorField;
    private string xCorField;
    private string potField;
    private string cilinField;
    private string pesoLField;
    private string pesoBField;
    private string nSerieField;
    private VeiculoTipoCombustivel tpCombField;
    private string nMotorField;
    private string cMTField;
    private string distField;
    private int? anoModField;
    private int? anoFabField;
    private string tpPintField;
    private VeiculoTipo tpVeicField;
    private VeiculoEspecie espVeicField;
    private VeiculoCondicaoChassi vINField;
    private VeiculoCondicao condVeicField;
    private string cModField;
    private VeiculoCorDENATRAN cCorDENATRANField;
    private int? lotaField;
    private VeiculoRestricao tpRestField;

    public VeiculoTipoOperacao tpOp
    {
        get => tpOpField;
        set
        {
            if (tpOpField.Equals(value) != true)
            {
                tpOpField = value;
                OnPropertyChanged(nameof(tpOp));
            }
        }
    }

    public string chassi
    {
        get => chassiField;
        set
        {
            if (chassiField is null || chassiField.Equals(value) != true)
            {
                chassiField = value;
                OnPropertyChanged(nameof(chassi));
            }
        }
    }

    public string cCor
    {
        get => cCorField;
        set
        {
            if (cCorField is null || cCorField.Equals(value) != true)
            {
                cCorField = value;
                OnPropertyChanged(nameof(cCor));
            }
        }
    }

    public string xCor
    {
        get => xCorField;
        set
        {
            if (xCorField is null || xCorField.Equals(value) != true)
            {
                xCorField = value;
                OnPropertyChanged(nameof(xCor));
            }
        }
    }

    public string pot
    {
        get => potField;
        set
        {
            if (potField is null || potField.Equals(value) != true)
            {
                potField = value;
                OnPropertyChanged(nameof(pot));
            }
        }
    }

    [XmlIgnore()]
    public double? Potencia
    {
        get
        {
            if (pot != null)
            {
                try
                {
                    return double.Parse(potField.Replace(",", "."));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            return default;
        }
    }

    public string cilin
    {
        get => cilinField;
        set
        {
            if (cilinField is null || cilinField.Equals(value) != true)
            {
                cilinField = value;
                OnPropertyChanged(nameof(cilin));
            }
        }
    }

    [XmlIgnore()]
    public double? Cilindradas
    {
        get
        {
            if (pot != null)
            {
                try
                {
                    return double.Parse(cilinField.Replace(",", "."));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            return default;
        }
    }

    public string pesoL
    {
        get => pesoLField;
        set
        {
            if (pesoLField is null || pesoLField.Equals(value) != true)
            {
                pesoLField = value;
                OnPropertyChanged(nameof(pesoL));
            }
        }
    }

    [XmlIgnore()]
    public double? PesoLiquido
    {
        get
        {
            if (pot != null)
            {
                try
                {
                    return double.Parse(pesoLField.Replace(",", "."));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            return default;
        }
    }

    public string pesoB
    {
        get => pesoBField;
        set
        {
            if (pesoBField is null || pesoBField.Equals(value) != true)
            {
                pesoBField = value;
                OnPropertyChanged(nameof(pesoB));
            }
        }
    }

    [XmlIgnore()]
    public double? PesoBruto
    {
        get
        {
            if (pot != null)
            {
                try
                {
                    return double.Parse(pesoBField.Replace(",", "."));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            return default;
        }
    }

    public string nSerie
    {
        get => nSerieField;
        set
        {
            if (nSerieField is null || nSerieField.Equals(value) != true)
            {
                nSerieField = value;
                OnPropertyChanged(nameof(nSerie));
            }
        }
    }

    public VeiculoTipoCombustivel tpComb
    {
        get => tpCombField;
        set
        {
            if (tpCombField.Equals(value) != true)
            {
                tpCombField = value;
                OnPropertyChanged(nameof(tpComb));
            }
        }
    }

    public string nMotor
    {
        get => nMotorField;
        set
        {
            if (nMotorField is null || nMotorField.Equals(value) != true)
            {
                nMotorField = value;
                OnPropertyChanged(nameof(nMotor));
            }
        }
    }

    public string CMT
    {
        get => cMTField;
        set
        {
            if (cMTField is null || cMTField.Equals(value) != true)
            {
                cMTField = value;
                OnPropertyChanged(nameof(CMT));
            }
        }
    }

    [XmlIgnore()]
    public double? CMT_Formatado
    {
        get
        {
            if (pot != null)
            {
                try
                {
                    return double.Parse(cMTField.Replace(",", "."));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            return default;
        }
    }

    public string dist
    {
        get => distField;
        set
        {
            if (distField is null || distField.Equals(value) != true)
            {
                distField = value;
                OnPropertyChanged(nameof(dist));
            }
        }
    }

    [XmlIgnore()]
    public double? Dist_Formatado
    {
        get
        {
            if (pot != null)
            {
                try
                {
                    return double.Parse(distField.Replace(",", "."));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            return default;
        }
    }

    public int? anoMod
    {
        get => anoModField;
        set
        {
            if (anoModField is null || anoModField.Equals(value) != true)
            {
                anoModField = value;
                OnPropertyChanged(nameof(anoMod));
            }
        }
    }

    public int? anoFab
    {
        get => anoFabField;
        set
        {
            if (anoFabField is null || anoFabField.Equals(value) != true)
            {
                anoFabField = value;
                OnPropertyChanged(nameof(anoFab));
            }
        }
    }

    public string tpPint
    {
        get => tpPintField;
        set
        {
            if (tpPintField is null || tpPintField.Equals(value) != true)
            {
                tpPintField = value;
                OnPropertyChanged(nameof(tpPint));
            }
        }
    }

    public VeiculoTipo tpVeic
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

    public VeiculoEspecie espVeic
    {
        get => espVeicField;
        set
        {
            if (espVeicField.Equals(value) != true)
            {
                espVeicField = value;
                OnPropertyChanged(nameof(espVeic));
            }
        }
    }

    public VeiculoCondicaoChassi VIN
    {
        get => vINField;
        set
        {
            if (vINField.Equals(value) != true)
            {
                vINField = value;
                OnPropertyChanged(nameof(VIN));
            }
        }
    }

    public VeiculoCondicao condVeic
    {
        get => condVeicField;
        set
        {
            if (condVeicField.Equals(value) != true)
            {
                condVeicField = value;
                OnPropertyChanged(nameof(condVeic));
            }
        }
    }

    public string cMod
    {
        get => cModField;
        set
        {
            if (cModField is null || cModField.Equals(value) != true)
            {
                cModField = value;
                OnPropertyChanged(nameof(cMod));
            }
        }
    }

    public VeiculoCorDENATRAN cCorDENATRAN
    {
        get => cCorDENATRANField;
        set
        {
            if (cCorDENATRANField.Equals(value) != true)
            {
                cCorDENATRANField = value;
                OnPropertyChanged(nameof(cCorDENATRAN));
            }
        }
    }

    public int? lota
    {
        get => lotaField;
        set
        {
            if (lotaField is null || lotaField.Equals(value) != true)
            {
                lotaField = value;
                OnPropertyChanged(nameof(lota));
            }
        }
    }

    public VeiculoRestricao tpRest
    {
        get => tpRestField;
        set
        {
            if (tpRestField.Equals(value) != true)
            {
                tpRestField = value;
                OnPropertyChanged(nameof(tpRest));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}