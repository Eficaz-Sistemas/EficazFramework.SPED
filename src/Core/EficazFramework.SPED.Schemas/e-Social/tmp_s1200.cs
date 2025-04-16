using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;

namespace eSocialSchema
{


    public class InfoComplem : ESocialBindableObject
    {
        private string nmTrab;
        private DateTime dtNascto;
        private SucessaoVinc sucessaoVinc;

        [XmlElement(ElementName = "nmTrab")]
        public string NmTrab
        {
            get => nmTrab;
            set
            {
                nmTrab = value;
                RaisePropertyChanged(nameof(NmTrab));
            }
        }

        [XmlElement(ElementName = "dtNascto")]
        public DateTime DtNascto
        {
            get => dtNascto;
            set
            {
                dtNascto = value;
                RaisePropertyChanged(nameof(DtNascto));
            }
        }

        [XmlElement(ElementName = "sucessaoVinc")]
        public SucessaoVinc SucessaoVinc
        {
            get => sucessaoVinc;
            set
            {
                sucessaoVinc = value;
                RaisePropertyChanged(nameof(SucessaoVinc));
            }
        }
    }

    public class SucessaoVinc : ESocialBindableObject
    {
        private string tpInsc;
        private string nrInsc;
        private string matricAnt;
        private DateTime dtAdm;
        private string observacao;

        [XmlElement(ElementName = "tpInsc")]
        public string TpInsc
        {
            get => tpInsc;
            set
            {
                tpInsc = value;
                RaisePropertyChanged(nameof(TpInsc));
            }
        }

        [XmlElement(ElementName = "nrInsc")]
        public string NrInsc
        {
            get => nrInsc;
            set
            {
                nrInsc = value;
                RaisePropertyChanged(nameof(NrInsc));
            }
        }

        [XmlElement(ElementName = "matricAnt")]
        public string MatricAnt
        {
            get => matricAnt;
            set
            {
                matricAnt = value;
                RaisePropertyChanged(nameof(MatricAnt));
            }
        }

        [XmlElement(ElementName = "dtAdm")]
        public DateTime DtAdm
        {
            get => dtAdm;
            set
            {
                dtAdm = value;
                RaisePropertyChanged(nameof(DtAdm));
            }
        }

        [XmlElement(ElementName = "observacao")]
        public string Observacao
        {
            get => observacao;
            set
            {
                observacao = value;
                RaisePropertyChanged(nameof(Observacao));
            }
        }
    }

    public class DmDev : ESocialBindableObject
    {
        private string ideDmDev;
        private string codCateg;
        private string indRRA;
        private TInfoRRA infoRRA;
        private InfoPerApur infoPerApur;
        private InfoPerAnt infoPerAnt;
        private InfoComplCont infoComplCont;

        [XmlElement(ElementName = "ideDmDev")]
        public string IdeDmDev
        {
            get => ideDmDev;
            set
            {
                ideDmDev = value;
                RaisePropertyChanged(nameof(IdeDmDev));
            }
        }

        [XmlElement(ElementName = "codCateg")]
        public string CodCateg
        {
            get => codCateg;
            set
            {
                codCateg = value;
                RaisePropertyChanged(nameof(CodCateg));
            }
        }

        [XmlElement(ElementName = "indRRA")]
        public string IndRRA
        {
            get => indRRA;
            set
            {
                indRRA = value;
                RaisePropertyChanged(nameof(IndRRA));
            }
        }

        [XmlElement(ElementName = "infoRRA")]
        public TInfoRRA InfoRRA
        {
            get => infoRRA;
            set
            {
                infoRRA = value;
                RaisePropertyChanged(nameof(InfoRRA));
            }
        }

        [XmlElement(ElementName = "infoPerApur")]
        public InfoPerApur InfoPerApur
        {
            get => infoPerApur;
            set
            {
                infoPerApur = value;
                RaisePropertyChanged(nameof(InfoPerApur));
            }
        }

        [XmlElement(ElementName = "infoPerAnt")]
        public InfoPerAnt InfoPerAnt
        {
            get => infoPerAnt;
            set
            {
                infoPerAnt = value;
                RaisePropertyChanged(nameof(InfoPerAnt));
            }
        }

        [XmlElement(ElementName = "infoComplCont")]
        public InfoComplCont InfoComplCont
        {
            get => infoComplCont;
            set
            {
                infoComplCont = value;
                RaisePropertyChanged(nameof(InfoComplCont));
            }
        }
    }

