using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using DateFormat = EficazFrameworkCore.SPED.Extensions.DateFormat;

namespace EficazFrameworkCore.SPED.Schemas.NFe
{

    /// <summary>
    /// Grupo de detalhamento de Produtos e Serviços da NF-e
    /// </summary>
    /// <remarks></remarks>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Item : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Item() : base()
        {
            // Me.impostoField = New Tributacao()
            // Me.prodField = New Produto()
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Produto prodField;
        private Tributacao impostoField;
        private string infAdProdField;
        private string nItemField;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("prod")]
        public Produto Dados
        {
            get
            {
                return prodField;
            }

            set
            {
                if (prodField is null || prodField.Equals(value) != true)
                {
                    prodField = value;
                    OnPropertyChanged("Dados");
                }
            }
        }

        [XmlElement("imposto")]
        public Tributacao Imposto
        {
            get
            {
                return impostoField;
            }

            set
            {
                if (impostoField is null || impostoField.Equals(value) != true)
                {
                    impostoField = value;
                    OnPropertyChanged("Imposto");
                }
            }
        }

        [XmlElement("infAdProd")]
        public string InformacoesAdicionais
        {
            get
            {
                return infAdProdField;
            }

            set
            {
                if (infAdProdField is null || infAdProdField.Equals(value) != true)
                {
                    infAdProdField = value;
                    OnPropertyChanged("InformacoesAdicionais");
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
            get
            {
                return nItemField;
            }

            set
            {
                if (nItemField is null || nItemField.Equals(value) != true)
                {
                    nItemField = value;
                    OnPropertyChanged("NumeroSequencial");
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
                    var icms = Imposto.DemaisImpostos[0];
                    var trib = icms.GetType().GetRuntimeProperty("Tributacao").GetValue(icms, null);
                    ST = Conversions.ToDouble(trib.GetType().GetRuntimeProperty("vICMSST").GetValue(trib));
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Produto : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Produto() : base()
        {
            itemsField = new List<object>();
            diField = new List<DeclaracaoImportacao>();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("cProd")]
        public string Codigo
        {
            get
            {
                return cProdField;
            }

            set
            {
                if (cProdField is null || cProdField.Equals(value) != true)
                {
                    cProdField = value;
                    OnPropertyChanged("Codigo");
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
            get
            {
                return cEANField;
            }

            set
            {
                if (cEANField is null || cEANField.Equals(value) != true)
                {
                    cEANField = value;
                    OnPropertyChanged("GTIN");
                }
            }
        }

        [XmlElement("xProd")]
        public string Descricao
        {
            get
            {
                return xProdField;
            }

            set
            {
                if (xProdField is null || xProdField.Equals(value) != true)
                {
                    xProdField = value;
                    OnPropertyChanged("Descricao");
                }
            }
        }

        public string NCM
        {
            get
            {
                return nCMField;
            }

            set
            {
                if (nCMField is null || nCMField.Equals(value) != true)
                {
                    nCMField = value;
                    OnPropertyChanged("NCM");
                }
            }
        }

        public string CEST
        {
            get
            {
                return _cest;
            }

            set
            {
                if (_cest is null || _cest.Equals(value) != true)
                {
                    _cest = value;
                    OnPropertyChanged("CEST");
                }
            }
        }

        public string EXTIPI
        {
            get
            {
                return eXTIPIField;
            }

            set
            {
                if (eXTIPIField is null || eXTIPIField.Equals(value) != true)
                {
                    eXTIPIField = value;
                    OnPropertyChanged("EXTIPI");
                }
            }
        }

        public string CFOP
        {
            get
            {
                return cFOPField;
            }

            set
            {
                if (cFOPField is null || cFOPField.Equals(value) != true)
                {
                    cFOPField = value;
                    OnPropertyChanged("CFOP");
                }
            }
        }

        [XmlElement("uCom")]
        public string UnidadeComercial
        {
            get
            {
                return uComField;
            }

            set
            {
                if (uComField is null || uComField.Equals(value) != true)
                {
                    uComField = value;
                    OnPropertyChanged("UnidadeComercial");
                }
            }
        }

        [XmlElement("qCom")]
        public double? QuantidadeComercial
        {
            get
            {
                return qComField;
            }

            set
            {
                if (qComField is null || qComField.Equals(value) != true)
                {
                    qComField = value;
                    OnPropertyChanged("qCom");
                }
            }
        }

        public bool ShouldSerializeQuantidadeComercial()
        {
            return qComField.HasValue;
        }

        [XmlElement("vUnCom")]
        public double? ValorUnitarioComercial
        {
            get
            {
                return vUnComField;
            }

            set
            {
                if (vUnComField is null || vUnComField.Equals(value) != true)
                {
                    vUnComField = value;
                    OnPropertyChanged("ValorUnitarioComercial");
                }
            }
        }

        public bool ShouldSerializeValorUnitarioComercial()
        {
            return vUnComField.HasValue;
        }

        [XmlIgnore()]
        public double? ValorTotalBruto
        {
            get
            {
                return vProdField;
            }

            set
            {
                if (vProdField is null || vProdField.Equals(value) != true)
                {
                    vProdField = value;
                    OnPropertyChanged("ValorTotalBruto");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vProdField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("ValorTotalBruto");
                }
            }
        }

        public bool ShouldSerializeValorTotalBruto_XML()
        {
            return vProdField.HasValue;
        }

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
            get
            {
                return cEANTribField;
            }

            set
            {
                if (cEANTribField is null || cEANTribField.Equals(value) != true)
                {
                    cEANTribField = value;
                    OnPropertyChanged("GTIN_Tributavel");
                }
            }
        }

        [XmlElement("uTrib")]
        public string UnidadeTributavel
        {
            get
            {
                return uTribField;
            }

            set
            {
                if (uTribField is null || uTribField.Equals(value) != true)
                {
                    uTribField = value;
                    OnPropertyChanged("UnidadeTributavel");
                }
            }
        }

        [XmlElement("qTrib")]
        public double? QuantidadeTributavel
        {
            get
            {
                return qTribField;
            }

            set
            {
                if (qTribField is null || qTribField.Equals(value) != true)
                {
                    qTribField = value;
                    OnPropertyChanged("QuantidadeTributavel");
                }
            }
        }

        public bool ShouldSerializeQuantidadeTributavel()
        {
            return qTribField.HasValue;
        }

        [XmlElement("vUnTrib")]
        public double? ValorUnitarioTributavel
        {
            get
            {
                return vUnTribField;
            }

            set
            {
                if (vUnTribField is null || vUnTribField.Equals(value) != true)
                {
                    vUnTribField = value;
                    OnPropertyChanged("ValorUnitarioTributavel");
                }
            }
        }

        public bool ShouldSerializeValorUnitarioTributavel()
        {
            return vUnTribField.HasValue;
        }

        [XmlElement("vFrete")]
        public double? ValorFrete
        {
            get
            {
                return vFreteField;
            }

            set
            {
                if (vFreteField is null || vFreteField.Equals(value) != true)
                {
                    vFreteField = value;
                    OnPropertyChanged("ValorFrete");
                }
            }
        }

        public bool ShouldSerializeValorFrete()
        {
            return vFreteField.HasValue;
        }

        [XmlElement("vSeg")]
        public double? ValorSeguro
        {
            get
            {
                return vSegField;
            }

            set
            {
                if (vSegField is null || vSegField.Equals(value) != true)
                {
                    vSegField = value;
                    OnPropertyChanged("ValorSeguro");
                }
            }
        }

        public bool ShouldSerializeValorSeguro()
        {
            return vSegField.HasValue;
        }

        [XmlElement("vDesc")]
        public double? ValorDesconto
        {
            get
            {
                return vDescField;
            }

            set
            {
                if (vDescField is null || vDescField.Equals(value) != true)
                {
                    vDescField = value;
                    OnPropertyChanged("ValorDesconto");
                }
            }
        }

        public bool ShouldSerializeValorDesconto()
        {
            return vDescField.HasValue;
        }

        [XmlElement("vOutro")]
        public double? ValorOutrasDespesas
        {
            get
            {
                return vOutroField;
            }

            set
            {
                if (vOutroField is null || vOutroField.Equals(value) != true)
                {
                    vOutroField = value;
                    OnPropertyChanged("ValorOutrasDespesas");
                }
            }
        }

        public bool ShouldSerializeValorOutrasDespesas()
        {
            return vOutroField.HasValue;
        }

        [XmlElement("indTot")]
        public IndicadorTotal IndicadorComposicaoTotal
        {
            get
            {
                return indTotField;
            }

            set
            {
                if (indTotField.Equals(value) != true)
                {
                    indTotField = value;
                    OnPropertyChanged("IndicadorComposicaoTotal");
                }
            }
        }

        [XmlElement("nFCI")]
        public string NumeroFCI
        {
            get
            {
                return _nFCIField;
            }

            set
            {
                if (cProdField is null || cProdField.Equals(value) != true)
                {
                    _nFCIField = value;
                    OnPropertyChanged("NumeroFCI");
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
            get
            {
                return diField;
            }

            set
            {
                if (diField is null || diField.Equals(value) != true)
                {
                    diField = value;
                    OnPropertyChanged("Importacoes");
                }
            }
        }

        [XmlElement("xPed")]
        public string PedidoCompraNumero
        {
            get
            {
                return xPedField;
            }

            set
            {
                if (xPedField is null || xPedField.Equals(value) != true)
                {
                    xPedField = value;
                    OnPropertyChanged("PedidoCompraNumero");
                }
            }
        }

        [XmlElement("nItemPed")]
        public int? PedidoCompraItem
        {
            get
            {
                return nItemPedField;
            }

            set
            {
                if (nItemPedField is null || nItemPedField.Equals(value) != true)
                {
                    nItemPedField = value;
                    OnPropertyChanged("nItemPed");
                }
            }
        }

        public bool ShouldSerializePedidoCompraItem()
        {
            return nItemPedField.HasValue;
        }

        [XmlElement("arma", typeof(DetalhamentoItemArma))]
        [XmlElement("comb", typeof(DetalhamentoItemCombustivel))]
        [XmlElement("med", typeof(DetalhamentoItemMedicamento))]
        [XmlElement("rastro", typeof(DetalhamentoItemMedicamento_Rastro))]
        [XmlElement("veicProd", typeof(DetalhamentoItemVeiculo))]
        public List<object> Detalhamentos
        {
            get
            {
                return itemsField;
            }

            set
            {
                if (itemsField is null || itemsField.Equals(value) != true)
                {
                    itemsField = value;
                    OnPropertyChanged("Detalhamentos");
                }
            }
        }

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
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("vTotTrib")]
        public double? ValorTotalTributos
        {
            get
            {
                return vTotTribField;
            }

            set
            {
                if (vTotTribField is null || vTotTribField.Equals(value) != true)
                {
                    vTotTribField = value;
                    OnPropertyChanged("ValorTotalTributos");
                }
            }
        }

        public bool ShouldSerializeValorTotalTributos()
        {
            return vTotTribField.HasValue;
        }

        [XmlElement("ICMS", typeof(DetalhamentoICMS))]
        [XmlElement("ICMSUFDest", typeof(DetalhamentoICMS_UF_Destinataria))]
        [XmlElement("II", typeof(DetalhamentoII))]
        [XmlElement("IPI", typeof(DetalhamentoIPI))]
        [XmlElement("ISSQN", typeof(DetalhamentoISSQN))]
        public List<object> DemaisImpostos
        {
            get
            {
                return itemsField;
            }

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
            get
            {
                return pISField;
            }

            set
            {
                if (pISField is null || pISField.Equals(value) != true)
                {
                    pISField = value;
                    OnPropertyChanged("PIS");
                }
            }
        }

        public DetalhamentoPISST PISST
        {
            get
            {
                return pISSTField;
            }

            set
            {
                if (pISSTField is null || pISSTField.Equals(value) != true)
                {
                    pISSTField = value;
                    OnPropertyChanged("PISST");
                }
            }
        }

        public DetalhamentoCOFINS COFINS
        {
            get
            {
                return cOFINSField;
            }

            set
            {
                if (cOFINSField is null || cOFINSField.Equals(value) != true)
                {
                    cOFINSField = value;
                    OnPropertyChanged("COFINS");
                }
            }
        }

        public DetalhamentoCOFINSST COFINSST
        {
            get
            {
                return cOFINSSTField;
            }

            set
            {
                if (cOFINSSTField is null || cOFINSSTField.Equals(value) != true)
                {
                    cOFINSSTField = value;
                    OnPropertyChanged("COFINSST");
                }
            }
        }

        [XmlIgnore()]
        public DetalhamentoICMS ICMS
        {
            get
            {
                // Return _icms
                for (int i = 0, loopTo = DemaisImpostos.Count - 1; i <= loopTo; i++)
                {
                    if (DemaisImpostos[i] is DetalhamentoICMS)
                    {
                        return (DetalhamentoICMS)DemaisImpostos[i];
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
                for (int i = 0, loopTo = DemaisImpostos.Count - 1; i <= loopTo; i++)
                {
                    if (DemaisImpostos[i] is DetalhamentoICMS_UF_Destinataria)
                    {
                        return (DetalhamentoICMS_UF_Destinataria)DemaisImpostos[i];
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
                for (int i = 0, loopTo = DemaisImpostos.Count - 1; i <= loopTo; i++)
                {
                    if (DemaisImpostos[i] is DetalhamentoIPI)
                    {
                        return (DetalhamentoIPI)DemaisImpostos[i];
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
                for (int i = 0, loopTo = DemaisImpostos.Count - 1; i <= loopTo; i++)
                {
                    if (DemaisImpostos[i] is DetalhamentoISSQN)
                    {
                        return (DetalhamentoISSQN)DemaisImpostos[i];
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
                for (int i = 0, loopTo = DemaisImpostos.Count - 1; i <= loopTo; i++)
                {
                    if (DemaisImpostos[i] is DetalhamentoII)
                    {
                        return (DetalhamentoII)DemaisImpostos[i];
                    }
                }

                return null;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoICMS : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_Tributacao itemField;
        private Tributacao_ICMS_Identifier itemElementNameField;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        [XmlElement("ICMS00", typeof(DetalhamentoICMS_Tributacao))]
        [XmlElement("ICMS10", typeof(DetalhamentoICMS_Tributacao))]
        [XmlElement("ICMS20", typeof(DetalhamentoICMS_Tributacao))]
        [XmlElement("ICMS30", typeof(DetalhamentoICMS_Tributacao))]
        [XmlElement("ICMS40", typeof(DetalhamentoICMS_Tributacao))]
        [XmlElement("ICMS51", typeof(DetalhamentoICMS_Tributacao))]
        [XmlElement("ICMS60", typeof(DetalhamentoICMS_Tributacao))]
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
            get
            {
                return itemField;
            }

            set
            {
                if (itemField is null || itemField.Equals(value) != true)
                {
                    itemField = value;
                    OnPropertyChanged("Tributacao");
                }
            }
        }

        [XmlIgnore()]
        public Tributacao_ICMS_Identifier TributacaoIndentifier
        {
            get
            {
                return itemElementNameField;
            }

            set
            {
                if (itemElementNameField.Equals(value) != true)
                {
                    itemElementNameField = value;
                    OnPropertyChanged("TributacaoIndentifier");
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
                        if ((int)TributacaoIndentifier <= 8)
                        {
                            return (int)Tributacao.orig + string.Format("{0:#00}", Tributacao.CSTFinal);
                        }
                        else if ((int)TributacaoIndentifier >= 10 & (int)TributacaoIndentifier <= 15)
                        {
                            return (int)Tributacao.orig + string.Format("{0:#000}", Tributacao.CSTFinal);
                        }
                        else if (TributacaoIndentifier == Tributacao_ICMS_Identifier.ICMSST)
                        {
                            return (int)Tributacao.orig + string.Format("{0:#00}", Tributacao.CSTFinal);
                        }
                        else
                        {
                            try
                            {
                                return (int)Tributacao.orig + string.Format("{0:#00}", Tributacao.CSTFinal);
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
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /// <summary>
    /// Clase genérica para tratamento das tributações de ICMS.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoICMS_Tributacao : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private OrigemMercadoria origField;
        private CST_ICMS cSTField = CST_ICMS.CST_NA;
        private CSOSN_ICMS cSOSNField = CSOSN_ICMS.CSTNA;
        private double? vBCField;
        private double? pICMSField;
        private double? vICMSField;


        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST00_ModBC modBCField00;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST10_ModBC modBCField10;
        private DetalhamentoICMS_CST10_ModBCST modBCSTField10;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST20_ModBC modBCField20;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST30_ModBCST modBCSTField30;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST51_ModBC? modBCField51;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? vBCSTRetField;
        private double? vICMSSTRetField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST70_ModBC modBCField70;
        private DetalhamentoICMS_CST70_ModBCST modBCSTField70;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST90_ModBC modBCField90;
        private DetalhamentoICMS_CST90_ModBCST modBCSTField90;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? pMVASTField;
        private double? pRedBCSTField;
        private double? vBCSTField;
        private double? pICMSSTField;
        private double? vICMSSTField;
        // ##FCP
        private double? vBCFCPSTField;
        private double? pFCPSTField;
        private double? vFCPSTField;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? pRedBCField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_CST40_MotivoDesoneracao motDesICMSField;
        private double? pvICMSDeson;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? pCredSNField;
        private double? vCredICMSSNField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMSSN_CSOSN201_ModBCST modBCSTField201;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMSSN_CSOSN202_ModBCST modBCSTField202;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMSSN_CSOSN900_ModBC modBCField900;
        private DetalhamentoICMSSN_CSOSN900_ModBCST modBCSTField900;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DetalhamentoICMS_Part_ModBC modBCFieldPart;
        private DetalhamentoICMS_Part_ModBCST modBCSTFieldPart;
        private Estado uFSTField;
        private double? pBCOpField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? vBCSTDestField;
        private double? vICMSSTDestField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? vBCEfetField;
        private double? pICMSEfetField;
        private double? vICMSEfetField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int? modBCField;
        private int? modBCSTField;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public OrigemMercadoria orig
        {
            get
            {
                return origField;
            }

            set
            {
                if (origField.Equals(value) != true)
                {
                    origField = value;
                    OnPropertyChanged("orig");
                }
            }
        }

        public CST_ICMS CST
        {
            get
            {
                return cSTField;
            }

            set
            {
                if (cSTField.Equals(value) != true)
                {
                    cSTField = value;
                    OnPropertyChanged("CSTNormal");
                }
            }
        }

        public bool ShouldSerializeCSTNormal()
        {
            return CST != CST_ICMS.CST_NA;
        }

        public CSOSN_ICMS CSOSN
        {
            get
            {
                return cSOSNField;
            }

            set
            {
                if (cSOSNField.Equals(value) != true)
                {
                    cSOSNField = value;
                    OnPropertyChanged("CSOSN");
                }
            }
        }

        public bool ShouldSerializeCSOSN()
        {
            return CSOSN != CSOSN_ICMS.CSTNA;
        }

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
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("vBC");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vBCField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vBC");
                }
            }
        }

        public bool ShouldSerializevBC_XML()
        {
            return vBCField.HasValue & CST != CST_ICMS.CST_30 & CST != CST_ICMS.CST_40 & CST != CST_ICMS.CST_41 & CST != CST_ICMS.CST_50 & CST != CST_ICMS.CST_60 & (CSOSN == CSOSN_ICMS.CSTNA | CSOSN == CSOSN_ICMS.CST900);
        }

        public double? pICMS
        {
            get
            {
                return pICMSField;
            }

            set
            {
                if (pICMSField is null || pICMSField.Equals(value) != true)
                {
                    pICMSField = value;
                    OnPropertyChanged("pICMS");
                }
            }
        }

        public bool ShouldSerializepICMS()
        {
            return pICMSField.HasValue & CST != CST_ICMS.CST_30 & CST != CST_ICMS.CST_40 & CST != CST_ICMS.CST_41 & CST != CST_ICMS.CST_50 & CST != CST_ICMS.CST_60 & (CSOSN == CSOSN_ICMS.CSTNA | CSOSN == CSOSN_ICMS.CST900);
        }

        [XmlIgnore()]
        public double? vICMS
        {
            get
            {
                return vICMSField;
            }

            set
            {
                if (vICMSField is null || vICMSField.Equals(value) != true)
                {
                    vICMSField = value;
                    OnPropertyChanged("vICMS");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vICMSField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vICMS");
                }
            }
        }

        public bool ShouldSerializevICMS_XML()
        {
            return vICMSField.HasValue & CST != CST_ICMS.CST_30 & CST != CST_ICMS.CST_60 & (CSOSN == CSOSN_ICMS.CSTNA | CSOSN == CSOSN_ICMS.CST900);
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_CST00_ModBC modBC00
        {
            get
            {
                return modBCField00;
            }

            set
            {
                if (modBCField00.Equals(value) != true)
                {
                    modBCField00 = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBC00");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_CST10_ModBC modBC10
        {
            get
            {
                return modBCField10;
            }

            set
            {
                if (modBCField10.Equals(value) != true)
                {
                    modBCField10 = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBC10");
                }
            }
        }

        [XmlIgnore()]
        public DetalhamentoICMS_CST10_ModBCST modBCST10
        {
            get
            {
                return modBCSTField10;
            }

            set
            {
                if (modBCSTField10.Equals(value) != true)
                {
                    modBCSTField10 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST10");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_CST20_ModBC modBC20
        {
            get
            {
                return modBCField20;
            }

            set
            {
                if (modBCField20.Equals(value) != true)
                {
                    modBCField20 = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBC20");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_CST30_ModBCST modBCST30
        {
            get
            {
                return modBCSTField30;
            }

            set
            {
                if (modBCSTField30.Equals(value) != true)
                {
                    modBCSTField30 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST30");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                    return (DetalhamentoICMS_CST51_ModBC)Conversions.ToInteger(default);
                }
            }

            set
            {
                if (modBCField51.Equals(value) != true)
                {
                    modBCField51 = value;
                    OnPropertyChanged("modBC51");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public double? vBCSTRet
        {
            get
            {
                return vBCSTRetField;
            }

            set
            {
                if (vBCSTRetField is null || vBCSTRetField.Equals(value) != true)
                {
                    vBCSTRetField = value;
                    OnPropertyChanged("vBCSTRet");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vBCSTRetField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vBCSTRet");
                }
            }
        }

        public bool ShouldSerializevBCSTRet_XML()
        {
            return vBCSTRet.HasValue & (CST == CST_ICMS.CST_60 | CSOSN == CSOSN_ICMS.CST500);
        }

        [XmlIgnore()]
        public double? vICMSSTRet
        {
            get
            {
                return vICMSSTRetField;
            }

            set
            {
                if (vICMSSTRetField is null || vICMSSTRetField.Equals(value) != true)
                {
                    vICMSSTRetField = value;
                    OnPropertyChanged("vICMSSTRet");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vICMSSTRetField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vICMSSTRet");
                }
            }
        }

        public bool ShouldSerializevICMSSTRet_XML()
        {
            return vICMSSTRet.HasValue & (CST == CST_ICMS.CST_60 | CSOSN == CSOSN_ICMS.CST500);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_CST70_ModBC modBC70
        {
            get
            {
                return modBCField70;
            }

            set
            {
                if (modBCField70.Equals(value) != true)
                {
                    modBCField70 = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBC70");
                }
            }
        }

        [XmlIgnore()]
        public DetalhamentoICMS_CST70_ModBCST modBCST70
        {
            get
            {
                return modBCSTField70;
            }

            set
            {
                if (modBCSTField70.Equals(value) != true)
                {
                    modBCSTField70 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST70");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_CST90_ModBC modBC90
        {
            get
            {
                return modBCField90;
            }

            set
            {
                if (modBCField90.Equals(value) != true)
                {
                    modBCField90 = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBC90");
                }
            }
        }

        [XmlIgnore()]
        public DetalhamentoICMS_CST90_ModBCST modBCST90
        {
            get
            {
                return modBCSTField90;
            }

            set
            {
                if (modBCSTField90.Equals(value) != true)
                {
                    modBCSTField90 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST90");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public double? pMVAST
        {
            get
            {
                return pMVASTField;
            }

            set
            {
                if (pMVASTField is null || pMVASTField.Equals(value) != true)
                {
                    pMVASTField = value;
                    OnPropertyChanged("pMVAST");
                }
            }
        }

        public bool ShouldSerializepMVAST()
        {
            return pMVAST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        public double? pRedBCST
        {
            get
            {
                return pRedBCSTField;
            }

            set
            {
                if (pRedBCSTField is null || pRedBCSTField.Equals(value) != true)
                {
                    pRedBCSTField = value;
                    OnPropertyChanged("pRedBCST");
                }
            }
        }

        public bool ShouldSerializepRedBCST()
        {
            return pRedBCST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        [XmlIgnore()]
        public double? vBCST
        {
            get
            {
                return vBCSTField;
            }

            set
            {
                if (vBCSTField is null || vBCSTField.Equals(value) != true)
                {
                    vBCSTField = value;
                    OnPropertyChanged("vBCST");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vBCSTField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vBCST");
                }
            }
        }

        public bool ShouldSerializevBCST_XML()
        {
            return vBCST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        public double? pICMSST
        {
            get
            {
                return pICMSSTField;
            }

            set
            {
                if (pICMSSTField is null || pICMSSTField.Equals(value) != true)
                {
                    pICMSSTField = value;
                    OnPropertyChanged("pICMSST");
                }
            }
        }

        public bool ShouldSerializepICMSST()
        {
            return pICMSST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        [XmlIgnore()]
        public double? vICMSST
        {
            get
            {
                return vICMSSTField;
            }

            set
            {
                if (vICMSSTField is null || vICMSSTField.Equals(value) != true)
                {
                    vICMSSTField = value;
                    OnPropertyChanged("vICMSST");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vICMSSTField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vICMSST");
                }
            }
        }

        public bool ShouldSerializevICMSST_XML()
        {
            return vICMSST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vBCFCPSTField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vBCFCPST");
                }
            }
        }

        public bool ShouldSerializevBCFCPST_XML()
        {
            return vBCFCPST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        [XmlIgnore()]
        public double? vBCFCPST
        {
            get
            {
                return vBCFCPSTField;
            }

            set
            {
                if (vBCFCPSTField is null || vBCFCPSTField.Equals(value) != true)
                {
                    vBCFCPSTField = value;
                    OnPropertyChanged("vBCFCPST");
                }
            }
        }

        public double? pFCPST
        {
            get
            {
                return pFCPSTField;
            }

            set
            {
                if (pFCPSTField is null || pFCPSTField.Equals(value) != true)
                {
                    pFCPSTField = value;
                    OnPropertyChanged("pFCPST");
                }
            }
        }

        public bool ShouldSerializepFCPST()
        {
            return pICMSST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        [XmlIgnore()]
        public double? vFCPST
        {
            get
            {
                return vFCPSTField;
            }

            set
            {
                if (vFCPSTField is null || vFCPSTField.Equals(value) != true)
                {
                    vFCPSTField = value;
                    OnPropertyChanged("vFCPST");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vFCPSTField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vFCPST");
                }
            }
        }

        public bool ShouldSerializevFCPST_XML()
        {
            return vFCPST.HasValue == true & (CST == CST_ICMS.CST_10 | CST == CST_ICMS.CST_30 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST202 | CSOSN == CSOSN_ICMS.CST203 | CSOSN == CSOSN_ICMS.CST900);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public double? pRedBC
        {
            get
            {
                return pRedBCField;
            }

            set
            {
                if (pRedBCField is null || pRedBCField.Equals(value) != true)
                {
                    pRedBCField = value;
                    OnPropertyChanged("pRedBC");
                }
            }
        }

        public bool ShouldSerializepRedBC()
        {
            return pRedBC.HasValue == true & (CST == CST_ICMS.CST_20 | CST == CST_ICMS.CST_51 | CST == CST_ICMS.CST_70 | CST == CST_ICMS.CST_90 | CSOSN == CSOSN_ICMS.CST900);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public DetalhamentoICMS_CST40_MotivoDesoneracao motDesICMS
        {
            get
            {
                return motDesICMSField;
            }

            set
            {
                if (motDesICMSField.Equals(value) != true)
                {
                    motDesICMSField = value;
                    OnPropertyChanged("motDesICMS");
                }
            }
        }

        public bool ShouldSerializemotDesICMS()
        {
            return CST == CST_ICMS.CST_40 | CST == CST_ICMS.CST_41 | CST == CST_ICMS.CST_50;
        }

        public double? vICMSDeson
        {
            get
            {
                return pvICMSDeson;
            }

            set
            {
                if (pvICMSDeson is null || pvICMSDeson.Equals(value) != true)
                {
                    pvICMSDeson = value;
                    OnPropertyChanged("vICMSDeson");
                }
            }
        }

        public bool ShouldSerializevICMSDeson()
        {
            return pvICMSDeson.HasValue & (CST == CST_ICMS.CST_40 | CST == CST_ICMS.CST_41 | CST == CST_ICMS.CST_50);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public double? pCredSN
        {
            get
            {
                return pCredSNField;
            }

            set
            {
                if (pCredSNField is null || pCredSNField.Equals(value) != true)
                {
                    pCredSNField = value;
                    OnPropertyChanged("pCredSN");
                }
            }
        }

        public bool ShouldSerializepCredSN()
        {
            return CSOSN == CSOSN_ICMS.CST101 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST900;
        }

        public double? vCredICMSSN
        {
            get
            {
                return vCredICMSSNField;
            }

            set
            {
                if (vCredICMSSNField is null || vCredICMSSNField.Equals(value) != true)
                {
                    vCredICMSSNField = value;
                    OnPropertyChanged("vCredICMSSN");
                }
            }
        }

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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vCredICMSSNField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vCredICMSSN");
                }
            }
        }

        public bool ShouldSerializevCredICMSSN_XML()
        {
            return CSOSN == CSOSN_ICMS.CST101 | CSOSN == CSOSN_ICMS.CST201 | CSOSN == CSOSN_ICMS.CST900;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMSSN_CSOSN201_ModBCST modBCST201
        {
            get
            {
                return modBCSTField201;
            }

            set
            {
                if (modBCSTField201.Equals(value) != true)
                {
                    modBCSTField201 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST201");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMSSN_CSOSN202_ModBCST modBCST202
        {
            get
            {
                return modBCSTField202;
            }

            set
            {
                if (modBCSTField202.Equals(value) != true)
                {
                    modBCSTField202 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST202");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMSSN_CSOSN900_ModBC modBC900
        {
            get
            {
                return modBCField900;
            }

            set
            {
                if (modBCField900.Equals(value) != true)
                {
                    modBCField900 = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBC900");
                }
            }
        }

        [XmlIgnore()]
        public DetalhamentoICMSSN_CSOSN900_ModBCST modBCST900
        {
            get
            {
                return modBCSTField900;
            }

            set
            {
                if (modBCSTField900.Equals(value) != true)
                {
                    modBCSTField900 = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST900");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public DetalhamentoICMS_Part_ModBC modBCPart
        {
            get
            {
                return (DetalhamentoICMS_Part_ModBC)modBCField;
            }

            set
            {
                if (modBCField.Equals(value) != true)
                {
                    modBCFieldPart = value;
                    modBCField = (int?)value;
                    OnPropertyChanged("modBCPart");
                }
            }
        }

        [XmlIgnore()]
        public DetalhamentoICMS_Part_ModBCST modBCSTPart
        {
            get
            {
                return (DetalhamentoICMS_Part_ModBCST)modBCSTField;
            }

            set
            {
                if (modBCSTField.Equals(value) != true)
                {
                    modBCSTFieldPart = value;
                    modBCSTField = (int?)value;
                    OnPropertyChanged("modBCST");
                }
            }
        }

        public Estado UFST
        {
            get
            {
                return uFSTField;
            }

            set
            {
                if (uFSTField.Equals(value) != true)
                {
                    uFSTField = value;
                    OnPropertyChanged("UFST");
                }
            }
        }

        public bool ShouldSerializeUFST()
        {
            return pBCOpField.HasValue == true;
        }

        public double? pBCOp
        {
            get
            {
                return pBCOpField;
            }

            set
            {
                if (pBCOpField is null || pBCOpField.Equals(value) != true)
                {
                    pBCOpField = value;
                    OnPropertyChanged("pBCOp");
                }
            }
        }

        public bool ShouldSerializepBCOp()
        {
            return pBCOpField.HasValue == true;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlIgnore()]
        public double? vBCSTDest
        {
            get
            {
                return vBCSTDestField;
            }

            set
            {
                if (vBCSTDestField is null || vBCSTDestField.Equals(value) != true)
                {
                    vBCSTDestField = value;
                    OnPropertyChanged("vBCSTDest");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vBCSTDestField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vBCSTDest");
                }
            }
        }

        public bool ShouldSerializevBCSTDest_XML()
        {
            return vBCSTDest.HasValue == true;
        }

        [XmlIgnore()]
        public double? vICMSSTDest
        {
            get
            {
                return vICMSSTDestField;
            }

            set
            {
                if (vICMSSTDestField is null || vICMSSTDestField.Equals(value) != true)
                {
                    vICMSSTDestField = value;
                    OnPropertyChanged("vICMSSTDest");
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
                        if (Information.IsNumeric(value))
                        {
                            if (!value.Contains(".") & !value.Contains(","))
                                value = value + "00"; // fix for 0 decimal values
                            vICMSSTDestField = Conversions.ToDouble(value) / 100d;
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

                    OnPropertyChanged("vICMSSTDest");
                }
            }
        }

        public bool ShouldSerializevICMSSTDest_XML()
        {
            return vICMSSTDest.HasValue == true;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("vBCEfet")]
        public double? vBCEfet
        {
            get
            {
                return vBCEfetField;
            }

            set
            {
                if (vBCEfetField is null || vBCEfetField.Equals(value) != true)
                {
                    vBCEfetField = value;
                    OnPropertyChanged("vBCEfet");
                }
            }
        }

        public bool ShouldSerializevBCEfet()
        {
            return vBCEfetField.HasValue;
        }

        public double? pICMSEfet
        {
            get
            {
                return pICMSEfetField;
            }

            set
            {
                if (pICMSEfetField is null || pICMSEfetField.Equals(value) != true)
                {
                    pICMSEfetField = value;
                    OnPropertyChanged("pICMSEfet");
                }
            }
        }

        public bool ShouldSerializepICMSEfet()
        {
            return pICMSEfetField.HasValue;
        }

        public double? vICMSEfet
        {
            get
            {
                return vICMSEfetField;
            }

            set
            {
                if (vICMSEfetField is null || vICMSEfetField.Equals(value) != true)
                {
                    vICMSEfetField = value;
                    OnPropertyChanged("vIvICMSEfetCMS");
                }
            }
        }

        public bool ShouldSerializevICMSEfet()
        {
            return vICMSEfetField.HasValue;
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
            get
            {
                return modBCField;
            }

            set
            {
                if (modBCField.Equals(value) != true)
                {
                    modBCField = value;
                    OnPropertyChanged("modBC");
                }
            }
        }

        [XmlIgnore()]
        public bool modBCSpecified
        {
            get
            {
                return modBCField.HasValue;
            }

            set
            {
                if (value == false)
                {
                    modBCField = default;
                }
            }
        }

        public bool ShouldSerializemodBC()
        {
            return modBCField.HasValue;
        }

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
            get
            {
                return modBCSTField;
            }

            set
            {
                if (modBCSTField.Equals(value) != true)
                {
                    modBCSTField = value;
                    OnPropertyChanged("modBCST");
                }
            }
        }

        [XmlIgnore()]
        public bool modBCSTSpecified
        {
            get
            {
                return modBCSTField.HasValue;
            }

            set
            {
                if (value == false)
                {
                    modBCSTField = default;
                }
            }
        }

        public bool ShouldSerializemodBCST()
        {
            return modBCSTField.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /// <summary>
    /// Campos referente EC 87/2015
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoICMS_UF_Destinataria : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? vBCUFDestField;
        private double? pFCPUFDestField;
        private double? pICMSUFDestField;
        private double? pICMSInterField;
        private double? pICMSInterPartField;
        private double? vFCPUFDestField;
        private double? vICMSUFDestField;
        private double? vICMSUFRemField;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("vBCUFDest")]
        public double? BaseCalculoUFDestino
        {
            get
            {
                return vBCUFDestField;
            }

            set
            {
                if (vBCUFDestField is null || vBCUFDestField.Equals(value) != true)
                {
                    vBCUFDestField = value;
                    OnPropertyChanged("BaseCalculoUFDestino");
                }
            }
        }

        [XmlElement("pFCPUFDest")]
        public double? PercentualICMS_FCP
        {
            get
            {
                return pFCPUFDestField;
            }

            set
            {
                if (pFCPUFDestField is null || pFCPUFDestField.Equals(value) != true)
                {
                    pFCPUFDestField = value;
                    OnPropertyChanged("PercentualICMS_FCP");
                }
            }
        }

        [XmlElement("pICMSUFDest")]
        public double? PercentualICMS_UFDestino
        {
            get
            {
                return pICMSUFDestField;
            }

            set
            {
                if (pICMSUFDestField is null || pICMSUFDestField.Equals(value) != true)
                {
                    pICMSUFDestField = value;
                    OnPropertyChanged("PercentualICMS_UFDestino");
                }
            }
        }

        [XmlElement("pICMSInter")]
        public double? PercentualICMS_Interno
        {
            get
            {
                return pICMSInterField;
            }

            set
            {
                if (pICMSInterField is null || pICMSInterField.Equals(value) != true)
                {
                    pICMSInterField = value;
                    OnPropertyChanged("PercentualICMS_Interno");
                }
            }
        }

        [XmlElement("pICMSInterPart")]
        public double? PercentualICMS_InternoPartilha
        {
            get
            {
                return pICMSInterPartField;
            }

            set
            {
                if (pICMSInterPartField is null || pICMSInterPartField.Equals(value) != true)
                {
                    pICMSInterPartField = value;
                    OnPropertyChanged("PercentualICMS_InternoPartilha");
                }
            }
        }

        [XmlElement("vFCPUFDest")]
        public double? ValorICMS_FCP
        {
            get
            {
                return vFCPUFDestField;
            }

            set
            {
                if (vFCPUFDestField is null || vFCPUFDestField.Equals(value) != true)
                {
                    vFCPUFDestField = value;
                    OnPropertyChanged("ValorICMS_FCP");
                }
            }
        }

        [XmlElement("vICMSUFDest")]
        public double? ValorICMS_UFDestinataria
        {
            get
            {
                return vICMSUFDestField;
            }

            set
            {
                if (vICMSUFDestField is null || vICMSUFDestField.Equals(value) != true)
                {
                    vICMSUFDestField = value;
                    OnPropertyChanged("ValorICMS_UFDestinataria");
                }
            }
        }

        [XmlElement("vICMSUFRemet")]
        public double? ValorICMS_UFRemetente
        {
            get
            {
                return vICMSUFRemField;
            }

            set
            {
                if (vICMSUFRemField is null || vICMSUFRemField.Equals(value) != true)
                {
                    vICMSUFRemField = value;
                    OnPropertyChanged("ValorICMS_UFRemetente");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("clEnq")]
        public string Classe
        {
            get
            {
                return clEnqField;
            }

            set
            {
                if (clEnqField is null || clEnqField.Equals(value) != true)
                {
                    clEnqField = value;
                    OnPropertyChanged("Classe");
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
            get
            {
                return cNPJProdField;
            }

            set
            {
                if (cNPJProdField is null || cNPJProdField.Equals(value) != true)
                {
                    cNPJProdField = value;
                    OnPropertyChanged("CNPJProdutor");
                }
            }
        }

        [XmlElement("cSelo")]
        public string SeloControle
        {
            get
            {
                return cSeloField;
            }

            set
            {
                if (cSeloField is null || cSeloField.Equals(value) != true)
                {
                    cSeloField = value;
                    OnPropertyChanged("SeloControle");
                }
            }
        }

        [XmlElement("qSelo")]
        public int? SeloQuantidade
        {
            get
            {
                return qSeloField;
            }

            set
            {
                if (qSeloField is null || qSeloField.Equals(value) != true)
                {
                    qSeloField = value;
                    OnPropertyChanged("qSelo");
                }
            }
        }

        public bool ShouldSerializeSeloQuantidade()
        {
            return qSeloField.HasValue;
        }

        [XmlElement("cEnq")]
        public string CodigoEnquadramento
        {
            get
            {
                return cEnqField;
            }

            set
            {
                if (cEnqField is null || cEnqField.Equals(value) != true)
                {
                    cEnqField = value;
                    OnPropertyChanged("CodigoEnquadramento");
                }
            }
        }

        [XmlElement("IPINT", typeof(DetalhamentoIPI_Tributacao))]
        [XmlElement("IPITrib", typeof(DetalhamentoIPI_Tributacao))]
        [XmlChoiceIdentifier("TributacaoIndentifier")]
        public DetalhamentoIPI_Tributacao Tributacao
        {
            get
            {
                return itemField;
            }

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
            get
            {
                return itemElementNameField;
            }

            set
            {
                if (itemElementNameField.Equals(value) != true)
                {
                    itemElementNameField = value;
                    OnPropertyChanged("TributacaoIndentifier");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return cSTField;
            }

            set
            {
                if (cSTField.Equals(value) != true)
                {
                    cSTField = value;
                    OnPropertyChanged("CST");
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
            get
            {
                return _pIPI;
            }

            set
            {
                if (_pIPI is null || _pIPI.Equals(value) != true)
                {
                    _pIPI = value;
                    OnPropertyChanged("Aliquota");
                }
            }
        }

        public bool ShouldSerializeAliquota()
        {
            return Aliquota.HasValue;
        }

        /// <summary>
        /// Informar apenas para IPI calculado por unidade.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("qUnid")]
        public double? Quantidade
        {
            get
            {
                return _qUnid;
            }

            set
            {
                if (_qUnid is null || _qUnid.Equals(value) != true)
                {
                    _qUnid = value;
                    OnPropertyChanged("Quantidade");
                }
            }
        }

        public bool ShouldSerializeQuantidade()
        {
            return Quantidade.HasValue;
        }

        /// <summary>
        /// Informar apenas para IPI calculado por alíquota.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("vBC")]
        public double? BaseDeCalculo
        {
            get
            {
                return _vBC;
            }

            set
            {
                if (_vBC is null || _vBC.Equals(value) != true)
                {
                    _vBC = value;
                    OnPropertyChanged("BaseDeCalculo");
                }
            }
        }

        public bool ShouldSerializeBaseDeCalculo()
        {
            return BaseDeCalculo.HasValue;
        }

        /// <summary>
        /// Informar apenas para IPI calculado por unidade.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [XmlElement("vUnid")]
        public double? ValorPorUnidade
        {
            get
            {
                return _vUnid;
            }

            set
            {
                if (_vUnid is null || _vUnid.Equals(value) != true)
                {
                    _vUnid = value;
                    OnPropertyChanged("ValorPorUnidade");
                }
            }
        }

        public bool ShouldSerializeValorPorUnidade()
        {
            return ValorPorUnidade.HasValue;
        }

        [XmlElement("vIPI")]
        public double? ValorIPI
        {
            get
            {
                return vIPIField;
            }

            set
            {
                if (vIPIField is null || vIPIField.Equals(value) != true)
                {
                    vIPIField = value;
                    OnPropertyChanged("ValorIPI");
                }
            }
        }

        public bool ShouldSerializeValorIPI()
        {
            return ValorIPI.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("vBC");
                }
            }
        }

        public bool ShouldSerializevBC()
        {
            return vBC.HasValue;
        }

        public double? vDespAdu
        {
            get
            {
                return vDespAduField;
            }

            set
            {
                if (vDespAduField is null || vDespAduField.Equals(value) != true)
                {
                    vDespAduField = value;
                    OnPropertyChanged("vDespAdu");
                }
            }
        }

        public bool ShouldSerializevDespAdu()
        {
            return vDespAdu.HasValue;
        }

        public double? vII
        {
            get
            {
                return vIIField;
            }

            set
            {
                if (vIIField is null || vIIField.Equals(value) != true)
                {
                    vIIField = value;
                    OnPropertyChanged("vII");
                }
            }
        }

        public bool ShouldSerializevII()
        {
            return vII.HasValue;
        }

        public double? vIOF
        {
            get
            {
                return vIOFField;
            }

            set
            {
                if (vIOFField is null || vIOFField.Equals(value) != true)
                {
                    vIOFField = value;
                    OnPropertyChanged("vIOF");
                }
            }
        }

        public bool ShouldSerializevIOF()
        {
            return vIOF.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("vBC");
                }
            }
        }

        public double? vAliq
        {
            get
            {
                return vAliqField;
            }

            set
            {
                if (vAliqField is null || vAliqField.Equals(value) != true)
                {
                    vAliqField = value;
                    OnPropertyChanged("vAliq");
                }
            }
        }

        public double? vISSQN
        {
            get
            {
                return vISSQNField;
            }

            set
            {
                if (vISSQNField is null || vISSQNField.Equals(value) != true)
                {
                    vISSQNField = value;
                    OnPropertyChanged("vISSQN");
                }
            }
        }

        public string cMunFG
        {
            get
            {
                return cMunFGField;
            }

            set
            {
                if (cMunFGField is null || cMunFGField.Equals(value) != true)
                {
                    cMunFGField = value;
                    OnPropertyChanged("cMunFG");
                }
            }
        }

        public string cListServ
        {
            get
            {
                return cListServField;
            }

            set
            {
                if (cListServField is null || cListServField.Equals(value) != true)
                {
                    cListServField = value;
                    OnPropertyChanged("cListServ");
                }
            }
        }

        public CST_ISSQN cSitTrib
        {
            get
            {
                return cSitTribField;
            }

            set
            {
                if (cSitTribField.Equals(value) != true)
                {
                    cSitTribField = value;
                    OnPropertyChanged("cSitTrib");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return itemField;
            }

            set
            {
                if (itemField is null || itemField.Equals(value) != true)
                {
                    itemField = value;
                    OnPropertyChanged("Tributacao");
                }
            }
        }

        [XmlIgnore()]
        public Tributacao_PIS_Identifier TributacaoIndentifier
        {
            get
            {
                return itemElementNameField;
            }

            set
            {
                if (itemElementNameField.Equals(value) != true)
                {
                    itemElementNameField = value;
                    OnPropertyChanged("TributacaoIndentifier");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /// <summary>
    /// Clase genérica para tratamento das tributações de PIS (sem ST).
    /// </summary>
    /// <remarks></remarks>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return cSTField;
            }

            set
            {
                if (cSTField.Equals(value) != true)
                {
                    cSTField = value;
                    OnPropertyChanged("CST");
                }
            }
        }

        public double? vBC
        {
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("vBC");
                }
            }
        }

        public bool ShouldSerializevBC()
        {
            return vBC.HasValue;
        }

        public double? pPIS
        {
            get
            {
                return pPISField;
            }

            set
            {
                if (pPISField is null || pPISField.Equals(value) != true)
                {
                    pPISField = value;
                    OnPropertyChanged("pPIS");
                }
            }
        }

        public bool ShouldSerializepPIS()
        {
            return pPIS.HasValue;
        }

        public double? vPIS
        {
            get
            {
                return vPISField;
            }

            set
            {
                if (vPISField is null || vPISField.Equals(value) != true)
                {
                    vPISField = value;
                    OnPropertyChanged("vPIS");
                }
            }
        }

        public bool ShouldSerializevPIS()
        {
            return vPIS.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public double? qBCProd
        {
            get
            {
                return qBCProdField;
            }

            set
            {
                if (qBCProdField is null || qBCProdField.Equals(value) != true)
                {
                    qBCProdField = value;
                    OnPropertyChanged("qBCProd");
                }
            }
        }

        public bool ShouldSerializeqBCProd()
        {
            return qBCProd.HasValue;
        }

        public double? vAliqProd
        {
            get
            {
                return vAliqProdField;
            }

            set
            {
                if (vAliqProdField is null || vAliqProdField.Equals(value) != true)
                {
                    vAliqProdField = value;
                    OnPropertyChanged("vAliqProd");
                }
            }
        }

        public bool ShouldSerializevAliqProd()
        {
            return vAliqProd.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return _pPIS;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _pPIS = value;
                    OnPropertyChanged("Aliquota");
                }
            }
        }

        [XmlElement("qBCProd")]
        public double? QuantidadeVendida
        {
            get
            {
                return _qBCProd;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _qBCProd = value;
                    OnPropertyChanged("QuantidadeVendida");
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
            get
            {
                return _vAliqProd;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _vAliqProd = value;
                    OnPropertyChanged("AliquotaMoeda");
                }
            }
        }

        [XmlElement("vBC")]
        public double? BaseDeCalculo
        {
            get
            {
                return _vBC;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _vBC = value;
                    OnPropertyChanged("BaseDeCalculo");
                }
            }
        }

        [XmlElement("vPIS")]
        public double? ValorPISST
        {
            get
            {
                return vPISField;
            }

            set
            {
                if (vPISField is null || vPISField.Equals(value) != true)
                {
                    vPISField = value;
                    OnPropertyChanged("ValorPISST");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return itemField;
            }

            set
            {
                if (itemField is null || itemField.Equals(value) != true)
                {
                    itemField = value;
                    OnPropertyChanged("Tributacao");
                }
            }
        }

        [XmlIgnore()]
        public Tributacao_COFINS_Identifier TributacaoIndentifier
        {
            get
            {
                return itemElementNameField;
            }

            set
            {
                if (itemElementNameField.Equals(value) != true)
                {
                    itemElementNameField = value;
                    OnPropertyChanged("TributacaoIndentifier");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /// <summary>
    /// Clase genérica para tratamento das tributações de COFINS (sem ST).
    /// </summary>
    /// <remarks></remarks>
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return cSTField;
            }

            set
            {
                if (cSTField.Equals(value) != true)
                {
                    cSTField = value;
                    OnPropertyChanged("CST");
                }
            }
        }

        public double? vBC
        {
            get
            {
                return vBCField;
            }

            set
            {
                if (vBCField is null || vBCField.Equals(value) != true)
                {
                    vBCField = value;
                    OnPropertyChanged("vBC");
                }
            }
        }

        public bool ShouldSerializevBC()
        {
            return vBC.HasValue;
        }

        public double? pCOFINS
        {
            get
            {
                return pCOFINSField;
            }

            set
            {
                if (pCOFINSField is null || pCOFINSField.Equals(value) != true)
                {
                    pCOFINSField = value;
                    OnPropertyChanged("pCOFINS");
                }
            }
        }

        public bool ShouldSerializepCOFINS()
        {
            return pCOFINS.HasValue;
        }

        public double? vCOFINS
        {
            get
            {
                return vCOFINSField;
            }

            set
            {
                if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
                {
                    vCOFINSField = value;
                    OnPropertyChanged("vCOFINS");
                }
            }
        }

        public bool ShouldSerializevCOFINS()
        {
            return vCOFINS.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public double? qBCProd
        {
            get
            {
                return qBCProdField;
            }

            set
            {
                if (qBCProdField is null || qBCProdField.Equals(value) != true)
                {
                    qBCProdField = value;
                    OnPropertyChanged("qBCProd");
                }
            }
        }

        public bool ShouldSerializeqBCProd()
        {
            return qBCProd.HasValue;
        }

        public double? vAliqProd
        {
            get
            {
                return vAliqProdField;
            }

            set
            {
                if (vAliqProdField is null || vAliqProdField.Equals(value) != true)
                {
                    vAliqProdField = value;
                    OnPropertyChanged("vAliqProd");
                }
            }
        }

        public bool ShouldSerializevAliqProd()
        {
            return vAliqProd.HasValue;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return _pCOFINS;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _pCOFINS = value;
                    OnPropertyChanged("Aliquota");
                }
            }
        }

        [XmlElement("qBCProd")]
        public double? QuantidadeVendida
        {
            get
            {
                return _qBCProd;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _qBCProd = value;
                    OnPropertyChanged("QuantidadeVendida");
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
            get
            {
                return _vAliqProd;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _vAliqProd = value;
                    OnPropertyChanged("AliquotaMoeda");
                }
            }
        }

        [XmlElement("vBC")]
        public double? BaseDeCalculo
        {
            get
            {
                return _vBC;
            }

            set
            {
                if (itemsElementNameField is null || itemsElementNameField.Equals(value) != true)
                {
                    _vBC = value;
                    OnPropertyChanged("BaseDeCalculo");
                }
            }
        }

        [XmlElement("vCOFINS")]
        public double? ValorCOFINS
        {
            get
            {
                return vCOFINSField;
            }

            set
            {
                if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
                {
                    vCOFINSField = value;
                    OnPropertyChanged("ValorCOFINS");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoItemArma : INotifyPropertyChanged
    {
        private TipoArma tpArmaField;
        private string nSerieField;
        private string nCanoField;
        private string descrField;

        public TipoArma tpArma
        {
            get
            {
                return tpArmaField;
            }

            set
            {
                if (tpArmaField.Equals(value) != true)
                {
                    tpArmaField = value;
                    OnPropertyChanged("tpArma");
                }
            }
        }

        public string nSerie
        {
            get
            {
                return nSerieField;
            }

            set
            {
                if (nSerieField is null || nSerieField.Equals(value) != true)
                {
                    nSerieField = value;
                    OnPropertyChanged("nSerie");
                }
            }
        }

        public string nCano
        {
            get
            {
                return nCanoField;
            }

            set
            {
                if (nCanoField is null || nCanoField.Equals(value) != true)
                {
                    nCanoField = value;
                    OnPropertyChanged("nCano");
                }
            }
        }

        public string descr
        {
            get
            {
                return descrField;
            }

            set
            {
                if (descrField is null || descrField.Equals(value) != true)
                {
                    descrField = value;
                    OnPropertyChanged("descr");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return cProdANPField;
            }

            set
            {
                if (cProdANPField is null || cProdANPField.Equals(value) != true)
                {
                    cProdANPField = value;
                    OnPropertyChanged("cProdANP");
                }
            }
        }

        [XmlElement("descANP")]
        public string descANP
        {
            get
            {
                return descANPField;
            }

            set
            {
                if (descANPField is null || descANPField.Equals(value) != true)
                {
                    descANPField = value;
                    OnPropertyChanged("descANP");
                }
            }
        }

        [XmlElement("CODIF")]
        public string CODIF
        {
            get
            {
                return cODIFField;
            }

            set
            {
                if (cODIFField is null || cODIFField.Equals(value) != true)
                {
                    cODIFField = value;
                    OnPropertyChanged("CODIF");
                }
            }
        }

        [XmlElement("qTemp")]
        public string qTemp
        {
            get
            {
                return qTempField;
            }

            set
            {
                if (qTempField is null || qTempField.Equals(value) != true)
                {
                    qTempField = value;
                    OnPropertyChanged("qTemp");
                }
            }
        }

        [XmlElement("UFCons")]
        public Estado UFCons
        {
            get
            {
                return uFConsField;
            }

            set
            {
                if (uFConsField.Equals(value) != true)
                {
                    uFConsField = value;
                    OnPropertyChanged("UFCons");
                }
            }
        }

        [XmlElement("CIDE")]
        public DetalhamentoItemCombustivelCIDE CIDE
        {
            get
            {
                return cIDEField;
            }

            set
            {
                if (cIDEField is null || cIDEField.Equals(value) != true)
                {
                    cIDEField = value;
                    OnPropertyChanged("CIDE");
                }
            }
        }

        [XmlElement("encerrante")]
        public DetalhamentoItemCombustivelEncerrante encerrante
        {
            get
            {
                return encerranteField;
            }

            set
            {
                if (encerranteField is null || encerranteField.Equals(value) != true)
                {
                    encerranteField = value;
                    OnPropertyChanged("encerrante");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoItemCombustivelCIDE : INotifyPropertyChanged
    {
        private double? qBCProdField;
        private double? vAliqProdField;
        private double? vCIDEField;

        public string qBCProd
        {
            get
            {
                return Conversions.ToString(qBCProdField);
            }

            set
            {
                if (qBCProdField is null || qBCProdField.Equals(value) != true)
                {
                    qBCProdField = Convert.ToDouble(value);
                    OnPropertyChanged("qBCProd");
                }
            }
        }

        public double? vAliqProd
        {
            get
            {
                return vAliqProdField;
            }

            set
            {
                if (vAliqProdField is null || vAliqProdField.Equals(value) != true)
                {
                    vAliqProdField = value;
                    OnPropertyChanged("vAliqProd");
                }
            }
        }

        public double? vCIDE
        {
            get
            {
                return vCIDEField;
            }

            set
            {
                if (vCIDEField is null || vCIDEField.Equals(value) != true)
                {
                    vCIDEField = value;
                    OnPropertyChanged("vCIDE");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class DetalhamentoItemCombustivelEncerrante : INotifyPropertyChanged
    {
        private string nBicoField;
        private string nBombaField;
        private string nTanqueField;
        private double? vEncIniField;
        private double? vEncFinField;

        public string nBico
        {
            get
            {
                return nBicoField;
            }

            set
            {
                if (nBicoField is null || nBicoField.Equals(value) != true)
                {
                    nBicoField = value;
                    OnPropertyChanged("nBico");
                }
            }
        }

        public string nBomba
        {
            get
            {
                return nBombaField;
            }

            set
            {
                if (nBombaField is null || nBombaField.Equals(value) != true)
                {
                    nBombaField = value;
                    OnPropertyChanged("nBomba");
                }
            }
        }

        public string nTanque
        {
            get
            {
                return nTanqueField;
            }

            set
            {
                if (nTanqueField is null || nTanqueField.Equals(value) != true)
                {
                    nTanqueField = value;
                    OnPropertyChanged("nTanque");
                }
            }
        }

        public double? vEncIni
        {
            get
            {
                return vEncIniField;
            }

            set
            {
                if (vEncIniField is null || vEncIniField.Equals(value) != true)
                {
                    vEncIniField = value;
                    OnPropertyChanged("vEncIni");
                }
            }
        }

        public double? vEncFin
        {
            get
            {
                return vEncFinField;
            }

            set
            {
                if (vEncFinField is null || vEncFinField.Equals(value) != true)
                {
                    vEncFinField = value;
                    OnPropertyChanged("vEncFin");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return nLoteField;
            }

            set
            {
                if (nLoteField is null || nLoteField.Equals(value) != true)
                {
                    nLoteField = value;
                    OnPropertyChanged("nLote");
                }
            }
        }

        public string qLote
        {
            get
            {
                return qLoteField;
            }

            set
            {
                if (qLoteField is null || qLoteField.Equals(value) != true)
                {
                    qLoteField = value;
                    OnPropertyChanged("qLote");
                }
            }
        }

        [XmlIgnore()]
        public DateTime? DataFabricacao
        {
            get
            {
                return dFabField;
            }

            set
            {
                if (dFabField is null || dFabField.Equals(value) != true)
                {
                    dFabField = value;
                    OnPropertyChanged("DataFabricacao");
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
                        dFabField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                    }
                    else
                    {
                        dFabField = default;
                    }

                    OnPropertyChanged("DataFabricacao");
                }
            }
        }

        [XmlIgnore()]
        public DateTime? DataValidade
        {
            get
            {
                return dValField.ToDate(DateFormat.XML_AAAAMMDD);
            }

            set
            {
                if (dValField is null || dValField.Equals(value) != true)
                {
                    dValField = Conversions.ToString(value);
                    OnPropertyChanged("DataValidade");
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
                        dValField = Conversions.ToString(new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2))));
                    }
                    else
                    {
                        dValField = null;
                    }

                    OnPropertyChanged("DataValidade");
                }
            }
        }

        public string cProdANVISA
        {
            get
            {
                return cProdAnvisaField;
            }

            set
            {
                if (cProdAnvisaField is null || cProdAnvisaField.Equals(value) != true)
                {
                    cProdAnvisaField = value;
                    OnPropertyChanged("cProdANVISA");
                }
            }
        }

        public double? vPMC
        {
            get
            {
                return vPMCField;
            }

            set
            {
                if (vPMCField is null || vPMCField.Equals(value) != true)
                {
                    vPMCField = value;
                    OnPropertyChanged("vPMC");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return nLoteField;
            }

            set
            {
                if (nLoteField is null || nLoteField.Equals(value) != true)
                {
                    nLoteField = value;
                    OnPropertyChanged("nLote");
                }
            }
        }

        public string qLote
        {
            get
            {
                return qLoteField;
            }

            set
            {
                if (qLoteField is null || qLoteField.Equals(value) != true)
                {
                    qLoteField = value;
                    OnPropertyChanged("qLote");
                }
            }
        }

        [XmlIgnore()]
        public DateTime? DataFabricacao
        {
            get
            {
                return dFabField;
            }

            set
            {
                if (dFabField is null || dFabField.Equals(value) != true)
                {
                    dFabField = value;
                    OnPropertyChanged("DataFabricacao");
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
                        dFabField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                    }
                    else
                    {
                        dFabField = default;
                    }

                    OnPropertyChanged("DataFabricacao");
                }
            }
        }

        [XmlIgnore()]
        public DateTime? DataValidade
        {
            get
            {
                return dValField.ToDate(DateFormat.XML_AAAAMMDD);
            }

            set
            {
                if (dValField is null || dValField.Equals(value) != true)
                {
                    dValField = Conversions.ToString(value);
                    OnPropertyChanged("DataValidade");
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
                        dValField = Conversions.ToString(new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2))));
                    }
                    else
                    {
                        dValField = null;
                    }

                    OnPropertyChanged("DataValidade");
                }
            }
        }

        public string cProdANVISA
        {
            get
            {
                return cProdAnvisaField;
            }

            set
            {
                if (cProdAnvisaField is null || cProdAnvisaField.Equals(value) != true)
                {
                    cProdAnvisaField = value;
                    OnPropertyChanged("cProdANVISA");
                }
            }
        }

        public double? vPMC
        {
            get
            {
                return vPMCField;
            }

            set
            {
                if (vPMCField is null || vPMCField.Equals(value) != true)
                {
                    vPMCField = value;
                    OnPropertyChanged("vPMC");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
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
            get
            {
                return tpOpField;
            }

            set
            {
                if (tpOpField.Equals(value) != true)
                {
                    tpOpField = value;
                    OnPropertyChanged("tpOp");
                }
            }
        }

        public string chassi
        {
            get
            {
                return chassiField;
            }

            set
            {
                if (chassiField is null || chassiField.Equals(value) != true)
                {
                    chassiField = value;
                    OnPropertyChanged("chassi");
                }
            }
        }

        public string cCor
        {
            get
            {
                return cCorField;
            }

            set
            {
                if (cCorField is null || cCorField.Equals(value) != true)
                {
                    cCorField = value;
                    OnPropertyChanged("cCor");
                }
            }
        }

        public string xCor
        {
            get
            {
                return xCorField;
            }

            set
            {
                if (xCorField is null || xCorField.Equals(value) != true)
                {
                    xCorField = value;
                    OnPropertyChanged("xCor");
                }
            }
        }

        public string pot
        {
            get
            {
                return potField;
            }

            set
            {
                if (potField is null || potField.Equals(value) != true)
                {
                    potField = value;
                    OnPropertyChanged("pot");
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
            get
            {
                return cilinField;
            }

            set
            {
                if (cilinField is null || cilinField.Equals(value) != true)
                {
                    cilinField = value;
                    OnPropertyChanged("cilin");
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
            get
            {
                return pesoLField;
            }

            set
            {
                if (pesoLField is null || pesoLField.Equals(value) != true)
                {
                    pesoLField = value;
                    OnPropertyChanged("pesoL");
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
            get
            {
                return pesoBField;
            }

            set
            {
                if (pesoBField is null || pesoBField.Equals(value) != true)
                {
                    pesoBField = value;
                    OnPropertyChanged("pesoB");
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
            get
            {
                return nSerieField;
            }

            set
            {
                if (nSerieField is null || nSerieField.Equals(value) != true)
                {
                    nSerieField = value;
                    OnPropertyChanged("nSerie");
                }
            }
        }

        public VeiculoTipoCombustivel tpComb
        {
            get
            {
                return tpCombField;
            }

            set
            {
                if (tpCombField.Equals(value) != true)
                {
                    tpCombField = value;
                    OnPropertyChanged("tpComb");
                }
            }
        }

        public string nMotor
        {
            get
            {
                return nMotorField;
            }

            set
            {
                if (nMotorField is null || nMotorField.Equals(value) != true)
                {
                    nMotorField = value;
                    OnPropertyChanged("nMotor");
                }
            }
        }

        public string CMT
        {
            get
            {
                return cMTField;
            }

            set
            {
                if (cMTField is null || cMTField.Equals(value) != true)
                {
                    cMTField = value;
                    OnPropertyChanged("CMT");
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
            get
            {
                return distField;
            }

            set
            {
                if (distField is null || distField.Equals(value) != true)
                {
                    distField = value;
                    OnPropertyChanged("dist");
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
            get
            {
                return anoModField;
            }

            set
            {
                if (anoModField is null || anoModField.Equals(value) != true)
                {
                    anoModField = value;
                    OnPropertyChanged("anoMod");
                }
            }
        }

        public int? anoFab
        {
            get
            {
                return anoFabField;
            }

            set
            {
                if (anoFabField is null || anoFabField.Equals(value) != true)
                {
                    anoFabField = value;
                    OnPropertyChanged("anoFab");
                }
            }
        }

        public string tpPint
        {
            get
            {
                return tpPintField;
            }

            set
            {
                if (tpPintField is null || tpPintField.Equals(value) != true)
                {
                    tpPintField = value;
                    OnPropertyChanged("tpPint");
                }
            }
        }

        public VeiculoTipo tpVeic
        {
            get
            {
                return tpVeicField;
            }

            set
            {
                if (tpVeicField.Equals(value) != true)
                {
                    tpVeicField = value;
                    OnPropertyChanged("tpVeic");
                }
            }
        }

        public VeiculoEspecie espVeic
        {
            get
            {
                return espVeicField;
            }

            set
            {
                if (espVeicField.Equals(value) != true)
                {
                    espVeicField = value;
                    OnPropertyChanged("espVeic");
                }
            }
        }

        public VeiculoCondicaoChassi VIN
        {
            get
            {
                return vINField;
            }

            set
            {
                if (vINField.Equals(value) != true)
                {
                    vINField = value;
                    OnPropertyChanged("VIN");
                }
            }
        }

        public VeiculoCondicao condVeic
        {
            get
            {
                return condVeicField;
            }

            set
            {
                if (condVeicField.Equals(value) != true)
                {
                    condVeicField = value;
                    OnPropertyChanged("condVeic");
                }
            }
        }

        public string cMod
        {
            get
            {
                return cModField;
            }

            set
            {
                if (cModField is null || cModField.Equals(value) != true)
                {
                    cModField = value;
                    OnPropertyChanged("cMod");
                }
            }
        }

        public VeiculoCorDENATRAN cCorDENATRAN
        {
            get
            {
                return cCorDENATRANField;
            }

            set
            {
                if (cCorDENATRANField.Equals(value) != true)
                {
                    cCorDENATRANField = value;
                    OnPropertyChanged("cCorDENATRAN");
                }
            }
        }

        public int? lota
        {
            get
            {
                return lotaField;
            }

            set
            {
                if (lotaField is null || lotaField.Equals(value) != true)
                {
                    lotaField = value;
                    OnPropertyChanged("lota");
                }
            }
        }

        public VeiculoRestricao tpRest
        {
            get
            {
                return tpRestField;
            }

            set
            {
                if (tpRestField.Equals(value) != true)
                {
                    tpRestField = value;
                    OnPropertyChanged("tpRest");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}