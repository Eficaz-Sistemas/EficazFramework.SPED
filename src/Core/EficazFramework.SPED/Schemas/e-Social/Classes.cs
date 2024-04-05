using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.eSocial
{









    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00", IsNullable = false)]
    public partial class S1020 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtTabLotacao evtTabLotacaoField;
        private SignatureType signatureField;

        public eSocialEvtTabLotacao evtTabLotacao
        {
            get
            {
                return evtTabLotacaoField;
            }

            set
            {
                evtTabLotacaoField = value;
                RaisePropertyChanged("evtTabLotacao");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void GeraEventoID()
        {
            evtTabLotacaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabLotacaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabLotacaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1020));
        }

        public override object GetEventoID()
        {
            return evtTabLotacaoField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtTabLotacaoField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class eSocialEvtTabLotacao : ESocialBindableObject
    {
        private IdentificacaoCadastro ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtTabLotacaoInfoLotacao infoLotacaoField;
        private string idField;

        public IdentificacaoCadastro ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        public eSocialEvtTabLotacaoInfoLotacao infoLotacao
        {
            get
            {
                return infoLotacaoField;
            }

            set
            {
                infoLotacaoField = value;
                RaisePropertyChanged("infoLotacao");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class eSocialEvtTabLotacaoInfoLotacao : ESocialBindableObject
    {
        private object itemField;

        [XmlElement("alteracao", typeof(S1020_Alteracao))]
        [XmlElement("exclusao", typeof(S1020_Exclusao))]
        [XmlElement("inclusao", typeof(S1020_Inclusao))]
        public object Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class TIdeLotacao : ESocialBindableObject
    {
        private string codLotacaoField;
        private string iniValidField;
        private string fimValidField;

        public string codLotacao
        {
            get
            {
                return codLotacaoField;
            }

            set
            {
                codLotacaoField = value;
                RaisePropertyChanged("codLotacao");
            }
        }

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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class TDadosLotacao : ESocialBindableObject
    {
        private string tpLotacaoField;
        private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
        private bool tpInscFieldSpecified;
        private string nrInscField;
        private TDadosLotacaoFpasLotacao fpasLotacaoField;
        private TDadosLotacaoInfoEmprParcial infoEmprParcialField;

        public string tpLotacao
        {
            get
            {
                return tpLotacaoField;
            }

            set
            {
                tpLotacaoField = value;
                RaisePropertyChanged("tpLotacao");
            }
        }

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

        [XmlIgnore()]
        public bool tpInscSpecified
        {
            get
            {
                return tpInscFieldSpecified;
            }

            set
            {
                tpInscFieldSpecified = value;
                RaisePropertyChanged("tpInscSpecified");
            }
        }

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

        public TDadosLotacaoFpasLotacao fpasLotacao
        {
            get
            {
                return fpasLotacaoField;
            }

            set
            {
                fpasLotacaoField = value;
                RaisePropertyChanged("fpasLotacao");
            }
        }

        public TDadosLotacaoInfoEmprParcial infoEmprParcial
        {
            get
            {
                return infoEmprParcialField;
            }

            set
            {
                infoEmprParcialField = value;
                RaisePropertyChanged("infoEmprParcial");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class TDadosLotacaoFpasLotacao : ESocialBindableObject
    {
        private string fpasField;
        private string codTercsField;
        private string codTercsSuspField;
        private TDadosLotacaoFpasLotacaoProcJudTerceiro[] infoProcJudTerceirosField;

        [XmlElement(DataType = "integer")]
        public string fpas
        {
            get
            {
                return fpasField;
            }

            set
            {
                fpasField = value;
                RaisePropertyChanged("fpas");
            }
        }

        public string codTercs
        {
            get
            {
                return codTercsField;
            }

            set
            {
                codTercsField = value;
                RaisePropertyChanged("codTercs");
            }
        }

        public string codTercsSusp
        {
            get
            {
                return codTercsSuspField;
            }

            set
            {
                codTercsSuspField = value;
                RaisePropertyChanged("codTercsSusp");
            }
        }

        [XmlArrayItem("procJudTerceiro", IsNullable = false)]
        public TDadosLotacaoFpasLotacaoProcJudTerceiro[] infoProcJudTerceiros
        {
            get
            {
                return infoProcJudTerceirosField;
            }

            set
            {
                infoProcJudTerceirosField = value;
                RaisePropertyChanged("infoProcJudTerceiros");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class TDadosLotacaoFpasLotacaoProcJudTerceiro : ESocialBindableObject
    {
        private string codTercField;
        private string nrProcJudField;
        private string codSuspField;

        public string codTerc
        {
            get
            {
                return codTercField;
            }

            set
            {
                codTercField = value;
                RaisePropertyChanged("codTerc");
            }
        }

        public string nrProcJud
        {
            get
            {
                return nrProcJudField;
            }

            set
            {
                nrProcJudField = value;
                RaisePropertyChanged("nrProcJud");
            }
        }

        [XmlElement(DataType = "integer")]
        public string codSusp
        {
            get
            {
                return codSuspField;
            }

            set
            {
                codSuspField = value;
                RaisePropertyChanged("codSusp");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class TDadosLotacaoInfoEmprParcial : ESocialBindableObject
    {
        private PersonalidadeJuridica tpInscContratField = PersonalidadeJuridica.CNPJ;
        private string nrInscContratField;
        private PersonalidadeJuridica tpInscPropField = PersonalidadeJuridica.CNPJ;
        private string nrInscPropField;

        public PersonalidadeJuridica tpInscContrat
        {
            get
            {
                return tpInscContratField;
            }

            set
            {
                tpInscContratField = value;
                RaisePropertyChanged("tpInscContrat");
            }
        }

        public string nrInscContrat
        {
            get
            {
                return nrInscContratField;
            }

            set
            {
                nrInscContratField = value;
                RaisePropertyChanged("nrInscContrat");
            }
        }

        public PersonalidadeJuridica tpInscProp
        {
            get
            {
                return tpInscPropField;
            }

            set
            {
                tpInscPropField = value;
                RaisePropertyChanged("tpInscProp");
            }
        }

        public string nrInscProp
        {
            get
            {
                return nrInscPropField;
            }

            set
            {
                nrInscPropField = value;
                RaisePropertyChanged("nrInscProp");
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

    // Exclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class S1020_Exclusao : ESocialBindableObject
    {
        private TIdeLotacao ideLotacaoField;

        public TIdeLotacao ideLotacao
        {
            get
            {
                return ideLotacaoField;
            }

            set
            {
                ideLotacaoField = value;
                RaisePropertyChanged("ideLotacao");
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

    // Inclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class S1020_Inclusao : ESocialBindableObject
    {
        private TIdeLotacao ideLotacaoField;
        private TDadosLotacao dadosLotacaoField;

        public TIdeLotacao ideLotacao
        {
            get
            {
                return ideLotacaoField;
            }

            set
            {
                ideLotacaoField = value;
                RaisePropertyChanged("ideLotacao");
            }
        }

        public TDadosLotacao dadosLotacao
        {
            get
            {
                return dadosLotacaoField;
            }

            set
            {
                dadosLotacaoField = value;
                RaisePropertyChanged("dadosLotacao");
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

    // Alteração
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabLotacao/v02_05_00")]
    public partial class S1020_Alteracao : ESocialBindableObject
    {
        private TIdeLotacao ideLotacaoField;
        private TDadosLotacao dadosLotacaoField;
        private IdePeriodo novaValidadeField;

        public TIdeLotacao ideLotacao
        {
            get
            {
                return ideLotacaoField;
            }

            set
            {
                ideLotacaoField = value;
                RaisePropertyChanged("ideLotacao");
            }
        }

        public TDadosLotacao dadosLotacao
        {
            get
            {
                return dadosLotacaoField;
            }

            set
            {
                dadosLotacaoField = value;
                RaisePropertyChanged("dadosLotacao");
            }
        }

        public IdePeriodo novaValidade
        {
            get
            {
                return novaValidadeField;
            }

            set
            {
                novaValidadeField = value;
                RaisePropertyChanged("novaValidade");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00", IsNullable = false)]
    public partial class S1030 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtTabCargo evtTabCargoField;
        private SignatureType signatureField;

        public eSocialEvtTabCargo evtTabCargo
        {
            get
            {
                return evtTabCargoField;
            }

            set
            {
                evtTabCargoField = value;
                RaisePropertyChanged("evtTabCargo");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void GeraEventoID()
        {
            evtTabCargoField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabCargoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabCargoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1030));
        }

        public override object GetEventoID()
        {
            return evtTabCargoField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtTabCargoField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class eSocialEvtTabCargo : ESocialBindableObject
    {
        private IdentificacaoCadastro ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtTabCargoInfoCargo infoCargoField;
        private string idField;

        public IdentificacaoCadastro ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        public eSocialEvtTabCargoInfoCargo infoCargo
        {
            get
            {
                return infoCargoField;
            }

            set
            {
                infoCargoField = value;
                RaisePropertyChanged("infoCargo");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class eSocialEvtTabCargoInfoCargo : ESocialBindableObject
    {
        private object itemField;

        [XmlElement("alteracao", typeof(S1030_Alteracao))]
        [XmlElement("exclusao", typeof(S1030_Exclusao))]
        [XmlElement("inclusao", typeof(S1030_Inclusao))]
        public object Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class TideCargo : ESocialBindableObject
    {
        private string codCargoField;
        private string iniValidField;
        private string fimValidField;

        public string codCargo
        {
            get
            {
                return codCargoField;
            }

            set
            {
                codCargoField = value;
                RaisePropertyChanged("codCargo");
            }
        }

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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class TDadosCargo : ESocialBindableObject
    {
        private string nmCargoField;
        private string codCBOField;
        private TDadosCargoCargoPublico cargoPublicoField;

        public string nmCargo
        {
            get
            {
                return nmCargoField;
            }

            set
            {
                nmCargoField = value;
                RaisePropertyChanged("nmCargo");
            }
        }

        public string codCBO
        {
            get
            {
                return codCBOField;
            }

            set
            {
                codCBOField = value;
                RaisePropertyChanged("codCBO");
            }
        }

        public TDadosCargoCargoPublico cargoPublico
        {
            get
            {
                return cargoPublicoField;
            }

            set
            {
                cargoPublicoField = value;
                RaisePropertyChanged("cargoPublico");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class TDadosCargoCargoPublico : ESocialBindableObject
    {
        private AcumuladorCargo acumCargoField = AcumuladorCargo.NaoAcumulavel;
        private ContagemEspecialCargo contagemEspField = ContagemEspecialCargo.Nao;
        private string dedicExclField;
        private TDadosCargoCargoPublicoLeiCargo leiCargoField;

        public AcumuladorCargo acumCargo
        {
            get
            {
                return acumCargoField;
            }

            set
            {
                acumCargoField = value;
                RaisePropertyChanged("acumCargo");
            }
        }

        public ContagemEspecialCargo contagemEsp
        {
            get
            {
                return contagemEspField;
            }

            set
            {
                contagemEspField = value;
                RaisePropertyChanged("contagemEsp");
            }
        }

        public string dedicExcl
        {
            get
            {
                return dedicExclField;
            }

            set
            {
                dedicExclField = value;
                RaisePropertyChanged("dedicExcl");
            }
        }

        public TDadosCargoCargoPublicoLeiCargo leiCargo
        {
            get
            {
                return leiCargoField;
            }

            set
            {
                leiCargoField = value;
                RaisePropertyChanged("leiCargo");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class TDadosCargoCargoPublicoLeiCargo : ESocialBindableObject
    {
        private string nrLeiField;
        private DateTime dtLeiField;
        private SituacaoCargoPublico sitCargoField = SituacaoCargoPublico.Criacao;

        public string nrLei
        {
            get
            {
                return nrLeiField;
            }

            set
            {
                nrLeiField = value;
                RaisePropertyChanged("nrLei");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtLei
        {
            get
            {
                return dtLeiField;
            }

            set
            {
                dtLeiField = value;
                RaisePropertyChanged("dtLei");
            }
        }

        public SituacaoCargoPublico sitCargo
        {
            get
            {
                return sitCargoField;
            }

            set
            {
                sitCargoField = value;
                RaisePropertyChanged("sitCargo");
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

    // Alteração
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class S1030_Alteracao : ESocialBindableObject
    {
        private TideCargo ideCargoField;
        private TDadosCargo dadosCargoField;
        private IdePeriodo novaValidadeField;

        public TideCargo ideCargo
        {
            get
            {
                return ideCargoField;
            }

            set
            {
                ideCargoField = value;
                RaisePropertyChanged("ideCargo");
            }
        }

        public TDadosCargo dadosCargo
        {
            get
            {
                return dadosCargoField;
            }

            set
            {
                dadosCargoField = value;
                RaisePropertyChanged("dadosCargo");
            }
        }

        public IdePeriodo novaValidade
        {
            get
            {
                return novaValidadeField;
            }

            set
            {
                novaValidadeField = value;
                RaisePropertyChanged("novaValidade");
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

    // Exclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class S1030_Exclusao : ESocialBindableObject
    {
        private TideCargo ideCargoField;

        public TideCargo ideCargo
        {
            get
            {
                return ideCargoField;
            }

            set
            {
                ideCargoField = value;
                RaisePropertyChanged("ideCargo");
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

    // Inclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabCargo/v02_05_00")]
    public partial class S1030_Inclusao : ESocialBindableObject
    {
        private TideCargo ideCargoField;
        private TDadosCargo dadosCargoField;

        public TideCargo ideCargo
        {
            get
            {
                return ideCargoField;
            }

            set
            {
                ideCargoField = value;
                RaisePropertyChanged("ideCargo");
            }
        }

        public TDadosCargo dadosCargo
        {
            get
            {
                return dadosCargoField;
            }

            set
            {
                dadosCargoField = value;
                RaisePropertyChanged("dadosCargo");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00", IsNullable = false)]
    public partial class S1040 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtTabFuncao evtTabFuncaoField;
        private SignatureType signatureField;

        public eSocialEvtTabFuncao evtTabFuncao
        {
            get
            {
                return evtTabFuncaoField;
            }

            set
            {
                evtTabFuncaoField = value;
                RaisePropertyChanged("evtTabFuncao");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void GeraEventoID()
        {
            evtTabFuncaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabFuncaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabFuncaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1040));
        }

        public override object GetEventoID()
        {
            return evtTabFuncaoField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtTabFuncaoField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class eSocialEvtTabFuncao : ESocialBindableObject
    {
        private IdentificacaoCadastro ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtTabFuncaoInfoFuncao infoFuncaoField;
        private string idField;

        public IdentificacaoCadastro ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        public eSocialEvtTabFuncaoInfoFuncao infoFuncao
        {
            get
            {
                return infoFuncaoField;
            }

            set
            {
                infoFuncaoField = value;
                RaisePropertyChanged("infoFuncao");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class eSocialEvtTabFuncaoInfoFuncao : ESocialBindableObject
    {
        private object itemField;

        [XmlElement("alteracao", typeof(S1040_Alteracao))]
        [XmlElement("exclusao", typeof(S1040_Exclusao))]
        [XmlElement("inclusao", typeof(S1040_Inclusao))]
        public object Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class TIdeFuncao : ESocialBindableObject
    {
        private string codFuncaoField;
        private string iniValidField;
        private string fimValidField;

        public string codFuncao
        {
            get
            {
                return codFuncaoField;
            }

            set
            {
                codFuncaoField = value;
                RaisePropertyChanged("codFuncao");
            }
        }

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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class TDadosFuncao : ESocialBindableObject
    {
        private string dscFuncaoField;
        private string codCBOField;

        public string dscFuncao
        {
            get
            {
                return dscFuncaoField;
            }

            set
            {
                dscFuncaoField = value;
                RaisePropertyChanged("dscFuncao");
            }
        }

        public string codCBO
        {
            get
            {
                return codCBOField;
            }

            set
            {
                codCBOField = value;
                RaisePropertyChanged("codCBO");
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

    // Alteração
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class S1040_Alteracao : ESocialBindableObject
    {
        private TIdeFuncao ideFuncaoField;
        private TDadosFuncao dadosFuncaoField;
        private IdePeriodo novaValidadeField;

        public TIdeFuncao ideFuncao
        {
            get
            {
                return ideFuncaoField;
            }

            set
            {
                ideFuncaoField = value;
                RaisePropertyChanged("ideFuncao");
            }
        }

        public TDadosFuncao dadosFuncao
        {
            get
            {
                return dadosFuncaoField;
            }

            set
            {
                dadosFuncaoField = value;
                RaisePropertyChanged("dadosFuncao");
            }
        }

        public IdePeriodo novaValidade
        {
            get
            {
                return novaValidadeField;
            }

            set
            {
                novaValidadeField = value;
                RaisePropertyChanged("novaValidade");
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

    // Exclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class S1040_Exclusao : ESocialBindableObject
    {
        private TIdeFuncao ideFuncaoField;

        public TIdeFuncao ideFuncao
        {
            get
            {
                return ideFuncaoField;
            }

            set
            {
                ideFuncaoField = value;
                RaisePropertyChanged("ideFuncao");
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

    // Inclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabFuncao/v02_05_00")]
    public partial class S1040_Inclusao : ESocialBindableObject
    {
        private TIdeFuncao ideFuncaoField;
        private TDadosFuncao dadosFuncaoField;

        public TIdeFuncao ideFuncao
        {
            get
            {
                return ideFuncaoField;
            }

            set
            {
                ideFuncaoField = value;
                RaisePropertyChanged("ideFuncao");
            }
        }

        public TDadosFuncao dadosFuncao
        {
            get
            {
                return dadosFuncaoField;
            }

            set
            {
                dadosFuncaoField = value;
                RaisePropertyChanged("dadosFuncao");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00", IsNullable = false)]
    public partial class S1050 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtTabHorTur evtTabHorTurField;
        private SignatureType signatureField;

        public eSocialEvtTabHorTur evtTabHorTur
        {
            get
            {
                return evtTabHorTurField;
            }

            set
            {
                evtTabHorTurField = value;
                RaisePropertyChanged("evtTabHorTur");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void GeraEventoID()
        {
            evtTabHorTurField.Id = string.Format("ID{0}{1}{2}", (int)(evtTabHorTurField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabHorTurField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1050));
        }

        public override object GetEventoID()
        {
            return evtTabHorTurField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtTabHorTurField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class eSocialEvtTabHorTur : ESocialBindableObject
    {
        private IdentificacaoCadastro ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtTabHorTurInfoHorContratual infoHorContratualField;
        private string idField;

        public IdentificacaoCadastro ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        public eSocialEvtTabHorTurInfoHorContratual infoHorContratual
        {
            get
            {
                return infoHorContratualField;
            }

            set
            {
                infoHorContratualField = value;
                RaisePropertyChanged("infoHorContratual");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class eSocialEvtTabHorTurInfoHorContratual : ESocialBindableObject
    {
        private object itemField;

        [XmlElement("alteracao", typeof(S1050_Alteracao))]
        [XmlElement("exclusao", typeof(S1050_Exclusao))]
        [XmlElement("inclusao", typeof(S1050_Inclusao))]
        public object Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class TIdeHorContratual : ESocialBindableObject
    {
        private string codHorContratField;
        private string iniValidField;
        private string fimValidField;

        public string codHorContrat
        {
            get
            {
                return codHorContratField;
            }

            set
            {
                codHorContratField = value;
                RaisePropertyChanged("codHorContrat");
            }
        }

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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class TDadosHorContratual : ESocialBindableObject
    {
        private string hrEntrField;
        private string hrSaidaField;
        private string durJornadaField;
        private string perHorFlexivelField;
        private TDadosHorContratualHorarioIntervalo[] horarioIntervaloField;

        public string hrEntr
        {
            get
            {
                return hrEntrField;
            }

            set
            {
                hrEntrField = value;
                RaisePropertyChanged("hrEntr");
            }
        }

        public string hrSaida
        {
            get
            {
                return hrSaidaField;
            }

            set
            {
                hrSaidaField = value;
                RaisePropertyChanged("hrSaida");
            }
        }

        [XmlElement(DataType = "integer")]
        public string durJornada
        {
            get
            {
                return durJornadaField;
            }

            set
            {
                durJornadaField = value;
                RaisePropertyChanged("durJornada");
            }
        }

        public string perHorFlexivel
        {
            get
            {
                return perHorFlexivelField;
            }

            set
            {
                perHorFlexivelField = value;
                RaisePropertyChanged("perHorFlexivel");
            }
        }

        [XmlElement("horarioIntervalo")]
        public TDadosHorContratualHorarioIntervalo[] horarioIntervalo
        {
            get
            {
                return horarioIntervaloField;
            }

            set
            {
                horarioIntervaloField = value;
                RaisePropertyChanged("horarioIntervalo");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class TDadosHorContratualHorarioIntervalo : ESocialBindableObject
    {
        private int tpIntervField;
        private string durIntervField;
        private string iniIntervField;
        private string termIntervField;

        public int tpInterv
        {
            get
            {
                return tpIntervField;
            }

            set
            {
                tpIntervField = value;
                RaisePropertyChanged("tpInterv");
            }
        }

        [XmlElement(DataType = "integer")]
        public string durInterv
        {
            get
            {
                return durIntervField;
            }

            set
            {
                durIntervField = value;
                RaisePropertyChanged("durInterv");
            }
        }

        public string iniInterv
        {
            get
            {
                return iniIntervField;
            }

            set
            {
                iniIntervField = value;
                RaisePropertyChanged("iniInterv");
            }
        }

        public string termInterv
        {
            get
            {
                return termIntervField;
            }

            set
            {
                termIntervField = value;
                RaisePropertyChanged("termInterv");
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

    // Alteração
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class S1050_Alteracao : ESocialBindableObject
    {
        private TIdeHorContratual ideHorContratualField;
        private TDadosHorContratual dadosHorContratualField;
        private IdePeriodo novaValidadeField;

        public TIdeHorContratual ideHorContratual
        {
            get
            {
                return ideHorContratualField;
            }

            set
            {
                ideHorContratualField = value;
                RaisePropertyChanged("ideHorContratual");
            }
        }

        public TDadosHorContratual dadosHorContratual
        {
            get
            {
                return dadosHorContratualField;
            }

            set
            {
                dadosHorContratualField = value;
                RaisePropertyChanged("dadosHorContratual");
            }
        }

        public IdePeriodo novaValidade
        {
            get
            {
                return novaValidadeField;
            }

            set
            {
                novaValidadeField = value;
                RaisePropertyChanged("novaValidade");
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

    // Exclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class S1050_Exclusao : ESocialBindableObject
    {
        private TIdeHorContratual ideHorContratualField;

        public TIdeHorContratual ideHorContratual
        {
            get
            {
                return ideHorContratualField;
            }

            set
            {
                ideHorContratualField = value;
                RaisePropertyChanged("ideHorContratual");
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

    // Inclusão
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtTabHorTur/v02_05_00")]
    public partial class S1050_Inclusao : ESocialBindableObject
    {
        private TIdeHorContratual ideHorContratualField;
        private TDadosHorContratual dadosHorContratualField;

        public TIdeHorContratual ideHorContratual
        {
            get
            {
                return ideHorContratualField;
            }

            set
            {
                ideHorContratualField = value;
                RaisePropertyChanged("ideHorContratual");
            }
        }

        public TDadosHorContratual dadosHorContratual
        {
            get
            {
                return dadosHorContratualField;
            }

            set
            {
                dadosHorContratualField = value;
                RaisePropertyChanged("dadosHorContratual");
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


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtAqProd/v02_05_00", IsNullable = false)]
    public partial class S1250 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtAqProd evtAqProdField;
        private SignatureType signatureField;

        [XmlElement(Order = 0)]
        public eSocialEvtAqProd evtAqProd
        {
            get
            {
                return evtAqProdField;
            }

            set
            {
                evtAqProdField = value;
                RaisePropertyChanged("evtAqProd");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
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

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1250));
        }

        public override void GeraEventoID()
        {
            evtAqProd.Id = string.Format("ID{0}{1}{2}", (int)(evtAqProd?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAqProd?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        public override object GetEventoID()
        {
            return evtAqProd.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtAqProd.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProd : ESocialBindableObject
    {
        private IdeEventoPeriodico ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtAqProdInfoAquisProd infoAquisProdField;
        private string idField;

        [XmlElement(Order = 0)]
        public IdeEventoPeriodico ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        [XmlElement(Order = 1)]
        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        [XmlElement(Order = 2)]
        public eSocialEvtAqProdInfoAquisProd infoAquisProd
        {
            get
            {
                return infoAquisProdField;
            }

            set
            {
                infoAquisProdField = value;
                RaisePropertyChanged("infoAquisProd");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProd : ESocialBindableObject
    {
        private eSocialEvtAqProdInfoAquisProdIdeEstabAdquir ideEstabAdquirField;

        [XmlElement(Order = 0)]
        public eSocialEvtAqProdInfoAquisProdIdeEstabAdquir ideEstabAdquir
        {
            get
            {
                return ideEstabAdquirField;
            }

            set
            {
                ideEstabAdquirField = value;
                RaisePropertyChanged("ideEstabAdquir");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProdIdeEstabAdquir : ESocialBindableObject
    {
        private PersonalidadeJuridica tpInscAdqField;
        private string nrInscAdqField;
        private eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquis[] tpAquisField;

        [XmlElement(Order = 0)]
        public PersonalidadeJuridica tpInscAdq
        {
            get
            {
                return tpInscAdqField;
            }

            set
            {
                tpInscAdqField = value;
                RaisePropertyChanged("tpInscAdq");
            }
        }

        [XmlElement(Order = 1)]
        public string nrInscAdq
        {
            get
            {
                return nrInscAdqField;
            }

            set
            {
                nrInscAdqField = value;
                RaisePropertyChanged("nrInscAdq");
            }
        }

        [XmlElement("tpAquis", Order = 2)]
        public eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquis[] tpAquis
        {
            get
            {
                return tpAquisField;
            }

            set
            {
                tpAquisField = value;
                RaisePropertyChanged("tpAquis");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquis : ESocialBindableObject
    {
        private List<eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutor> ideProdutorField = new List<eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutor>();
        private eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisInfoProcJ[] infoProcJField;
        private IndicadorAquisicaoS1250 indAquisField = IndicadorAquisicaoS1250.ProdRuralPF;
        private decimal vlrTotAquisField;

        [XmlElement("ideProdutor", Order = 0)]
        public List<eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutor> ideProdutor
        {
            get
            {
                return ideProdutorField;
            }

            set
            {
                ideProdutorField = value;
                RaisePropertyChanged("ideProdutor");
            }
        }

        [XmlElement("infoProcJ", Order = 1)]
        public eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisInfoProcJ[] infoProcJ
        {
            get
            {
                return infoProcJField;
            }

            set
            {
                infoProcJField = value;
                RaisePropertyChanged("infoProcJ");
            }
        }

        [XmlAttribute()]
        public IndicadorAquisicaoS1250 indAquis
        {
            get
            {
                return indAquisField;
            }

            set
            {
                indAquisField = value;
                RaisePropertyChanged("indAquis");
            }
        }

        [XmlAttribute()]
        public decimal vlrTotAquis
        {
            get
            {
                return vlrTotAquisField;
            }

            set
            {
                vlrTotAquisField = value;
                RaisePropertyChanged("vlrTotAquis");
            }
        }

        [XmlIgnore()]
        public decimal vrCPDesc
        {
            get
            {
                return ideProdutor.Sum(f => f.vrCPDescPR);
            }
        }

        [XmlIgnore()]
        public decimal vrRatDescPR
        {
            get
            {
                return ideProdutor.Sum(f => f.vrRatDescPR);
            }
        }

        [XmlIgnore()]
        public decimal vrSenarDesc
        {
            get
            {
                return ideProdutor.Sum(f => f.vrSenarDesc);
            }
        }

        public void InvokePropertyChanged(string propName)
        {
            RaisePropertyChanged(propName);
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutor : ESocialBindableObject
    {
        private List<eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorNfs> nfsField = new List<eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorNfs>();
        private eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorInfoProcJud[] infoProcJudField;
        private PersonalidadeJuridica tpInscProdField;
        private string nrInscProdField;
        private decimal vlrBrutoField;
        private decimal vrCPDescPRField;
        private decimal vrRatDescPRField;
        private decimal vrSenarDescField;
        private OpcaoTributacaoPrevidenciaria indOpcCPField = OpcaoTributacaoPrevidenciaria.Comercializacao;

        [XmlElement("nfs", Order = 0)]
        public List<eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorNfs> nfs
        {
            get
            {
                return nfsField;
            }

            set
            {
                nfsField = value;
                RaisePropertyChanged("nfs");
            }
        }

        [XmlElement("infoProcJud", Order = 1)]
        public eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorInfoProcJud[] infoProcJud
        {
            get
            {
                return infoProcJudField;
            }

            set
            {
                infoProcJudField = value;
                RaisePropertyChanged("infoProcJud");
            }
        }

        [XmlAttribute()]
        public PersonalidadeJuridica tpInscProd
        {
            get
            {
                return tpInscProdField;
            }

            set
            {
                tpInscProdField = value;
                RaisePropertyChanged("tpInscProd");
            }
        }

        [XmlAttribute()]
        public string nrInscProd
        {
            get
            {
                return nrInscProdField;
            }

            set
            {
                nrInscProdField = value;
                RaisePropertyChanged("nrInscProd");
            }
        }

        [XmlAttribute()]
        public decimal vlrBruto
        {
            get
            {
                return vlrBrutoField;
            }

            set
            {
                vlrBrutoField = value;
                RaisePropertyChanged("vlrBruto");
            }
        }

        [XmlAttribute()]
        public decimal vrCPDescPR
        {
            get
            {
                return vrCPDescPRField;
            }

            set
            {
                vrCPDescPRField = value;
                RaisePropertyChanged("vrCPDescPR");
            }
        }

        [XmlAttribute()]
        public decimal vrRatDescPR
        {
            get
            {
                return vrRatDescPRField;
            }

            set
            {
                vrRatDescPRField = value;
                RaisePropertyChanged("vrRatDescPR");
            }
        }

        [XmlAttribute()]
        public decimal vrSenarDesc
        {
            get
            {
                return vrSenarDescField;
            }

            set
            {
                vrSenarDescField = value;
                RaisePropertyChanged("vrSenarDesc");
            }
        }

        [XmlAttribute()]
        public OpcaoTributacaoPrevidenciaria indOpcCP
        {
            get
            {
                return indOpcCPField;
            }

            set
            {
                indOpcCPField = value;
                RaisePropertyChanged("indOpcCP");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorNfs : ESocialBindableObject
    {
        private string serieField;
        private string nrDoctoField;
        private DateTime dtEmisNFField;
        private decimal vlrBrutoField;
        private decimal vrCPDescPRField;
        private decimal vrRatDescPRField;
        private decimal vrSenarDescField;

        [XmlAttribute()]
        public string serie
        {
            get
            {
                return serieField;
            }

            set
            {
                serieField = value;
                RaisePropertyChanged("serie");
            }
        }

        [XmlAttribute()]
        public string nrDocto
        {
            get
            {
                return nrDoctoField;
            }

            set
            {
                nrDoctoField = value;
                RaisePropertyChanged("nrDocto");
            }
        }

        [XmlAttribute(DataType = "date")]
        public DateTime dtEmisNF
        {
            get
            {
                return dtEmisNFField;
            }

            set
            {
                dtEmisNFField = value;
                RaisePropertyChanged("dtEmisNF");
            }
        }

        [XmlAttribute()]
        public decimal vlrBruto
        {
            get
            {
                return vlrBrutoField;
            }

            set
            {
                vlrBrutoField = value;
                RaisePropertyChanged("vlrBruto");
            }
        }

        [XmlAttribute()]
        public decimal vrCPDescPR
        {
            get
            {
                return vrCPDescPRField;
            }

            set
            {
                vrCPDescPRField = value;
                RaisePropertyChanged("vrCPDescPR");
            }
        }

        [XmlAttribute()]
        public decimal vrRatDescPR
        {
            get
            {
                return vrRatDescPRField;
            }

            set
            {
                vrRatDescPRField = value;
                RaisePropertyChanged("vrRatDescPR");
            }
        }

        [XmlAttribute()]
        public decimal vrSenarDesc
        {
            get
            {
                return vrSenarDescField;
            }

            set
            {
                vrSenarDescField = value;
                RaisePropertyChanged("vrSenarDesc");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisIdeProdutorInfoProcJud : ESocialBindableObject
    {
        private string nrProcJudField;
        private string codSuspField;
        private decimal vrCPNRetField;
        private decimal vrRatNRetField;
        private decimal vrSenarNRetField;

        [XmlAttribute()]
        public string nrProcJud
        {
            get
            {
                return nrProcJudField;
            }

            set
            {
                nrProcJudField = value;
                RaisePropertyChanged("nrProcJud");
            }
        }

        [XmlAttribute(DataType = "integer")]
        public string codSusp
        {
            get
            {
                return codSuspField;
            }

            set
            {
                codSuspField = value;
                RaisePropertyChanged("codSusp");
            }
        }

        [XmlAttribute()]
        public decimal vrCPNRet
        {
            get
            {
                return vrCPNRetField;
            }

            set
            {
                vrCPNRetField = value;
                RaisePropertyChanged("vrCPNRet");
            }
        }

        [XmlAttribute()]
        public decimal vrRatNRet
        {
            get
            {
                return vrRatNRetField;
            }

            set
            {
                vrRatNRetField = value;
                RaisePropertyChanged("vrRatNRet");
            }
        }

        [XmlAttribute()]
        public decimal vrSenarNRet
        {
            get
            {
                return vrSenarNRetField;
            }

            set
            {
                vrSenarNRetField = value;
                RaisePropertyChanged("vrSenarNRet");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtAqProdInfoAquisProdIdeEstabAdquirTpAquisInfoProcJ : ESocialBindableObject
    {
        private string nrProcJudField;
        private string codSuspField;
        private decimal vrCPNRetField;
        private decimal vrRatNRetField;
        private decimal vrSenarNRetField;

        [XmlAttribute()]
        public string nrProcJud
        {
            get
            {
                return nrProcJudField;
            }

            set
            {
                nrProcJudField = value;
                RaisePropertyChanged("nrProcJud");
            }
        }

        [XmlAttribute(DataType = "integer")]
        public string codSusp
        {
            get
            {
                return codSuspField;
            }

            set
            {
                codSuspField = value;
                RaisePropertyChanged("codSusp");
            }
        }

        [XmlAttribute()]
        public decimal vrCPNRet
        {
            get
            {
                return vrCPNRetField;
            }

            set
            {
                vrCPNRetField = value;
                RaisePropertyChanged("vrCPNRet");
            }
        }

        [XmlAttribute()]
        public decimal vrRatNRet
        {
            get
            {
                return vrRatNRetField;
            }

            set
            {
                vrRatNRetField = value;
                RaisePropertyChanged("vrRatNRet");
            }
        }

        [XmlAttribute()]
        public decimal vrSenarNRet
        {
            get
            {
                return vrSenarNRetField;
            }

            set
            {
                vrSenarNRetField = value;
                RaisePropertyChanged("vrSenarNRet");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtComProd/v02_05_00", IsNullable = false)]
    public partial class S1260 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtComProd evtComProdField;
        private SignatureType signatureField;

        [XmlElement(Order = 0)]
        public eSocialEvtComProd evtComProd
        {
            get
            {
                return evtComProdField;
            }

            set
            {
                evtComProdField = value;
                RaisePropertyChanged("evtComProd");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
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

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1260));
        }

        public override void GeraEventoID()
        {
            evtComProdField.Id = string.Format("ID{0}{1}{2}", (int)(evtComProdField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtComProdField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        public override object GetEventoID()
        {
            return evtComProdField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtComProdField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProd : ESocialBindableObject
    {
        private IdeEventoPeriodico ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtComProdInfoComProd infoComProdField;
        private string idField;

        [XmlElement(Order = 0)]
        public IdeEventoPeriodico ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        [XmlElement(Order = 1)]
        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        [XmlElement(Order = 2)]
        public eSocialEvtComProdInfoComProd infoComProd
        {
            get
            {
                return infoComProdField;
            }

            set
            {
                infoComProdField = value;
                RaisePropertyChanged("infoComProd");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProdInfoComProd : ESocialBindableObject
    {
        private eSocialEvtComProdInfoComProdIdeEstabel ideEstabelField;

        [XmlElement(Order = 0)]
        public eSocialEvtComProdInfoComProdIdeEstabel ideEstabel
        {
            get
            {
                return ideEstabelField;
            }

            set
            {
                ideEstabelField = value;
                RaisePropertyChanged("ideEstabel");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProdInfoComProdIdeEstabel : ESocialBindableObject
    {
        private string nrInscEstabRuralField;
        private ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComerc> tpComercField = new ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComerc>();

        /// <summary>
        /// CAEPF (substituiu o CEI)
        /// </summary>
        /// <returns></returns>
        [XmlElement(Order = 0)]
        public string nrInscEstabRural
        {
            get
            {
                return nrInscEstabRuralField;
            }

            set
            {
                nrInscEstabRuralField = value;
                RaisePropertyChanged("nrInscEstabRural");
            }
        }

        [XmlElement("tpComerc", Order = 1)]
        public ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComerc> tpComerc
        {
            get
            {
                return tpComercField;
            }

            set
            {
                tpComercField = value;
                RaisePropertyChanged("tpComerc");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComerc : ESocialBindableObject
    {
        private IndicadorComercializacaoS1260 indComercField = IndicadorComercializacaoS1260.Vendas_a_PJ;
        private decimal vrTotComField;
        private ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir> ideAdquirField = new ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir>();
        private eSocialEvtComProdInfoComProdIdeEstabelTpComercInfoProcJud[] infoProcJudField;

        [XmlElement(Order = 0)]
        public IndicadorComercializacaoS1260 indComerc
        {
            get
            {
                return indComercField;
            }

            set
            {
                indComercField = value;
                RaisePropertyChanged("indComerc");
            }
        }

        [XmlElement(Order = 1)]
        public decimal vrTotCom
        {
            get
            {
                return vrTotComField;
            }

            set
            {
                vrTotComField = value;
                RaisePropertyChanged("vrTotCom");
            }
        }

        [XmlIgnore()]
        public decimal vrCPDesc
        {
            get
            {
                return ideAdquirField.Sum(f => f.vrCPDesc);
            }
        }

        [XmlIgnore()]
        public decimal vrRatDescPR
        {
            get
            {
                return ideAdquirField.Sum(f => f.vrRatDescPR);
            }
        }

        [XmlIgnore()]
        public decimal vrSenarDesc
        {
            get
            {
                return ideAdquirField.Sum(f => f.vrSenarDesc);
            }
        }


        [XmlElement("ideAdquir", Order = 2)]
        public ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir> ideAdquir
        {
            get
            {
                return ideAdquirField;
            }

            set
            {
                ideAdquirField = value;
                RaisePropertyChanged("ideAdquir");
            }
        }

        [XmlElement("infoProcJud", Order = 3)]
        public eSocialEvtComProdInfoComProdIdeEstabelTpComercInfoProcJud[] infoProcJud
        {
            get
            {
                return infoProcJudField;
            }

            set
            {
                infoProcJudField = value;
                RaisePropertyChanged("infoProcJud");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquir : ESocialBindableObject
    {
        private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
        private string nrInscField;
        private decimal vrComercField;
        private ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs> nfsField = new ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs>();

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

        [XmlElement(Order = 2)]
        public decimal vrComerc
        {
            get
            {
                return vrComercField;
            }

            set
            {
                vrComercField = value;
                RaisePropertyChanged("vrComerc");
            }
        }

        [XmlIgnore()]
        public decimal vrCPDesc
        {
            get
            {
                return nfs.Sum(f => f.vrCPDescPR);
            }
        }

        [XmlIgnore()]
        public decimal vrRatDescPR
        {
            get
            {
                return nfs.Sum(f => f.vrRatDescPR);
            }
        }

        [XmlIgnore()]
        public decimal vrSenarDesc
        {
            get
            {
                return nfs.Sum(f => f.vrSenarDesc);
            }
        }


        [XmlElement("nfs", Order = 3)]
        public ObservableCollection<eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs> nfs
        {
            get
            {
                return nfsField;
            }

            set
            {
                nfsField = value;
                RaisePropertyChanged("nfs");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComercIdeAdquirNfs : ESocialBindableObject
    {
        private string serieField;
        private string nrDoctoField;
        private DateTime dtEmisNFField;
        private decimal vlrBrutoField;
        private decimal vrCPDescPRField;
        private decimal vrRatDescPRField;
        private decimal vrSenarDescField;

        [XmlElement(Order = 0)]
        public string serie
        {
            get
            {
                return serieField;
            }

            set
            {
                serieField = value;
                RaisePropertyChanged("serie");
            }
        }

        [XmlElement(Order = 1)]
        public string nrDocto
        {
            get
            {
                return nrDoctoField;
            }

            set
            {
                nrDoctoField = value;
                RaisePropertyChanged("nrDocto");
            }
        }

        [XmlElement(DataType = "date", Order = 2)]
        public DateTime dtEmisNF
        {
            get
            {
                return dtEmisNFField;
            }

            set
            {
                dtEmisNFField = value;
                RaisePropertyChanged("dtEmisNF");
            }
        }

        [XmlElement(Order = 3)]
        public decimal vlrBruto
        {
            get
            {
                return vlrBrutoField;
            }

            set
            {
                vlrBrutoField = value;
                RaisePropertyChanged("vlrBruto");
            }
        }

        [XmlElement(Order = 4)]
        public decimal vrCPDescPR
        {
            get
            {
                return vrCPDescPRField;
            }

            set
            {
                vrCPDescPRField = value;
                RaisePropertyChanged("vrCPDescPR");
            }
        }

        [XmlElement(Order = 5)]
        public decimal vrRatDescPR
        {
            get
            {
                return vrRatDescPRField;
            }

            set
            {
                vrRatDescPRField = value;
                RaisePropertyChanged("vrRatDescPR");
            }
        }

        [XmlElement(Order = 6)]
        public decimal vrSenarDesc
        {
            get
            {
                return vrSenarDescField;
            }

            set
            {
                vrSenarDescField = value;
                RaisePropertyChanged("vrSenarDesc");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtComProdInfoComProdIdeEstabelTpComercInfoProcJud : ESocialBindableObject
    {
        private sbyte tpProcField;
        private string nrProcField;
        private string codSuspField;
        private decimal vrCPSuspField;
        private bool vrCPSuspFieldSpecified;
        private decimal vrRatSuspField;
        private bool vrRatSuspFieldSpecified;
        private decimal vrSenarSuspField;
        private bool vrSenarSuspFieldSpecified;

        [XmlElement(Order = 0)]
        public sbyte tpProc
        {
            get
            {
                return tpProcField;
            }

            set
            {
                tpProcField = value;
                RaisePropertyChanged("tpProc");
            }
        }

        [XmlElement(Order = 1)]
        public string nrProc
        {
            get
            {
                return nrProcField;
            }

            set
            {
                nrProcField = value;
                RaisePropertyChanged("nrProc");
            }
        }

        [XmlElement(DataType = "integer", Order = 2)]
        public string codSusp
        {
            get
            {
                return codSuspField;
            }

            set
            {
                codSuspField = value;
                RaisePropertyChanged("codSusp");
            }
        }

        [XmlElement(Order = 3)]
        public decimal vrCPSusp
        {
            get
            {
                return vrCPSuspField;
            }

            set
            {
                vrCPSuspField = value;
                RaisePropertyChanged("vrCPSusp");
            }
        }

        [XmlIgnore()]
        public bool vrCPSuspSpecified
        {
            get
            {
                return vrCPSuspFieldSpecified;
            }

            set
            {
                vrCPSuspFieldSpecified = value;
                RaisePropertyChanged("vrCPSuspSpecified");
            }
        }

        [XmlElement(Order = 4)]
        public decimal vrRatSusp
        {
            get
            {
                return vrRatSuspField;
            }

            set
            {
                vrRatSuspField = value;
                RaisePropertyChanged("vrRatSusp");
            }
        }

        [XmlIgnore()]
        public bool vrRatSuspSpecified
        {
            get
            {
                return vrRatSuspFieldSpecified;
            }

            set
            {
                vrRatSuspFieldSpecified = value;
                RaisePropertyChanged("vrRatSuspSpecified");
            }
        }

        [XmlElement(Order = 5)]
        public decimal vrSenarSusp
        {
            get
            {
                return vrSenarSuspField;
            }

            set
            {
                vrSenarSuspField = value;
                RaisePropertyChanged("vrSenarSusp");
            }
        }

        [XmlIgnore()]
        public bool vrSenarSuspSpecified
        {
            get
            {
                return vrSenarSuspFieldSpecified;
            }

            set
            {
                vrSenarSuspFieldSpecified = value;
                RaisePropertyChanged("vrSenarSuspSpecified");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtReabreEvPer/v02_05_00", IsNullable = false)]
    public partial class S1298 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtReabreEvPer evtReabreEvPerField;
        private SignatureType signatureField;

        [XmlElement(Order = 0)]
        public eSocialEvtReabreEvPer evtReabreEvPer
        {
            get
            {
                return evtReabreEvPerField;
            }

            set
            {
                evtReabreEvPerField = value;
                RaisePropertyChanged("evtReabreEvPer");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
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

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1298));
        }

        public override void GeraEventoID()
        {
            evtReabreEvPerField.Id = string.Format("ID{0}{1}{2}", (int)(evtReabreEvPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtReabreEvPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        public override object GetEventoID()
        {
            return evtReabreEvPerField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtReabreEvPerField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtReabreEvPer : ESocialBindableObject
    {
        private eSocialEvtReabreEvPerIdeEvento ideEventoField;
        private Empregador ideEmpregadorField;
        private string idField;

        [XmlElement(Order = 0)]
        public eSocialEvtReabreEvPerIdeEvento ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        [XmlElement(Order = 1)]
        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtReabreEvPerIdeEvento : ESocialBindableObject
    {
        private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
        private string perApurField;
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
        private string verProcField;

        [XmlElement(Order = 0)]
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

        [XmlElement(Order = 1)]
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

        [XmlElement(Order = 2)]
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

        [XmlElement(Order = 3)]
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

        [XmlElement(Order = 4)]
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/evt/evtFechaEvPer/v02_05_00", IsNullable = false)]
    public partial class S1299 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtFechaEvPer evtFechaEvPerField;
        private SignatureType signatureField;

        [XmlElement(Order = 0)]
        public eSocialEvtFechaEvPer evtFechaEvPer
        {
            get
            {
                return evtFechaEvPerField;
            }

            set
            {
                evtFechaEvPerField = value;
                RaisePropertyChanged("evtFechaEvPer");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
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

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S1299));
        }

        public override void GeraEventoID()
        {
            evtFechaEvPerField.Id = string.Format("ID{0}{1}{2}", (int)(evtFechaEvPerField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtFechaEvPerField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        public override object GetEventoID()
        {
            return evtFechaEvPerField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtFechaEvPerField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtFechaEvPer : ESocialBindableObject
    {
        private eSocialEvtFechaEvPerIdeEvento ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtFechaEvPerIdeRespInf ideRespInfField;
        private eSocialEvtFechaEvPerInfoFech infoFechField;
        private string idField;

        [XmlElement(Order = 0)]
        public eSocialEvtFechaEvPerIdeEvento ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        [XmlElement(Order = 1)]
        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        [XmlElement(Order = 2)]
        public eSocialEvtFechaEvPerIdeRespInf ideRespInf
        {
            get
            {
                return ideRespInfField;
            }

            set
            {
                ideRespInfField = value;
                RaisePropertyChanged("ideRespInf");
            }
        }

        [XmlElement(Order = 3)]
        public eSocialEvtFechaEvPerInfoFech infoFech
        {
            get
            {
                return infoFechField;
            }

            set
            {
                infoFechField = value;
                RaisePropertyChanged("infoFech");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtFechaEvPerIdeEvento : ESocialBindableObject
    {
        private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
        private string perApurField;
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
        private string verProcField;

        [XmlElement(Order = 0)]
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

        [XmlElement(Order = 1)]
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

        [XmlElement(Order = 2)]
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

        [XmlElement(Order = 3)]
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

        [XmlElement(Order = 4)]
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtFechaEvPerIdeRespInf : ESocialBindableObject
    {
        private string nmRespField;
        private string cpfRespField;
        private string telefoneField;
        private string emailField;

        [XmlElement(Order = 0)]
        public string nmResp
        {
            get
            {
                return nmRespField;
            }

            set
            {
                nmRespField = value;
                RaisePropertyChanged("nmResp");
            }
        }

        [XmlElement(Order = 1)]
        public string cpfResp
        {
            get
            {
                return cpfRespField;
            }

            set
            {
                cpfRespField = value;
                RaisePropertyChanged("cpfResp");
            }
        }

        [XmlElement(Order = 2)]
        public string telefone
        {
            get
            {
                return telefoneField;
            }

            set
            {
                telefoneField = value;
                RaisePropertyChanged("telefone");
            }
        }

        [XmlElement(Order = 3)]
        public string email
        {
            get
            {
                return emailField;
            }

            set
            {
                emailField = value;
                RaisePropertyChanged("email");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class eSocialEvtFechaEvPerInfoFech : ESocialBindableObject
    {
        private SimNaoString evtRemunField = SimNaoString.Nao;
        private SimNaoString evtPgtosField = SimNaoString.Nao;
        private SimNaoString evtAqProdField = SimNaoString.Nao;
        private SimNaoString evtComProdField = SimNaoString.Nao;
        private SimNaoString evtContratAvNPField = SimNaoString.Nao;
        private SimNaoString evtInfoComplPerField = SimNaoString.Nao;
        private string compSemMovtoField;

        [XmlElement(Order = 0)]
        public SimNaoString evtRemun
        {
            get
            {
                return evtRemunField;
            }

            set
            {
                evtRemunField = value;
                RaisePropertyChanged("evtRemun");
            }
        }

        [XmlElement(Order = 1)]
        public SimNaoString evtPgtos
        {
            get
            {
                return evtPgtosField;
            }

            set
            {
                evtPgtosField = value;
                RaisePropertyChanged("evtPgtos");
            }
        }

        [XmlElement(Order = 2)]
        public SimNaoString evtAqProd
        {
            get
            {
                return evtAqProdField;
            }

            set
            {
                evtAqProdField = value;
                RaisePropertyChanged("evtAqProd");
            }
        }

        [XmlElement(Order = 3)]
        public SimNaoString evtComProd
        {
            get
            {
                return evtComProdField;
            }

            set
            {
                evtComProdField = value;
                RaisePropertyChanged("evtComProd");
            }
        }

        [XmlElement(Order = 4)]
        public SimNaoString evtContratAvNP
        {
            get
            {
                return evtContratAvNPField;
            }

            set
            {
                evtContratAvNPField = value;
                RaisePropertyChanged("evtContratAvNP");
            }
        }

        [XmlElement(Order = 5)]
        public SimNaoString evtInfoComplPer
        {
            get
            {
                return evtInfoComplPerField;
            }

            set
            {
                evtInfoComplPerField = value;
                RaisePropertyChanged("evtInfoComplPer");
            }
        }

        [XmlElement(Order = 6)]
        public string compSemMovto
        {
            get
            {
                return compSemMovtoField;
            }

            set
            {
                compSemMovtoField = value;
                RaisePropertyChanged("compSemMovto");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    [XmlRoot(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00", IsNullable = false)]
    public partial class S2200 : IeSocialEvt, INotifyPropertyChanged
    {
        private eSocialEvtAdmissao evtAdmissaoField;
        private SignatureType signatureField;

        public eSocialEvtAdmissao evtAdmissao
        {
            get
            {
                return evtAdmissaoField;
            }

            set
            {
                evtAdmissaoField = value;
                RaisePropertyChanged("evtAdmissao");
            }
        }

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return signatureField;
            }

            set
            {
                signatureField = value;
                RaisePropertyChanged("Signature");
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

        public override XmlSerializer DefineSerializer()
        {
            return new XmlSerializer(typeof(S2200));
        }

        public override void GeraEventoID()
        {
            evtAdmissaoField.Id = string.Format("ID{0}{1}{2}", (int)(evtAdmissaoField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtAdmissaoField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", eSocialTimeStampUtils.GetTimeStampIDForEvent());
        }

        public override object GetEventoID()
        {
            return evtAdmissaoField.Id;
        }

        public override string ContribuinteCNPJ()
        {
            return evtAdmissaoField.ideEmpregador.nrInsc;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissao : ESocialBindableObject
    {
        private IdeEventoNaoPeriodico ideEventoField;
        private Empregador ideEmpregadorField;
        private eSocialEvtAdmissaoTrabalhador trabalhadorField;
        private eSocialEvtAdmissaoVinculo vinculoField;
        private string idField;

        public IdeEventoNaoPeriodico ideEvento
        {
            get
            {
                return ideEventoField;
            }

            set
            {
                ideEventoField = value;
                RaisePropertyChanged("ideEvento");
            }
        }

        public Empregador ideEmpregador
        {
            get
            {
                return ideEmpregadorField;
            }

            set
            {
                ideEmpregadorField = value;
                RaisePropertyChanged("ideEmpregador");
            }
        }

        public eSocialEvtAdmissaoTrabalhador trabalhador
        {
            get
            {
                return trabalhadorField;
            }

            set
            {
                trabalhadorField = value;
                RaisePropertyChanged("trabalhador");
            }
        }

        public eSocialEvtAdmissaoVinculo vinculo
        {
            get
            {
                return vinculoField;
            }

            set
            {
                vinculoField = value;
                RaisePropertyChanged("vinculo");
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                idField = value;
                RaisePropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoTrabalhador : ESocialBindableObject
    {
        private string cpfTrabField;
        private string nisTrabField;
        private string nmTrabField;
        private string sexoField;
        private RacaCor racaCorField = RacaCor.NaoInformado;
        private EstadoCivil estCivField = EstadoCivil.Solteiro;
        private bool estCivFieldSpecified;
        private GrauInstrucao grauInstrField = GrauInstrucao.Analfabeto;
        private SimNaoString indPriEmprField = SimNaoString.Nao;
        private string nmSocField;
        private eSocialEvtAdmissaoTrabalhadorNascimento nascimentoField;
        private eSocialEvtAdmissaoTrabalhadorDocumentos documentosField;
        private eSocialEvtAdmissaoTrabalhadorEndereco enderecoField;
        private TTrabEstrang trabEstrangeiroField;
        private eSocialEvtAdmissaoTrabalhadorInfoDeficiencia infoDeficienciaField;
        private List<TDependente> dependenteField = new List<TDependente>();
        private eSocialEvtAdmissaoTrabalhadorAposentadoria aposentadoriaField;
        private TContato contatoField;

        public string cpfTrab
        {
            get
            {
                return cpfTrabField;
            }

            set
            {
                cpfTrabField = value;
                RaisePropertyChanged("cpfTrab");
            }
        }

        public string nisTrab
        {
            get
            {
                return nisTrabField;
            }

            set
            {
                nisTrabField = value;
                RaisePropertyChanged("nisTrab");
            }
        }

        public string nmTrab
        {
            get
            {
                return nmTrabField;
            }

            set
            {
                nmTrabField = value;
                RaisePropertyChanged("nmTrab");
            }
        }

        public string sexo
        {
            get
            {
                return sexoField;
            }

            set
            {
                sexoField = value;
                RaisePropertyChanged("sexo");
            }
        }

        public RacaCor racaCor
        {
            get
            {
                return racaCorField;
            }

            set
            {
                racaCorField = value;
                RaisePropertyChanged("racaCor");
            }
        }

        public EstadoCivil estCiv
        {
            get
            {
                return estCivField;
            }

            set
            {
                estCivField = value;
                RaisePropertyChanged("estCiv");
            }
        }

        [XmlIgnore()]
        public bool estCivSpecified
        {
            get
            {
                return estCivFieldSpecified;
            }

            set
            {
                estCivFieldSpecified = value;
                RaisePropertyChanged("estCivSpecified");
            }
        }

        public GrauInstrucao grauInstr
        {
            get
            {
                return grauInstrField;
            }

            set
            {
                grauInstrField = value;
                RaisePropertyChanged("grauInstr");
            }
        }

        public SimNaoString indPriEmpr
        {
            get
            {
                return indPriEmprField;
            }

            set
            {
                indPriEmprField = value;
                RaisePropertyChanged("indPriEmpr");
            }
        }

        public string nmSoc
        {
            get
            {
                return nmSocField;
            }

            set
            {
                nmSocField = value;
                RaisePropertyChanged("nmSoc");
            }
        }

        public eSocialEvtAdmissaoTrabalhadorNascimento nascimento
        {
            get
            {
                return nascimentoField;
            }

            set
            {
                nascimentoField = value;
                RaisePropertyChanged("nascimento");
            }
        }

        public eSocialEvtAdmissaoTrabalhadorDocumentos documentos
        {
            get
            {
                return documentosField;
            }

            set
            {
                documentosField = value;
                RaisePropertyChanged("documentos");
            }
        }

        public eSocialEvtAdmissaoTrabalhadorEndereco endereco
        {
            get
            {
                return enderecoField;
            }

            set
            {
                enderecoField = value;
                RaisePropertyChanged("endereco");
            }
        }

        public TTrabEstrang trabEstrangeiro
        {
            get
            {
                return trabEstrangeiroField;
            }

            set
            {
                trabEstrangeiroField = value;
                RaisePropertyChanged("trabEstrangeiro");
            }
        }

        public eSocialEvtAdmissaoTrabalhadorInfoDeficiencia infoDeficiencia
        {
            get
            {
                return infoDeficienciaField;
            }

            set
            {
                infoDeficienciaField = value;
                RaisePropertyChanged("infoDeficiencia");
            }
        }

        [XmlElement("dependente")]
        public List<TDependente> dependente
        {
            get
            {
                return dependenteField;
            }

            set
            {
                dependenteField = value;
                RaisePropertyChanged("dependente");
            }
        }

        public eSocialEvtAdmissaoTrabalhadorAposentadoria aposentadoria
        {
            get
            {
                return aposentadoriaField;
            }

            set
            {
                aposentadoriaField = value;
                RaisePropertyChanged("aposentadoria");
            }
        }

        public TContato contato
        {
            get
            {
                return contatoField;
            }

            set
            {
                contatoField = value;
                RaisePropertyChanged("contato");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoTrabalhadorNascimento : ESocialBindableObject
    {
        private DateTime dtNasctoField;
        private string codMunicField;
        private UFCadastro ufField;
        private bool ufFieldSpecified;
        private string paisNasctoField;
        private string paisNacField;
        private string nmMaeField;
        private string nmPaiField;

        [XmlElement(DataType = "date")]
        public DateTime dtNascto
        {
            get
            {
                return dtNasctoField;
            }

            set
            {
                dtNasctoField = value;
                RaisePropertyChanged("dtNascto");
            }
        }

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

        [XmlIgnore()]
        public bool ufSpecified
        {
            get
            {
                return ufFieldSpecified;
            }

            set
            {
                ufFieldSpecified = value;
                RaisePropertyChanged("ufSpecified");
            }
        }

        public string paisNascto
        {
            get
            {
                return paisNasctoField;
            }

            set
            {
                paisNasctoField = value;
                RaisePropertyChanged("paisNascto");
            }
        }

        public string paisNac
        {
            get
            {
                return paisNacField;
            }

            set
            {
                paisNacField = value;
                RaisePropertyChanged("paisNac");
            }
        }

        public string nmMae
        {
            get
            {
                return nmMaeField;
            }

            set
            {
                nmMaeField = value;
                RaisePropertyChanged("nmMae");
            }
        }

        public string nmPai
        {
            get
            {
                return nmPaiField;
            }

            set
            {
                nmPaiField = value;
                RaisePropertyChanged("nmPai");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoTrabalhadorDocumentos : ESocialBindableObject
    {
        private TCtps cTPSField;
        private TRic rICField;
        private TRg rgField;
        private TRne rNEField;
        private TOc ocField;
        private TCnh cNHField;

        public TCtps CTPS
        {
            get
            {
                return cTPSField;
            }

            set
            {
                cTPSField = value;
                RaisePropertyChanged("CTPS");
            }
        }

        public TRic RIC
        {
            get
            {
                return rICField;
            }

            set
            {
                rICField = value;
                RaisePropertyChanged("RIC");
            }
        }

        public TRg RG
        {
            get
            {
                return rgField;
            }

            set
            {
                rgField = value;
                RaisePropertyChanged("RG");
            }
        }

        public TRne RNE
        {
            get
            {
                return rNEField;
            }

            set
            {
                rNEField = value;
                RaisePropertyChanged("RNE");
            }
        }

        public TOc OC
        {
            get
            {
                return ocField;
            }

            set
            {
                ocField = value;
                RaisePropertyChanged("OC");
            }
        }

        public TCnh CNH
        {
            get
            {
                return cNHField;
            }

            set
            {
                cNHField = value;
                RaisePropertyChanged("CNH");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TCtps : ESocialBindableObject
    {
        private string nrCtpsField;
        private string serieCtpsField;
        private UFCadastro ufCtpsField;

        public string nrCtps
        {
            get
            {
                return nrCtpsField;
            }

            set
            {
                nrCtpsField = value;
                RaisePropertyChanged("nrCtps");
            }
        }

        public string serieCtps
        {
            get
            {
                return serieCtpsField;
            }

            set
            {
                serieCtpsField = value;
                RaisePropertyChanged("serieCtps");
            }
        }

        public UFCadastro ufCtps
        {
            get
            {
                return ufCtpsField;
            }

            set
            {
                ufCtpsField = value;
                RaisePropertyChanged("ufCtps");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TRic : ESocialBindableObject
    {
        private string nrRicField;
        private string orgaoEmissorField;
        private DateTime dtExpedField;
        private bool dtExpedFieldSpecified;

        public string nrRic
        {
            get
            {
                return nrRicField;
            }

            set
            {
                nrRicField = value;
                RaisePropertyChanged("nrRic");
            }
        }

        public string orgaoEmissor
        {
            get
            {
                return orgaoEmissorField;
            }

            set
            {
                orgaoEmissorField = value;
                RaisePropertyChanged("orgaoEmissor");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtExped
        {
            get
            {
                return dtExpedField;
            }

            set
            {
                dtExpedField = value;
                RaisePropertyChanged("dtExped");
            }
        }

        [XmlIgnore()]
        public bool dtExpedSpecified
        {
            get
            {
                return dtExpedFieldSpecified;
            }

            set
            {
                dtExpedFieldSpecified = value;
                RaisePropertyChanged("dtExpedSpecified");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TRg : ESocialBindableObject
    {
        private string nrRgField;
        private string orgaoEmissorField;
        private DateTime dtExpedField;
        private bool dtExpedFieldSpecified;

        public string nrRg
        {
            get
            {
                return nrRgField;
            }

            set
            {
                nrRgField = value;
                RaisePropertyChanged("nrRg");
            }
        }

        public string orgaoEmissor
        {
            get
            {
                return orgaoEmissorField;
            }

            set
            {
                orgaoEmissorField = value;
                RaisePropertyChanged("orgaoEmissor");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtExped
        {
            get
            {
                return dtExpedField;
            }

            set
            {
                dtExpedField = value;
                RaisePropertyChanged("dtExped");
            }
        }

        [XmlIgnore()]
        public bool dtExpedSpecified
        {
            get
            {
                return dtExpedFieldSpecified;
            }

            set
            {
                dtExpedFieldSpecified = value;
                RaisePropertyChanged("dtExpedSpecified");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TRne : ESocialBindableObject
    {
        private string nrRneField;
        private string orgaoEmissorField;
        private DateTime dtExpedField;
        private bool dtExpedFieldSpecified;

        public string nrRne
        {
            get
            {
                return nrRneField;
            }

            set
            {
                nrRneField = value;
                RaisePropertyChanged("nrRne");
            }
        }

        public string orgaoEmissor
        {
            get
            {
                return orgaoEmissorField;
            }

            set
            {
                orgaoEmissorField = value;
                RaisePropertyChanged("orgaoEmissor");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtExped
        {
            get
            {
                return dtExpedField;
            }

            set
            {
                dtExpedField = value;
                RaisePropertyChanged("dtExped");
            }
        }

        [XmlIgnore()]
        public bool dtExpedSpecified
        {
            get
            {
                return dtExpedFieldSpecified;
            }

            set
            {
                dtExpedFieldSpecified = value;
                RaisePropertyChanged("dtExpedSpecified");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TOc : ESocialBindableObject
    {
        private string nrOcField;
        private string orgaoEmissorField;
        private DateTime dtExpedField;
        private bool dtExpedFieldSpecified;
        private DateTime dtValidField;
        private bool dtValidFieldSpecified;

        public string nrOc
        {
            get
            {
                return nrOcField;
            }

            set
            {
                nrOcField = value;
                RaisePropertyChanged("nrOc");
            }
        }

        public string orgaoEmissor
        {
            get
            {
                return orgaoEmissorField;
            }

            set
            {
                orgaoEmissorField = value;
                RaisePropertyChanged("orgaoEmissor");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtExped
        {
            get
            {
                return dtExpedField;
            }

            set
            {
                dtExpedField = value;
                RaisePropertyChanged("dtExped");
            }
        }

        [XmlIgnore()]
        public bool dtExpedSpecified
        {
            get
            {
                return dtExpedFieldSpecified;
            }

            set
            {
                dtExpedFieldSpecified = value;
                RaisePropertyChanged("dtExpedSpecified");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtValid
        {
            get
            {
                return dtValidField;
            }

            set
            {
                dtValidField = value;
                RaisePropertyChanged("dtValid");
            }
        }

        [XmlIgnore()]
        public bool dtValidSpecified
        {
            get
            {
                return dtValidFieldSpecified;
            }

            set
            {
                dtValidFieldSpecified = value;
                RaisePropertyChanged("dtValidSpecified");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TCnh : ESocialBindableObject
    {
        private string nrRegCnhField;
        private DateTime dtExpedField;
        private bool dtExpedFieldSpecified;
        private UFCadastro ufCnhField;
        private DateTime dtValidField;
        private DateTime dtPriHabField;
        private bool dtPriHabFieldSpecified;
        private string categoriaCnhField;

        public string nrRegCnh
        {
            get
            {
                return nrRegCnhField;
            }

            set
            {
                nrRegCnhField = value;
                RaisePropertyChanged("nrRegCnh");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtExped
        {
            get
            {
                return dtExpedField;
            }

            set
            {
                dtExpedField = value;
                RaisePropertyChanged("dtExped");
            }
        }

        [XmlIgnore()]
        public bool dtExpedSpecified
        {
            get
            {
                return dtExpedFieldSpecified;
            }

            set
            {
                dtExpedFieldSpecified = value;
                RaisePropertyChanged("dtExpedSpecified");
            }
        }

        public UFCadastro ufCnh
        {
            get
            {
                return ufCnhField;
            }

            set
            {
                ufCnhField = value;
                RaisePropertyChanged("ufCnh");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtValid
        {
            get
            {
                return dtValidField;
            }

            set
            {
                dtValidField = value;
                RaisePropertyChanged("dtValid");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtPriHab
        {
            get
            {
                return dtPriHabField;
            }

            set
            {
                dtPriHabField = value;
                RaisePropertyChanged("dtPriHab");
            }
        }

        [XmlIgnore()]
        public bool dtPriHabSpecified
        {
            get
            {
                return dtPriHabFieldSpecified;
            }

            set
            {
                dtPriHabFieldSpecified = value;
                RaisePropertyChanged("dtPriHabSpecified");
            }
        }

        public string categoriaCnh
        {
            get
            {
                return categoriaCnhField;
            }

            set
            {
                categoriaCnhField = value;
                RaisePropertyChanged("categoriaCnh");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoTrabalhadorEndereco : ESocialBindableObject
    {
        private object itemField;

        [XmlElement("brasil", typeof(EnderecoBrasileiro))]
        [XmlElement("exterior", typeof(TEnderecoExterior))]
        public object Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TEnderecoExterior : ESocialBindableObject
    {
        private string paisResidField;
        private string dscLogradField;
        private string nrLogradField;
        private string complementoField;
        private string bairroField;
        private string nmCidField;
        private string codPostalField;

        public string paisResid
        {
            get
            {
                return paisResidField;
            }

            set
            {
                paisResidField = value;
                RaisePropertyChanged("paisResid");
            }
        }

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

        public string nmCid
        {
            get
            {
                return nmCidField;
            }

            set
            {
                nmCidField = value;
                RaisePropertyChanged("nmCid");
            }
        }

        public string codPostal
        {
            get
            {
                return codPostalField;
            }

            set
            {
                codPostalField = value;
                RaisePropertyChanged("codPostal");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TTrabEstrang : ESocialBindableObject
    {
        private DateTime dtChegadaField;
        private bool dtChegadaFieldSpecified;
        private ClasseTrabEstrangeiro classTrabEstrangField = ClasseTrabEstrangeiro.VistoPermanente;
        private SimNaoString casadoBrField = SimNaoString.Nao;
        private SimNaoString filhosBrField = SimNaoString.Nao;

        [XmlElement(DataType = "date")]
        public DateTime dtChegada
        {
            get
            {
                return dtChegadaField;
            }

            set
            {
                dtChegadaField = value;
                RaisePropertyChanged("dtChegada");
            }
        }

        [XmlIgnore()]
        public bool dtChegadaSpecified
        {
            get
            {
                return dtChegadaFieldSpecified;
            }

            set
            {
                dtChegadaFieldSpecified = value;
                RaisePropertyChanged("dtChegadaSpecified");
            }
        }

        public ClasseTrabEstrangeiro classTrabEstrang
        {
            get
            {
                return classTrabEstrangField;
            }

            set
            {
                classTrabEstrangField = value;
                RaisePropertyChanged("classTrabEstrang");
            }
        }

        public SimNaoString casadoBr
        {
            get
            {
                return casadoBrField;
            }

            set
            {
                casadoBrField = value;
                RaisePropertyChanged("casadoBr");
            }
        }

        public SimNaoString filhosBr
        {
            get
            {
                return filhosBrField;
            }

            set
            {
                filhosBrField = value;
                RaisePropertyChanged("filhosBr");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoTrabalhadorInfoDeficiencia : ESocialBindableObject
    {
        private SimNaoString defFisicaField = SimNaoString.Nao;
        private SimNaoString defVisualField = SimNaoString.Nao;
        private SimNaoString defAuditivaField = SimNaoString.Nao;
        private SimNaoString defMentalField = SimNaoString.Nao;
        private SimNaoString defIntelectualField = SimNaoString.Nao;
        private SimNaoString reabReadapField = SimNaoString.Nao;
        private SimNaoString infoCotaField = SimNaoString.Nao;
        private string observacaoField;

        public SimNaoString defFisica
        {
            get
            {
                return defFisicaField;
            }

            set
            {
                defFisicaField = value;
                RaisePropertyChanged("defFisica");
            }
        }

        public SimNaoString defVisual
        {
            get
            {
                return defVisualField;
            }

            set
            {
                defVisualField = value;
                RaisePropertyChanged("defVisual");
            }
        }

        public SimNaoString defAuditiva
        {
            get
            {
                return defAuditivaField;
            }

            set
            {
                defAuditivaField = value;
                RaisePropertyChanged("defAuditiva");
            }
        }

        public SimNaoString defMental
        {
            get
            {
                return defMentalField;
            }

            set
            {
                defMentalField = value;
                RaisePropertyChanged("defMental");
            }
        }

        public SimNaoString defIntelectual
        {
            get
            {
                return defIntelectualField;
            }

            set
            {
                defIntelectualField = value;
                RaisePropertyChanged("defIntelectual");
            }
        }

        public SimNaoString reabReadap
        {
            get
            {
                return reabReadapField;
            }

            set
            {
                reabReadapField = value;
                RaisePropertyChanged("reabReadap");
            }
        }

        public SimNaoString infoCota
        {
            get
            {
                return infoCotaField;
            }

            set
            {
                infoCotaField = value;
                RaisePropertyChanged("infoCota");
            }
        }

        public string observacao
        {
            get
            {
                return observacaoField;
            }

            set
            {
                observacaoField = value;
                RaisePropertyChanged("observacao");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TDependente : ESocialBindableObject
    {
        private string tpDepField;
        private string nmDepField;
        private DateTime dtNasctoField;
        private string cpfDepField;
        private SimNaoString depIRRFField = SimNaoString.Nao;
        private SimNaoString depSFField = SimNaoString.Nao;
        private SimNaoString incTrabField = SimNaoString.Nao;

        public string tpDep
        {
            get
            {
                return tpDepField;
            }

            set
            {
                tpDepField = value;
                RaisePropertyChanged("tpDep");
            }
        }

        public string nmDep
        {
            get
            {
                return nmDepField;
            }

            set
            {
                nmDepField = value;
                RaisePropertyChanged("nmDep");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtNascto
        {
            get
            {
                return dtNasctoField;
            }

            set
            {
                dtNasctoField = value;
                RaisePropertyChanged("dtNascto");
            }
        }

        public string cpfDep
        {
            get
            {
                return cpfDepField;
            }

            set
            {
                cpfDepField = value;
                RaisePropertyChanged("cpfDep");
            }
        }

        public SimNaoString depIRRF
        {
            get
            {
                return depIRRFField;
            }

            set
            {
                depIRRFField = value;
                RaisePropertyChanged("depIRRF");
            }
        }

        public SimNaoString depSF
        {
            get
            {
                return depSFField;
            }

            set
            {
                depSFField = value;
                RaisePropertyChanged("depSF");
            }
        }

        public SimNaoString incTrab
        {
            get
            {
                return incTrabField;
            }

            set
            {
                incTrabField = value;
                RaisePropertyChanged("incTrab");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoTrabalhadorAposentadoria : ESocialBindableObject
    {
        private SimNaoString trabAposentField = SimNaoString.Nao;

        public SimNaoString trabAposent
        {
            get
            {
                return trabAposentField;
            }

            set
            {
                trabAposentField = value;
                RaisePropertyChanged("trabAposent");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TContato : ESocialBindableObject
    {
        private string fonePrincField;
        private string foneAlternatField;
        private string emailPrincField;
        private string emailAlternatField;

        public string fonePrinc
        {
            get
            {
                return fonePrincField;
            }

            set
            {
                fonePrincField = value;
                RaisePropertyChanged("fonePrinc");
            }
        }

        public string foneAlternat
        {
            get
            {
                return foneAlternatField;
            }

            set
            {
                foneAlternatField = value;
                RaisePropertyChanged("foneAlternat");
            }
        }

        public string emailPrinc
        {
            get
            {
                return emailPrincField;
            }

            set
            {
                emailPrincField = value;
                RaisePropertyChanged("emailPrinc");
            }
        }

        public string emailAlternat
        {
            get
            {
                return emailAlternatField;
            }

            set
            {
                emailAlternatField = value;
                RaisePropertyChanged("emailAlternat");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculo : ESocialBindableObject
    {
        private string matriculaField;
        private VinculoTrabalhista tpRegTrabField = VinculoTrabalhista.CLT;
        private RegimePrevidenciario tpRegPrevField = RegimePrevidenciario.RGPS;
        private string nrRecInfPrelimField;
        private SimNaoString cadIniField = SimNaoString.Nao;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrab infoRegimeTrabField;
        private eSocialEvtAdmissaoVinculoInfoContrato infoContratoField;
        private eSocialEvtAdmissaoVinculoSucessaoVinc sucessaoVincField;
        private eSocialEvtAdmissaoVinculoTransfDom transfDomField;
        private eSocialEvtAdmissaoVinculoMudancaCPF mudancaCPFField;
        private eSocialEvtAdmissaoVinculoAfastamento afastamentoField;
        private eSocialEvtAdmissaoVinculoDesligamento desligamentoField;

        public string matricula
        {
            get
            {
                return matriculaField;
            }

            set
            {
                matriculaField = value;
                RaisePropertyChanged("matricula");
            }
        }

        public VinculoTrabalhista tpRegTrab
        {
            get
            {
                return tpRegTrabField;
            }

            set
            {
                tpRegTrabField = value;
                RaisePropertyChanged("tpRegTrab");
            }
        }

        public RegimePrevidenciario tpRegPrev
        {
            get
            {
                return tpRegPrevField;
            }

            set
            {
                tpRegPrevField = value;
                RaisePropertyChanged("tpRegPrev");
            }
        }

        public string nrRecInfPrelim
        {
            get
            {
                return nrRecInfPrelimField;
            }

            set
            {
                nrRecInfPrelimField = value;
                RaisePropertyChanged("nrRecInfPrelim");
            }
        }

        public SimNaoString cadIni
        {
            get
            {
                return cadIniField;
            }

            set
            {
                cadIniField = value;
                RaisePropertyChanged("cadIni");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoRegimeTrab infoRegimeTrab
        {
            get
            {
                return infoRegimeTrabField;
            }

            set
            {
                infoRegimeTrabField = value;
                RaisePropertyChanged("infoRegimeTrab");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoContrato infoContrato
        {
            get
            {
                return infoContratoField;
            }

            set
            {
                infoContratoField = value;
                RaisePropertyChanged("infoContrato");
            }
        }

        public eSocialEvtAdmissaoVinculoSucessaoVinc sucessaoVinc
        {
            get
            {
                return sucessaoVincField;
            }

            set
            {
                sucessaoVincField = value;
                RaisePropertyChanged("sucessaoVinc");
            }
        }

        public eSocialEvtAdmissaoVinculoTransfDom transfDom
        {
            get
            {
                return transfDomField;
            }

            set
            {
                transfDomField = value;
                RaisePropertyChanged("transfDom");
            }
        }

        public eSocialEvtAdmissaoVinculoMudancaCPF mudancaCPF
        {
            get
            {
                return mudancaCPFField;
            }

            set
            {
                mudancaCPFField = value;
                RaisePropertyChanged("mudancaCPF");
            }
        }

        public eSocialEvtAdmissaoVinculoAfastamento afastamento
        {
            get
            {
                return afastamentoField;
            }

            set
            {
                afastamentoField = value;
                RaisePropertyChanged("afastamento");
            }
        }

        public eSocialEvtAdmissaoVinculoDesligamento desligamento
        {
            get
            {
                return desligamentoField;
            }

            set
            {
                desligamentoField = value;
                RaisePropertyChanged("desligamento");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrab : ESocialBindableObject
    {
        private object itemField;

        [XmlElement("infoCeletista", typeof(eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletista))]
        [XmlElement("infoEstatutario", typeof(eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutario))]
        public object Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletista : ESocialBindableObject
    {
        private DateTime dtAdmField;
        private TipoAdmissaoCLT tpAdmissaoField = TipoAdmissaoCLT.Admissao;
        private IndicadorAdmissao indAdmissaoField = IndicadorAdmissao.Normal;
        private VinculoRegimeJornada tpRegJorField = VinculoRegimeJornada.SubHorarioTrabalho;
        private NaturezaAtividade natAtividadeField = NaturezaAtividade.Urbano;
        private int dtBaseField;
        private bool dtBaseFieldSpecified;
        private string cnpjSindCategProfField;
        private TFgts fGTSField;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporario trabTemporarioField;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaAprend aprendField;

        [XmlElement(DataType = "date")]
        public DateTime dtAdm
        {
            get
            {
                return dtAdmField;
            }

            set
            {
                dtAdmField = value;
                RaisePropertyChanged("dtAdm");
            }
        }

        public TipoAdmissaoCLT tpAdmissao
        {
            get
            {
                return tpAdmissaoField;
            }

            set
            {
                tpAdmissaoField = value;
                RaisePropertyChanged("tpAdmissao");
            }
        }

        public IndicadorAdmissao indAdmissao
        {
            get
            {
                return indAdmissaoField;
            }

            set
            {
                indAdmissaoField = value;
                RaisePropertyChanged("indAdmissao");
            }
        }

        public VinculoRegimeJornada tpRegJor
        {
            get
            {
                return tpRegJorField;
            }

            set
            {
                tpRegJorField = value;
                RaisePropertyChanged("tpRegJor");
            }
        }

        public NaturezaAtividade natAtividade
        {
            get
            {
                return natAtividadeField;
            }

            set
            {
                natAtividadeField = value;
                RaisePropertyChanged("natAtividade");
            }
        }

        public sbyte dtBase
        {
            get
            {
                return (sbyte)dtBaseField;
            }

            set
            {
                dtBaseField = value;
                RaisePropertyChanged("dtBase");
            }
        }

        [XmlIgnore()]
        public bool dtBaseSpecified
        {
            get
            {
                return dtBaseFieldSpecified;
            }

            set
            {
                dtBaseFieldSpecified = value;
                RaisePropertyChanged("dtBaseSpecified");
            }
        }

        public string cnpjSindCategProf
        {
            get
            {
                return cnpjSindCategProfField;
            }

            set
            {
                cnpjSindCategProfField = value;
                RaisePropertyChanged("cnpjSindCategProf");
            }
        }

        public TFgts FGTS
        {
            get
            {
                return fGTSField;
            }

            set
            {
                fGTSField = value;
                RaisePropertyChanged("FGTS");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporario trabTemporario
        {
            get
            {
                return trabTemporarioField;
            }

            set
            {
                trabTemporarioField = value;
                RaisePropertyChanged("trabTemporario");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaAprend aprend
        {
            get
            {
                return aprendField;
            }

            set
            {
                aprendField = value;
                RaisePropertyChanged("aprend");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TFgts : ESocialBindableObject
    {
        private OpcaoFGTS opcFGTSField = OpcaoFGTS.Optante;
        private DateTime dtOpcFGTSField;
        private bool dtOpcFGTSFieldSpecified;

        public OpcaoFGTS opcFGTS
        {
            get
            {
                return opcFGTSField;
            }

            set
            {
                opcFGTSField = value;
                RaisePropertyChanged("opcFGTS");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtOpcFGTS
        {
            get
            {
                return dtOpcFGTSField;
            }

            set
            {
                dtOpcFGTSField = value;
                RaisePropertyChanged("dtOpcFGTS");
            }
        }

        [XmlIgnore()]
        public bool dtOpcFGTSSpecified
        {
            get
            {
                return dtOpcFGTSFieldSpecified;
            }

            set
            {
                dtOpcFGTSFieldSpecified = value;
                RaisePropertyChanged("dtOpcFGTSSpecified");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporario : ESocialBindableObject
    {
        private TrabTemporarioHipotese hipLegField = TrabTemporarioHipotese.DemandaComplementar;
        private string justContrField;
        private TrabTemporarioTpInclusao tpInclContrField = TrabTemporarioTpInclusao.Superior3Meses;
        private bool tpInclContrFieldSpecified;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServ ideTomadorServField;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTrabSubstituido[] ideTrabSubstituidoField;

        public TrabTemporarioHipotese hipLeg
        {
            get
            {
                return hipLegField;
            }

            set
            {
                hipLegField = value;
                RaisePropertyChanged("hipLeg");
            }
        }

        public string justContr
        {
            get
            {
                return justContrField;
            }

            set
            {
                justContrField = value;
                RaisePropertyChanged("justContr");
            }
        }

        public TrabTemporarioTpInclusao tpInclContr
        {
            get
            {
                return tpInclContrField;
            }

            set
            {
                tpInclContrField = value;
                RaisePropertyChanged("tpInclContr");
            }
        }

        [XmlIgnore()]
        public bool tpInclContrSpecified
        {
            get
            {
                return tpInclContrFieldSpecified;
            }

            set
            {
                tpInclContrFieldSpecified = value;
                RaisePropertyChanged("tpInclContrSpecified");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServ ideTomadorServ
        {
            get
            {
                return ideTomadorServField;
            }

            set
            {
                ideTomadorServField = value;
                RaisePropertyChanged("ideTomadorServ");
            }
        }

        [XmlElement("ideTrabSubstituido")]
        public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTrabSubstituido[] ideTrabSubstituido
        {
            get
            {
                return ideTrabSubstituidoField;
            }

            set
            {
                ideTrabSubstituidoField = value;
                RaisePropertyChanged("ideTrabSubstituido");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServ : ESocialBindableObject
    {
        private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
        private string nrInscField;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServIdeEstabVinc ideEstabVincField;

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

        public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServIdeEstabVinc ideEstabVinc
        {
            get
            {
                return ideEstabVincField;
            }

            set
            {
                ideEstabVincField = value;
                RaisePropertyChanged("ideEstabVinc");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTomadorServIdeEstabVinc : ESocialBindableObject
    {
        private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
        private string nrInscField;

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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaTrabTemporarioIdeTrabSubstituido : ESocialBindableObject
    {
        private string cpfTrabSubstField;

        public string cpfTrabSubst
        {
            get
            {
                return cpfTrabSubstField;
            }

            set
            {
                cpfTrabSubstField = value;
                RaisePropertyChanged("cpfTrabSubst");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoCeletistaAprend : ESocialBindableObject
    {
        private PersonalidadeJuridica tpInscField;
        private string nrInscField;

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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutario : ESocialBindableObject
    {
        private IndicadorAdmissaoEstatutario indProvimField = IndicadorAdmissaoEstatutario.Normal;
        private TipoProvimentoEstatutario tpProvField = TipoProvimentoEstatutario.NomeacaoEfetivo;
        private DateTime dtNomeacaoField;
        private DateTime dtPosseField;
        private DateTime dtExercicioField;
        private PlanoSegregacaoMassa tpPlanRPField = PlanoSegregacaoMassa.PrevUnico;
        private bool tpPlanRPFieldSpecified;
        private eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutarioInfoDecJud infoDecJudField;

        public IndicadorAdmissaoEstatutario indProvim
        {
            get
            {
                return indProvimField;
            }

            set
            {
                indProvimField = value;
                RaisePropertyChanged("indProvim");
            }
        }

        public TipoProvimentoEstatutario tpProv
        {
            get
            {
                return tpProvField;
            }

            set
            {
                tpProvField = value;
                RaisePropertyChanged("tpProv");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtNomeacao
        {
            get
            {
                return dtNomeacaoField;
            }

            set
            {
                dtNomeacaoField = value;
                RaisePropertyChanged("dtNomeacao");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtPosse
        {
            get
            {
                return dtPosseField;
            }

            set
            {
                dtPosseField = value;
                RaisePropertyChanged("dtPosse");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtExercicio
        {
            get
            {
                return dtExercicioField;
            }

            set
            {
                dtExercicioField = value;
                RaisePropertyChanged("dtExercicio");
            }
        }

        public PlanoSegregacaoMassa tpPlanRP
        {
            get
            {
                return tpPlanRPField;
            }

            set
            {
                tpPlanRPField = value;
                RaisePropertyChanged("tpPlanRP");
            }
        }

        [XmlIgnore()]
        public bool tpPlanRPSpecified
        {
            get
            {
                return tpPlanRPFieldSpecified;
            }

            set
            {
                tpPlanRPFieldSpecified = value;
                RaisePropertyChanged("tpPlanRPSpecified");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutarioInfoDecJud infoDecJud
        {
            get
            {
                return infoDecJudField;
            }

            set
            {
                infoDecJudField = value;
                RaisePropertyChanged("infoDecJud");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoRegimeTrabInfoEstatutarioInfoDecJud : ESocialBindableObject
    {
        private string nrProcJudField;

        public string nrProcJud
        {
            get
            {
                return nrProcJudField;
            }

            set
            {
                nrProcJudField = value;
                RaisePropertyChanged("nrProcJud");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContrato : ESocialBindableObject
    {
        private string codCargoField;
        private string codFuncaoField;
        private string codCategField;
        private string codCarreiraField;
        private DateTime dtIngrCarrField;
        private bool dtIngrCarrFieldSpecified;
        private TRemun remuneracaoField;
        private eSocialEvtAdmissaoVinculoInfoContratoDuracao duracaoField;
        private eSocialEvtAdmissaoVinculoInfoContratoLocalTrabalho localTrabalhoField;
        private eSocialEvtAdmissaoVinculoInfoContratoHorContratual horContratualField;
        private eSocialEvtAdmissaoVinculoInfoContratoFiliacaoSindical[] filiacaoSindicalField;
        private eSocialEvtAdmissaoVinculoInfoContratoAlvaraJudicial alvaraJudicialField;
        private eSocialEvtAdmissaoVinculoInfoContratoObservacoes[] observacoesField;

        public string codCargo
        {
            get
            {
                return codCargoField;
            }

            set
            {
                codCargoField = value;
                RaisePropertyChanged("codCargo");
            }
        }

        public string codFuncao
        {
            get
            {
                return codFuncaoField;
            }

            set
            {
                codFuncaoField = value;
                RaisePropertyChanged("codFuncao");
            }
        }

        [XmlElement(DataType = "integer")]
        public string codCateg
        {
            get
            {
                return codCategField;
            }

            set
            {
                codCategField = value;
                RaisePropertyChanged("codCateg");
            }
        }

        public string codCarreira
        {
            get
            {
                return codCarreiraField;
            }

            set
            {
                codCarreiraField = value;
                RaisePropertyChanged("codCarreira");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtIngrCarr
        {
            get
            {
                return dtIngrCarrField;
            }

            set
            {
                dtIngrCarrField = value;
                RaisePropertyChanged("dtIngrCarr");
            }
        }

        [XmlIgnore()]
        public bool dtIngrCarrSpecified
        {
            get
            {
                return dtIngrCarrFieldSpecified;
            }

            set
            {
                dtIngrCarrFieldSpecified = value;
                RaisePropertyChanged("dtIngrCarrSpecified");
            }
        }

        public TRemun remuneracao
        {
            get
            {
                return remuneracaoField;
            }

            set
            {
                remuneracaoField = value;
                RaisePropertyChanged("remuneracao");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoContratoDuracao duracao
        {
            get
            {
                return duracaoField;
            }

            set
            {
                duracaoField = value;
                RaisePropertyChanged("duracao");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoContratoLocalTrabalho localTrabalho
        {
            get
            {
                return localTrabalhoField;
            }

            set
            {
                localTrabalhoField = value;
                RaisePropertyChanged("localTrabalho");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoContratoHorContratual horContratual
        {
            get
            {
                return horContratualField;
            }

            set
            {
                horContratualField = value;
                RaisePropertyChanged("horContratual");
            }
        }

        [XmlElement("filiacaoSindical")]
        public eSocialEvtAdmissaoVinculoInfoContratoFiliacaoSindical[] filiacaoSindical
        {
            get
            {
                return filiacaoSindicalField;
            }

            set
            {
                filiacaoSindicalField = value;
                RaisePropertyChanged("filiacaoSindical");
            }
        }

        public eSocialEvtAdmissaoVinculoInfoContratoAlvaraJudicial alvaraJudicial
        {
            get
            {
                return alvaraJudicialField;
            }

            set
            {
                alvaraJudicialField = value;
                RaisePropertyChanged("alvaraJudicial");
            }
        }

        [XmlElement("observacoes")]
        public eSocialEvtAdmissaoVinculoInfoContratoObservacoes[] observacoes
        {
            get
            {
                return observacoesField;
            }

            set
            {
                observacoesField = value;
                RaisePropertyChanged("observacoes");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TRemun : ESocialBindableObject
    {
        private decimal vrSalFxField;
        private UnidadeSalarial undSalFixoField = UnidadeSalarial.Mes;
        private string dscSalVarField;

        public decimal vrSalFx
        {
            get
            {
                return vrSalFxField;
            }

            set
            {
                vrSalFxField = value;
                RaisePropertyChanged("vrSalFx");
            }
        }

        public UnidadeSalarial undSalFixo
        {
            get
            {
                return undSalFixoField;
            }

            set
            {
                undSalFixoField = value;
                RaisePropertyChanged("undSalFixo");
            }
        }

        public string dscSalVar
        {
            get
            {
                return dscSalVarField;
            }

            set
            {
                dscSalVarField = value;
                RaisePropertyChanged("dscSalVar");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContratoDuracao : ESocialBindableObject
    {
        private TipoContrato tpContrField = TipoContrato.Indeterminado;
        private DateTime dtTermField;
        private bool dtTermFieldSpecified;
        private SimNaoString clauAssecField = SimNaoString.Nao;
        private bool clauAssecFieldSpecified = false;
        private string objDetField;

        public sbyte tpContr
        {
            get
            {
                return (sbyte)tpContrField;
            }

            set
            {
                tpContrField = (TipoContrato)value;
                RaisePropertyChanged("tpContr");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtTerm
        {
            get
            {
                return dtTermField;
            }

            set
            {
                dtTermField = value;
                RaisePropertyChanged("dtTerm");
            }
        }

        [XmlIgnore()]
        public bool dtTermSpecified
        {
            get
            {
                return dtTermFieldSpecified;
            }

            set
            {
                dtTermFieldSpecified = value;
                RaisePropertyChanged("dtTermSpecified");
            }
        }

        public SimNaoString clauAssec
        {
            get
            {
                return clauAssecField;
            }

            set
            {
                clauAssecField = value;
                RaisePropertyChanged("clauAssec");
            }
        }

        [XmlIgnore()]
        public bool clauAssecSpecified
        {
            get
            {
                return clauAssecFieldSpecified;
            }

            set
            {
                clauAssecFieldSpecified = value;
                RaisePropertyChanged("clauAssecSpecified");
            }
        }


        public string objDet
        {
            get
            {
                return objDetField;
            }

            set
            {
                objDetField = value;
                RaisePropertyChanged("objDet");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContratoLocalTrabalho : ESocialBindableObject
    {
        private TLocalTrab localTrabGeralField;
        private EnderecoBrasileiro localTrabDomField;

        public TLocalTrab localTrabGeral
        {
            get
            {
                return localTrabGeralField;
            }

            set
            {
                localTrabGeralField = value;
                RaisePropertyChanged("localTrabGeral");
            }
        }

        public EnderecoBrasileiro localTrabDom
        {
            get
            {
                return localTrabDomField;
            }

            set
            {
                localTrabDomField = value;
                RaisePropertyChanged("localTrabDom");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TLocalTrab : ESocialBindableObject
    {
        private TipoInscricao tpInscField = TipoInscricao.CNPJ;
        private string nrInscField;
        private string descCompField;

        public sbyte tpInsc
        {
            get
            {
                return (sbyte)tpInscField;
            }

            set
            {
                tpInscField = (TipoInscricao)value;
                RaisePropertyChanged("tpInsc");
            }
        }

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

        public string descComp
        {
            get
            {
                return descCompField;
            }

            set
            {
                descCompField = value;
                RaisePropertyChanged("descComp");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContratoHorContratual : ESocialBindableObject
    {
        private decimal qtdHrsSemField;
        private bool qtdHrsSemFieldSpecified;
        private TipoJornada tpJornadaField = TipoJornada.HorarioFixoFolgaFixa_Dom;
        private string dscTpJornField;
        private sbyte tmpParcField;
        private THorario[] horarioField;

        public decimal qtdHrsSem
        {
            get
            {
                return qtdHrsSemField;
            }

            set
            {
                qtdHrsSemField = value;
                RaisePropertyChanged("qtdHrsSem");
            }
        }

        [XmlIgnore()]
        public bool qtdHrsSemSpecified
        {
            get
            {
                return qtdHrsSemFieldSpecified;
            }

            set
            {
                qtdHrsSemFieldSpecified = value;
                RaisePropertyChanged("qtdHrsSemSpecified");
            }
        }

        public TipoJornada tpJornada
        {
            get
            {
                return tpJornadaField;
            }

            set
            {
                tpJornadaField = value;
                RaisePropertyChanged("tpJornada");
            }
        }

        public string dscTpJorn
        {
            get
            {
                return dscTpJornField;
            }

            set
            {
                dscTpJornField = value;
                RaisePropertyChanged("dscTpJorn");
            }
        }

        public sbyte tmpParc
        {
            get
            {
                return tmpParcField;
            }

            set
            {
                tmpParcField = value;
                RaisePropertyChanged("tmpParc");
            }
        }

        [XmlElement("horario")]
        public THorario[] horario
        {
            get
            {
                return horarioField;
            }

            set
            {
                horarioField = value;
                RaisePropertyChanged("horario");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class THorario : ESocialBindableObject
    {
        private sbyte diaField;
        private string codHorContratField;

        public sbyte dia
        {
            get
            {
                return diaField;
            }

            set
            {
                diaField = value;
                RaisePropertyChanged("dia");
            }
        }

        public string codHorContrat
        {
            get
            {
                return codHorContratField;
            }

            set
            {
                codHorContratField = value;
                RaisePropertyChanged("codHorContrat");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContratoFiliacaoSindical : ESocialBindableObject
    {
        private string cnpjSindTrabField;

        public string cnpjSindTrab
        {
            get
            {
                return cnpjSindTrabField;
            }

            set
            {
                cnpjSindTrabField = value;
                RaisePropertyChanged("cnpjSindTrab");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContratoAlvaraJudicial : ESocialBindableObject
    {
        private string nrProcJudField;

        public string nrProcJud
        {
            get
            {
                return nrProcJudField;
            }

            set
            {
                nrProcJudField = value;
                RaisePropertyChanged("nrProcJud");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoInfoContratoObservacoes : ESocialBindableObject
    {
        private string observacaoField;

        public string observacao
        {
            get
            {
                return observacaoField;
            }

            set
            {
                observacaoField = value;
                RaisePropertyChanged("observacao");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoSucessaoVinc : ESocialBindableObject
    {
        private VinculoSucecssaoAnteriorTipo tpInscAntField = VinculoSucecssaoAnteriorTipo.CNPJ;
        private string cnpjEmpregAntField;
        private string matricAntField;
        private DateTime dtTransfField;
        private string observacaoField;

        public VinculoSucecssaoAnteriorTipo tpInscAnt
        {
            get
            {
                return tpInscAntField;
            }

            set
            {
                tpInscAntField = value;
                RaisePropertyChanged("tpInscAnt");
            }
        }

        public string cnpjEmpregAnt
        {
            get
            {
                return cnpjEmpregAntField;
            }

            set
            {
                cnpjEmpregAntField = value;
                RaisePropertyChanged("cnpjEmpregAnt");
            }
        }

        public string matricAnt
        {
            get
            {
                return matricAntField;
            }

            set
            {
                matricAntField = value;
                RaisePropertyChanged("matricAnt");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtTransf
        {
            get
            {
                return dtTransfField;
            }

            set
            {
                dtTransfField = value;
                RaisePropertyChanged("dtTransf");
            }
        }

        public string observacao
        {
            get
            {
                return observacaoField;
            }

            set
            {
                observacaoField = value;
                RaisePropertyChanged("observacao");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoTransfDom : ESocialBindableObject
    {
        private string cpfSubstituidoField;
        private string matricAntField;
        private DateTime dtTransfField;

        public string cpfSubstituido
        {
            get
            {
                return cpfSubstituidoField;
            }

            set
            {
                cpfSubstituidoField = value;
                RaisePropertyChanged("cpfSubstituido");
            }
        }

        public string matricAnt
        {
            get
            {
                return matricAntField;
            }

            set
            {
                matricAntField = value;
                RaisePropertyChanged("matricAnt");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtTransf
        {
            get
            {
                return dtTransfField;
            }

            set
            {
                dtTransfField = value;
                RaisePropertyChanged("dtTransf");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoMudancaCPF : ESocialBindableObject
    {
        private string cpfAntField;
        private string matricAntField;
        private DateTime dtAltCPFField;
        private string observacaoField;

        public string cpfAnt
        {
            get
            {
                return cpfAntField;
            }

            set
            {
                cpfAntField = value;
                RaisePropertyChanged("cpfAnt");
            }
        }

        public string matricAnt
        {
            get
            {
                return matricAntField;
            }

            set
            {
                matricAntField = value;
                RaisePropertyChanged("matricAnt");
            }
        }

        [XmlElement(DataType = "date")]
        public DateTime dtAltCPF
        {
            get
            {
                return dtAltCPFField;
            }

            set
            {
                dtAltCPFField = value;
                RaisePropertyChanged("dtAltCPF");
            }
        }

        public string observacao
        {
            get
            {
                return observacaoField;
            }

            set
            {
                observacaoField = value;
                RaisePropertyChanged("observacao");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoAfastamento : ESocialBindableObject
    {
        private DateTime dtIniAfastField;
        private string codMotAfastField;

        [XmlElement(DataType = "date")]
        public DateTime dtIniAfast
        {
            get
            {
                return dtIniAfastField;
            }

            set
            {
                dtIniAfastField = value;
                RaisePropertyChanged("dtIniAfast");
            }
        }

        public string codMotAfast
        {
            get
            {
                return codMotAfastField;
            }

            set
            {
                codMotAfastField = value;
                RaisePropertyChanged("codMotAfast");
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

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class eSocialEvtAdmissaoVinculoDesligamento : ESocialBindableObject
    {
        private DateTime dtDesligField;

        [XmlElement(DataType = "date")]
        public DateTime dtDeslig
        {
            get
            {
                return dtDesligField;
            }

            set
            {
                dtDesligField = value;
                RaisePropertyChanged("dtDeslig");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}