    public class InfoPerApur : ESocialBindableObject
    {
        private List<IdeEstabLot> ideEstabLot;

        [XmlElement(ElementName = "ideEstabLot")]
        public List<IdeEstabLot> IdeEstabLot
        {
            get => ideEstabLot;
            set
            {
                ideEstabLot = value;
                RaisePropertyChanged(nameof(IdeEstabLot));
            }
        }
    }

    public class IdeEstabLot : ESocialBindableObject
    {
        private string tpInsc;
        private string nrInsc;
        private string codLotacao;
        private int qtdDiasAv;
        private List<RemunPerApur> remunPerApur;

        [XmlElement(ElementName = "tpInsc")]
        public string TpInsc
        {
            get => tpInsc;
            set
            {
                tpInsc = value;
                RaisePropertyChanged(nameof(TpInsc));
            }
        }

        [XmlElement(ElementName = "nrInsc")]
        public string NrInsc
        {
            get => nrInsc;
            set
            {
                nrInsc = value;
                RaisePropertyChanged(nameof(NrInsc));
            }
        }

        [XmlElement(ElementName = "codLotacao")]
        public string CodLotacao
        {
            get => codLotacao;
            set
            {
                codLotacao = value;
                RaisePropertyChanged(nameof(CodLotacao));
            }
        }

        [XmlElement(ElementName = "qtdDiasAv")]
        public int QtdDiasAv
        {
            get => qtdDiasAv;
            set
            {
                qtdDiasAv = value;
                RaisePropertyChanged(nameof(QtdDiasAv));
            }
        }

        [XmlElement(ElementName = "remunPerApur")]
        public List<RemunPerApur> RemunPerApur
        {
            get => remunPerApur;
            set
            {
                remunPerApur = value;
                RaisePropertyChanged(nameof(RemunPerApur));
            }
        }
    }

    public class RemunPerApur : ESocialBindableObject
    {
        private string matricula;
        private string indSimples;
        private List<TItensRemunDescFolha> itensRemun;
        private TInfoAgNocivo infoAgNocivo;

        [XmlElement(ElementName = "matricula")]
        public string Matricula
        {
            get => matricula;
            set
            {
                matricula = value;
                RaisePropertyChanged(nameof(Matricula));
            }
        }

        [XmlElement(ElementName = "indSimples")]
        public string IndSimples
        {
            get => indSimples;
            set
            {
                indSimples = value;
                RaisePropertyChanged(nameof(IndSimples));
            }
        }

        [XmlElement(ElementName = "itensRemun")]
        public List<TItensRemunDescFolha> ItensRemun
        {
            get => itensRemun;
            set
            {
                itensRemun = value;
                RaisePropertyChanged(nameof(ItensRemun));
            }
        }

        [XmlElement(ElementName = "infoAgNocivo")]
        public TInfoAgNocivo InfoAgNocivo
        {
            get => infoAgNocivo;
            set
            {
                infoAgNocivo = value;
                RaisePropertyChanged(nameof(InfoAgNocivo));
            }
        }
    }

    public class TItensRemunDescFolha : TItensRemun
    {
        private string descFolha;

        [XmlElement(ElementName = "descFolha")]
        public string DescFolha
        {
            get => descFolha;
            set
            {
                descFolha = value;
                RaisePropertyChanged(nameof(DescFolha));
            }
        }
    }

    public class TItensRemun : ESocialBindableObject
    {
        private string codRubr;
        private string ideTabRubr;
        private decimal qtdRubr;
        private decimal fatorRubr;
        private decimal vrRubr;
        private string indApurIR;

        [XmlElement(ElementName = "codRubr")]
        public string CodRubr
        {
            get => codRubr;
            set
            {
                codRubr = value;
                RaisePropertyChanged(nameof(CodRubr));
            }
        }

        [XmlElement(ElementName = "ideTabRubr")]
        public string IdeTabRubr
        {
            get => ideTabRubr;
            set
            {
                ideTabRubr = value;
                RaisePropertyChanged(nameof(IdeTabRubr));
            }
        }

        [XmlElement(ElementName = "qtdRubr")]
        public decimal QtdRubr
        {
            get => qtdRubr;
            set
            {
                qtdRubr = value;
                RaisePropertyChanged(nameof(QtdRubr));
            }
        }

        [XmlElement(ElementName = "fatorRubr")]
        public decimal FatorRubr
        {
            get => fatorRubr;
            set
            {
                fatorRubr = value;
                RaisePropertyChanged(nameof(FatorRubr));
            }
        }

        [XmlElement(ElementName = "vrRubr")]
        public decimal VrRubr
        {
            get => vrRubr;
            set
            {
                vrRubr = value;
                RaisePropertyChanged(nameof(VrRubr));
            }
        }

        [XmlElement(ElementName = "indApurIR")]
        public string IndApurIR
        {
            get => indApurIR;
            set
            {
                indApurIR = value;
                RaisePropertyChanged(nameof(IndApurIR));
            }
        }
    }

    public class TInfoAgNocivo : ESocialBindableObject
    {
        private string grauExp;

        [XmlElement(ElementName = "grauExp")]
        public string GrauExp
        {
            get => grauExp;
            set
            {
                grauExp = value;
                RaisePropertyChanged(nameof(GrauExp));
            }
        }
    }

    public class InfoPerAnt : ESocialBindableObject
    {
        private List<IdeADC> ideADC;

        [XmlElement(ElementName = "ideADC")]
        public List<IdeADC> IdeADC
        {
            get => ideADC;
            set
            {
                ideADC = value;
                RaisePropertyChanged(nameof(IdeADC));
            }
        }
    }

    public class IdeADC : ESocialBindableObject
    {
        private DateTime dtAcConv;
        private string tpAcConv;
        private string dsc;
        private string remunSuc;
        private List<IdePeriodo> idePeriodo;

        [XmlElement(ElementName = "dtAcConv")]
        public DateTime DtAcConv
        {
            get => dtAcConv;
            set
            {
                dtAcConv = value;
                RaisePropertyChanged(nameof(DtAcConv));
            }
        }

        [XmlElement(ElementName = "tpAcConv")]
        public string TpAcConv
        {
            get => tpAcConv;
            set
            {
                tpAcConv = value;
                RaisePropertyChanged(nameof(TpAcConv));
            }
        }

        [XmlElement(ElementName = "dsc")]
        public string Dsc
        {
            get => dsc;
            set
            {
                dsc = value;
                RaisePropertyChanged(nameof(Dsc));
            }
        }

        [XmlElement(ElementName = "remunSuc")]
        public string RemunSuc
        {
            get => remunSuc;
            set
            {
                remunSuc = value;
                RaisePropertyChanged(nameof(RemunSuc));
            }
        }

        [XmlElement(ElementName = "idePeriodo")]
        public List<IdePeriodo> IdePeriodo
        {
            get => idePeriodo;
            set
            {
                idePeriodo = value;
                RaisePropertyChanged(nameof(IdePeriodo));
            }
        }
    }

    public class IdePeriodo : ESocialBindableObject
    {
        private string perRef;
        private List<IdeEstabLot> ideEstabLot;

        [XmlElement(ElementName = "perRef")]
        public string PerRef
        {
            get => perRef;
            set
            {
                perRef = value;
                RaisePropertyChanged(nameof(PerRef));
            }
        }

        [XmlElement(ElementName = "ideEstabLot")]
        public List<IdeEstabLot> IdeEstabLot
        {
            get => ideEstabLot;
            set
            {
                ideEstabLot = value;
                RaisePropertyChanged(nameof(IdeEstabLot));
            }
        }
    }

    public class InfoComplCont : ESocialBindableObject
    {
        private string codCBO;
        private string natAtividade;
        private int qtdDiasTrab;

        [XmlElement(ElementName = "codCBO")]
        public string CodCBO
        {
            get => codCBO;
            set
            {
                codCBO = value;
                RaisePropertyChanged(nameof(CodCBO));
            }
        }

        [XmlElement(ElementName = "natAtividade")]
        public string NatAtividade
        {
            get => natAtividade;
            set
            {
                natAtividade = value;
                RaisePropertyChanged(nameof(NatAtividade));
            }
        }

        [XmlElement(ElementName = "qtdDiasTrab")]
        public int QtdDiasTrab
        {
            get => qtdDiasTrab;
            set
            {
                qtdDiasTrab = value;
                RaisePropertyChanged(nameof(QtdDiasTrab));
            }
        }
    }

    public class TProcJudTrab : ESocialBindableObject
    {
        // Define properties for T_procJudTrab
    }

    public class TInfoInterm : ESocialBindableObject
    {
        // Define properties for T_infoInterm
    }

    public class TInfoRRA : ESocialBindableObject
    {
        // Define properties for T_infoRRA
    }
}
